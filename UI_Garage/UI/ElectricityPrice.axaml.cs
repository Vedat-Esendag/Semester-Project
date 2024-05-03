using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace UI;

public partial class ElectricityPrice : UserControl
{ 
    public ElectricityPrice()
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