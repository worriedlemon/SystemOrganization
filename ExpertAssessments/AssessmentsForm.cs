using ExpertAssessments.Assessment;

namespace ExpertAssessments
{
    public partial class AssessmentsForm : Form
    {
        readonly AbstractAssessmentMethod[] methods = {
            new NoAssessment(),
            new DirectAssessment(),
            //new RankingAssessment(),
        };

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
            var data = ReadCsvFile(ofd.FileName);

            if (headersCheck.Checked)
            {
                string[] headers = data.First();
                for (int i = 0; i < headers.Length; ++i)
                {
                    assessmentsData.Columns.Add($"column{i}", headers[i]);
                }
                data.Remove(headers);
            }

            foreach (var row in data)
            {
                assessmentsData.Rows.Add(row);
            }
        }

        private List<string[]> ReadCsvFile(string path)
        {
            List<string[]> list = new();
            StreamReader reader = new(path);
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                if (line == null) break;
                string[] values = line.Split(',');
                list.Add(values);
            }
            return list;
        }

        private void OnCalculateClick(object sender, EventArgs e)
        {
            AbstractAssessmentMethod? method = methodCombo.SelectedItem as AbstractAssessmentMethod;

            try
            {
                method?.LoadData(GetDataFromTable());
                method?.Calculate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ExpertAssessment GetDataFromTable()
        {
            int criteriaCount = assessmentsData.Columns.Count - 2;
            HashSet<string> objects = new();
            HashSet<int> experts = new();

            for (int i = 0; i < assessmentsData.Rows.Count - 1; ++i)
            {

                experts.Add(Convert.ToInt32(assessmentsData.Rows[i].Cells[0].Value as string));
                objects.Add(assessmentsData.Rows[i].Cells[1].Value as string);
            }

            int objectsCount = objects.Count;
            int expertsCount = experts.Count;

            Dictionary<int, double[,]> values = new();

            for (int i = 0; i < expertsCount; ++i)
            {
                values.TryAdd(i, new double[objectsCount, criteriaCount]);
                
                for (int j = 0; j < objectsCount; ++j)
                {
                    for (int k = 0; k < criteriaCount; ++k)
                    {
                        values[i][j, k] = Convert.ToDouble(assessmentsData.Rows[i * objectsCount + j].Cells[k + 2].Value);
                    }
                }
            }

            return new(values);
        }
    }
}
