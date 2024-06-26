using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace SourceDataManager
{
    public class CsvRead
    {
        public List<PeriodData> winterPeriods = new List<PeriodData>();
        public List<PeriodData> summerPeriods = new List<PeriodData>();

        // Static fields to hold the directory and file path
        private static string currentDirectory = Path.GetDirectoryName(Path.GetFullPath("data.csv"));
        public string filePath = currentDirectory + "\\data.csv";

        public void ReadCSV()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
            };

            try
            {
                // Use the dynamically determined file path
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
                        ReadPeriods(csv, winterPeriods, winterStartIndex, summerStartIndex);
                        ReadPeriods(csv, summerPeriods, summerStartIndex, headers.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }
        }

        private void ReadPeriods(CsvReader csv, List<PeriodData> periods, int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i += 4)
            {
                var timeFrom = csv.GetField(i);
                var timeTo = csv.GetField(i + 1);
                var heatDemand = csv.GetField(i + 2);
                var electricityPrice = csv.GetField(i + 3);

                if (DateTime.TryParse(timeFrom, out var fromDateTime) &&
                    DateTime.TryParse(timeTo, out var toDateTime) &&
                    double.TryParse(heatDemand, out var heatDemandParsed) &&
                    double.TryParse(electricityPrice, out var electricityPriceParsed))
                {
                    periods.Add(new PeriodData
                    {
                        TimeFrom = fromDateTime,
                        TimeTo = toDateTime,
                        HeatDemand = heatDemandParsed,
                        ElectricityPrice = electricityPriceParsed
                    });
                }
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