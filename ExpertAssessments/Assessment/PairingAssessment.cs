using System.Globalization;
using System.Reflection.Metadata;

namespace ExpertAssessments.Assessment
{
    public class PairingAssessment : AbstractAssessmentMethod
    {
        public override string MethodName => "Pairing";
        public override string FileFilter => "*.p.csv";

        protected Dictionary<int, float[,]>? data;

        public PairingAssessment() : base() { }

        public override double[] Calculate()
        {
            if (data is null) throw new ArgumentNullException(nameof(data), "Additional data is not loaded yet");

            float[,] x = new float[objectsCount, objectsCount];
            for (int i = 0; i < objectsCount; ++i)
            {
                for (int j = 0; j < objectsCount; ++j)
                {
                    foreach (int exp in data.Keys)
                    {
                        x[i, j] += data[exp][i, j];
                    }
                    x[i, j] /= expertsCount;
                }
            }

            double[] k = new double[objectsCount];
            double[] k1 = new double[objectsCount];
            for (int i = 0; i < objectsCount; ++i)
            {
                k1[i] = 1;
            }

            double eps = 1e-2;
            while (k.Select((val, i) => { return Math.Pow(Math.Abs(val - k1[i]), 2); }).Sum() > eps * eps)
            {
                k = k1;
                k1 = new double[objectsCount];
                double lambda = 0;
                for (int i = 0; i < objectsCount; ++i)
                {
                    for (int j = 0; j < objectsCount; ++j)
                    {
                        lambda += x[i, j] * k[j];
                    }
                }

                for (int i = 0; i < objectsCount; ++i)
                {
                    for (int j = 0; j < objectsCount; ++j)
                    {
                        k1[j] += x[i, j] * k[j] / lambda;
                    }
                }
            }

            return k1;
        }

        public override void LoadData(string path)
        {
            var lines = Program.ReadCsvFile(path);

            objectsCount = lines[0].Length - 2;
            data = new();
            foreach (var line in lines)
            {
                int expert = Convert.ToInt32(line[0]);
                data.TryAdd(expert, new float[objectsCount, objectsCount]);
                
                int obj = Convert.ToInt32(line[1]);
                for (int i = 0; i < objectsCount; ++i)
                {
                    data[expert][obj, i] = (float)Convert.ToDouble(line[i + 2], CultureInfo.InvariantCulture);
                }
            }
            expertsCount = data.Keys.Count;
        }
    }
}
