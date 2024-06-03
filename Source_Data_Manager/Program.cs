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
            Console.WriteLine("Starting CSV reading...");
            CsvRead csvRead = new CsvRead();
            csvRead.ReadCSV();
            Console.WriteLine("Heat demand:");
            foreach (var demand in GetData.WinterHeatDemand())
            {
                Console.WriteLine(demand);
            }
            Console.WriteLine();

            Console.WriteLine("Summer heat demand:");
            Console.WriteLine(GetData.SummerHeatDemand());
            Console.WriteLine();

            Console.WriteLine("Winter electricity price:");
            foreach (var price in GetData.WinterElectricityPrice())
            {
                Console.WriteLine(price);
            }
            Console.WriteLine();

            Console.WriteLine("Summer electricity price:");
            foreach (var price in GetData.SummerElectricityPrice())
            {
                Console.WriteLine(price);
            }
            Console.WriteLine();

            Console.WriteLine("Winter time:");
            foreach (var time in GetData.WinterTime())
            {
                Console.WriteLine(time);
            }
        }
    }
}