using System;
using SourceDataManager;
using AM;
using System.Security.Cryptography.X509Certificates;

namespace Optimizer
{
    class Program
    {
        public static void Main()
        {
            CsvRead csvRead= new();
            Optimize optimizer= new Optimize();
            csvRead.ReadCSV();
            optimizer.OptimizeData(csvRead.winterPeriods);
            optimizer.OptimizeData(csvRead.summerPeriods);
        }
    }
}