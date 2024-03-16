using System;
using System.Collections.Generic;
using System.Data; 
using System.IO;
using ExcelDataReader; 
using System;
using System.Text;
public class ExcelReader
{
    public static List<string> ImportColumn(string filePath, int columnIndex, int rowIndex)
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
                        UseHeaderRow = false // Assuming the header is not to be used....
                    }
                });

                var dataTable = result.Tables[0];
                for (int i = rowIndex; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    if (row[columnIndex] != DBNull.Value)
                    {
                        columnData.Add(row[columnIndex].ToString());
                    }
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

        // Guys! Adjust the columnIndex and rowIndex as needed
        var winter_Time_from = ExcelReader.ImportColumn(@"2024 Heat Production Optimization - Danfoss Deliveries - Source Data Manager.xlsx", 2, 3);
        var winter_Time_to = ExcelReader.ImportColumn(@"2024 Heat Production Optimization - Danfoss Deliveries - Source Data Manager.xlsx", 3, 3);
        var winter_HeatDemand = ExcelReader.ImportColumn(@"2024 Heat Production Optimization - Danfoss Deliveries - Source Data Manager.xlsx", 4, 3);
        var winter_ElectricityPrice = ExcelReader.ImportColumn(@"2024 Heat Production Optimization - Danfoss Deliveries - Source Data Manager.xlsx", 5, 3);

        foreach (var cellValue in winter_Time_from)
        {
            Console.WriteLine(cellValue);
        }
    }
}
