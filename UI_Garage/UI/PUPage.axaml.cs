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
            var mainWindow = new MainWindow();
            mainWindow.Show();
            (this.Parent as Window)?.Close();
        }

        private void NavigateToMap_Click(object sender, RoutedEventArgs e)
        {
            var map = new Map();
            Content = map;
            
        }
    }
}