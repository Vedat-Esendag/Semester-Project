using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace SourceDataManager
{
    class SDM
    {
        public static void Main()
        {
            CsvRead csvRead = new();
            Console.WriteLine("Starting CSV reading...");
            csvRead.ReadCSV();
            Console.WriteLine("Heat demand:");
            foreach (var a in GetData.WinterHeatDemand())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
            Console.WriteLine(GetData.SummerHeatDemand());
            Console.WriteLine("Electricity price:");
            Console.WriteLine(GetData.WinterElectricityPrice());
            Console.WriteLine(GetData.SummerElectricityPrice());
            Console.WriteLine();
            foreach (var a in GetData.WinterTime())
            {
                Console.WriteLine(a);
            }
            GetData.SummerTime();
        }
    }
}