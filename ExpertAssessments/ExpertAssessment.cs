namespace ExpertAssessments
{
    public class ExpertAssessment
    {
        public readonly int ObjectsCount;
        public readonly int CriteriaCount;
        public readonly int ExpertsCount;

        public double[,,] Values { get; private set; }

        public ExpertAssessment(Dictionary<int, double[,]> values)
        {
            double[,] v = values.First().Value;
            ExpertsCount = values.Count;
            ObjectsCount = v.GetLength(0);
            CriteriaCount = v.GetLength(1);
            Values = new double[ExpertsCount, ObjectsCount, CriteriaCount];

            foreach (var k in values)
            {
                double[,] v1 = values.First().Value;
                for (int i = 0; i < ObjectsCount; ++i)
                {
                    for (int j = 0; j < CriteriaCount; ++j)
                    {
                        Values[k.Key, i, j] = v1[i, j];
                    }
                }
            }
        }
    }
}
