using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using SourceDataManager;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using System;
using System.IO;
using System.Collections.Generic;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace UI
{
    public partial class HeatPage : UserControl
    {
        public IEnumerable<ISeries> WinterHeatDemandSeries { get; } = GetWinterHeatDemandSeries();

        public HeatPage()
        {
            InitializeComponent();
            
            FromDate.SelectedDateChanged += FromDate_DateChanged_Winter;
            ToDate.SelectedDateChanged += ToDate_DateChanged_Winter;
            // Create a custom mapper for ObservablePoint
            var mapper = Mappers.Xy<ObservablePoint>()
                .X(point => point.X) // Map X property of ObservablePoint
                .Y(point => point.Y); // Map Y property of ObservablePoint
    
            // Register the mapper with LiveCharts
            Charting.For<ObservablePoint>(mapper);

            
            DataContext = this;
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
        
        private void FromDate_DateChanged_Winter(object? sender, DatePickerSelectedValueChangedEventArgs  e)
        {
            // Check if the selected date is before the minimum date
            if (FromDate.SelectedDate < new DateTimeOffset(new DateTime(2023, 2, 8)))
            {
                // Set the selected date to the minimum date
                FromDate.SelectedDate = new DateTimeOffset(new DateTime(2023, 2, 8));
            }
            // Check if the selected date is after the maximum date
            else if (FromDate.SelectedDate > new DateTimeOffset(new DateTime(2023, 2, 14)))
            {
                // Set the selected date to the maximum date
                FromDate.SelectedDate = new DateTimeOffset(new DateTime(2023, 2, 14));
            }
        }

        private void ToDate_DateChanged_Winter(object? sender, DatePickerSelectedValueChangedEventArgs  e)
        {
            // Check if the selected date is before the minimum date
            if (ToDate.SelectedDate < new DateTimeOffset(new DateTime(2023, 2, 8)))
            {
                // Set the selected date to the minimum date
                ToDate.SelectedDate = new DateTimeOffset(new DateTime(2023, 2, 8));
            }
            // Check if the selected date is after the maximum date
            else if (ToDate.SelectedDate > new DateTimeOffset(new DateTime(2023, 2, 14)))
            {
                // Set the selected date to the maximum date
                ToDate.SelectedDate = new DateTimeOffset(new DateTime(2023, 2, 14));
            }
        }

        
        private static IEnumerable<ISeries> GetWinterHeatDemandSeries()
        {
            var seriesCollection = new List<ISeries>();

            if (File.Exists(GetData.filePath))
            {
                var values = new ChartValues<ObservablePoint>();

                using (var reader = new StreamReader(GetData.filePath))
                {
                    reader.ReadLine(); // Skip headers
                    reader.ReadLine(); // Skip additional lines
                    reader.ReadLine(); // Skip additional lines

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var columns = line.Split(',');

                        // Extract values for plotting
                        DateTime x = DateTime.Parse(columns[0]);
                        DateTime y = DateTime.Parse(columns[1]);

                        // Convert the DateTime to a suitable format for plotting
                        double xAxisValue = x.ToOADate();
                        double x2AxisValue = y.ToOADate(); // or x.Ticks, depending on your requirements

                        // Create new ObservablePoint instance with specified X and Y values
                        var point = new ObservablePoint(xAxisValue, x2AxisValue);

                        // Add ObservablePoint to the values collection
                        values.Add(point);
                    }
                }

                var lineSeriesView = new LineSeries<ObservablePoint>
                {
                    Name = "Winter Heat Demand",
                    Values = values
                };

                // Add the series view to the series collection
                seriesCollection.Add(lineSeriesView);
            }
            else
            {
                Console.WriteLine($"File not found: {GetData.filePath}");
            }

            return seriesCollection;
        }



        private void DisplayWinterHeatDemand_Click(object sender, RoutedEventArgs e)
        {
            DateTimeOffset fromDateOffset = FromDate.SelectedDate ?? DateTimeOffset.MinValue;
            DateTimeOffset toDateOffset = ToDate.SelectedDate ?? DateTimeOffset.MaxValue;
            
            // Call the method to get winter heat demand series and display it in a chart
            var seriesCollection = GetWinterHeatDemandSeries();
            // Set the SeriesCollection to the chart in your UI
            WinterHeatDemandChart.Series = seriesCollection;

            // Display winter heat demand time period in a text block
            //WinterHeatDemandTime.Text = GetData.WinterHeatDemandTime();
        }
    }
}
