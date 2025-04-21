using System.Globalization;
using System.Text;

namespace CablePenentrant
{
    public class CablePenentrant2D : IFormattable
    {
        private Vector4 coords_;
        private Vector4 sizes_;

        public CablePenentrant2D(double x = 0, double y = 0, double w = 0, double h = 0)
        {
            coords_ = new Vector4(x, y);
            sizes_ = new Vector4(w, h);
        }

        public CablePenentrant2D(CablePenentrant2D other)
        {
            coords_ = new Vector4(other.coords_);
            sizes_ = new Vector4(other.sizes_);
        }

        public Vector4 GetSize()
        {
            return sizes_;
        }

        public static bool operator==(CablePenentrant2D first, CablePenentrant2D second)
        {
            return first.Equals(second);
        }

        public static bool operator!=(CablePenentrant2D first, CablePenentrant2D second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            if (obj is CablePenentrant2D other)
            {
                return coords_ == other.coords_ && sizes_ == other.sizes_;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(sizes_.GetHashCode(), coords_.GetHashCode());
        }

        public override string ToString()
        {
            return ToString(null, CultureInfo.InvariantCulture);
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            string result;
            if (format is null)
            {
                result = $"size: ({sizes_[0]}, {sizes_[1]}); coordinates: ({coords_[0]}, {coords_[1]})";
            }
            else if (format == "simple")
            {
                result = $"{sizes_[0]} {sizes_[1]} {coords_[0]} {coords_[1]}";
            }
            else
            {
                throw new FormatException($"Unknown format {format}");
            }
            return result;
        }

        public void SetPosition(double x, double y)
        {
            coords_[0] = x;
            coords_[1] = y;
        }

        public Vector4 GetPosition()
        {
            return coords_;
        }
    }
}
