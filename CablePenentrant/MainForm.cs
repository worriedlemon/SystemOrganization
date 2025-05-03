using System.Diagnostics;

namespace CablePenentrant
{
    public partial class MainForm : Form
    {
        SolutionFinder solution;
        List<CablePenentrant2D> cablePens;
        string path;
        readonly string logFile = Path.Combine(Environment.CurrentDirectory, "program.log");
        Graphics g;

        public MainForm()
        {
            File.Delete(logFile);
            InitializeComponent();
            Program.LogMessage += Console.WriteLine;
            Program.LogMessage += (string message) =>
            {
                File.AppendAllText(logFile, message + Environment.NewLine);
            };

            path = "";
            cablePens = new();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            g = picture.CreateGraphics();
            g.TranslateTransform(0, picture.Size.Height);
            g.ScaleTransform(1, -1);
        }

        private List<RectangleF> GetCoordinates(float scaleFactor)
        {
            return cablePens.Select(pen =>
            {
                var pos = pen.GetPosition();
                var size = pen.GetSize();
                return new RectangleF()
                {
                    X = (float)pos[0] * scaleFactor,
                    Y = (float)pos[1] * scaleFactor,
                    Width = (float)size[0] * scaleFactor,
                    Height = (float)size[1] * scaleFactor
                };
            }).ToList();
        }

        private void Visualize()
        {
            List<RectangleF> r = GetCoordinates((float)scalingFactorNumeric.Value);
            g.Clear(Color.White);
            Pen p = new(new SolidBrush(Color.Red));
            foreach (RectangleF rect in r)
            {
                g.FillRectangle(new SolidBrush(Color.LightGray), rect);
                g.DrawRectangle(p, rect);
            }
        }

        private void OnRefreshClick(object sender, EventArgs e)
        {
            try
            {
                solution.FailsCount = Convert.ToInt32(tryCountNumeric.Value);
                solution.ReplaceRatio = Convert.ToDouble(replaceRatio.Value);
                cablePens = solution.FindSolution(out double _);
                Visualize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.Log($"Error occurred: {ex.Message}");
            }
        }

        private void OnLoadClick(object sender, EventArgs e)
        {
            DialogResult r = ofd.ShowDialog();
            if (r != DialogResult.OK) return;

            path = ofd.FileName;
            refresh.Enabled = true;
            solution = new(path)
            {
                FailsCount = Convert.ToInt32(tryCountNumeric.Value),
                ReplaceRatio = Convert.ToDouble(replaceRatio.Value)
            };
            solution.OnVisualize += Visualize;
        }

        private void OnShowLogClick(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", logFile)?.WaitForExit();
        }
    }
}
