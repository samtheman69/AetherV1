using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WindowsAPICodePack.Dialogs;
using WpfApp6.Services;

namespace WpfApp6.Pages
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
            commonOpenFileDialog.IsFolderPicker = true;
            commonOpenFileDialog.Title = "Select A Fortnite Build";
            commonOpenFileDialog.Multiselect = false;
            CommonFileDialogResult commonFileDialogResult = commonOpenFileDialog.ShowDialog();

            if (commonFileDialogResult == CommonFileDialogResult.Ok)
            {
                if (File.Exists(System.IO.Path.Join(commonOpenFileDialog.FileName, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe")))
                {
                }
                else
                {
                    MessageBox.Show("Please make sure that the folder contains FortniteGame and Engine.");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateINI.WriteToConfig("Auth", "Email", EmailBox.Text);
            UpdateINI.WriteToConfig("Auth", "Password", PasswordBox.Password);
        }
    }
}
