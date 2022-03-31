
namespace WebForms
{
    partial class FormYesNo
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
            this.label_areYouSure = new System.Windows.Forms.Label();
            this.label_areYouSure2 = new System.Windows.Forms.Label();
            this.button_yes = new System.Windows.Forms.Button();
            this.button_no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_areYouSure
            // 
            this.label_areYouSure.AutoSize = true;
            this.label_areYouSure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_areYouSure.Location = new System.Drawing.Point(67, 61);
            this.label_areYouSure.Name = "label_areYouSure";
            this.label_areYouSure.Size = new System.Drawing.Size(97, 17);
            this.label_areYouSure.TabIndex = 0;
            this.label_areYouSure.Text = "Are you sure?";
            // 
            // label_areYouSure2
            // 
            this.label_areYouSure2.AutoSize = true;
            this.label_areYouSure2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_areYouSure2.Location = new System.Drawing.Point(67, 36);
            this.label_areYouSure2.Name = "label_areYouSure2";
            this.label_areYouSure2.Size = new System.Drawing.Size(106, 17);
            this.label_areYouSure2.TabIndex = 1;
            this.label_areYouSure2.Text = "Jeste li sigurni?";
            // 
            // button_yes
            // 
            this.button_yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button_yes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_yes.Location = new System.Drawing.Point(25, 110);
            this.button_yes.Name = "button_yes";
            this.button_yes.Size = new System.Drawing.Size(85, 33);
            this.button_yes.TabIndex = 2;
            this.button_yes.Text = "Da / Yes";
            this.button_yes.UseVisualStyleBackColor = true;
            // 
            // button_no
            // 
            this.button_no.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_no.Location = new System.Drawing.Point(131, 110);
            this.button_no.Name = "button_no";
            this.button_no.Size = new System.Drawing.Size(85, 33);
            this.button_no.TabIndex = 3;
            this.button_no.Text = "Ne / No";
            this.button_no.UseVisualStyleBackColor = true;
            // 
            // FormYesNo
            // 
            this.AcceptButton = this.button_yes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_no;
            this.ClientSize = new System.Drawing.Size(240, 155);
            this.Controls.Add(this.button_no);
            this.Controls.Add(this.button_yes);
            this.Controls.Add(this.label_areYouSure2);
            this.Controls.Add(this.label_areYouSure);
            this.MaximizeBox = false;
            this.Name = "FormYesNo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormYesNo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_areYouSure;
        private System.Windows.Forms.Label label_areYouSure2;
        private System.Windows.Forms.Button button_yes;
        private System.Windows.Forms.Button button_no;
    }
}