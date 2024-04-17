using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;



namespace SourceDataManager
{
    class ElectrictyPrice
    {
        public static void ReadElectricityPriceOnly()
        {
            string filePath = "data.csv";
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
            };

            List<string> electricityPrices = new List<string>();

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read();
                    csv.ReadHeader();
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        var electricityPrice = csv.GetField("Electricity Price");
                        electricityPrices.Add(electricityPrice);
                    }

                    Console.WriteLine("Electricity Price Values:");
                    foreach (var price in electricityPrices)
                    {
                        Console.WriteLine(price);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Electricity Price from CSV file: {ex.Message}");
            }
        }
    }
}