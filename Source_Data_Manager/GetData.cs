using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SourceDataManager
{
    public class GetData
    {
        private static string currentDirectory = Path.GetDirectoryName(Path.GetFullPath("data.csv"));
        public static string filePath = currentDirectory + "\\data.csv";
        
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
                            Console.WriteLine($"Read demand: {demand}");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to parse demand from line: {line}");
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
        
        public static List<DateTime> SummerTime()
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

                        if (DateTime.TryParse(columns[6], out DateTime dateFrom))
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
        
        public static List<HeatDemandData> ReadCsvFile(string filePath)
        {
            var data = File.ReadAllLines(filePath)
                .Skip(1) // Skip the header row
                .Select(line => line.Split(','))
                .Select(parts => 
                {
                    try
                    {
                        return new HeatDemandData
                        {
                            Date = DateTime.Parse(parts[0], CultureInfo.InvariantCulture),
                            HeatDemand = double.Parse(parts[1], CultureInfo.InvariantCulture)
                        };
                    }
                    catch (FormatException)
                    {
                        return null;
                    }
                })
                .Where(d => d != null)
                .ToList();

            return data;
        }

    }
    
    public class HeatDemandData
    {
        public DateTime Date { get; set; }
        public double HeatDemand { get; set; }
    }
}