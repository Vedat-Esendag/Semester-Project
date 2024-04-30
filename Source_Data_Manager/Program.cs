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
            GetData getData = new GetData();
            Console.WriteLine("Starting CSV reading...");
            csvRead.ReadCSV();
            Console.WriteLine("Heat demand:");
            List<string> winterHeatDemands = GetData.WinterHeatDemand();
            foreach (string demand in winterHeatDemands)
            {
                Console.WriteLine(demand);
            }
            List<string> summerHeatDemands = GetData.SummerHeatDemand();
            foreach (string demand in summerHeatDemands)
            {
                Console.WriteLine(demand);
            }
            Console.WriteLine("Electricity price:");
            List<string> winterElectricityPrices = GetData.WinterElectricityPrice();
            foreach (string price in winterElectricityPrices)
            {
                Console.WriteLine(price);
            }
            List<string> summerElectricityPrices = GetData.SummerElectricityPrice();
            foreach (string price in summerElectricityPrices)
            {
                Console.WriteLine(price);
            }

            Console.WriteLine("Time from:");
            (List<string> timeFromList, List<string> timeToList) = GetData.TimeList();
            foreach (string time in timeFromList)
            {
                Console.WriteLine(time);
            }
            Console.WriteLine("Time to:");
            foreach (string time in timeToList)
            {
                Console.WriteLine(time);
            }
            
        }
    }
}