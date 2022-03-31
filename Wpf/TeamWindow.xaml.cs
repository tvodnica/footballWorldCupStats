using System;
using System.Windows;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        public TeamWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string teamFifaCode="";
            Data.Team team = new Data.Team();

            try
            {
                teamFifaCode = Data.Files.LoadTeamFile4Info();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            try
            {
                team = Data.GetData.GetTeamByFifaCode(teamFifaCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }


            txtNaziv.Text = team.Country;
            txtFifaCode.Text = team.FifaCode;

            txtPlayed.Text = team.GamesPlayed.ToString();
            txtWon.Text = team.Wins.ToString();
            txtLost.Text = team.Losses.ToString();
            txtDraw.Text = team.Draws.ToString();

            txtGoalsScored.Text = team.GoalsFor.ToString();
            txtGoalsAgainst.Text = team.GoalsAgainst.ToString();
            txtGoalDifference.Text = team.GoalDifferential.ToString();

        }
    }
}
