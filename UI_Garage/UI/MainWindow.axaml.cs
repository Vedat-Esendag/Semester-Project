using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace UI
{
    public partial class MainWindow : Window
    {

        public MainWindow()
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

        private void NavigateToHeatDemand_Click(object sender, RoutedEventArgs e)
        {
            var heatPage = new HeatPage();
            Content = heatPage;
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
    }
}