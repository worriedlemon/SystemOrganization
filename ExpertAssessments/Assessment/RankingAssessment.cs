namespace ExpertAssessments.Assessment
{
    public class RankingAssessment : PairingAssessment
    {
        public override string MethodName => "Ranking";

        public override string FileFilter => "*.r.csv";

        public RankingAssessment() : base() { }

        public override void LoadData(string path)
        {
            var lines = Program.ReadCsvFile(path);

            objectsCount = lines[0].Length - 1;
            Dictionary<int, int[]> ranking = new();
            foreach (var line in lines)
            {
                int expert = Convert.ToInt32(line[0]);
                ranking.TryAdd(expert, new int[objectsCount]);
                for (int i = 0; i < objectsCount; ++i)
                {
                    ranking[expert][i] = Convert.ToInt32(line[i + 1]);
                }
            }
            expertsCount = ranking.Keys.Count;

            double eps = 1e-2;
            data = new();
            foreach (int i in ranking.Keys)
            {
                data.TryAdd(i, new float[objectsCount, objectsCount]);
                for (int j = 0; j < objectsCount; ++j)
                {
                    for (int k = 0; k < objectsCount; ++k)
                    {
                        float diff = ranking[i][j] - ranking[i][k];
                        if (Math.Abs(diff) < eps)
                        {
                            data[i][j, k] = 0.5f;
                        }
                        else
                        {
                            data[i][j, k] = diff < 0 ? 1f : 0f;
                        }
                    }
                }
            }
        }
    }
}
