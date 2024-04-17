using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace SourceDataManager
{
    class SDM
    {
        static void Main()
        {
            Console.WriteLine("Starting CSV reading...");
            ReadCSV();
            Console.WriteLine("KURVAAAA");
            ReadHeatDemandOnly();
        }

        public static void ReadCSV()
        {
            string filePath = "data.csv"; // Correct file path
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // Enable header record processing
                HeaderValidated = null, // Optional: ignore header mismatches during validation
                MissingFieldFound = null, // Optional: handle missing fields gracefully
            };

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    // Skip the first header row that does not contain actual column names
                    csv.Read();
                    csv.ReadHeader();
                    csv.Read(); // Move to the second row which contains the actual column names
                    csv.ReadHeader(); // This now reads the second header row as the actual headers

                    while (csv.Read())
                    {
                        var timeFrom = csv.GetField("Time from");
                        var timeTo = csv.GetField("Time to");
                        var heatDemand = csv.GetField("Heat Demand");
                        var electricityPrice = csv.GetField("Electricity Price");

                        Console.WriteLine($"Time From: {timeFrom}, Time To: {timeTo}, Heat Demand: {heatDemand}, Electricity Price: {electricityPrice}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }
        }
        
        public static void ReadHeatDemandOnly()
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