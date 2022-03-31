using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WebForms.Properties;

namespace WebForms
{
    public partial class FormSortedPlayers : Form
    {
        public FormSortedPlayers()
        {
            Data.GetData.GetCulture();
            InitializeComponent();
        }

        private List<Data.Player> players = new List<Player>();

        private const string Goals = "goals";
        private const string YellowCards = "yellowCards";


        //----------------- ON LOAD ------------------
        private void FormSortedPlayers_Load(object sender, EventArgs e)
        {
            bgWorker_loadPlayers.RunWorkerAsync();
        }
        private void bgWorker_loadPlayers_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadPlayers();
        }
        private void bgWorker_loadPlayers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowPlayers(Goals);
        }

        
        //----------------- LOADING, SORTING AND SHOWING PLAYERS ------------------
        private void LoadPlayers()
        {           
            try
            {
                players = Data.GetData.GetPlayersOfFavoriteTeam();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return;
            }
        }
        private void ShowPlayers(string sortBy)
        {
            tableLayoutPanel_sort.Controls.Clear();

            //-- SORT --
            if (sortBy == Goals)
            {
                players.Sort((x, y) => -x.Goals.CompareTo(y.Goals));
            }
            else if (sortBy == YellowCards)
            {
                players.Sort((x, y) => -x.YellowCards.CompareTo(y.YellowCards));
            }

            //-- ADD --
            for (int i = 0; i < players.Count; i++)
            {
                tableLayoutPanel_sort.RowCount += 1;
                if (tableLayoutPanel_sort.Height + 40 <= panel_tableContainer.Height)
                {
                    tableLayoutPanel_sort.Height += 40;
                }

                PictureBox pb_image = new PictureBox();
                pb_image.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_image.Width = 30;
                pb_image.Image =
                    !(players[i].Image == "") ?
                    Image.FromFile(players[i].Image) :
                    Resources.playerImage;

                Label label_number = new Label();
                label_number.Text = (i + 1).ToString() + ".";
                label_number.Anchor = AnchorStyles.Left;

                Label label_name = new Label();
                label_name.Text = players[i].Name;
                label_name.Anchor = AnchorStyles.Left;
                label_name.AutoSize = true;

                Label label_goals = new Label();
                label_goals.Text = players[i].Goals.ToString();
                label_goals.Anchor = AnchorStyles.Left;

                Label label_yellowCards = new Label();
                label_yellowCards.Text = players[i].YellowCards.ToString();
                label_yellowCards.Anchor = AnchorStyles.Left;

                tableLayoutPanel_sort.Controls.Add(label_number, 0, i);
                tableLayoutPanel_sort.Controls.Add(pb_image, 1, i);
                tableLayoutPanel_sort.Controls.Add(label_name, 2, i);
                tableLayoutPanel_sort.Controls.Add(label_goals, 3, i);
                tableLayoutPanel_sort.Controls.Add(label_yellowCards, 4, i);
            }
        }
        private void label_goales_Click(object sender, EventArgs e)
        {
            ShowPlayers(Goals);
            label_goalsFixed.BackColor = Color.LightGray;
            label_yellowCardsFixed.BackColor = Color.Transparent;
        }
        private void label_yellowCards_Click(object sender, EventArgs e)
        {
            ShowPlayers(YellowCards);
            label_goalsFixed.BackColor = Color.Transparent;
            label_yellowCardsFixed.BackColor = Color.LightGray;
        }



        //----------------- PRINTING ------------------
        private void button_printSetupPlayers_Click(object sender, EventArgs e)
        {
            pageSetupDialog_players.ShowDialog();
        }
        private void button_printPreviewPlayers_Click(object sender, EventArgs e)
        {
            printPreviewDialog_players.ShowDialog();
        }
        private void button_printPlayers_Click(object sender, EventArgs e)
        {
            if (printDialog_players.ShowDialog() == DialogResult.OK)
            {
                printDocument_players.DocumentName = "Players details";
                printDocument_players.Print();
            }
        }
        private void printDocument_players_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            Bitmap memoryImage = new Bitmap(s.Width - 20, s.Height - 100, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X + 10, this.Location.Y, 0, 0, s);
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

    }
}
