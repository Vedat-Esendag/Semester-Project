using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

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
    }
}