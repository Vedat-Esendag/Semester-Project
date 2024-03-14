using System;
using System.Collections.Generic;
using System.Data; 
using System.IO;
using ExcelDataReader; 
using System;
using System.Text;
using ExcelDataReader.DataSet;


namespace ConsoleApp
{
    public class ExcelReader
    {
        public static List<string> ImportColumn(string filePath, int columnIndex)
        {
            List<string> columnData = new List<string>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true // Set this to false if your column does not have a header
                        }
                    });

                    var dataTable = result.Tables[0];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        columnData.Add(row[columnIndex].ToString());
                    }
                }
            }

            return columnData;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var columnData = ExcelReader.ImportColumn(@"Data\2024 Heat Production Optimization - Danfoss Deliveries - Source Data Manager.xlsx", 3);
            foreach (var cellValue in columnData)
            {
                Console.WriteLine(cellValue);
            }
        }
    }
}

