using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SourceDataManager
{
    public class GetData
    {
        // Define static fields
        private static string currentDirectory = "../../Source_Data_Manager/data.csv";
        public static string filePath = "../../Source_Data_Manager/data.csv";
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

        public static List<double> WinterElectricityPrice()
        {
            List<double> data = new List<double>();

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

                        // Assuming the electricity price is in the first column
                        if (double.TryParse(values[0], out double price))
                        {
                            data.Add(price);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }

            return data;
        }

        public static List<double> SummerElectricityPrice()
        {
            List<double> data = new List<double>();
            string filePath = "path_to_your_summer_data.csv";

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

                        // Assuming the electricity price is in the first column
                        if (double.TryParse(values[0], out double price))
                        {
                            data.Add(price);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }

            return data;
        }

        public static List<DateTime> SummerTime()
        {
            List<DateTime> dates = new List<DateTime>();
            string filePath = "path_to_your_summer_data.csv";

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

                        // Extract summer period start time from column 1, like in WinterTime()
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
    }
}
