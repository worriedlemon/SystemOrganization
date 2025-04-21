using System.Diagnostics;

namespace CablePenentrant
{
    public partial class MainForm : Form
    {
        List<CablePenentrant2D> cablePens;
        string path;
        string logFile = Path.Combine(Environment.CurrentDirectory, "program.log");
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

        void FindSolution()
        {
            cablePens = CablePenentrantReader.FromFile(path);

            Program.Log("Parsed cable penentrants:");
            foreach (var p in cablePens)
            {
                Program.Log(p.ToString());
            }

            Program.Log("Initializing placement algorithm...");

            CablePlacement placement = new(ref cablePens);
            placement.Init();
            placement.Shrink(true);

            Program.Log("Initial placement done!");
            Program.Log($"Criteria value = {placement.GetMinimumRectangle().Length()}.");
            Visualize();
            MessageBox.Show("Wait for continue");

            int failsLeft = 5;
            while (failsLeft > 0)
            {
                Program.Log("Rearranging...");

                double crv;
                if (placement.Rearrange(cablePens.Count / 3, out crv))
                {
                    Program.Log("Found better solution. Applying it.");
                    failsLeft = 5;
                }
                else
                {
                    Program.Log("Solution rollback, trying again...");
                    --failsLeft;
                }
                Program.Log($"Criteria value = {crv}.");
            }
            Program.Log("Found pseudooptimal solution!\nResult:");
            foreach (var p in cablePens)
            {
                Program.Log(p.ToString());
            }
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
                FindSolution();
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
        }

        private void OnShowLogClick(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", logFile)?.WaitForExit();
        }
    }
}
