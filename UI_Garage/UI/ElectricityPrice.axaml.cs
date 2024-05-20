using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace UI;

public partial class ElectricityPrice : UserControl
{ 
    private ElectricityViewModel _electricityViewModel;

    public ElectricityPrice()
    {
        InitializeComponent();
        _electricityViewModel = new ElectricityViewModel();
        DataContext = _electricityViewModel;
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
     
    private void ShowGraphBtn_Click(object sender, RoutedEventArgs e)
    {
        _electricityViewModel.LoadData();
    }
}

/*
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
    */