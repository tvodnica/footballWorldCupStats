
namespace WebForms
{
    partial class FormSortedMatch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSortedMatch));
            this.tableLP_sortMatches = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker_loadMatches = new System.ComponentModel.BackgroundWorker();
            this.label_matchAwayteamFixed = new System.Windows.Forms.Label();
            this.label_matchHomeTeamFixed = new System.Windows.Forms.Label();
            this.label_matchAttendanceFixed = new System.Windows.Forms.Label();
            this.label_matchLocationFixed = new System.Windows.Forms.Label();
            this.button_printMatch = new System.Windows.Forms.Button();
            this.pageSetupDialog_match = new System.Windows.Forms.PageSetupDialog();
            this.printDocument_match = new System.Drawing.Printing.PrintDocument();
            this.printDialog_match = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog_match = new System.Windows.Forms.PrintPreviewDialog();
            this.button_printPreviewMatch = new System.Windows.Forms.Button();
            this.button_printSetupMatch = new System.Windows.Forms.Button();
            this.label_matchNumberFixed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tableLP_sortMatches
            // 
            resources.ApplyResources(this.tableLP_sortMatches, "tableLP_sortMatches");
            this.tableLP_sortMatches.Name = "tableLP_sortMatches";
            // 
            // backgroundWorker_loadMatches
            // 
            this.backgroundWorker_loadMatches.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_loadMatches_DoWork);
            this.backgroundWorker_loadMatches.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_loadMatches_RunWorkerCompleted);
            // 
            // label_matchAwayteamFixed
            // 
            resources.ApplyResources(this.label_matchAwayteamFixed, "label_matchAwayteamFixed");
            this.label_matchAwayteamFixed.Name = "label_matchAwayteamFixed";
            // 
            // label_matchHomeTeamFixed
            // 
            resources.ApplyResources(this.label_matchHomeTeamFixed, "label_matchHomeTeamFixed");
            this.label_matchHomeTeamFixed.Name = "label_matchHomeTeamFixed";
            // 
            // label_matchAttendanceFixed
            // 
            resources.ApplyResources(this.label_matchAttendanceFixed, "label_matchAttendanceFixed");
            this.label_matchAttendanceFixed.BackColor = System.Drawing.Color.LightGray;
            this.label_matchAttendanceFixed.Name = "label_matchAttendanceFixed";
            this.label_matchAttendanceFixed.Click += new System.EventHandler(this.label_matchAttendanceFixed_Click);
            // 
            // label_matchLocationFixed
            // 
            resources.ApplyResources(this.label_matchLocationFixed, "label_matchLocationFixed");
            this.label_matchLocationFixed.Name = "label_matchLocationFixed";
            // 
            // button_printMatch
            // 
            resources.ApplyResources(this.button_printMatch, "button_printMatch");
            this.button_printMatch.Name = "button_printMatch";
            this.button_printMatch.UseVisualStyleBackColor = true;
            this.button_printMatch.Click += new System.EventHandler(this.button_printMatch_Click);
            // 
            // pageSetupDialog_match
            // 
            this.pageSetupDialog_match.Document = this.printDocument_match;
            // 
            // printDocument_match
            // 
            this.printDocument_match.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_match_PrintPage);
            // 
            // printDialog_match
            // 
            this.printDialog_match.Document = this.printDocument_match;
            this.printDialog_match.UseEXDialog = true;
            // 
            // printPreviewDialog_match
            // 
            resources.ApplyResources(this.printPreviewDialog_match, "printPreviewDialog_match");
            this.printPreviewDialog_match.Document = this.printDocument_match;
            this.printPreviewDialog_match.Name = "printPreviewDialog_match";
            this.printPreviewDialog_match.UseAntiAlias = true;
            // 
            // button_printPreviewMatch
            // 
            resources.ApplyResources(this.button_printPreviewMatch, "button_printPreviewMatch");
            this.button_printPreviewMatch.Name = "button_printPreviewMatch";
            this.button_printPreviewMatch.UseVisualStyleBackColor = true;
            this.button_printPreviewMatch.Click += new System.EventHandler(this.button_printPreviewMatch_Click);
            // 
            // button_printSetupMatch
            // 
            resources.ApplyResources(this.button_printSetupMatch, "button_printSetupMatch");
            this.button_printSetupMatch.Name = "button_printSetupMatch";
            this.button_printSetupMatch.UseVisualStyleBackColor = true;
            this.button_printSetupMatch.Click += new System.EventHandler(this.button_printSetupMatch_Click);
            // 
            // label_matchNumberFixed
            // 
            resources.ApplyResources(this.label_matchNumberFixed, "label_matchNumberFixed");
            this.label_matchNumberFixed.Name = "label_matchNumberFixed";
            // 
            // FormSortedMatch
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_matchNumberFixed);
            this.Controls.Add(this.button_printSetupMatch);
            this.Controls.Add(this.button_printPreviewMatch);
            this.Controls.Add(this.button_printMatch);
            this.Controls.Add(this.tableLP_sortMatches);
            this.Controls.Add(this.label_matchAwayteamFixed);
            this.Controls.Add(this.label_matchHomeTeamFixed);
            this.Controls.Add(this.label_matchAttendanceFixed);
            this.Controls.Add(this.label_matchLocationFixed);
            this.Name = "FormSortedMatch";
            this.Load += new System.EventHandler(this.FormSortedMatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLP_sortMatches;
        private System.ComponentModel.BackgroundWorker backgroundWorker_loadMatches;
        private System.Windows.Forms.Label label_matchAwayteamFixed;
        private System.Windows.Forms.Label label_matchHomeTeamFixed;
        private System.Windows.Forms.Label label_matchAttendanceFixed;
        private System.Windows.Forms.Label label_matchLocationFixed;
        private System.Windows.Forms.Button button_printMatch;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog_match;
        private System.Windows.Forms.PrintDialog printDialog_match;
        private System.Drawing.Printing.PrintDocument printDocument_match;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog_match;
        private System.Windows.Forms.Button button_printPreviewMatch;
        private System.Windows.Forms.Button button_printSetupMatch;
        private System.Windows.Forms.Label label_matchNumberFixed;
    }
}