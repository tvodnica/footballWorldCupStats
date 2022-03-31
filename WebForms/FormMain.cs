using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WebForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            Thread.CurrentThread.CurrentUICulture = Data.GetData.GetCulture();
            InitializeComponent();
        }

        private const string EN = "en";
        private const string HR = "hr";

        private int selectedPlayersCount = 0;
        private int addedPlayersCount = 0;

        private List<Data.Team> teams = new List<Data.Team>();

        private List<Data.Player> originalPlayers = new List<Data.Player>();
        private List<Data.Player> favPlayers = new List<Data.Player>();

        private List<UserControlPlayer> selectedPlayers = new List<UserControlPlayer>();
        private List<UserControlPlayer> selectedPlayersCopy = new List<UserControlPlayer>();

        private UserControlPlayer playerDoingDnd = new UserControlPlayer();


        //----------------- ON FORM LOAD ---------------------- 
        private void FormMain_Load(object sender, EventArgs e)
        {
            SetStatusLoading();
            DisableButtons();
            bgFormLoad.RunWorkerAsync();

        }
        private void bgFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            bgFormLoad.ReportProgress(20);
            LoadTeams();
            bgFormLoad.ReportProgress(60);
            LoadPlayers();
            bgFormLoad.ReportProgress(80);

        }
        private void bgFormLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }
        private void bgFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ClearForm();
            AddTeamsIntoDDL();
            AddPlayers();
            LoadFavPlayers();

            foreach (var favPlayer in favPlayers)
            {
                foreach (UserControlPlayer player in flp_allPlayers.Controls)
                {
                    if (player.label_name.Text == favPlayer.Name)
                    {
                        if (favPlayer.Image != "")
                        {
                            player.pictureBox_player.Image = Image.FromFile(favPlayer.Image);
                        }
                        selectedPlayers.Add(player);
                    }
                }
            }
            SendPlayersToOtherPanel();
            favPlayers.Clear();

            EnableButtons();
            SetStatusOk();
        }


        //---------------- SAVE FAVORITE TEAM FILE AND GET PLAYERS FOR IT ---------------------------
        private void button_confirm_Click(object sender, EventArgs e)
        {
            bgWorker_SaveFavTeamGetPlayers.RunWorkerAsync(comboBox_teams.SelectedItem);
            DisableButtons();
            SetStatusLoading();
        }
        private void bgWorker_SaveFavTeamGetPlayers_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWorker_SaveFavTeamGetPlayers.ReportProgress(20);
            //SAVE FILE
            SaveFavTeam(e.Argument);

            bgWorker_SaveFavTeamGetPlayers.ReportProgress(70);

            //GET PLAYERS
            LoadPlayers();
            bgWorker_SaveFavTeamGetPlayers.ReportProgress(100);

        }
        private void bgWorker_SaveFavTeamGetPlayers_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }
        private void bgWorker_SaveFavTeamGetPlayers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel_selectPlayers.Enabled = true;

            flp_allPlayers.Controls.Clear();
            flp_FavoritePlayers.Controls.Clear();
            selectedPlayersCount = 0;
            addedPlayersCount = 0;

            AddPlayers();
            EnableButtons();
            SetStatusOk();
        }


        //------------ LOADERS ------------
        private void LoadTeams()
        {
            try
            {
                teams = Data.GetData.GetAllTeams();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void LoadPlayers()
        {
            try
            {
                if (!Data.Files.FavTeamFileExists())
                {
                    Data.Files.SaveFavTeamFile(teams[0].Id, teams[0].FifaCode);
                }
                originalPlayers = Data.GetData.GetPlayersOfFavoriteTeam();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return;
            }

        }
        private void LoadFavPlayers()
        {
            try
            {
                if (Data.Files.FavPlayersExists())
                {
                    favPlayers = Data.Files.LoadFavPlayersFile();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        private void AddTeamsIntoDDL()
        {
            int selectedTeamId = 0;

            if (Data.Files.FavTeamFileExists())
            {
                {
                    try
                    {
                        selectedTeamId = int.Parse(Data.Files.LoadFavTeamFile()[0]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR");
                    }
                }
            };
            foreach (var team in teams)
            {
                comboBox_teams.Items.Add(team);
                if (team.Id == selectedTeamId)
                {
                    comboBox_teams.SelectedItem = team;
                }
            }
            if (!Data.Files.FavTeamFileExists())
            {
                comboBox_teams.SelectedIndex = 0;
            }
        }
        private void AddPlayers()
        {
            foreach (var player in originalPlayers)
            {
                UserControlPlayer ucp = new UserControlPlayer();

                ucp.label_name.Text = player.Name;
                ucp.label_position.Text = player.Position.ToString();
                ucp.label_shirtNumber.Text = player.ShirtNumber.ToString();
                ucp.label_captain.Text = player.Captain ? "C" : "";
                if (player.Image != "")
                {
                    ucp.pictureBox_player.Image = Image.FromFile(player.Image);
                }


                ucp.label_captain.BackColor = Color.Red;

                ucp.ContextMenuStrip = cms_SendToOtherPanel;

                ucp.MouseDown += Ucp_MouseDown;
                ucp.MouseDoubleClick += Ucp_MouseDoubleClick;

                flp_allPlayers.Controls.Add(ucp);
            }
        }


        //------------ SAVE FILES ------------
        private void SaveFavTeam(object argument)
        {
            Data.Team team = (Data.Team)argument;
            try
            {
                Data.Files.SaveFavTeamFile(team.Id, team.FifaCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return;
            }
        }
        private void SaveFavPlayers()
        {
            foreach (UserControlPlayer ucp in flp_FavoritePlayers.Controls)
            {
                Data.Player favPlayer = new Data.Player();
                favPlayer.Name = ucp.label_name.Text;
                favPlayer.ShirtNumber = int.Parse(ucp.label_shirtNumber.Text);
                favPlayer.Position = ucp.label_position.Text;
                favPlayer.Captain = ucp.label_name.Text == "" ? false : true;

                foreach (var player in originalPlayers)
                {
                    if (player.Name == favPlayer.Name)
                    {
                        favPlayer.Image = player.Image;
                    }
                }

                favPlayers.Add(favPlayer);
            }
            Data.Files.SaveFavPlayersFile(favPlayers);
        }


        //------------------ DRAG AND DROP -----------------------
        private void Ucp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                UserControlPlayer ucp = (UserControlPlayer)sender;
                ucp.DoDragDrop(selectedPlayers, DragDropEffects.Move);
                playerDoingDnd = ucp;
            }
        }
        private void flp_DragEnter(object sender, DragEventArgs e)
        {
            if (playerDoingDnd.Parent == sender)
            {
                e.Effect = DragDropEffects.None;
            }
            else e.Effect = DragDropEffects.Move;

        }
        private void flp_DragDrop(object sender, DragEventArgs e)
        {
            SendPlayersToOtherPanel();
        }


        //-------------- SELECT AND SEND PLAYERS ------------------
        private void Ucp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var clickedPlayer = (UserControlPlayer)sender;

            if (e.Button == MouseButtons.Left)
            {
                if (clickedPlayer.BackColor == Color.Lime)
                {
                    clickedPlayer.BackColor = Color.Transparent;
                    selectedPlayers.Remove(clickedPlayer);
                    selectedPlayersCount--;
                }
                else
                {
                    clickedPlayer.BackColor = Color.Lime;
                    selectedPlayers.Add(clickedPlayer);
                    selectedPlayersCount++;
                }
            }
        }
        private void sendToOtherPanel_Click(object sender, EventArgs e)
        {
            SendPlayersToOtherPanel();
        }
        private void SendPlayersToOtherPanel()
        {
            foreach (var player in selectedPlayers)
            {
                player.BackColor = Color.Transparent;
                selectedPlayersCount = 0;

                if (!flp_FavoritePlayers.Controls.Contains(player))
                {
                    if (addedPlayersCount >= 3)
                    {
                        MessageBox.Show("Maksimalni broj omiljenih igrača je 3", "Greška");
                        selectedPlayers.Clear();

                        return;
                    }
                    player.pictureBox_favStar.Visible = true;
                    flp_FavoritePlayers.Controls.Add(player);
                    addedPlayersCount++;
                    selectedPlayersCopy.Add(player);
                }
                else
                {
                    flp_allPlayers.Controls.Add(player);
                    player.pictureBox_favStar.Visible = false;
                    addedPlayersCount--;
                    selectedPlayersCopy.Add(player);
                }
            }

            foreach (var item in selectedPlayersCopy)
            {
                selectedPlayers.Remove(item);
            }
        }


        //------------------ ADD, DELETE OR EDIT PLAYER IMAGE --------------------
        private void addEditImage_Click(object sender, EventArgs e)
        {
            string selectedPicture;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Odabir slike";
            ofd.Filter = "Slike (.png, .jpeg, .jpg)|*.png; *.jpeg; *.jpg|All files| *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedPicture = ofd.FileName;
                foreach (var selectedPlayer in selectedPlayers)
                {
                    selectedPlayer.pictureBox_player.Image = Image.FromFile(selectedPicture);
                    Data.Files.SavePlayersImages(selectedPlayer.label_name.Text, selectedPicture);
                }
            }
        }
        private void deleteImage_Click(object sender, EventArgs e)
        {
            foreach (var player in selectedPlayers)
            {
                player.pictureBox_player.Image = player.pictureBox_player.InitialImage;
                Data.Files.SavePlayersImages(player.label_name.Text, string.Empty);
            }
        }


        //------------------ SHOW SORTED PLAYER FORM --------------------
        private void button_showSortedPlayers_Click(object sender, EventArgs e)
        {
            FormSortedPlayers formSortedPlayers = new FormSortedPlayers();
            formSortedPlayers.ShowDialog();
        }
        private void button_showSortedMatches_Click(object sender, EventArgs e)
        {
            FormSortedMatch formSortedMatch = new FormSortedMatch();
            formSortedMatch.ShowDialog();
        }


        //------------------ DO STUFF --------------------
        private void button_settings_Click(object sender, EventArgs e)
        {
            FormConfig form = new FormConfig();
            form.ShowDialog();
            FormMain fm = new FormMain();
            fm.Show();
            this.Hide();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormYesNo fyn = new FormYesNo();
            if (fyn.ShowDialog() == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                SaveFavPlayers();
                foreach (Form form in Application.OpenForms)
                {
                    form.Dispose();
                }
            }
        }
        private void ClearForm()
        {
            comboBox_teams.Items.Clear();
            flp_allPlayers.Controls.Clear();
            flp_FavoritePlayers.Controls.Clear();
            selectedPlayersCount = 0;
            addedPlayersCount = 0;
            selectedPlayers.Clear();
        }
        private void SetStatusLoading()
        {
            if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == HR) toolStripStatusLabel1.Text = "Učitavam, molim pričekajte...";
            else if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == EN) toolStripStatusLabel1.Text = "Loading, please wait...";
        }
        private void SetStatusOk()
        {
            if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == HR) toolStripStatusLabel1.Text = "Sve ok!";
            else if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == EN) toolStripStatusLabel1.Text = "All good!";
            toolStripProgressBar1.Visible = false;
        }
        private void DisableButtons()
        {
            button_confirm.Enabled = false;
            button_showSortedMatches.Enabled = false;
            button_showSortedPlayers.Enabled = false;
        }
        private void EnableButtons()
        {
            button_confirm.Enabled = true;
            button_showSortedMatches.Enabled = true;
            button_showSortedPlayers.Enabled = true;
        }
    }
}