
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace SourceDataManager
{
    class CsvRead
    {
        public void ReadCSV()
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
                List<PeriodData> winterPeriods = new List<PeriodData>();
                List<PeriodData> summerPeriods = new List<PeriodData>();

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read();
                    csv.ReadHeader();

                    string[] headers = csv.HeaderRecord;

                    int winterStartIndex = Array.IndexOf(headers, "Winter period");
                    int summerStartIndex = Array.IndexOf(headers, "Summer period");

                    while (csv.Read())
                    {
                        // Read winter periods
                        for (int i = winterStartIndex; i < summerStartIndex; i += 4)
                        {
                            var timeFrom = csv.GetField(i);
                            var timeTo = csv.GetField(i + 1);
                            var heatDemand = csv.GetField(i + 2);
                            var electricityPrice = csv.GetField(i + 3);

                            if (!string.IsNullOrWhiteSpace(timeFrom) && !string.IsNullOrWhiteSpace(timeTo))
                            {
                                DateTime fromDateTime, toDateTime;
                                if (DateTime.TryParse(timeFrom, out fromDateTime) && DateTime.TryParse(timeTo, out toDateTime))
                                {
                                    var data = new PeriodData
                                    {
                                        TimeFrom = fromDateTime,
                                        TimeTo = toDateTime,
                                        HeatDemand = double.Parse(heatDemand),
                                        ElectricityPrice = double.Parse(electricityPrice)
                                    };
                                    winterPeriods.Add(data);
                                }
                            }
                        }

                        // Read summer periods
                        for (int i = summerStartIndex; i < headers.Length - 3; i += 4)
                        {
                            var timeFrom = csv.GetField(i);
                            var timeTo = csv.GetField(i + 1);
                            var heatDemand = csv.GetField(i + 2);
                            var electricityPrice = csv.GetField(i + 3);

                            if (!string.IsNullOrWhiteSpace(timeFrom) && !string.IsNullOrWhiteSpace(timeTo))
                            {
                                DateTime fromDateTime, toDateTime;
                                if (DateTime.TryParse(timeFrom, out fromDateTime) && DateTime.TryParse(timeTo, out toDateTime))
                                {
                                    var data = new PeriodData
                                    {
                                        TimeFrom = fromDateTime,
                                        TimeTo = toDateTime,
                                        HeatDemand = double.Parse(heatDemand),
                                        ElectricityPrice = double.Parse(electricityPrice)
                                    };
                                    summerPeriods.Add(data);
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Winter Period Data:");
                foreach (var data in winterPeriods)
                {
                    Console.WriteLine($"Time: {data.TimeFrom} - {data.TimeTo}, Heat Demand: {data.HeatDemand}, Electricity Price: {data.ElectricityPrice}");
                }

                Console.WriteLine();
                
                Console.WriteLine("Summer Period Data:");
                foreach (var data in summerPeriods)
                {
                    Console.WriteLine($"Time: {data.TimeFrom} - {data.TimeTo}, Heat Demand: {data.HeatDemand}, Electricity Price: {data.ElectricityPrice}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }
        }
    }

    public class PeriodData
    {
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public double HeatDemand { get; set; }
        public double ElectricityPrice { get; set; }
    }
}
