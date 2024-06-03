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
        public HeatPage()
        {
            InitializeComponent();

            // Configure LiveCharts to map ObservablePoint
            LiveChartsCore.LiveCharts.Configure(settings =>
            {
                settings.HasMap<ObservablePoint>((point, index) => new LiveChartsCore.Kernel.Coordinate(point.X, point.Y));
            });

            DataContext = new HeatDemandViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            (this.Parent as Window)?.Close();
        }

        private void PrintHeatDemandData_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as HeatDemandViewModel;
            if (viewModel != null)
            {
                var heatDemandDataText = viewModel.GetHeatDemandDataAsText();
                var heatDemandTextBlock = this.FindControl<TextBlock>("HeatDemandTextBlock");
                heatDemandTextBlock.Text = heatDemandDataText;
            }
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
