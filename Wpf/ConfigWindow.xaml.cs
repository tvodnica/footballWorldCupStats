using System;
using System.Windows;


namespace Wpf
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }
       
        private static string cup;
        private static string language;
        private string dataSource;
        private string screenResolution;

        private void btn_confirm_Click(object sender, RoutedEventArgs e)
        {
            //Get cup
            if (radioBtn_female.IsChecked == true)
            {
                cup = "f";
            }
            else if (radioBtn_male.IsChecked == true)
            {
                cup = "m";
            }
            else
            {
                MessageBox.Show("Odaberite vrstu prvenstva!" +
                    Environment.NewLine +
                    "Please select type of cup!", "Greška / Error");
            }

            //Get language
            if (radioBtn_hr.IsChecked == true)
            {
                language = "hr";
            }
            else if (radioBtn_en.IsChecked == true)
            {
                language = "en";
            }
            else
            {
                MessageBox.Show("Odaberite jezik!" +
                    Environment.NewLine +
                    "Please select language!", "Greška / Error");
            }

            //Get data source
            if (radioBtn_local.IsChecked == true)
            {
                dataSource = "local";
            }
            else if (radioBtn_remote.IsChecked == true)
            {
                dataSource = "remote";
            }
            else
            {
                MessageBox.Show("Odaberite izvor podataka!" +
                    Environment.NewLine +
                    "Please select data source!", "Greška / Error");
            }

            //Get screen resolution
            if (radioBtn_fullscreen.IsChecked == true)
            {
                screenResolution = "fs";
            }
            else if (radioBtn_700x550.IsChecked == true)
            {
                screenResolution = "700x550";
            }
            else if (radioBtn_945x750.IsChecked == true)
            {
                screenResolution = "945x750";
            }
            else if (radioBtn_1145x900.IsChecked == true)
            {
                screenResolution = "1145x900";
            }
            else
            {
                MessageBox.Show("Odaberite rezoluciju zaslona!" +
                    Environment.NewLine +
                    "Please select screen resoultion!", "Greška / Error");
            }

            //Save config file and close
            if (cup != null && language != null && dataSource != null && screenResolution != null)
            {
                MessageBoxResult mbr = MessageBox.Show("Jeste li sigurni?", "POTVRDA", System.Windows.MessageBoxButton.YesNo);
                if (mbr == MessageBoxResult.Yes)
                {
                    try
                    {
                        Data.Files.SaveConfigFile(cup, language, dataSource, screenResolution);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }
    }

}
