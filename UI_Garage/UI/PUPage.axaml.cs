using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UI
{
    public partial class PuPage : UserControl
    {
        public PuPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}