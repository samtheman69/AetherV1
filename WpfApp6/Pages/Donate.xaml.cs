using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfApp6.Pages
{
    public partial class Donate : Page
    {
        public Donate()
        {
            InitializeComponent();
            Loaded += Donate_Loaded;
        }

        private void Donate_Loaded(object sender, RoutedEventArgs e)
        {
            var fadeInStoryboard = (Storyboard)FindResource("FadeInStoryboard");
            fadeInStoryboard.Begin();
        }

        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://aethermp.mysellix.io/") { UseShellExecute = true });
        }
    }
}
