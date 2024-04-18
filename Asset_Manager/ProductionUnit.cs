namespace AM
{
    public class AssetManager
    {
        GasBoiler gasBoiler = new GasBoiler();
        OilBoiler oilBoiler = new OilBoiler();
        GasMotor gasMotor= new GasMotor();
        ElectricBoiler electricBoiler= new ElectricBoiler();
        List<ProductionUnit> productionUnits1= new List<ProductionUnit>();
        List<ProductionUnit> productionUnits2= new List<ProductionUnit>();
        public void AddBoilers()
        {
            if(productionUnits1.Count==0)
                {
                productionUnits1.Add(gasBoiler);
                productionUnits1.Add(oilBoiler);
                }
            if(productionUnits2.Count==0)
            {
                productionUnits2.Add(gasBoiler);
                productionUnits2.Add(oilBoiler);
                productionUnits2.Add(gasMotor);
                productionUnits2.Add(electricBoiler);
            }
        }
        public void SaveBoilers()
        {

        }
        class ProductionUnit
        {
        public string Name { get; set; }
        public string Image { get; set; }
        public double MaxHeat { get; set; }
        public double GasConsumption { get; set; }
        public decimal ProductionCost { get; set; }
        public decimal CO2Emissions { get; set; }
        }

        class GasBoiler : ProductionUnit
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
        class OilBoiler : ProductionUnit
        {
            public OilBoiler()
            {
                Name = "OB";
                MaxHeat = 5;
                ProductionCost = 700;
                CO2Emissions = 265;
                GasConsumption = 1.2;
            }
        }
        class GasMotor : ProductionUnit
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
        class ElectricBoiler : ProductionUnit
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