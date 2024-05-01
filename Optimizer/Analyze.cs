using System;
using OxyPlot.Series;
using SourceDataManager;
using AM;

namespace Optimizer
{
    interface IAnalyze
    {
        void CalculatePricesWinterElectric();
        void CalculatePricesWinterOil();
        void CalculatePricesWinterMotor();
        void CalculatePricesWinterGas();
        void CalculatePricesSummerElectric();
        void CalculatePricesSummerOil();
        void CalculatePricesSummerMotor();
        void CalculatePricesSummerGas();


        void CreatePlaceWinterGas();
        void CreatePlaceSummerGas();
        void CreatePlaceWinterOil();
        void CreatePlaceSummerOil();
        void CreatePlaceWinterMotor();
        void CreatePlaceSummerMotor();
        void CreatePlaceWinterElectric();
        void CreatePlaceSummerElectric();


        void OptimizeSummer();
        void OptimizeWinter();
    }

    public class Analyze : IAnalyze
    {
        List<double> oilWinterProductionPrices = new List<double>();
        List<double> oilSummerProductionPrices = new List<double>();

        List<double> gasWinterProductionPrices = new List<double>();
        List<double> gasSummerProductionPrices = new List<double>();

        List<double> motorWinterProductionPrices = new List<double>();
        List<double> motorSummerProductionPrices = new List<double>();

        List<double> electricWinterProductionPrices = new List<double>();
        List<double> electricSummerProductionPrices = new List<double>();


        List <int> placesWinterGas = new List<int>();
        List <int> placesSummerGas = new List<int>();
        List <int> placesWinterOil = new List<int>();
        List <int> placesSummerOil = new List<int>();
        List <int> placesWinterMotor = new List<int>();
        List <int> placesSummerMotor = new List<int>();
        List <int> placesWinterElectric = new List<int>();
        List <int> placesSummerElectric = new List<int>();

        CsvRead csvRead = new CsvRead();
        AssetManager assetManager = new AssetManager();

        OilBoiler oilBoiler = new OilBoiler();
        GasBoiler gasBoiler = new GasBoiler();

        GasMotor gasMotor = new GasMotor();
        ElectricBoiler electricBoiler= new ElectricBoiler();

