using Avalonia;
using Avalonia.Controls;
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
}