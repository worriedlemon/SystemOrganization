using ExpertAssessments.Assessment;

namespace ExpertAssessments
{
    public partial class AssessmentsForm : Form
    {
        readonly AbstractAssessmentMethod[] methods = {
            new DirectAssessment(),
            new PairingAssessment(),
            new RankingAssessment(),
        };

        AbstractAssessmentMethod currentMethod
        {
            get
            {
                return (methodCombo.SelectedItem as AbstractAssessmentMethod)!;
            }
        }

        public AssessmentsForm()
        {
            InitializeComponent();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            methodCombo.Items.AddRange(methods);
            methodCombo.SelectedIndex = 0;
        }

        private void OnLoadClick(object? sender, EventArgs e)
        {
            DialogResult r = ofd.ShowDialog();
            if (r != DialogResult.OK) return;

            assessmentsData.Columns.Clear();
            assessmentsData.Rows.Clear();
            var content = Program.ReadCsvFile(ofd.FileName, false);

            if (headersCheck.Checked)
            {
                string[] headers = content.First();
                for (int i = 0; i < headers.Length; ++i)
                {
                    assessmentsData.Columns.Add($"column{i}", headers[i]);
                }
                content.Remove(headers);
            }

            foreach (var row in content)
            {
                assessmentsData.Rows.Add(row);
            }

            try
            {
                currentMethod.LoadData(ofd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void OnCalculateClick(object sender, EventArgs e)
        {
            if (currentMethod is null) return;

            try
            {
                double[] results = currentMethod.Calculate();
                string resultString = results
                    .Select((d, i) => $"Object {i}: {d:f3}")
                    .Aggregate((s1, s2) => $"{s1}\n{s2}");
                MessageBox.Show($"Results are:\n{resultString}", "Results");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
