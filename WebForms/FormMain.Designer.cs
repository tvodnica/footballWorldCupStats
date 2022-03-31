
namespace WebForms
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.comboBox_teams = new System.Windows.Forms.ComboBox();
            this.label_favoriteTeam = new System.Windows.Forms.Label();
            this.button_confirm = new System.Windows.Forms.Button();
            this.bgFormLoad = new System.ComponentModel.BackgroundWorker();
            this.bgWorker_SaveFavTeamGetPlayers = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.flp_FavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_allPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.cms_SendToOtherPanel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.prebaciUDrugiPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajurediSlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izbrišiSlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_showSortedMatches = new System.Windows.Forms.Button();
            this.button_showSortedPlayers = new System.Windows.Forms.Button();
            this.label_favoritePlayers = new System.Windows.Forms.Label();
            this.label_allPlayers = new System.Windows.Forms.Label();
            this.panel_selectPlayers = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.postavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otvoriPostavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cms_SendToOtherPanel.SuspendLayout();
            this.panel_selectPlayers.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_teams
            // 
            this.comboBox_teams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBox_teams, "comboBox_teams");
            this.comboBox_teams.FormattingEnabled = true;
            this.comboBox_teams.Name = "comboBox_teams";
            // 
            // label_favoriteTeam
            // 
            resources.ApplyResources(this.label_favoriteTeam, "label_favoriteTeam");
            this.label_favoriteTeam.Name = "label_favoriteTeam";
            // 
            // button_confirm
            // 
            resources.ApplyResources(this.button_confirm, "button_confirm");
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // bgFormLoad
            // 
            this.bgFormLoad.WorkerReportsProgress = true;
            this.bgFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgFormLoad_DoWork);
            this.bgFormLoad.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgFormLoad_ProgressChanged);
            this.bgFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgFormLoad_RunWorkerCompleted);
            // 
            // bgWorker_SaveFavTeamGetPlayers
            // 
            this.bgWorker_SaveFavTeamGetPlayers.WorkerReportsProgress = true;
            this.bgWorker_SaveFavTeamGetPlayers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_SaveFavTeamGetPlayers_DoWork);
            this.bgWorker_SaveFavTeamGetPlayers.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_SaveFavTeamGetPlayers_ProgressChanged);
            this.bgWorker_SaveFavTeamGetPlayers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_SaveFavTeamGetPlayers_RunWorkerCompleted);
            // 
            // flp_FavoritePlayers
            // 
            this.flp_FavoritePlayers.AllowDrop = true;
            resources.ApplyResources(this.flp_FavoritePlayers, "flp_FavoritePlayers");
            this.flp_FavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flp_FavoritePlayers.Name = "flp_FavoritePlayers";
            this.flp_FavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flp_DragDrop);
            this.flp_FavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flp_DragEnter);
            // 
            // flp_allPlayers
            // 
            this.flp_allPlayers.AllowDrop = true;
            resources.ApplyResources(this.flp_allPlayers, "flp_allPlayers");
            this.flp_allPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flp_allPlayers.Name = "flp_allPlayers";
            this.flp_allPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flp_DragDrop);
            this.flp_allPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flp_DragEnter);
            // 
            // cms_SendToOtherPanel
            // 
            this.cms_SendToOtherPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prebaciUDrugiPanelToolStripMenuItem,
            this.dodajurediSlikuToolStripMenuItem,
            this.izbrišiSlikuToolStripMenuItem});
            this.cms_SendToOtherPanel.Name = "cms_SendToOtherPanel";
            resources.ApplyResources(this.cms_SendToOtherPanel, "cms_SendToOtherPanel");
            // 
            // prebaciUDrugiPanelToolStripMenuItem
            // 
            this.prebaciUDrugiPanelToolStripMenuItem.Name = "prebaciUDrugiPanelToolStripMenuItem";
            resources.ApplyResources(this.prebaciUDrugiPanelToolStripMenuItem, "prebaciUDrugiPanelToolStripMenuItem");
            this.prebaciUDrugiPanelToolStripMenuItem.Click += new System.EventHandler(this.sendToOtherPanel_Click);
            // 
            // dodajurediSlikuToolStripMenuItem
            // 
            this.dodajurediSlikuToolStripMenuItem.Name = "dodajurediSlikuToolStripMenuItem";
            resources.ApplyResources(this.dodajurediSlikuToolStripMenuItem, "dodajurediSlikuToolStripMenuItem");
            this.dodajurediSlikuToolStripMenuItem.Click += new System.EventHandler(this.addEditImage_Click);
            // 
            // izbrišiSlikuToolStripMenuItem
            // 
            this.izbrišiSlikuToolStripMenuItem.Name = "izbrišiSlikuToolStripMenuItem";
            resources.ApplyResources(this.izbrišiSlikuToolStripMenuItem, "izbrišiSlikuToolStripMenuItem");
            this.izbrišiSlikuToolStripMenuItem.Click += new System.EventHandler(this.deleteImage_Click);
            // 
            // button_showSortedMatches
            // 
            resources.ApplyResources(this.button_showSortedMatches, "button_showSortedMatches");
            this.button_showSortedMatches.Name = "button_showSortedMatches";
            this.button_showSortedMatches.UseVisualStyleBackColor = true;
            this.button_showSortedMatches.Click += new System.EventHandler(this.button_showSortedMatches_Click);
            // 
            // button_showSortedPlayers
            // 
            resources.ApplyResources(this.button_showSortedPlayers, "button_showSortedPlayers");
            this.button_showSortedPlayers.Name = "button_showSortedPlayers";
            this.button_showSortedPlayers.UseVisualStyleBackColor = true;
            this.button_showSortedPlayers.Click += new System.EventHandler(this.button_showSortedPlayers_Click);
            // 
            // label_favoritePlayers
            // 
            resources.ApplyResources(this.label_favoritePlayers, "label_favoritePlayers");
            this.label_favoritePlayers.Name = "label_favoritePlayers";
            // 
            // label_allPlayers
            // 
            resources.ApplyResources(this.label_allPlayers, "label_allPlayers");
            this.label_allPlayers.Name = "label_allPlayers";
            // 
            // panel_selectPlayers
            // 
            resources.ApplyResources(this.panel_selectPlayers, "panel_selectPlayers");
            this.panel_selectPlayers.Controls.Add(this.flp_allPlayers);
            this.panel_selectPlayers.Controls.Add(this.label_allPlayers);
            this.panel_selectPlayers.Controls.Add(this.flp_FavoritePlayers);
            this.panel_selectPlayers.Controls.Add(this.label_favoritePlayers);
            this.panel_selectPlayers.Controls.Add(this.button_showSortedPlayers);
            this.panel_selectPlayers.Controls.Add(this.button_showSortedMatches);
            this.panel_selectPlayers.Name = "panel_selectPlayers";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // postavkeToolStripMenuItem
            // 
            this.postavkeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otvoriPostavkeToolStripMenuItem});
            this.postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
            resources.ApplyResources(this.postavkeToolStripMenuItem, "postavkeToolStripMenuItem");
            // 
            // otvoriPostavkeToolStripMenuItem
            // 
            this.otvoriPostavkeToolStripMenuItem.Name = "otvoriPostavkeToolStripMenuItem";
            resources.ApplyResources(this.otvoriPostavkeToolStripMenuItem, "otvoriPostavkeToolStripMenuItem");
            this.otvoriPostavkeToolStripMenuItem.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel_selectPlayers);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.label_favoriteTeam);
            this.Controls.Add(this.comboBox_teams);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.cms_SendToOtherPanel.ResumeLayout(false);
            this.panel_selectPlayers.ResumeLayout(false);
            this.panel_selectPlayers.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_teams;
        private System.Windows.Forms.Label label_favoriteTeam;
        private System.Windows.Forms.Button button_confirm;
        private System.ComponentModel.BackgroundWorker bgFormLoad;
        private System.ComponentModel.BackgroundWorker bgWorker_SaveFavTeamGetPlayers;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel flp_FavoritePlayers;
        private System.Windows.Forms.FlowLayoutPanel flp_allPlayers;
        private System.Windows.Forms.ContextMenuStrip cms_SendToOtherPanel;
        private System.Windows.Forms.ToolStripMenuItem prebaciUDrugiPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajurediSlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izbrišiSlikuToolStripMenuItem;
        private System.Windows.Forms.Button button_showSortedMatches;
        private System.Windows.Forms.Button button_showSortedPlayers;
        private System.Windows.Forms.Label label_favoritePlayers;
        private System.Windows.Forms.Label label_allPlayers;
        private System.Windows.Forms.Panel panel_selectPlayers;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem postavkeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otvoriPostavkeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}