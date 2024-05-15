using System;
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
     private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        (this.Parent as Window)?.Close();
    }
    
    private void DisplayWinterElectricityPrice_Click(object sender, RoutedEventArgs e)
    {
        DisplayWinterElectricityPrice();
    }

    private void DisplaySummerElectricityPrice_Click(object sender, RoutedEventArgs e)
    {
        DisplaySummerElectricityPrice();
    }


    private void DisplayWinterElectricityPrice()
    {
        string winterElectricityPrice = SourceDataManager.GetData.WinterElectricityPrice();

        if (WinterElectricityPriceTextBlock != null)
        {
            WinterElectricityPriceTextBlock.Text = winterElectricityPrice;
        }
        else
        {
            Console.WriteLine("WinterElectricityPriceTextBlock is null.");
        }
    }

    private void DisplaySummerElectricityPrice()
    {
        string summerElectricityPrice = SourceDataManager.GetData.SummerElectricityPrice();

        if (SummerElectricityPriceTextBlock != null)
        {
            SummerElectricityPriceTextBlock.Text = summerElectricityPrice;
        }
        else
        {
            Console.WriteLine("SummerElectricityPriceTextBlock is null.");
        }
    }
}