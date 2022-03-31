using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WebForms
{
    public partial class FormSortedMatch : Form
    {
        public FormSortedMatch()
        {
            Data.GetData.GetCulture();
            InitializeComponent();
        }

        private List<Data.Match> matches = new List<Data.Match>();
        private bool sortByAttendance = true;


        //----------------- LOADING ------------------
        private void FormSortedMatch_Load(object sender, EventArgs e)
        {
            backgroundWorker_loadMatches.RunWorkerAsync();
        }
        private void backgroundWorker_loadMatches_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadMatches();
        }
        private void backgroundWorker_loadMatches_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowMatches();
        }



        //----------------- DOING STUFF ------------------
        private void label_matchAttendanceFixed_Click(object sender, EventArgs e)
        {
            sortByAttendance = !sortByAttendance;
            ShowMatches();
        }
        private void LoadMatches()
        {
            try
            {
                matches = Data.GetData.GetMatchesOfFavoriteTeam();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void ShowMatches()
        {
            SortMatches();
            tableLP_sortMatches.Controls.Clear();

            for (int i = 0; i < matches.Count; i++)
            {
                Label label_number = new Label();
                label_number.Text = (i + 1).ToString() + ".";

                Label label_location = new Label();
                label_location.Text = matches[i].Location;

                Label label_attendance = new Label();
                label_attendance.Text = matches[i].Attendance.ToString();

                Label label_homeTeam = new Label();
                label_homeTeam.Text = matches[i].HomeTeam.Country;

                Label label_awayTeam = new Label();
                label_awayTeam.Text = matches[i].AwayTeam.Country;

                tableLP_sortMatches.Controls.Add(label_number, 0, i);
                tableLP_sortMatches.Controls.Add(label_location, 1, i);
                tableLP_sortMatches.Controls.Add(label_attendance, 2, i);
                tableLP_sortMatches.Controls.Add(label_homeTeam, 3, i);
                tableLP_sortMatches.Controls.Add(label_awayTeam, 4, i);
            }

        }
        private void SortMatches()
        {
            if (sortByAttendance)
            {
                matches.Sort((x, y) => -(x.Attendance).CompareTo(y.Attendance));
            }
            else if (!sortByAttendance)
            {
                matches.Sort((x, y) => (x.Attendance).CompareTo(y.Attendance));
            }
            else
            {
                return;
            }
        }



        //----------------- PRINTING ------------------
        private void button_printSetupMatch_Click(object sender, EventArgs e)
        {
            pageSetupDialog_match.ShowDialog();
        }
        private void button_printPreviewMatch_Click(object sender, EventArgs e)
        {
            printPreviewDialog_match.ShowDialog();
        }
        private void button_printMatch_Click(object sender, EventArgs e)
        {
            if (printDialog_match.ShowDialog() == DialogResult.OK)
            {
                printDocument_match.DocumentName = "Match details";
                printDocument_match.Print();
            }
        }

        private void printDocument_match_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
