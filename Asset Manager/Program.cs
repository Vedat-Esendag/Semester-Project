using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

class HeatingGrid
{
    public string Name { get; set; }
    public string Image { get; set; }
}

class ProductionUnit
{
    public string Name { get; set; }
    public double MaxHeat { get; set; }
    public double MaxElectricity { get; set; }
    public double ProductionCosts { get; set; }
    public double CO2Emissions { get; set; }
    public double GasConsumption { get; set; }
    public double OilConsumption { get; set; }

    public ProductionUnit(string name, double maxHeat, double maxElectricity, double productionCosts, double co2Emissions, double gasConsumption, double oilConsumption)
    {
        Name = name;
        MaxHeat = maxHeat;
        MaxElectricity = maxElectricity;
        ProductionCosts = productionCosts;
        CO2Emissions = co2Emissions;
        GasConsumption = gasConsumption;
        OilConsumption = oilConsumption;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Max Heat: {MaxHeat} MW");
        Console.WriteLine($"Max Electricity: {MaxElectricity} MW");
        Console.WriteLine($"Production Costs: {ProductionCosts} DKK / MWh(th)");
        Console.WriteLine($"CO2 Emissions: {CO2Emissions} kg / MWh(th)");
        Console.WriteLine($"Gas Consumption: {GasConsumption} MWh(gas) / MWh(th)");
        Console.WriteLine($"Oil Consumption: {OilConsumption} MWh(oil) / MWh(th)");
        Console.WriteLine();
    }
}

class AssetManager
{
    private List<HeatingGrid> heatingGrids;
    private List<ProductionUnit> productionUnits;

    public AssetManager()
    {
        heatingGrids = new List<HeatingGrid>();
        productionUnits = new List<ProductionUnit>();
    }

    public void AddHeatingGrid(string name, string image)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Error: Heating grid name cannot be empty.");
            return;
        }

        if (heatingGrids.Any(grid => grid.Name == name))
        {
            Console.WriteLine($"Error: A heating grid with the name '{name}' already exists.");
            return;
        }

        if (!string.IsNullOrWhiteSpace(image) && !File.Exists(image))
        {
            Console.WriteLine($"Error: Image file '{image}' not found.");
            return;
        }

        heatingGrids.Add(new HeatingGrid { Name = name, Image = image });
        Console.WriteLine($"Heating grid '{name}' added successfully.");
    }

    public void AddProductionUnit(string name, double maxHeat, double maxElectricity, double productionCosts, double co2Emissions, double gasConsumption, double oilConsumption)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Error: Production unit name cannot be empty.");
            return;
        }

        if (productionUnits.Any(unit => unit.Name == name))
        {
            Console.WriteLine($"Error: A production unit with the name '{name}' already exists.");
            return;
        }

        if (maxHeat <= 0 || maxElectricity <= 0 || productionCosts <= 0 || co2Emissions < 0 || gasConsumption < 0 || oilConsumption < 0)
        {
            Console.WriteLine("Error: Invalid parameter values. Please provide positive values for maxHeat, maxElectricity, productionCosts, co2Emissions, gasConsumption, and oilConsumption.");
            return;
        }

        productionUnits.Add(new ProductionUnit(name, maxHeat, maxElectricity, productionCosts, co2Emissions, gasConsumption, oilConsumption));
        Console.WriteLine($"Production unit '{name}' added successfully.");
    }

    public void DisplayHeatingGrids()
    {
        if (heatingGrids.Count == 0)
        {
            Console.WriteLine("No heating grids found.");
            return;
        }

        Console.WriteLine("Heating Grids:");
        foreach (var grid in heatingGrids)
        {
            Console.WriteLine($"Name: {grid.Name}, Image: {grid.Image ?? "Not provided"}");
        }
    }

    public void DisplayProductionUnits()
    {
        if (productionUnits.Count == 0)
        {
            Console.WriteLine("No production units found.");
            return;
        }

        Console.WriteLine("Production Units:");
        foreach (var unit in productionUnits)
        {
            unit.DisplayDetails();
        }
    }

    public List<HeatingGrid> GetHeatingGrids()
    {
        return heatingGrids;
    }

    public List<ProductionUnit> GetProductionUnits()
    {
        return productionUnits;
    }
}

class Program
{
    static void Main(string[] args)
    {
        AssetManager assetManager = new AssetManager();
        
        assetManager.AddHeatingGrid("Heating Grid 1", "heating_grid_image.jpg");

        ReadProductionUnitsFromExcel(assetManager, "production_units.xlsx");

        assetManager.DisplayHeatingGrids();
        assetManager.DisplayProductionUnits();
    }

    static void ReadProductionUnitsFromExcel(AssetManager assetManager, string filePath)
    {
        if (File.Exists(filePath))
        {
            FileInfo fileInfo = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++) // Assuming the first row is headers
                {
                    string name = worksheet.Cells[row, 1].GetValue<string>();
                    double maxHeat = worksheet.Cells[row, 2].GetValue<double>();
                    double maxElectricity = worksheet.Cells[row, 3].GetValue<double>();
                    double productionCosts = worksheet.Cells[row, 4].GetValue<double>();
                    double co2Emissions = worksheet.Cells[row, 5].GetValue<double>();
                    double gasConsumption = worksheet.Cells[row, 6].GetValue<double>();
                    double oilConsumption = worksheet.Cells[row, 7].GetValue<double>();

                    assetManager.AddProductionUnit(name, maxHeat, maxElectricity, productionCosts, co2Emissions, gasConsumption, oilConsumption);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }
    }
}
