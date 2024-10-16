using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WindowsAPICodePack.Dialogs;
using WpfApp6.Services;

namespace WpfApp6.Pages
{
    public partial class Library : Page
    {
        public Library()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
        }

        private void PathBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateINI.WriteToConfig("Auth", "Path", PathBox.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Select A Fortnite Build",
                Multiselect = false
            };

            CommonFileDialogResult commonFileDialogResult = commonOpenFileDialog.ShowDialog();

            if (commonFileDialogResult == CommonFileDialogResult.Ok)
            {
                string selectedPath = commonOpenFileDialog.FileName;

                if (File.Exists(System.IO.Path.Combine(selectedPath, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe")))
                {
                    PathBox.Text = selectedPath;
                }
                else
                {
                    MessageBox.Show("Please make sure that your folder contains FortniteGame and Engine folders.");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateINI.WriteToConfig("Auth", "Path", PathBox.Text);
            MessageBox.Show("Path saved successfully!");
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://public.simplyblk.xyz/Fortnite%2012.41.zip";

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            string discordLink = "https://discord.gg/NejQ4NyBVV";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = discordLink,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to open the link: {ex.Message}");
            }
        }
    }
}
