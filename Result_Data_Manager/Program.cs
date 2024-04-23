using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace Result_Data_Manager
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
    public class Program
    {
        public static void CsvWriterCreator(string filePath)
        {
            string resultData = null;    // This should be deleted when we have optimizer or calculations(could be dictionary)
            List<Person> people = new List<Person>
            {
                new Person{Name = "John", Age = 25, City="London" },
                new Person{Name = "George", Age = 18, City="Los angeles" },
                new Person{Name = "Ödön", Age = 45, City="Patapoklosi" }
            };
            
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
                    csvWriter.WriteRecords(people); //resultdata comes from optimizer or calculation
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

            CsvWriterCreator(filePath);
            Console.WriteLine("Successfully added!");
            Console.ReadKey();
        }
    }
}
