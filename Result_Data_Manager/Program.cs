using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Optimizer;
using SourceDataManager;
namespace Result_Data_Manager
{
    public class Program
    {
        static Optimize optimize = new Optimize();
        public static void CsvWriterCreator(string filePath)
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            try
            {
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath)) ;
                }
                
                using (StreamWriter writer = new StreamWriter(filePath, true))
                using (CsvWriter csvWriter = new CsvWriter(writer, config))
                {
                    csvWriter.WriteRecords(optimize.resultDatas); //resultdata comes from optimizer
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Main(string[] args)
        {
            //What is the path of the file?
            string path = "./";
            string fileName = "data.csv";
            string filePath = Path.Combine(path, fileName);

            //This can be deleted
            CsvWriterCreator(filePath);
            Console.WriteLine("Successfully added!");
            Console.ReadKey();
        }
    }
}
