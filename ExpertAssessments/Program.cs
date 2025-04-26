namespace ExpertAssessments
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new AssessmentsForm());
        }

        public static List<string[]> ReadCsvFile(string path, bool skipHeader = true)
        {
            List<string[]> list = new();
            StreamReader reader = new(path);
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                if (skipHeader)
                {
                    skipHeader = false;
                    continue;
                }
                if (string.IsNullOrEmpty(line)) continue;
                string[] values = line.Split(',');
                list.Add(values);
            }
            return list;
        }
    }
}