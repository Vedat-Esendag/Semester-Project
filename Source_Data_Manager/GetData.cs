using System;
using System.IO;

namespace SourceDataManager
{
    public class GetData
    {
        public static (List<string>, List<string>) TimeList()
        {
            string filePath = "data.csv";
            List<string> timeFromList = new List<string>();
            List<string> timeToList = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    timeFromList.Add(values[0]); // "Time from"
                    timeToList.Add(values[1]); // "Time to"
                }
            }

            return (timeFromList, timeToList);
        }

        public static List<string> WinterHeatDemand()
        {
            string filePath = "data.csv";
            List<string> winterHeatDemands = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    winterHeatDemands.Add(values[2]);
                }
            }

            return winterHeatDemands;
        }
        public static List<string> SummerHeatDemand()
        {
            string filePath = "data.csv";
            List<string> summerHeatDemands = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    summerHeatDemands.Add(values[7]);
                }
            }

            return summerHeatDemands;
        }
        public static List<string> WinterElectricityPrice()
        {
            string filePath = "data.csv";
            List<string> winterElectricityPrices = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    winterElectricityPrices.Add(values[3]);
                }
            }

            return winterElectricityPrices;
        }
        public static List<string> SummerElectricityPrice()
        {
            string filePath = "data.csv";
            List<string> summerElectricityPrices = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    summerElectricityPrices.Add(values[8]);
                }
            }

            return summerElectricityPrices;
        }
    }
}
