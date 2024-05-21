using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SourceDataManager
{
    public class GetData
    {
        // Define static fields
        private static string currentDirectory = Directory.GetCurrentDirectory();
        private static string relativePathToCsv = Path.Combine("..", "..", "..", "..", "Source_Data_Manager", "data.csv");
        public static string filePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePathToCsv));

        public static List<double> WinterHeatDemand()
        {
            List<double> heatDemand = new List<double>();

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Skip headers
                    reader.ReadLine(); // Skip additional lines
                    reader.ReadLine(); // Skip additional lines

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var columns = line.Split(',');

                        if (double.TryParse(columns[3], out double demand))
                        {
                            heatDemand.Add(demand);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }

            return heatDemand;
        }

        public static string SummerHeatDemand()
        {
            StringBuilder text = new StringBuilder();

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        text.AppendLine(string.Join(", ", values));
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }

            return text.ToString();
        }

        public static string WinterElectricityPrice()
        {
            StringBuilder text = new StringBuilder();

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        text.AppendLine(string.Join(", ", values));
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }

            return text.ToString();
        }

        public static string SummerElectricityPrice()
        {
            StringBuilder text = new StringBuilder();

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        text.AppendLine(string.Join(", ", values));
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }

            return text.ToString();
        }

        public static List<DateTime> WinterTime()
        {
            List<DateTime> dates = new List<DateTime>();

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Skip headers
                    reader.ReadLine(); // Skip additional lines
                    reader.ReadLine(); // Skip additional lines

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var columns = line.Split(',');

                        // Extract winter period start time from column 1
                        if (DateTime.TryParse(columns[1], out DateTime dateFrom))
                        {
                            dates.Add(dateFrom);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }

            return dates;
        }

        public static void SummerTime()
        {
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        // Extract summer period time from and to from columns 6 and 7
                        Console.WriteLine($"Summer Heat Demand Time: From {values[6]} To {values[7]}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }
    }
}
