
namespace CablePenentrant
{
    public class Vector4
    {
        private double[] data;

        public Vector4(double x = 0, double y = 0, double z = 0, double w = 0)
        {
            data = new double[4];
            data[0] = x;
            data[1] = y;
            data[2] = z;
            data[3] = w;
        }

        public Vector4(Vector4 other)
        {
            data = new double[4];
            data[0] = other[0];
            data[1] = other[1];
            data[2] = other[2];
            data[3] = other[3];
        }

        public double this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        public double Length()
        {
            double value = 0;
            for (int i = 0; i < 4; i++)
            {
                value += data[i] * data[i];
            }
            return Math.Sqrt(value);
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a[0] + b[0], a[1] + b[1], a[2] + b[2], a[3] + b[3]);
        }

        public static bool operator ==(Vector4 a, Vector4 b)
        {
            return a.data[0] == b.data[0] &&
                    a.data[1] == b.data[1] &&
                    a.data[2] == b.data[2] &&
                    a.data[3] == b.data[3];
        }

        public static bool operator !=(Vector4 a, Vector4 b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is Vector4 vector && this == vector;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(data[0], data[1], data[2], data[3]);
        }
    }
}
