using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UI;

public partial class Consumption : UserControl
{
    public Consumption()
    {
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}