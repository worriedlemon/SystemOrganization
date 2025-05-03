using System.Globalization;
using System.Runtime.InteropServices;

namespace CablePenentrant
{
    internal static class Program
    {
        public static event Action<string>? LogMessage;

        static Dictionary<string, object?> ParseArguments(string[] args)
        {
            Dictionary<string, object?> result = new();
            for (int i = 0; i < args.Length; ++i)
            {
                string argument = args[i];
                if (argument == "--nogui")
                {
                    result.Add("--nogui", null);
                }
                else if (argument == "-r")
                {
                    result.Add("-r", Convert.ToDouble(args[i + 1], CultureInfo.InvariantCulture));
                    ++i;
                }
                else if (argument == "-n")
                {
                    result.Add("-n", Convert.ToInt32(args[i + 1]));
                    ++i;
                }
                else if (argument == "--output")
                {
                    result.Add("--output", args[i + 1]);
                    ++i;
                }
                else if (argument == "--input")
                {
                    result.Add("--input", args[i + 1]);
                    ++i;
                }
                else if (argument == "--log")
                {
                    result.Add("--log", args[i + 1]);
                    ++i;
                }
            }

            return result;
        }
        
        static void LoadGUI()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, object?> options = ParseArguments(args);

                if (options.Count == 0)
                {
                    LoadGUI();
                }
                else if (options.ContainsKey("--nogui"))
                {
                    double rate = Convert.ToDouble(options["-r"], CultureInfo.InvariantCulture);
                    int attempts = Convert.ToInt32(options["-n"]);
                    string inputFile = (options["--input"] as string)!;
                    string outputFile = (options["--output"] as string)!;

                    if (options.ContainsKey("--log"))
                    {
                        string opt = (options["--log"] as string)!;
                        if (opt == "console")
                        {
                            AttachConsole(ATTACH_PARENT_PROCESS);
                            LogMessage += Console.WriteLine;
                        }
                        else
                        {
                            LogMessage += (string message) => {
                                File.AppendAllText(opt, $"{message}\n");
                            };
                        }
                    }

                    SolutionFinder finder = new(inputFile)
                    {
                        FailsCount = attempts,
                        ReplaceRatio = rate,
                    };
                    var cablePens = finder.FindSolution(out double criteria);

                    StreamWriter ws = new(outputFile);
                    ws.WriteLine(criteria);
                    foreach (var cp in cablePens)
                    {
                        ws.WriteLine($"{cp:simple}");
                    }
                    ws.Close();
                }
                else
                {
                    AttachConsole(ATTACH_PARENT_PROCESS);
                    Console.WriteLine("""
                        Usage:
                        CablePenentrant.exe [--nogui -r <Rate> -n <Attempts> --input <path> --output <path>]

                        --nogui          - enables NO GUI mode
                        -r               - set ratio
                        -n               - set attempts count
                        --output <path>  - set path for file
                        """.Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                Environment.Exit(1);
            }
        }

        public static void Log(string message) => LogMessage?.Invoke(message);
    }
}