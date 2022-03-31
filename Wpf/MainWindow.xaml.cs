using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SubscribeAllBackgroungWorkers();
        }

        private readonly BackgroundWorker bgWorkerFavTeams = new BackgroundWorker();
        private readonly BackgroundWorker bgWorkerAgainstTeams = new BackgroundWorker();
        private readonly BackgroundWorker bgWorkerFavTeamChanged = new BackgroundWorker();

        private string favTeam;
        private bool closeWithoutWarning = false;

        private List<Data.Team> allTeams = new List<Data.Team>();
        private List<Data.Team> teamsPlayedAgainst;

        private Data.Team teamFav;
        private Data.Team teamAgainst;
        private Data.Team selectedTeam;

        private Data.Match selectedMatch = new Data.Match();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CheckIfConfigExists())
            {
                SetWindowSize();
                LoadTeamsIntoDDLS();
            }
        }


        //LOAD FAVORITE TEAMS
        private void LoadTeamsIntoDDLS()
        {
            if (Data.Files.FavTeamFileExists())
            {
                try
                {
                    favTeam = Data.Files.LoadFavTeamFile()[1];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }
            }
            text_StatusBar.Text = "Učitavam omiljene reprezentacije...";
            progressBar.Visibility = Visibility.Visible;
            progressBar.Value = 20;
            button_FavTeamInfo.IsEnabled = false;
            bgWorkerFavTeams.RunWorkerAsync();
        }
        private void BgWorkerFavTeams_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                allTeams = Data.GetData.GetAllTeams();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            selectedTeam = allTeams[0];
        }
        private void BgWorkerFavTeams_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            comboBox_favTeam.SelectedIndex = 0;
            foreach (var team in allTeams)
            {
                comboBox_favTeam.Items.Add(team);
                if (team.FifaCode == favTeam)
                {
                    comboBox_favTeam.SelectedItem = team;
                    selectedTeam = team;
                }
            }
            button_FavTeamInfo.IsEnabled = true;
            comboBox_favTeam.SelectionChanged += ComboBox_favTeam_SelectionChanged;
            LoadTeamsAgainst();
        }


        //LOAD AGAINST TEAMS
        private void LoadTeamsAgainst()
        {
            progressBar.Visibility = Visibility.Visible;
            progressBar.Value = 50;
            text_StatusBar.Text = "Učitavam protivničke reprezentacije...";
            button_againstTeamInfo.IsEnabled = false;
            bgWorkerAgainstTeams.RunWorkerAsync(selectedTeam);
        }
        private void BgWorkerAgainstTeams_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Data.Team selectedTeam1 = (Data.Team)e.Argument;
                teamsPlayedAgainst = Data.GetData.GetTeamsPlayedAgainst(selectedTeam1.FifaCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GREŠKA");
            }
        }
        private void BgWorkerAgainstTeams_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            comboBox_againstTeam.Items.Clear();
            foreach (var team in teamsPlayedAgainst)
            {
                comboBox_againstTeam.Items.Add(team);
            }
            comboBox_againstTeam.SelectedIndex = 0;
            button_againstTeamInfo.IsEnabled = true;
        }


        //LOAD MATCH DETAILS
        private void LoadMatchDetails()
        {
            teamFav = (Data.Team)comboBox_favTeam.SelectedItem;
            teamAgainst = (Data.Team)comboBox_againstTeam.SelectedItem;
            progressBar.Visibility = Visibility.Visible;
            progressBar.Value = 80;
            text_StatusBar.Text = "Učitavam podatke o utakmici...";
            try
            {
                bgWorkerFavTeamChanged.RunWorkerAsync(new Data.Team[2] { teamFav, teamAgainst });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }
        private void BgWorkerFavTeamChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            Data.Team[] data = (Data.Team[])e.Argument;
            teamFav = data[0];
            teamAgainst = data[1];
            try
            {
                if (teamFav != null && teamAgainst != null)
                {
                    selectedMatch = Data.GetData.GetMatch(teamFav, teamAgainst);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void BgWorkerFavTeamChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            selectedMatch.HomeTeam.GoalsFor = 0;
            selectedMatch.AwayTeam.GoalsFor = 0;

            //GET ALL PLAYERS FOR THIS MATCH
            List<Data.Player> allPlayersFromCurrentMatch = new List<Data.Player>();
            try
            {
                allPlayersFromCurrentMatch = Data.GetData.GetPlayersFromMatch(selectedMatch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            GetGoalsAndYellowCards(allPlayersFromCurrentMatch);
            AddPlayersToPitch();

            Data.Files.SavePlayersFromCurrentMatch(allPlayersFromCurrentMatch);
            SetStatusBarOk();

        }
        private void GetGoalsAndYellowCards(List<Data.Player> allPlayersFromCurrentMatch)
        {
            foreach (var events in selectedMatch.HomeTeamEvents)
            {
                if (events.TypeOfEvent == "goal-penalty" || events.TypeOfEvent == "goal")
                {
                    selectedMatch.HomeTeam.GoalsFor++;
                    foreach (var player in allPlayersFromCurrentMatch)
                    {
                        if (player.Name == events.Player)
                        {
                            player.GoalsInThisMatch++;
                        }
                    }
                }
            }
            foreach (var events in selectedMatch.HomeTeamEvents)
            {
                if (events.TypeOfEvent == "yellow-card")
                {
                    foreach (var player in allPlayersFromCurrentMatch)
                    {
                        if (player.Name == events.Player)
                        {
                            player.YellowCardsInThisMatch++;
                        }
                    }
                }
            }
            foreach (var events in selectedMatch.AwayTeamEvents)
            {
                if (events.TypeOfEvent == "goal-penalty" || events.TypeOfEvent == "goal")
                {
                    selectedMatch.AwayTeam.GoalsFor++;
                    foreach (var player in allPlayersFromCurrentMatch)
                    {
                        if (player.Name == events.Player)
                        {
                            player.GoalsInThisMatch++;
                        }
                    }
                }
            }
            foreach (var events in selectedMatch.AwayTeamEvents)
            {
                if (events.TypeOfEvent == "yellow-card")
                {
                    foreach (var player in allPlayersFromCurrentMatch)
                    {
                        if (player.Name == events.Player)
                        {
                            player.YellowCardsInThisMatch++;
                        }
                    }
                }
            }
        }
        private void ClearPitch()
        {
            foreach (UCPlayerWindow player in grid_pitch.Children)
            {
                player.text_Name.Text = " ";
                player.text_Number.Text = " ";
                player.image_playerImage.Visibility = Visibility.Hidden;
            }
        }
        private void AddPlayersToPitch()
        {
            int fav_df = 0;
            int fav_md = 0;
            int fav_fw = 0;
            int against_df = 0;
            int against_md = 0;
            int against_fw = 0;

            ClearPitch();

            if (selectedMatch.HomeTeam.Code == teamFav.FifaCode)
            {
                textBlock_favScore.Text = selectedMatch.HomeTeam.GoalsFor.ToString();
                textBlock_againstScore.Text = selectedMatch.AwayTeam.GoalsFor.ToString();
                foreach (var player in selectedMatch.HomeTeamStatistics.StartingEleven)
                {
                    if (player.Position == "Goalie")
                    {
                        ucp_FavGK.text_Number.Text = player.ShirtNumber.ToString();
                        ucp_FavGK.text_Name.Text = player.Name;
                        ucp_FavGK.image_playerImage.Visibility = Visibility.Visible;
                    }
                    else if (player.Position == "Defender")
                    {
                        switch (fav_df)
                        {
                            case 0:
                                ucp_FavDF2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavDF2.text_Name.Text = player.Name;
                                ucp_FavDF2.image_playerImage.Visibility = Visibility.Visible;
                                fav_df++;
                                break;
                            case 1:
                                ucp_FavDF3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavDF3.text_Name.Text = player.Name;
                                ucp_FavDF3.image_playerImage.Visibility = Visibility.Visible;
                                fav_df++;
                                break;
                            case 2:
                                ucp_FavDF1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavDF1.text_Name.Text = player.Name;
                                ucp_FavDF1.image_playerImage.Visibility = Visibility.Visible;
                                fav_df++;
                                break;
                            case 3:
                                ucp_FavDF4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavDF4.text_Name.Text = player.Name;
                                ucp_FavDF4.image_playerImage.Visibility = Visibility.Visible;
                                fav_df++;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (player.Position == "Midfield")
                    {
                        switch (fav_md)
                        {
                            case 0:
                                ucp_FavMD2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavMD2.text_Name.Text = player.Name;
                                ucp_FavMD2.image_playerImage.Visibility = Visibility.Visible;
                                fav_md++;
                                break;
                            case 1:
                                ucp_FavMD3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavMD3.text_Name.Text = player.Name;
                                ucp_FavMD3.image_playerImage.Visibility = Visibility.Visible;
                                fav_md++;
                                break;
                            case 2:
                                ucp_FavMD1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavMD1.text_Name.Text = player.Name;
                                ucp_FavMD1.image_playerImage.Visibility = Visibility.Visible;
                                fav_md++;
                                break;
                            case 3:
                                ucp_FavMD4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavMD4.text_Name.Text = player.Name;
                                ucp_FavMD4.image_playerImage.Visibility = Visibility.Visible;
                                fav_md++;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (player.Position == "Forward")
                    {
                        switch (fav_fw)
                        {
                            case 0:
                                ucp_FavFW2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavFW2.text_Name.Text = player.Name;
                                ucp_FavFW2.image_playerImage.Visibility = Visibility.Visible;
                                fav_fw++;
                                break;
                            case 1:
                                ucp_FavFW3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavFW3.text_Name.Text = player.Name;
                                ucp_FavFW3.image_playerImage.Visibility = Visibility.Visible;
                                fav_fw++;
                                break;
                            case 2:
                                ucp_FavFW1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavFW1.text_Name.Text = player.Name;
                                ucp_FavFW1.image_playerImage.Visibility = Visibility.Visible;
                                fav_fw++;
                                break;
                            case 3:
                                ucp_FavFW4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavFW4.text_Name.Text = player.Name;
                                ucp_FavFW4.image_playerImage.Visibility = Visibility.Visible;
                                fav_fw++;
                                break;
                            default:
                                break;
                        }
                    }

                }
                foreach (var player in selectedMatch.AwayTeamStatistics.StartingEleven)
                {
                    if (player.Position == "Goalie")
                    {
                        ucp_AgainstGK.text_Number.Text = player.ShirtNumber.ToString();
                        ucp_AgainstGK.text_Name.Text = player.Name;
                    }
                    else if (player.Position == "Defender")
                    {
                        switch (against_df)
                        {
                            case 0:
                                ucp_AgainstDF2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstDF2.text_Name.Text = player.Name;
                                against_df++;
                                break;
                            case 1:
                                ucp_AgainstDF3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstDF3.text_Name.Text = player.Name;
                                against_df++;
                                break;
                            case 2:
                                ucp_AgainstDF1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstDF1.text_Name.Text = player.Name;
                                against_df++;
                                break;
                            case 3:
                                ucp_AgainstDF4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstDF4.text_Name.Text = player.Name;
                                against_df++;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (player.Position == "Midfield")
                    {
                        switch (against_md)
                        {
                            case 0:
                                ucp_AgainstMD2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstMD2.text_Name.Text = player.Name;
                                against_md++;
                                break;
                            case 1:
                                ucp_AgainstMD3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstMD3.text_Name.Text = player.Name;
                                against_md++;
                                break;
                            case 2:
                                ucp_AgainstMD1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstMD1.text_Name.Text = player.Name;
                                against_md++;
                                break;
                            case 3:
                                ucp_AgainstMD4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstMD4.text_Name.Text = player.Name;
                                against_md++;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (player.Position == "Forward")
                    {
                        switch (against_fw)
                        {
                            case 0:
                                ucp_AgainstFW2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstFW2.text_Name.Text = player.Name;
                                against_fw++;
                                break;
                            case 1:
                                ucp_AgainstFW3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstFW3.text_Name.Text = player.Name;
                                against_fw++;
                                break;
                            case 2:
                                ucp_AgainstFW1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstFW1.text_Name.Text = player.Name;
                                against_fw++;
                                break;
                            case 3:
                                ucp_AgainstFW4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstFW4.text_Name.Text = player.Name;
                                against_fw++;
                                break;
                            default:
                                break;
                        }
                    }

                }
            }
            else
            {
                textBlock_favScore.Text = selectedMatch.AwayTeam.GoalsFor.ToString();
                textBlock_againstScore.Text = selectedMatch.HomeTeam.GoalsFor.ToString();
                foreach (var player in selectedMatch.AwayTeamStatistics.StartingEleven)
                {
                    if (player.Position == "Goalie")
                    {
                        ucp_FavGK.text_Number.Text = player.ShirtNumber.ToString();
                        ucp_FavGK.text_Name.Text = player.Name;
                    }
                    else if (player.Position == "Defender")
                    {
                        switch (fav_df)
                        {
                            case 0:
                                ucp_FavDF2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavDF2.text_Name.Text = player.Name;
                                fav_df++;
                                break;
                            case 1:
                                ucp_FavDF3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavDF3.text_Name.Text = player.Name;
                                fav_df++;
                                break;
                            case 2:
                                ucp_FavDF1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavDF1.text_Name.Text = player.Name;
                                fav_df++;
                                break;
                            case 3:
                                ucp_FavDF4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavDF4.text_Name.Text = player.Name;
                                fav_df++;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (player.Position == "Midfield")
                    {
                        switch (fav_md)
                        {
                            case 0:
                                ucp_FavMD2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavMD2.text_Name.Text = player.Name;
                                fav_md++;
                                break;
                            case 1:
                                ucp_FavMD3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavMD3.text_Name.Text = player.Name;
                                fav_md++;
                                break;
                            case 2:
                                ucp_FavMD1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavMD1.text_Name.Text = player.Name;
                                fav_md++;
                                break;
                            case 3:
                                ucp_FavMD4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavMD4.text_Name.Text = player.Name;
                                fav_md++;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (player.Position == "Forward")
                    {
                        switch (fav_fw)
                        {
                            case 0:
                                ucp_FavFW2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavFW2.text_Name.Text = player.Name;
                                fav_fw++;
                                break;
                            case 1:
                                ucp_FavFW3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavFW3.text_Name.Text = player.Name;
                                fav_fw++;
                                break;
                            case 2:
                                ucp_FavFW1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavFW1.text_Name.Text = player.Name;
                                fav_fw++;
                                break;
                            case 3:
                                ucp_FavFW4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_FavFW4.text_Name.Text = player.Name;
                                fav_fw++;
                                break;
                            default:
                                break;
                        }
                    }

                }
                foreach (var player in selectedMatch.HomeTeamStatistics.StartingEleven)
                {
                    if (player.Position == "Goalie")
                    {
                        ucp_AgainstGK.text_Number.Text = player.ShirtNumber.ToString();
                        ucp_AgainstGK.text_Name.Text = player.Name;
                    }
                    else if (player.Position == "Defender")
                    {
                        switch (against_df)
                        {
                            case 0:
                                ucp_AgainstDF2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstDF2.text_Name.Text = player.Name;
                                against_df++;
                                break;
                            case 1:
                                ucp_AgainstDF3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstDF3.text_Name.Text = player.Name;
                                against_df++;
                                break;
                            case 2:
                                ucp_AgainstDF1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstDF1.text_Name.Text = player.Name;
                                against_df++;
                                break;
                            case 3:
                                ucp_AgainstDF4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstDF4.text_Name.Text = player.Name;
                                against_df++;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (player.Position == "Midfield")
                    {
                        switch (against_md)
                        {
                            case 0:
                                ucp_AgainstMD2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstMD2.text_Name.Text = player.Name;
                                against_md++;
                                break;
                            case 1:
                                ucp_AgainstMD3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstMD3.text_Name.Text = player.Name;
                                against_md++;
                                break;
                            case 2:
                                ucp_AgainstMD1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstMD1.text_Name.Text = player.Name;
                                against_md++;
                                break;
                            case 3:
                                ucp_AgainstMD4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstMD4.text_Name.Text = player.Name;
                                against_md++;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (player.Position == "Forward")
                    {
                        switch (against_fw)
                        {
                            case 0:
                                ucp_AgainstFW2.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstFW2.text_Name.Text = player.Name;
                                against_fw++;
                                break;
                            case 1:
                                ucp_AgainstFW3.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstFW3.text_Name.Text = player.Name;
                                against_fw++;
                                break;
                            case 2:
                                ucp_AgainstFW1.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstFW1.text_Name.Text = player.Name;
                                against_fw++;
                                break;
                            case 3:
                                ucp_AgainstFW4.text_Number.Text = player.ShirtNumber.ToString();
                                ucp_AgainstFW4.text_Name.Text = player.Name;
                                against_fw++;
                                break;
                            default:
                                break;
                        }
                    }

                }
            }

            foreach (UCPlayerWindow player in grid_pitch.Children)
            {
                if (player.text_Name.Text != " ")
                {
                    player.image_playerImage.Visibility = Visibility.Visible;
                }
            }
        }



        //COMBOBOX SELECTION CHANGE
        private void ComboBox_favTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeam = (Data.Team)comboBox_favTeam.SelectedItem;
            Data.Files.SaveFavTeamFile(selectedTeam.Id, selectedTeam.FifaCode);
            LoadTeamsAgainst();
        }
        private void comboBox_againstTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox_againstTeam.SelectedIndex >= 0)
            {
                LoadMatchDetails();
            }
        }


        // OTHER
        private void SubscribeAllBackgroungWorkers()
        {
            bgWorkerAgainstTeams.DoWork += BgWorkerAgainstTeams_DoWork;
            bgWorkerAgainstTeams.RunWorkerCompleted += BgWorkerAgainstTeams_RunWorkerCompleted;
            bgWorkerFavTeams.DoWork += BgWorkerFavTeams_DoWork;
            bgWorkerFavTeams.RunWorkerCompleted += BgWorkerFavTeams_RunWorkerCompleted;
            bgWorkerFavTeamChanged.DoWork += BgWorkerFavTeamChanged_DoWork;
            bgWorkerFavTeamChanged.RunWorkerCompleted += BgWorkerFavTeamChanged_RunWorkerCompleted;
        }
        private void SetWindowSize()
        {
            try
            {
                string[] screenResolution = Data.Files.LoadConfigFile()[3].Split('x');
                if (screenResolution[0] == "fs")
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.Width = int.Parse(screenResolution[0]);
                    this.Height = int.Parse(screenResolution[1]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom postavljanja rezolucije prozora", "ERROR");
            }


        }
        private void button_FavTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            Data.Team team = (Data.Team)comboBox_favTeam.SelectedItem;
            Data.Files.SaveTeamFile4Info(team);
            TeamWindow tw = new TeamWindow();
            tw.ShowDialog();
        }
        private void button_againstTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            Data.Team team = (Data.Team)comboBox_againstTeam.SelectedItem;
            Data.Files.SaveTeamFile4Info(team);
            TeamWindow tw = new TeamWindow();
            tw.ShowDialog();
        }
        private bool CheckIfConfigExists()
        {
            if (!Data.Files.ConfigExists())
            {
                ConfigWindow cw = new ConfigWindow();
                cw.Show();
                closeWithoutWarning = true;
                this.Close();
                return false;
            }
            return true;
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindow cw = new ConfigWindow();
            cw.ShowDialog();
            closeWithoutWarning = true;
            this.Close();
        }
        private void SetStatusBarOk()
        {
            text_StatusBar.Text = "Sve 5!";
            progressBar.Visibility = Visibility.Collapsed;
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!closeWithoutWarning)
            {
                MessageBoxResult mbr = MessageBox.Show("Jeste li sigurni?", "POTVRDA", System.Windows.MessageBoxButton.YesNo);
                if (mbr != MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                }
            }

        }
    }
}
