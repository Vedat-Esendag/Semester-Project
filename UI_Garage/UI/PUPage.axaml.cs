using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
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
        
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var goBack = new MainWindow();
            Content = goBack;
        }
    }
}