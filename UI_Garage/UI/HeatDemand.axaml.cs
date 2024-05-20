using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using SourceDataManager;
using LiveCharts;
using LiveCharts.Defaults;
using System;
using LiveChartsCore.SkiaSharpView.Avalonia;


namespace UI
{
    public partial class HeatPage : UserControl
    {
        //public IEnumerable<ISeries> WinterHeatDemandSeries { get; } = GetWinterHeatDemandSeries();

        public HeatPage()
        {
            InitializeComponent();
            
            // Configure LiveCharts to map ObservablePoint
            LiveChartsCore.LiveCharts.Configure(settings =>
            {
                settings.HasMap<ObservablePoint>((point, index) => new LiveChartsCore.Kernel.Coordinate(point.X, point.Y));
            });
            
            DataContext = new HeatDemandViewModel();
            
            //(DataContext as HeatDemandViewModel)?.LoadData();
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
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            (this.Parent as Window)?.Close();
        }
        
        private void DisplayWinterHeatDemand_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as HeatDemandViewModel;
            if (viewModel != null)
            {
                viewModel.LoadData();

                var chart = new CartesianChart
                {
                    Series = viewModel.WinterHeatDemandSeries,
                    Width = 650,
                    Height = 650
                };

                var chartPlaceholder = this.FindControl<ContentControl>("ChartPlaceholder");
                chartPlaceholder.Content = chart;
            }
        }

    }
}
