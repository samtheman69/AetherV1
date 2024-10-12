using ModernWpf.Controls;
using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using WpfApp6.Pages; 

namespace WpfApp6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Opacity = 0;
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            NavigateToHome();
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                NavigateToSettings();
            }
            else
            {
                var item = args.SelectedItem as NavigationViewItem;

                if (item != null)
                {
                    switch (item.Tag.ToString())
                    {
                        case "Home":
                            NavigateToHome();
                            break;
                        case "Library":
                            NavigateToLibrary();
                            break;
                        case "News": 
                            NavigateToNews();
                            break;
                        case "Download": 
                            NavigateToDownload(); 
                            break;
                        case "Donate": 
                            NavigateToDonate(); 
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void NavigateToHome()
        {
            StartFadeOutAnimation(() =>
            {
                ContentFrame.Navigate(new Uri("Pages/Home.xaml", UriKind.Relative));
                StartFadeInAnimation();
            });
        }

        private void NavigateToLibrary()
        {
            StartFadeOutAnimation(() =>
            {
                try
                {

                    ContentFrame.Navigate(new Uri("Pages/Library.xaml", UriKind.Relative));
                    StartFadeInAnimation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to navigate to Library. Error: {ex.Message}");
                }
            });
        }

        private void NavigateToNews() 
        {
            StartFadeOutAnimation(() =>
            {
                try
                {
                    ContentFrame.Navigate(new Uri("Pages/News.xaml", UriKind.Relative));
                    StartFadeInAnimation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to navigate to News. Error: {ex.Message}");
                }
            });
        }

        private void NavigateToDownload()
        {
            StartFadeOutAnimation(() =>
            {
                try
                {
                    ContentFrame.Navigate(new Uri("Pages/Download.xaml", UriKind.Relative));
                    StartFadeInAnimation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to navigate to Download. Error: {ex.Message}");
                }
            });
        }

        private void NavigateToDonate()
        {
            StartFadeOutAnimation(() =>
            {
                try
                {
                    ContentFrame.Navigate(new Uri("Pages/Donate.xaml", UriKind.Relative));
                    StartFadeInAnimation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to navigate to Donate. Error: {ex.Message}");
                }
            });
        }

        private void NavigateToSettings()
        {
            StartFadeOutAnimation(() =>
            {
                try
                {
                    ContentFrame.Navigate(new Uri("Pages/Settings.xaml", UriKind.Relative));
                    StartFadeInAnimation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to navigate to Settings. Error: {ex.Message}");
                }
            });
        }

        private void StartFadeOutAnimation(Action completedAction)
        {
            var fadeOutStoryboard = (Storyboard)FindResource("FadeOutStoryboard");
            fadeOutStoryboard.Completed += (s, e) => completedAction();
            fadeOutStoryboard.Begin();
        }

        private void StartFadeInAnimation()
        {
            var fadeInStoryboard = (Storyboard)FindResource("FadeInStoryboard");
            fadeInStoryboard.Begin();
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            MessageBox.Show($"Failed to load page. Error: {e.Exception.Message}");
        }
    }

    internal class Download
    {
    }
}
