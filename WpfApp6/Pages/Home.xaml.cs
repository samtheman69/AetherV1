using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using WpfApp6.Services.Launch;
using WpfApp6.Services;

namespace WpfApp6.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            Loaded += Home_Loaded; // Attach the Loaded event
        }

        private void Home_Loaded(object sender, RoutedEventArgs e)
        {
            // Start the fade-in storyboard
            Storyboard fadeInStoryboard = (Storyboard)FindResource("FadeInStoryboard");
            fadeInStoryboard.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Path69 = UpdateINI.ReadValue("Auth", "Path");
                if (Path69 != "NONE")
                {
                    if (File.Exists(System.IO.Path.Join(Path69, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe")))
                    {
                        if (UpdateINI.ReadValue("Auth", "Email") == "NONE" || UpdateINI.ReadValue("Auth", "Password") == "NONE")
                        {
                            MessageBox.Show("Please Add Your Info In Settings");
                            return;
                        }

                        WebClient OMG = new WebClient();
                        OMG.DownloadFile("https://cdn.discordapp.com/attachments/1125117879763865642/1125490815372890183/EonCurl.dll",
                            Path.Combine(Path69, "Engine\\Binaries\\ThirdParty\\NVIDIA\\NVaftermath\\Win64", "GFSDK_Aftermath_Lib.x64.dll"));

                        PSBasics.Start(Path69, "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck",
                            UpdateINI.ReadValue("Auth", "Email"), UpdateINI.ReadValue("Auth", "Password"));

                        FakeAC.Start(Path69, "FortniteClient-Win64-Shipping_BE.exe",
                            $"-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck", "r");

                        FakeAC.Start(Path69, "FortniteLauncher.exe",
                            $"-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck", "dsf");

                        PSBasics._FortniteProcess.WaitForExit();

                        try
                        {
                            FakeAC._FNLauncherProcess.Close();
                            FakeAC._FNAntiCheatProcess.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("There Has Been An Error Closing");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Add Your Info In Settings");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void DiscordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://discord.gg/aethermp") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Discord: " + ex.Message);
            }
        }
    }
}
