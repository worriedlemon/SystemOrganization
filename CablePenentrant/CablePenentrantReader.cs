namespace CablePenentrant
{
    public static class CablePenentrantReader
    {
        public static CablePenentrant2D FromString(string str)
        {
            const string header = "cable_penentrant: ";
            if (!str.StartsWith(header))
            {
                throw new FormatException($"New line should start with '{header}'");
            }

            if (!str.EndsWith(';'))
            {
                throw new FormatException($"New line should end with semicolon (;)");
            }

            string[] parsing = str[header.Length..(str.Length - 1)].Split(", ");

            return new(0, 0, double.Parse(parsing[0]), double.Parse(parsing[1]));
        }

        public static List<CablePenentrant2D> FromFile(string path)
        {
            Program.Log("Begin parsing file...");
            using StreamReader reader = new(path);
            List<CablePenentrant2D> list = new();

            int lineCounter = 1;
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();

                if (line is null) break;

                if (string.IsNullOrWhiteSpace(line))
                {
                    Program.Log($"Empty line {lineCounter++} skipped...");
                    continue;
                }

                if (line.StartsWith('#'))
                {
                    Program.Log($"Comment line {lineCounter++} skipped...");
                    continue;
                }

                Program.Log($"Parsing line {lineCounter}: '{line}'...");
                list.Add(FromString(line));
                lineCounter++;
            }

            Program.Log("Parsing ended.\n");
            var sortedList = list.OrderByDescending(c => c.GetSize()[0] * c.GetSize()[1]).ToList();
            return sortedList;
        }
    }
}
