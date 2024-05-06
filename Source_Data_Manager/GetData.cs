using System;
using System.IO;
using System.Text;

namespace SourceDataManager
{
    public class GetData
    {
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "data.csv");
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

        public static void SummerHeatDemand()
        {
            //string filePath = "data.csv";
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Console.WriteLine($"Summer Heat Demand: {values[7]}");
                }
            }
        }
        public static void WinterElectricityPrice()
        {
            //string filePath = "data.csv";
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Console.WriteLine($"Winter Electricity Price: {values[3]}");
                }
            }
        }
        public static void SummerElectricityPrice()
        {
            //string filePath = "data.csv";
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Console.WriteLine($"Summer Electricity Price: {values[8]}");
                }
            }
        }
    }
}
