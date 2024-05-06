using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CsvHelper.Configuration.Attributes;
using SourceDataManager;
using LiveCharts;
using LiveCharts.Wpf;
using System;

namespace UI
{
    public partial class HeatPage : UserControl
    {
        public HeatPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        private void NavigateToPuPage_Click(object sender, RoutedEventArgs e)
        {
            var puPage = new PuPage();
            Content = puPage;
        }
        
        private void NavigateToElectricityPrice_Click(object sender, RoutedEventArgs e)
        {
            var electricityPage = new ElectricityPrice();
            Content = electricityPage;
        }
        
        private void NavigateToConsumption_Click(object sender, RoutedEventArgs e)
        {
            var consumption = new Consumption();
            Content = consumption;
        }
        
        private void NavigateToAdvancedDetails_Click(object sender, RoutedEventArgs e)
        {
            var advancedDetails = new AdvancedDetails();
            Content = advancedDetails;
        }

        private void DisplayWinterHeatDemand()
        {
            string winterHeatDemandText = SourceDataManager.GetData.WinterHeatDemand();

            if (WinterHeatDemandTextBlock != null)
            {
                WinterHeatDemandTextBlock.Text = winterHeatDemandText;
            }
            else
            {
                Console.WriteLine("WinterHeatDemandTextBlock is null.");
            }

            // Extract winter heat demand data and time data for the chart
            string[] heatDemandData = winterHeatDemandText.Split(',');
            string[] timeData = new string[heatDemandData.Length / 2];
            double[] demandValues = new double[heatDemandData.Length / 2];

            for (int i = 0; i < heatDemandData.Length; i += 2)
            {
                timeData[i / 2] = heatDemandData[i];
                demandValues[i / 2] = double.Parse(heatDemandData[i + 1]);
            }

            // Clear existing series and add new series to the chart
            WinterHeatDemandChart.Series.Clear();
            WinterHeatDemandChart.Series.Add(new ColumnSeries
            {
                Title = "Winter Heat Demand",
                Values = new ChartValues<double>(demandValues),
                DataLabels = true,
                LabelPoint = point => $"{point.Y}",
                LabelsPosition = BarLabelPosition.Top
            });

            // Update X axis labels with time data
            WinterHeatDemandChart.AxisX.Clear();
            WinterHeatDemandChart.AxisX.Add(new Axis
            {
                Title = "Time", // Add title if needed
                Labels = timeData
            });
        }


        private void DisplayWinterHeatDemand_Click(object sender, RoutedEventArgs e)
        {
            DisplayWinterHeatDemand();
        }
    }
}