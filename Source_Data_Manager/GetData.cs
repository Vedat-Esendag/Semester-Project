using System;
using System.IO;

namespace SourceDataManager
{
    class GetData
    {
        public static void WinterHeatDemand()
        {
            string filePath = "data.csv";
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Console.WriteLine($"Winter Heat Demand: {values[2]}");
                }
            }
        }
        public static void SummerHeatDemand()
        {
            string filePath = "data.csv";
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
            string filePath = "data.csv";
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
            string filePath = "data.csv";
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
