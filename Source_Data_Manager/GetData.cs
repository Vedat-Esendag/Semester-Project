using System;
using System.IO;
using System.Text;

namespace SourceDataManager
{
    public class GetData
    {
        public static readonly string filePath =
            @"C:\Users\admin\Desktop\SDU\S2\Semester Project 2\Semester Project Code\Semester-Project\Source_Data_Manager\data.csv";
        public static List<double> WinterHeatDemand()
        {
            var heatDemands = new List<double>();

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    // Skip header lines
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        // Assuming the third column contains winter heat demand
                        var winterHeatDemand = double.Parse(values[2]); // Index 2 for the third column

                        heatDemands.Add(winterHeatDemand);
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }

            return heatDemands;
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
        
        
        public static string WinterHeatDemandTime()
        {
            StringBuilder text = new StringBuilder();

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

                        // Extract winter period time from and to from columns 1 and 2
                        text.AppendLine($"Winter Heat Demand Time: From {columns[1]} To {columns[2]}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }

            return text.ToString();
        }
        public static void SummerHeatDemandTime()
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
