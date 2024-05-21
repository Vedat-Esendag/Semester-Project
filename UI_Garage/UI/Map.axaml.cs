using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace UI
{
    public partial class Map : UserControl
    {
        public Map()
        {
            InitializeComponent();
        }

        private void Pup_Click(object sender, RoutedEventArgs e)
        {
            var PuPage = new UI.PuPage();
                Content = PuPage;
            
            
        }
    }
    
}
