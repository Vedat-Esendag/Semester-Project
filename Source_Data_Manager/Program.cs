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
            GetData.WinterHeatDemand();
            GetData.SummerHeatDemand();
            Console.WriteLine("Electricity price:");
            GetData.WinterElectricityPrice();
            GetData.SummerElectricityPrice();
        }
    }
}