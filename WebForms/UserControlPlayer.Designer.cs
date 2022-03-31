
namespace WebForms
{
    partial class UserControlPlayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_name = new System.Windows.Forms.Label();
            this.label_position = new System.Windows.Forms.Label();
            this.label_captain = new System.Windows.Forms.Label();
            this.label_shirtNumber = new System.Windows.Forms.Label();
            this.pictureBox_favStar = new System.Windows.Forms.PictureBox();
            this.pictureBox_player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_favStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player)).BeginInit();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(75, 3);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(30, 17);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Ime";
            // 
            // label_position
            // 
            this.label_position.AutoSize = true;
            this.label_position.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_position.Location = new System.Drawing.Point(75, 42);
            this.label_position.Name = "label_position";
            this.label_position.Size = new System.Drawing.Size(56, 17);
            this.label_position.TabIndex = 1;
            this.label_position.Text = "Pozicija";
            // 
            // label_captain
            // 
            this.label_captain.AutoSize = true;
            this.label_captain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_captain.Location = new System.Drawing.Point(99, 24);
            this.label_captain.Name = "label_captain";
            this.label_captain.Size = new System.Drawing.Size(17, 17);
            this.label_captain.TabIndex = 2;
            this.label_captain.Text = "C";
            // 
            // label_shirtNumber
            // 
            this.label_shirtNumber.AutoSize = true;
            this.label_shirtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_shirtNumber.Location = new System.Drawing.Point(75, 24);
            this.label_shirtNumber.Name = "label_shirtNumber";
            this.label_shirtNumber.Size = new System.Drawing.Size(24, 17);
            this.label_shirtNumber.TabIndex = 3;
            this.label_shirtNumber.Text = "99";
            // 
            // pictureBox_favStar
            // 
            this.pictureBox_favStar.Image = global::WebForms.Properties.Resources._252px_Black_bordered_yellow_star_svg;
            this.pictureBox_favStar.Location = new System.Drawing.Point(76, 61);
            this.pictureBox_favStar.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_favStar.Name = "pictureBox_favStar";
            this.pictureBox_favStar.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_favStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_favStar.TabIndex = 4;
            this.pictureBox_favStar.TabStop = false;
            // 
            // pictureBox_player
            // 
            this.pictureBox_player.Image = global::WebForms.Properties.Resources.playerImage;
            this.pictureBox_player.InitialImage = global::WebForms.Properties.Resources.playerImage;
            this.pictureBox_player.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_player.Name = "pictureBox_player";
            this.pictureBox_player.Size = new System.Drawing.Size(66, 83);
            this.pictureBox_player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_player.TabIndex = 5;
            this.pictureBox_player.TabStop = false;
            // 
            // UserControlPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox_player);
            this.Controls.Add(this.pictureBox_favStar);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_shirtNumber);
            this.Controls.Add(this.label_captain);
            this.Controls.Add(this.label_position);
            this.Name = "UserControlPlayer";
            this.Size = new System.Drawing.Size(243, 89);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_favStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label_name;
        public System.Windows.Forms.Label label_shirtNumber;
        public System.Windows.Forms.Label label_position;
        public System.Windows.Forms.Label label_captain;
        public System.Windows.Forms.PictureBox pictureBox_favStar;
        public System.Windows.Forms.PictureBox pictureBox_player;
    }
}