        public void CalculatePricesWinterOil()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.winterPeriods[i].HeatDemand / oilBoiler.MaxHeat;
                double price = (csvRead.winterPeriods[i].HeatDemand*oilBoiler.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*oilBoiler.MaxElectricity*efficiencyRate);
                oilWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerOil()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.summerPeriods[i].HeatDemand / oilBoiler.MaxHeat;
                double price = (csvRead.summerPeriods[i].HeatDemand*oilBoiler.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*oilBoiler.MaxElectricity*efficiencyRate);
                oilSummerProductionPrices.Add(price);
            }
        }

        public void CalculatePricesWinterGas()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.winterPeriods[i].HeatDemand / gasBoiler.MaxHeat;
                double price = (csvRead.winterPeriods[i].HeatDemand*gasBoiler.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*gasBoiler.MaxElectricity*efficiencyRate);
                gasWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerGas()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.summerPeriods[i].HeatDemand / gasBoiler.MaxHeat;
                double price = (csvRead.summerPeriods[i].HeatDemand*gasBoiler.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*gasBoiler.MaxElectricity*efficiencyRate);
                gasSummerProductionPrices.Add(price);
            }
        }

        public void CalculatePricesWinterMotor()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.winterPeriods[i].HeatDemand / gasMotor.MaxHeat;
                double price = (csvRead.winterPeriods[i].HeatDemand*gasMotor.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*gasMotor.MaxElectricity*efficiencyRate);
                motorWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerMotor()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.summerPeriods[i].HeatDemand / gasMotor.MaxHeat;
                double price = (csvRead.summerPeriods[i].HeatDemand*gasMotor.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*gasMotor.MaxElectricity*efficiencyRate);
                motorSummerProductionPrices.Add(price);
            }

            for (int i = 0; i<motorSummerProductionPrices.Count;i++)
            {
                Console.WriteLine("Motor" +motorSummerProductionPrices[i]);
            }
        }

        public void CalculatePricesWinterElectric()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.winterPeriods[i].HeatDemand / electricBoiler.MaxHeat;
                double price = (csvRead.winterPeriods[i].HeatDemand*electricBoiler.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*electricBoiler.MaxElectricity*efficiencyRate);
                electricWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerElectric()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.summerPeriods[i].HeatDemand / electricBoiler.MaxHeat;
                double price = (csvRead.summerPeriods[i].HeatDemand*electricBoiler.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*electricBoiler.MaxElectricity*efficiencyRate);
                electricSummerProductionPrices.Add(price);
            }

            
            for (int i = 0; i<electricSummerProductionPrices.Count;i++)
            {
                Console.WriteLine("Electric"+electricSummerProductionPrices[i]);
            }
        }



        //Creating order, calculating places for each production unit.

        public void CreatePlaceWinterGas()
        {
            for (int i =0; i < gasWinterProductionPrices.Count(); i ++) 
            {
                int placeWinterGas;
                if(gasWinterProductionPrices[i] > oilWinterProductionPrices[i])
                {
                    if(gasWinterProductionPrices[i] > motorWinterProductionPrices[i])
                    {
                        if(gasWinterProductionPrices[i] > electricWinterProductionPrices[i])
                        {
                            placeWinterGas =4;
                            placesWinterGas.Add(placeWinterGas);
                        }
                        else 
                        {
                            placeWinterGas = 3;
                            placesWinterGas.Add(placeWinterGas);
                        }
                    }

                    else 
                    {
                        if(gasWinterProductionPrices[i] > electricWinterProductionPrices[i]) 
                        {
                            placeWinterGas=3;
                            placesWinterGas.Add(placeWinterGas);
                        }
                        else
                        {
                            placeWinterGas=2;
                            placesWinterGas.Add(placeWinterGas);
                        }

                    }
                }

                else 
                {
                    if (gasWinterProductionPrices[i] > motorWinterProductionPrices[i])
                    {
                        if (gasWinterProductionPrices[i] > electricWinterProductionPrices[i])
                        {
                            placeWinterGas= 3;
                            placesWinterGas.Add(placeWinterGas);
                        }
                        else
                        {
                            placeWinterGas=2;
                            placesWinterGas.Add(placeWinterGas);
                        }

                    }
                    else
                    {
                        if (gasWinterProductionPrices[i] > electricWinterProductionPrices[i])
                        {
                            placeWinterGas=2;
                            placesWinterGas.Add(placeWinterGas);
                        }
                        else
                        {
                            placeWinterGas=1;
                            placesWinterGas.Add(placeWinterGas);
                        }

                    }

                }
            }                    
        }

        public void CreatePlaceSummerGas()
        {
            for (int i =0; i<gasSummerProductionPrices.Count() ; i ++)
            {
                int placeSummerGas;
                if(gasSummerProductionPrices[i] > oilSummerProductionPrices[i])
                {
                    if(gasSummerProductionPrices[i] > motorSummerProductionPrices[i])
                    {
                        if(gasSummerProductionPrices[i] > electricSummerProductionPrices[i])
                        {
                            placeSummerGas =4;
                            placesSummerGas.Add(placeSummerGas);
                        }
                        else 
                        {
                            placeSummerGas = 3;
                            placesSummerGas.Add(placeSummerGas);
                        }
                    }

                    else 
                    {
                        if(gasSummerProductionPrices[i] > electricSummerProductionPrices[i]) 
                        {
                            placeSummerGas=3;
                            placesSummerGas.Add(placeSummerGas);
                        }
                        else
                        {
                            placeSummerGas=2;
                            placesSummerGas.Add(placeSummerGas);
                        }

                    }
                }

                else 
                {
                    if (gasSummerProductionPrices[i] > motorSummerProductionPrices[i])
                    {
                        if (gasSummerProductionPrices[i] > electricSummerProductionPrices[i])
                        {
                            placeSummerGas= 3;
                            placesSummerGas.Add(placeSummerGas);
                        }
                        else
                        {
                            placeSummerGas=2;
                            placesSummerGas.Add(placeSummerGas);
                        }

                    }
                    else
                    {
                        if (gasSummerProductionPrices[i] > electricSummerProductionPrices[i])
                        {
                            placeSummerGas=2;
                            placesSummerGas.Add(placeSummerGas);
                        }
                        else
                        {
                            placeSummerGas=1;
                            placesSummerGas.Add(placeSummerGas);
                        }

                    }

                }
                
            }
        }

        public void CreatePlaceWinterOil()
        {
            for (int i =0; i < oilWinterProductionPrices.Count(); i ++) 
            {
                int placeWinterOil;
                if(oilWinterProductionPrices[i] > gasWinterProductionPrices[i])
                {
                    if(oilWinterProductionPrices[i] > motorWinterProductionPrices[i])
                    {
                        if(oilWinterProductionPrices[i] > electricWinterProductionPrices[i])
                        {
                            placeWinterOil =4;
                            placesWinterOil.Add(placeWinterOil);
                        }
                        else 
                        {
                            placeWinterOil = 3;
                            placesWinterOil.Add(placeWinterOil);
                        }
                    }

                    else 
                    {
                        if(oilWinterProductionPrices[i] > electricWinterProductionPrices[i]) 
                        {
                            placeWinterOil=3;
                            placesWinterOil.Add(placeWinterOil);
                        }
                        else
                        {
                            placeWinterOil=2;
                            placesWinterOil.Add(placeWinterOil);
                        }

                    }
                }

                else 
                {
                    if (oilWinterProductionPrices[i] > motorWinterProductionPrices[i])
                    {
                        if (oilWinterProductionPrices[i] > electricWinterProductionPrices[i])
                        {
                            placeWinterOil= 3;
                            placesWinterOil.Add(placeWinterOil);
                        }
                        else
                        {
                            placeWinterOil=2;
                            placesWinterOil.Add(placeWinterOil);
                        }

                    }
                    else
                    {
                        if (oilWinterProductionPrices[i] > electricWinterProductionPrices[i])
                        {
                            placeWinterOil=2;
                            placesWinterOil.Add(placeWinterOil);
                        }
                        else
                        {
                            placeWinterOil=1;
                            placesWinterOil.Add(placeWinterOil);
                        }

                    }

                }
            }                    
        }

        public void CreatePlaceSummerOil()
        {
            for (int i =0; i<oilSummerProductionPrices.Count() ; i ++)
            {
                int placeSummerOil;
                if(oilSummerProductionPrices[i] > gasSummerProductionPrices[i])
                {
                    if(oilSummerProductionPrices[i] > motorSummerProductionPrices[i])
                    {
                        if(oilSummerProductionPrices[i] > electricSummerProductionPrices[i])
                        {
                            placeSummerOil =4;
                            placesSummerOil.Add(placeSummerOil);
                        }
                        else 
                        {
                            placeSummerOil = 3;
                            placesSummerOil.Add(placeSummerOil);
                        }
                    }

                    else 
                    {
                        if(oilSummerProductionPrices[i] > electricSummerProductionPrices[i]) 
                        {
                            placeSummerOil=3;
                            placesSummerOil.Add(placeSummerOil);
                        }
                        else
                        {
                            placeSummerOil=2;
                            placesSummerOil.Add(placeSummerOil);
                        }

                    }
                }

                else 
                {
                    if (oilSummerProductionPrices[i] > motorSummerProductionPrices[i])
                    {
                        if (oilSummerProductionPrices[i] > electricSummerProductionPrices[i])
                        {
                            placeSummerOil= 3;
                            placesSummerOil.Add(placeSummerOil);
                        }
                        else
                        {
                            placeSummerOil=2;
                            placesSummerOil.Add(placeSummerOil);
                        }

                    }
                    else
                    {
                        if (oilSummerProductionPrices[i] > electricSummerProductionPrices[i])
                        {
                            placeSummerOil=2;
                            placesSummerOil.Add(placeSummerOil);
                        }
                        else
                        {
                            placeSummerOil=1;
                            placesSummerOil.Add(placeSummerOil);
                        }

                    }

                }
            }
        }

        public void CreatePlaceWinterMotor()
        {
            for (int i =0; i < motorWinterProductionPrices.Count(); i ++) 
            {
                int placeWinterMotor;
                if(motorWinterProductionPrices[i] > oilWinterProductionPrices[i])
                {
                    if(motorWinterProductionPrices[i] > electricWinterProductionPrices[i])
                    {
                        if(motorWinterProductionPrices[i] > gasWinterProductionPrices[i])
                        {
                            placeWinterMotor =4;
                            placesWinterMotor.Add(placeWinterMotor);
                        }
                        else 
                        {
                            placeWinterMotor = 3;
                            placesWinterMotor.Add(placeWinterMotor);
                        }
                    }

                    else 
                    {
                        if(motorWinterProductionPrices[i] > gasWinterProductionPrices[i]) 
                        {
                            placeWinterMotor=3;
                            placesWinterMotor.Add(placeWinterMotor);
                        }
                        else
                        {
                            placeWinterMotor=2;
                            placesWinterMotor.Add(placeWinterMotor);
                        }

                    }
                }

                else 
                {
                    if (motorWinterProductionPrices[i] > electricWinterProductionPrices[i])
                    {
                        if (motorWinterProductionPrices[i] > gasWinterProductionPrices[i])
                        {
                            placeWinterMotor= 3;
                            placesWinterMotor.Add(placeWinterMotor);
                        }
                        else
                        {
                            placeWinterMotor=2;
                            placesWinterMotor.Add(placeWinterMotor);
                        }

                    }
                    else
                    {
                        if (motorWinterProductionPrices[i] > gasWinterProductionPrices[i])
                        {
                            placeWinterMotor=2;
                            placesWinterMotor.Add(placeWinterMotor);
                        }
                        else
                        {
                            placeWinterMotor=1;
                            placesWinterMotor.Add(placeWinterMotor);
                        }

                    }

                }
                
            }                    
        }

        public void CreatePlaceSummerMotor()
        {
            for (int i =0; i<motorSummerProductionPrices.Count() ; i ++)
            {
                int placeSummerMotor;
                if(motorSummerProductionPrices[i] > oilSummerProductionPrices[i])
                {
                    if(motorSummerProductionPrices[i] > electricSummerProductionPrices[i])
                    {
                        if(motorSummerProductionPrices[i] > gasSummerProductionPrices[i])
                        {
                            placeSummerMotor =4;
                            placesSummerMotor.Add(placeSummerMotor);
                        }
                        else 
                        {
                            placeSummerMotor = 3;
                            placesSummerMotor.Add(placeSummerMotor);
                        }
                    }

                    else 
                    {
                        if(motorSummerProductionPrices[i] > gasSummerProductionPrices[i]) 
                        {
                            placeSummerMotor=3;
                            placesSummerMotor.Add(placeSummerMotor);
                        }
                        else
                        {
                            placeSummerMotor=2;
                            placesSummerMotor.Add(placeSummerMotor);
                        }

                    }
                }

                else 
                {
                    if (motorSummerProductionPrices[i] > electricSummerProductionPrices[i])
                    {
                        if (motorSummerProductionPrices[i] > gasSummerProductionPrices[i])
                        {
                            placeSummerMotor= 3;
                            placesSummerMotor.Add(placeSummerMotor);
                        }
                        else
                        {
                            placeSummerMotor=2;
                            placesSummerMotor.Add(placeSummerMotor);
                        }

                    }
                    else
                    {
                        if (motorSummerProductionPrices[i] > gasSummerProductionPrices[i])
                        {
                            placeSummerMotor=2;
                            placesSummerMotor.Add(placeSummerMotor);
                        }
                        else
                        {
                            placeSummerMotor=1;
                            placesSummerMotor.Add(placeSummerMotor);
                        }

                    }

                }
                
            }
        }

        public void CreatePlaceWinterElectric()
        {
            for (int i =0; i < electricWinterProductionPrices.Count(); i ++) 
            {
                int placeWinterElectric;
                if(electricWinterProductionPrices[i] > oilWinterProductionPrices[i])
                {
                    if(electricWinterProductionPrices[i] > motorWinterProductionPrices[i])
                    {
                        if(electricWinterProductionPrices[i] > gasWinterProductionPrices[i])
                        {
                            placeWinterElectric =4;
                            placesWinterElectric.Add(placeWinterElectric);
                        }
                        else 
                        {
                            placeWinterElectric = 3;
                            placesWinterElectric.Add(placeWinterElectric);
                        }
                    }

                    else 
                    {
                        if(electricWinterProductionPrices[i] > gasWinterProductionPrices[i]) 
                        {
                            placeWinterElectric=3;
                            placesWinterElectric.Add(placeWinterElectric);
                        }
                        else
                        {
                            placeWinterElectric=2;
                            placesWinterElectric.Add(placeWinterElectric);
                        }

                    }
                }

                else 
                {
                    if (electricWinterProductionPrices[i] > motorWinterProductionPrices[i])
                    {
                        if (electricWinterProductionPrices[i] > gasWinterProductionPrices[i])
                        {
                            placeWinterElectric= 3;
                            placesWinterElectric.Add(placeWinterElectric);
                        }
                        else
                        {
                            placeWinterElectric=2;
                            placesWinterElectric.Add(placeWinterElectric);
                        }

                    }
                    else
                    {
                        if (electricWinterProductionPrices[i] > gasWinterProductionPrices[i])
                        {
                            placeWinterElectric=2;
                            placesWinterElectric.Add(placeWinterElectric);
                        }
                        else
                        {
                            placeWinterElectric=1;
                            placesWinterElectric.Add(placeWinterElectric);
                        }

                    }

                }
            }                    
        }

        public void CreatePlaceSummerElectric()
        {
            for (int i =0; i<electricSummerProductionPrices.Count() ; i ++)
            {
                int placeSummerElectric;
                if(electricSummerProductionPrices[i] > oilSummerProductionPrices[i])
                {
                    if(electricSummerProductionPrices[i] > motorSummerProductionPrices[i])
                    {
                        if(electricSummerProductionPrices[i] > gasSummerProductionPrices[i])
                        {
                            placeSummerElectric =4;
                            placesSummerElectric.Add(placeSummerElectric);
                        }
                        else 
                        {
                            placeSummerElectric = 3;
                            placesSummerElectric.Add(placeSummerElectric);
                        }
                    }

                    else 
                    {
                        if(electricSummerProductionPrices[i] > gasSummerProductionPrices[i]) 
                        {
                            placeSummerElectric=3;
                            placesSummerElectric.Add(placeSummerElectric);
                        }
                        else
                        {
                            placeSummerElectric=2;
                            placesSummerElectric.Add(placeSummerElectric);
                        }

                    }
                }

                else 
                {
                    if (electricSummerProductionPrices[i] > motorSummerProductionPrices[i])
                    {
                        if (electricSummerProductionPrices[i] > gasSummerProductionPrices[i])
                        {
                            placeSummerElectric= 3;
                            placesSummerElectric.Add(placeSummerElectric);
                        }
                        else
                        {
                            placeSummerElectric=2;
                            placesSummerElectric.Add(placeSummerElectric);
                        }

                    }
                    else
                    {
                        if (electricSummerProductionPrices[i] > gasSummerProductionPrices[i])
                        {
                            placeSummerElectric=2;
                            placesSummerElectric.Add(placeSummerElectric);
                        }
                        else
                        {
                            placeSummerElectric=1;
                            placesSummerElectric.Add(placeSummerElectric);
                        }

                    }

                }
            }
        }




        //Optimizing based on places in order.

        public void OptimizeSummer()
        {
            for (int i =0; i < placesSummerGas.Count() ; i ++) 
            {
                switch (placesSummerGas[i])
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }

                switch (placesSummerElectric[i])
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }

                switch (placesSummerMotor[i])
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                
                switch (placesSummerOil[i])
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
            }

        }

        public void OptimizeWinter()
        {
            for (int i =0; i < placesWinterGas.Count() ; i ++) 
            {
                switch (placesWinterGas[i])
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }

                switch (placesWinterElectric[i])
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }

                switch (placesWinterMotor[i])
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                
                switch (placesWinterOil[i])
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
            }
        }
    }
}