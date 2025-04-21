namespace CablePenentrant
{
    internal static class Program
    {
        public static event Action<string>? LogMessage;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        public static void Log(string message) => LogMessage?.Invoke(message);
    }
}