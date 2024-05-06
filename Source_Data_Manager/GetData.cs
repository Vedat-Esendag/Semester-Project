using System;
using System.IO;
using System.Text;

namespace SourceDataManager
{
    public class GetData
    {
        private static readonly string filePath = "C:\\Users\\admin\\Desktop\\SDU\\S2\\Semester Project 2\\Semester Project Code\\Semester-Project\\Source_Data_Manager\\data.csv";//Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "data.csv");
        public static string WinterHeatDemand()
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
        
        
        public static void WinterHeatDemandTime()
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

                        // Extract winter period time from and to from columns 1 and 2
                        Console.WriteLine($"Winter Heat Demand Time: From {values[1]} To {values[2]}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
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
