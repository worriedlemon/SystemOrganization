using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace CablePenentrantStatistics
{
    internal class Program
    {
        const string program = @"..\..\..\..\CablePenentrant\bin\Debug\net8.0-windows\CablePenentrant.exe";
        const string inputFile = @"..\..\..\..\CablePenentrant\penentrants.txt";
        const string outputFile = @"..\..\..\Logs\results.txt";
        const string logFile = @"..\..\..\Logs\program.log";

        static string BuildArgString(double rate, int attempts)
        {
            StringBuilder sb = new();
            sb.Append("--nogui");
            sb.Append($" -r {rate.ToString(CultureInfo.InvariantCulture)}");
            sb.Append($" -n {attempts} ");
            sb.Append($" --input {inputFile}");
            sb.Append($" --output {outputFile}");
            // Раскомментировать, чтобы получить полный лог программы
            //sb.Append($" --log {logFile}");
            return sb.ToString();
        }

        static void Main()
        {
            try
            {
                File.Create(logFile).Close();

                double initRate = 0.33;
                int initAttempts = 6;

                Console.WriteLine("Parameters:\n(1) Rate\n(2) Attemts count\n");
                Console.WriteLine("Enter parameter:");
                string param = Console.ReadLine()!;

                Console.WriteLine("\nEnter start count:");
                int count = Convert.ToInt32(Console.ReadLine()!);

                List<(double rate, int attempts)> p = new();

                if (param == "1")
                {
                    Console.WriteLine("Enter step:");
                    double step = Convert.ToDouble(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    for (double k = step; k <= 1.0; k += step)
                    {
                        p.Add((k, initAttempts));
                    }
                }
                else if (param == "2")
                {
                    Console.WriteLine("Enter max attempts:");
                    int maxAttempts = Convert.ToInt32(Console.ReadLine()!);
                    for (int k = 0; k <= maxAttempts; ++k)
                    {
                        p.Add((initRate, k));
                    }
                }
                else
                {
                    Console.WriteLine("No such parameter");
                    Environment.ExitCode = 2;
                    return;
                }

                List<(double rate, double attempts, double critAvg, double critBest)> criteria = new(p.Count);
                foreach (var val in p)
                {
                    double[] criteriaTemp = new double[count];
                    for (int i = 0; i < count; ++i)
                    {
                        string args = BuildArgString(val.rate, val.attempts);
                        Process proc = Process.Start(program, args);
                        proc.WaitForExit();

                        StreamReader sr = new(outputFile);
                        criteriaTemp[i] = Convert.ToDouble(sr.ReadLine());
                        sr.Close();
                    }
                    criteria.Add((val.rate, val.attempts, criteriaTemp.Average(), criteriaTemp.Min()));
                    Console.WriteLine($"({val.rate:f2}, {val.attempts}) finished.");
                }

                Console.WriteLine("\nResults:");
                int cur = 0;
                foreach (var (rate, attempts, critAvg, critBest) in criteria)
                {
                    Console.WriteLine($"{++cur}: rate = {rate:f2}, attempts = {attempts}, avg. crit = {critAvg:f3}, best crit = {critBest:f3}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                Environment.ExitCode = 1;
            }
        }
    }
}
