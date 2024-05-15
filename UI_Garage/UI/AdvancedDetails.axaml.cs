using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace UI;

public partial class AdvancedDetails : UserControl
{
    public AdvancedDetails()
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
}