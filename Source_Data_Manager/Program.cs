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
            HeatDemand heatDemand = new();
            ElectrictyPrice electrictyPrice = new();
            Console.WriteLine("Starting CSV reading...");
            csvRead.ReadCSV();
            Console.WriteLine("Ara beni yala beni :)");
            heatDemand.ReadHeatDemandOnly();
            Console.WriteLine("HAM HAM");
            ElectrictyPrice.ReadElectricityPriceOnly();
        }
    }
}