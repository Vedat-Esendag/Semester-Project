using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace AM
{
    public interface IProductionUnit
    {
        string Name { get; set; }
        double MaxHeat { get; set; }
        decimal ProductionCost { get; set; }
        decimal CO2Emissions { get; set; }
        double GasConsumption { get; set; }
        string Image { get; set; }
    }

    public class AssetManager
    {
        GasBoiler gasBoiler = new GasBoiler();
        OilBoiler oilBoiler = new OilBoiler();
        GasMotor gasMotor = new GasMotor();
        ElectricBoiler electricBoiler = new ElectricBoiler();
        List<IProductionUnit> productionUnits1 = new List<IProductionUnit>();
        List<IProductionUnit> productionUnits2 = new List<IProductionUnit>();

        public void AddBoilersAndSaveState(string filePath)
        {
            AddBoilers();
            SaveBoilers(filePath);
        }

        public void AddBoilers()
        {
            if (productionUnits1.Count == 0)
            {
                productionUnits1.Add(gasBoiler);
                productionUnits1.Add(oilBoiler);
            }
            if (productionUnits2.Count == 0)
            {
                productionUnits2.Add(gasBoiler);
                productionUnits2.Add(oilBoiler);
                productionUnits2.Add(gasMotor);
                productionUnits2.Add(electricBoiler);
            }
        }

        public void SaveBoilers(string filePath)
        {
            string json1 = JsonConvert.SerializeObject(productionUnits1, Formatting.Indented);
            string json2 = JsonConvert.SerializeObject(productionUnits2, Formatting.Indented);

            if (!filePath.EndsWith("/"))
                filePath += "/";
            File.WriteAllText(filePath + "json1.json", json1);
            File.WriteAllText(filePath + "json2.json", json2);
        }

        public class ProductionUnit : IProductionUnit
        {
            public string Name { get; set; }
            public double MaxHeat { get; set; }
            public decimal ProductionCost { get; set; }
            public decimal CO2Emissions { get; set; }
            public double GasConsumption { get; set; }
            public string Image { get; set; }
        }

        public class GasBoiler : ProductionUnit
        {
            public GasBoiler()
            {
                Name = "GB";
                MaxHeat = 5;
                ProductionCost = 500;
                CO2Emissions = 215;
                GasConsumption = 1.1;

            }
        }

        public class OilBoiler : ProductionUnit
        {
            public OilBoiler()
            {
                Name = "OB";
                MaxHeat = 4;
                ProductionCost = 700;
                CO2Emissions = 265;
                GasConsumption = 1.2;
            }
        }

        public class GasMotor : ProductionUnit
        {
            public double MaxElectricity { get; set; }
            public GasMotor()
            {
                Name = "GM";
                MaxHeat = 3.6;
                MaxElectricity = 2.7;
                ProductionCost = 1100;
                CO2Emissions = 640;
                GasConsumption = 1.9;
            }
        }

        public class ElectricBoiler : ProductionUnit
        {
            public decimal MaxElectricity { get; set; }
            public ElectricBoiler()
            {
                Name = "EK";
                MaxHeat = 8;
                MaxElectricity = -8;
                ProductionCost = 50;
            }
        }
    }
}