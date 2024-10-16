using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Resources;
using WpfApp6.Services;

namespace WpfApp6.Pages
{
    public partial class Settings : UserControl
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private string sfxFilePath = "pack://application:,,,/WpfApp6;component/Pages/sfx.mp3";

        public Settings()
        {
            InitializeComponent();
        }

        private void SfxCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri sfxUri = new Uri(sfxFilePath, UriKind.RelativeOrAbsolute);

                StreamResourceInfo resourceInfo = Application.GetResourceStream(sfxUri);
                if (resourceInfo != null)
                {
                    mediaPlayer.Open(sfxUri);
                    mediaPlayer.Play();
                }
                else
                {
                    MessageBox.Show("SFX file not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing SFX: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SfxCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateINI.WriteToConfig("Auth", "Email", EmailBox.Text);
            UpdateINI.WriteToConfig("Auth", "Password", PasswordBox.Password);
            MessageBox.Show("Information updated successfully!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
