using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Optimizer;
using SourceDataManager;
namespace Result_Data_Manager
{
    public class Program
    {
        static Optimize optimizer = new Optimize();
        static CsvRead csvRead = new CsvRead();
        public class ResultDataMap : ClassMap<ResultData>
        {
            public ResultDataMap()
            {
                Map(m => m.UnitName).Name("Unit name");
                Map(m => m.Electricity).Name("Electricity usage");
                Map(m => m.Expenses).Name("Expenses");
                Map(m => m.HeatProduced).Name("Produced heat");
                Map(m => m.PrimaryEnergyConsumed).Name("Primary energy");
                Map(m => m.CO2).Name("CO2");
                Map(m => m.TimeFrom).Name("Time From");
                Map(m => m.TimeTo).Name("Time To");
                Map(m => m.HeatDemand).Name("Heat Demand");
                Map(m => m.ElectricityPrice).Name("Electricity Price");
            }
        }

        public static void CsvWriterCreator(string filePath)
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                using (CsvWriter csvWriter = new CsvWriter(writer, config))
                {
                    //Mapping Implement
                    csvWriter.Context.RegisterClassMap<ResultDataMap>();
                    csvWriter.WriteRecords(optimizer.resultDatas); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Main(string[] args)
        {
            string path = "./";
            string fileName = "result.csv";
            string filePath = Path.Combine(path, fileName);

            csvRead.ReadCSV();
            optimizer.OptimizeData(csvRead.summerPeriods);
            optimizer.OptimizeData(csvRead.winterPeriods);

            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) ;
            }
            bool isEmpty = new FileInfo(fileName).Length == 0;
            if(isEmpty)
            {
                CsvWriterCreator(filePath);
            }
        }
    }
}
