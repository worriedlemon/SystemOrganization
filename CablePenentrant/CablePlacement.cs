using System.Drawing;

namespace CablePenentrant
{
    public class StraightCablePlacement
    {
        protected List<CablePenentrant2D> penentrants;
        protected enum Coord
        {
            X = 0, Y = 1
        }

        public StraightCablePlacement(in List<CablePenentrant2D> ps)
        {
            penentrants = ps;
        }

        public void Init()
        {
            double overallArea = 0;
            foreach (var p in penentrants)
            {
                Vector4 size = p.GetSize();
                overallArea += size[0] * size[1];
            }

            double width = 0;
            double maxWidth = Math.Sqrt(overallArea);
            double height = 0;
            double maxHeight = 0;

            foreach (CablePenentrant2D p in penentrants)
            {
                Vector4 size = p.GetSize();
                if (width + size[0] <= maxWidth)
                {
                    if (maxHeight < size[1])
                    {
                        maxHeight = size[1];
                    }
                    p.SetPosition(width, height);
                    width += size[0];
                }
                else
                {
                    height += maxHeight;
                    maxHeight = size[1];
                    p.SetPosition(0, height);
                    width = size[0];
                }
            }
            Shrink(true);
        }

        public Vector4 GetMinimumRectangle()
        {
            double maxX = 0, maxY = 0;
            foreach (CablePenentrant2D p in penentrants)
            {
                Vector4 leftUpper = p.GetPosition() + p.GetSize();
                if (maxX < leftUpper[0])
                {
                    maxX = leftUpper[0];
                }
                if (maxY < leftUpper[1])
                {
                    maxY = leftUpper[1];
                }
            }

            return new Vector4(maxX, maxY);
        }

        public void Shrink(bool inverseOrder = false, List<CablePenentrant2D>? takenOut = null)
        {
            int changes;
            do
            {
                changes = 0;
                for (int i = 0; i < 2; ++i)
                {
                    int coord = inverseOrder ? 1 - i : i;
                    foreach (CablePenentrant2D current in penentrants)
                    {
                        if (takenOut is not null && Contains(takenOut, current))
                        {
                            continue;
                        }

                        double shift = ShrinkInner(current, (Coord)coord, takenOut);
                        if (shift > 0)
                        {
                            Vector4 position = current.GetPosition();
                            position[coord] -= shift;
                            current.SetPosition(position[0], position[1]);
                            changes++;
                        }
                    }
                }
            } while (changes > 0);
        }
        private double ShrinkInner(CablePenentrant2D cp, Coord coord, List<CablePenentrant2D>? takenOut)
        {
            double max = -1;
            Vector4 position = cp.GetPosition();
            Vector4 size = cp.GetSize();
            foreach (CablePenentrant2D other in penentrants)
            {
                if (other == cp || takenOut is not null && Contains(takenOut, other)) continue;

                Vector4 otherPos = other.GetPosition();
                Vector4 otherSize = other.GetSize();

                int coordi = (int)coord;
                int opposi = 1 - coordi;
                bool notFits = (otherPos[opposi] <= position[opposi] && otherPos[opposi] + otherSize[opposi] <= position[opposi]) ||
                    (otherPos[opposi] >= position[opposi] + size[opposi] && otherPos[opposi] + otherSize[opposi] >= position[opposi] + size[opposi]);

                if (notFits) continue;

                double distance = position[coordi] - (otherPos[coordi] + otherSize[coordi]);

                if (distance >= 0 && (max < 0 || distance < max))
                {
                    max = distance;
                }
            }

            return max < 0 ? position[(int)coord] : max;
        }

        private static bool Contains(List<CablePenentrant2D> takenOut, CablePenentrant2D cp)
        {
            foreach (CablePenentrant2D p in takenOut)
            {
                if (p == cp) return true;
            }
            return false;
        }
    }

    public class CablePlacement : StraightCablePlacement
    {
        private Random rng;

        public CablePlacement(in List<CablePenentrant2D> ps) : base(ps)
        {
            rng = new();
        }        

        public bool Rearrange(int count, out double criteriaValue)
        {
            Vector4 oldMin = GetMinimumRectangle();
            List<CablePenentrant2D> copy = new();
            foreach (var cp in penentrants)
            {
                copy.Add(new CablePenentrant2D(cp));
            }

            CablePlacement placement = new(copy);

            int[] availableIndexes = Enumerable.Range(0, copy.Count).ToArray();
            rng.Shuffle(availableIndexes);

            List<CablePenentrant2D> taken = new();
            for (int i = 0; i < count; ++i)
            {
                taken.Add(copy[availableIndexes[i]]);
            }

            placement.Shrink(false, taken);

            int direction = oldMin[0] > oldMin[1] ? 1 : 0;
            Vector4 startPos = new();
            startPos[direction] = oldMin[direction];
            foreach (CablePenentrant2D cp in taken)
            {
                Vector4 pos = startPos + cp.GetPosition();
                cp.SetPosition(pos[0], pos[1]);
                Vector4 size = cp.GetSize();
                if (size[0] > size[1] && direction == 0 || size[0] < size[1] && direction == 1)
                {
                    cp.Transpose();
                }
            }

            copy.Sort((CablePenentrant2D first, CablePenentrant2D second) =>
            {
                var posA = first.GetPosition();
                var posB = second.GetPosition();

                if (posA[1] < posB[1] || (posA[1] == posB[1] && posA[0] < posB[0])) return -1;
                else if (posA[0] == posB[0] && posA[1] == posB[0]) return 0;
                else return 1;
            });

            placement.Shrink(true);

            Vector4 newMin = GetMinimumRectangle();

            criteriaValue = newMin.Length();

            if (criteriaValue < oldMin.Length())
            {
                penentrants.Clear();
                penentrants.AddRange(copy);
                return true;
            }
            return false;
        }
    }
}
