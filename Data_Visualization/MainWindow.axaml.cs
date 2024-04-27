using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Data_Visualization;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void OpenSettingsWindow(object sender, RoutedEventArgs e)
    {
        var settingsWindow = new SettingsWindow();
        settingsWindow.Show();
    }
}