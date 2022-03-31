
namespace WebForms
{
    partial class FormSortedPlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSortedPlayers));
            this.tableLayoutPanel_sort = new System.Windows.Forms.TableLayoutPanel();
            this.bgWorker_loadPlayers = new System.ComponentModel.BackgroundWorker();
            this.label_yellowCardsFixed = new System.Windows.Forms.Label();
            this.label_goalsFixed = new System.Windows.Forms.Label();
            this.label_playerNameFixed = new System.Windows.Forms.Label();
            this.label_playerImageFixed = new System.Windows.Forms.Label();
            this.button_printSetupMatch = new System.Windows.Forms.Button();
            this.button_printPreviewMatch = new System.Windows.Forms.Button();
            this.button_printMatch = new System.Windows.Forms.Button();
            this.panel_tableContainer = new System.Windows.Forms.Panel();
            this.label_playerNumberFixed = new System.Windows.Forms.Label();
            this.pageSetupDialog_players = new System.Windows.Forms.PageSetupDialog();
            this.printDocument_players = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog_players = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog_players = new System.Windows.Forms.PrintDialog();
            this.panel_tableContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_sort
            // 
            resources.ApplyResources(this.tableLayoutPanel_sort, "tableLayoutPanel_sort");
            this.tableLayoutPanel_sort.Name = "tableLayoutPanel_sort";
            // 
            // bgWorker_loadPlayers
            // 
            this.bgWorker_loadPlayers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_loadPlayers_DoWork);
            this.bgWorker_loadPlayers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_loadPlayers_RunWorkerCompleted);
            // 
            // label_yellowCardsFixed
            // 
            resources.ApplyResources(this.label_yellowCardsFixed, "label_yellowCardsFixed");
            this.label_yellowCardsFixed.Name = "label_yellowCardsFixed";
            this.label_yellowCardsFixed.Click += new System.EventHandler(this.label_yellowCards_Click);
            // 
            // label_goalsFixed
            // 
            resources.ApplyResources(this.label_goalsFixed, "label_goalsFixed");
            this.label_goalsFixed.BackColor = System.Drawing.Color.LightGray;
            this.label_goalsFixed.Name = "label_goalsFixed";
            this.label_goalsFixed.Click += new System.EventHandler(this.label_goales_Click);
            // 
            // label_playerNameFixed
            // 
            resources.ApplyResources(this.label_playerNameFixed, "label_playerNameFixed");
            this.label_playerNameFixed.Name = "label_playerNameFixed";
            // 
            // label_playerImageFixed
            // 
            resources.ApplyResources(this.label_playerImageFixed, "label_playerImageFixed");
            this.label_playerImageFixed.Name = "label_playerImageFixed";
            // 
            // button_printSetupMatch
            // 
            resources.ApplyResources(this.button_printSetupMatch, "button_printSetupMatch");
            this.button_printSetupMatch.Name = "button_printSetupMatch";
            this.button_printSetupMatch.UseVisualStyleBackColor = true;
            this.button_printSetupMatch.Click += new System.EventHandler(this.button_printSetupPlayers_Click);
            // 
            // button_printPreviewMatch
            // 
            resources.ApplyResources(this.button_printPreviewMatch, "button_printPreviewMatch");
            this.button_printPreviewMatch.Name = "button_printPreviewMatch";
            this.button_printPreviewMatch.UseVisualStyleBackColor = true;
            this.button_printPreviewMatch.Click += new System.EventHandler(this.button_printPreviewPlayers_Click);
            // 
            // button_printMatch
            // 
            resources.ApplyResources(this.button_printMatch, "button_printMatch");
            this.button_printMatch.Name = "button_printMatch";
            this.button_printMatch.UseVisualStyleBackColor = true;
            this.button_printMatch.Click += new System.EventHandler(this.button_printPlayers_Click);
            // 
            // panel_tableContainer
            // 
            resources.ApplyResources(this.panel_tableContainer, "panel_tableContainer");
            this.panel_tableContainer.Controls.Add(this.tableLayoutPanel_sort);
            this.panel_tableContainer.Name = "panel_tableContainer";
            // 
            // label_playerNumberFixed
            // 
            resources.ApplyResources(this.label_playerNumberFixed, "label_playerNumberFixed");
            this.label_playerNumberFixed.Name = "label_playerNumberFixed";
            // 
            // pageSetupDialog_players
            // 
            this.pageSetupDialog_players.Document = this.printDocument_players;
            // 
            // printDocument_players
            // 
            this.printDocument_players.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_players_PrintPage);
            // 
            // printPreviewDialog_players
            // 
            resources.ApplyResources(this.printPreviewDialog_players, "printPreviewDialog_players");
            this.printPreviewDialog_players.Document = this.printDocument_players;
            this.printPreviewDialog_players.Name = "printPreviewDialog_match";
            this.printPreviewDialog_players.UseAntiAlias = true;
            // 
            // printDialog_players
            // 
            this.printDialog_players.Document = this.printDocument_players;
            this.printDialog_players.UseEXDialog = true;
            // 
            // FormSortedPlayers
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_playerNumberFixed);
            this.Controls.Add(this.panel_tableContainer);
            this.Controls.Add(this.button_printSetupMatch);
            this.Controls.Add(this.button_printPreviewMatch);
            this.Controls.Add(this.button_printMatch);
            this.Controls.Add(this.label_yellowCardsFixed);
            this.Controls.Add(this.label_goalsFixed);
            this.Controls.Add(this.label_playerNameFixed);
            this.Controls.Add(this.label_playerImageFixed);
            this.Name = "FormSortedPlayers";
            this.Load += new System.EventHandler(this.FormSortedPlayers_Load);
            this.panel_tableContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_sort;
        private System.ComponentModel.BackgroundWorker bgWorker_loadPlayers;
        private System.Windows.Forms.Label label_yellowCardsFixed;
        private System.Windows.Forms.Label label_goalsFixed;
        private System.Windows.Forms.Label label_playerNameFixed;
        private System.Windows.Forms.Label label_playerImageFixed;
        private System.Windows.Forms.Button button_printSetupMatch;
        private System.Windows.Forms.Button button_printPreviewMatch;
        private System.Windows.Forms.Button button_printMatch;
        private System.Windows.Forms.Panel panel_tableContainer;
        private System.Windows.Forms.Label label_playerNumberFixed;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog_players;
        private System.Drawing.Printing.PrintDocument printDocument_players;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog_players;
        private System.Windows.Forms.PrintDialog printDialog_players;
    }
}