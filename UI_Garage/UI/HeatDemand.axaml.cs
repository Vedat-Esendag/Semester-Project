using Avalonia.Controls;
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
    }
}