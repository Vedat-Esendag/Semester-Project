using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using SourceDataManager;
using LiveCharts;
using System;
using System.Linq;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

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
            // Get winter heat demand data from the source data manager
            string winterHeatDemandData = GetData.WinterHeatDemand();

            // Parse the data and prepare it for visualization
            var series = new LineSeries
            {
                Title = "Winter Heat Demand",
                Values = ParseData(winterHeatDemandData)
            };

            // Create a new SeriesCollection and add the series to it
            var seriesCollection = new SeriesCollection { series };

            // Assign the SeriesCollection to the chart
            WinterHeatDemandChart.Series = seriesCollection.Cast<LiveChartsCore.ISeries>();
        }

        private ChartValues<ObservablePoint> ParseData(string data)
        {
            var chartValues = new ChartValues<ObservablePoint>();

            // Assuming the data format is comma-separated values
            string[] rows = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            foreach (string row in rows)
            {
                string[] values = row.Split(',');
                if (values.Length >= 2) // Assuming the data contains at least two columns (x and y)
                {
                    double x, y;
                    if (double.TryParse(values[0], out x) && double.TryParse(values[1], out y))
                    {
                        chartValues.Add(new ObservablePoint(x, y));
                    }
                }
            }

            return chartValues;
        }
        
        private void DisplayWinterHeatDemand_Click(object sender, RoutedEventArgs e)
        {
            DisplayWinterHeatDemand();
        }
    }
}