using Avalonia;
using Avalonia.Controls;
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
}