namespace ExpertAssessments.Assessment
{
    public class DirectAssessment : AbstractAssessmentMethod
    {
        public override string MethodName => "Direct";

        Dictionary<int, double[]>? data;

        public DirectAssessment() : base() { }

        public override void LoadData(string path)
        {
            var loaded = Program.ReadCsvFile(path);
            objectsCount = loaded[0].Length - 1;
            data = new();
            foreach (var line in loaded)
            {
                int expert = Convert.ToInt32(line[0]);
                data.TryAdd(expert, new double[objectsCount]);
                for (int i = 0; i < objectsCount; ++i)
                {
                    data[expert][i] = Convert.ToDouble(line[i + 1]);
                }
            }
            expertsCount = data.Keys.Count;
        }

        public override double[] Calculate()
        {
            if (data is null) throw new ArgumentNullException(nameof(data), "Data is not loaded yet");

            double eps = 1e-2;
            double[] result = new double[objectsCount];

            Dictionary<int, double> k = new(expertsCount);
            Dictionary<int, double> k1 = new(expertsCount);
            foreach (int i in data.Keys)
            {
                k.TryAdd(i, 0.0);
                k1.TryAdd(i, 1.0 / expertsCount);
            }
            while (k.Select((val, i) => { return Math.Pow(Math.Abs(val.Value - k1[val.Key]), 2); }).Sum() > eps * eps)
            {
                k = k1;
                double[] x_t = new double[objectsCount];
                for (int i = 0; i < objectsCount; ++i)
                {
                    foreach (int j in data.Keys)
                    {
                        x_t[i] += data[j][i] * k[j];
                    }
                }

                double lambda = 0;
                for (int i = 0; i < objectsCount; ++i)
                {
                    foreach (int j in data.Keys)
                    {
                        lambda += data[j][i] * x_t[i];
                    }
                }

                k1 = new(expertsCount);
                for (int i = 0; i < objectsCount; ++i)
                {
                    foreach (int j in data.Keys)
                    {
                        k1.TryAdd(j, 0.0);
                        k1[j] += data[j][i] * x_t[i] / lambda;
                    }
                }
            }

            for (int i = 0; i < objectsCount; ++i)
            {
                foreach (int j in data.Keys)
                {
                    result[i] += data[j][i] * k[j];
                }
            }

            return result;
        }
    }
}
