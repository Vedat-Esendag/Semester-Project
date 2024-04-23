using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace SourceDataManager
{
    class HeatDemand
    {
        public void ReadHeatDemandOnly()
        {
            string filePath = "data.csv";
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
            };

            List<string> heatDemands = new List<string>(); // List to store heat demand values

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
                        var heatDemand = csv.GetField("Heat Demand");
                        heatDemands.Add(heatDemand); // Add each heat demand to the list
                    }

                    Console.WriteLine("Heat Demand Values:");
                    foreach (var demand in heatDemands)
                    {
                        Console.WriteLine(demand);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Heat Demand from CSV file: {ex.Message}");
            }
        }
    }
}