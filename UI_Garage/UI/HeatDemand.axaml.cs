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
            
        }

        private void DisplayWinterHeatDemand_Click(object sender, RoutedEventArgs e)
        {
            DisplayWinterHeatDemand();
        }
    }
}