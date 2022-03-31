using System;
using System.Windows.Forms;

namespace WebForms
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private static string cup;
        private static string language;
        private string dataSource;

        private void button_confirm_Click(object sender, EventArgs e)
        {
            //Get cup
            if (radioButton_female.Checked)
            {
                cup = "f";
            }
            else if (radioButton_male.Checked)
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
            if (radioButton_croatian.Checked)
            {
                language = "hr";
            }
            else if (radioButton_english.Checked)
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
            if (radioButton_local.Checked)
            {
                dataSource = "local";
            }
            else if (radioButton_remote.Checked)
            {
                dataSource = "remote";
            }
            else
            {
                MessageBox.Show("Odaberite izvor podataka!" +
                    Environment.NewLine +
                    "Please select data source!", "Greška / Error");
            }

            //Save config file and close
            if (cup != null && language != null && dataSource != null)
            {
                FormYesNo fyn = new FormYesNo();
                if (fyn.ShowDialog() == DialogResult.Yes)
                {
                    try
                    {
                        Data.Files.SaveConfigFile(cup, language, dataSource, " ");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error"); 
                    }
                }

            }
        }

    }

}
