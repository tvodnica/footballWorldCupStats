
namespace WebForms
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.label_cup = new System.Windows.Forms.Label();
            this.radioButton_male = new System.Windows.Forms.RadioButton();
            this.radioButton_female = new System.Windows.Forms.RadioButton();
            this.label_language = new System.Windows.Forms.Label();
            this.groupBox_cup = new System.Windows.Forms.GroupBox();
            this.groupBox_language = new System.Windows.Forms.GroupBox();
            this.radioButton_english = new System.Windows.Forms.RadioButton();
            this.radioButton_croatian = new System.Windows.Forms.RadioButton();
            this.button_confirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_remote = new System.Windows.Forms.RadioButton();
            this.radioButton_local = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_cup.SuspendLayout();
            this.groupBox_language.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_cup
            // 
            resources.ApplyResources(this.label_cup, "label_cup");
            this.label_cup.Name = "label_cup";
            // 
            // radioButton_male
            // 
            resources.ApplyResources(this.radioButton_male, "radioButton_male");
            this.radioButton_male.Name = "radioButton_male";
            this.radioButton_male.UseVisualStyleBackColor = true;
            // 
            // radioButton_female
            // 
            resources.ApplyResources(this.radioButton_female, "radioButton_female");
            this.radioButton_female.Name = "radioButton_female";
            this.radioButton_female.UseVisualStyleBackColor = true;
            // 
            // label_language
            // 
            resources.ApplyResources(this.label_language, "label_language");
            this.label_language.Name = "label_language";
            // 
            // groupBox_cup
            // 
            this.groupBox_cup.Controls.Add(this.radioButton_female);
            this.groupBox_cup.Controls.Add(this.radioButton_male);
            resources.ApplyResources(this.groupBox_cup, "groupBox_cup");
            this.groupBox_cup.Name = "groupBox_cup";
            this.groupBox_cup.TabStop = false;
            // 
            // groupBox_language
            // 
            this.groupBox_language.Controls.Add(this.radioButton_english);
            this.groupBox_language.Controls.Add(this.radioButton_croatian);
            resources.ApplyResources(this.groupBox_language, "groupBox_language");
            this.groupBox_language.Name = "groupBox_language";
            this.groupBox_language.TabStop = false;
            // 
            // radioButton_english
            // 
            resources.ApplyResources(this.radioButton_english, "radioButton_english");
            this.radioButton_english.Name = "radioButton_english";
            this.radioButton_english.UseVisualStyleBackColor = true;
            // 
            // radioButton_croatian
            // 
            resources.ApplyResources(this.radioButton_croatian, "radioButton_croatian");
            this.radioButton_croatian.Name = "radioButton_croatian";
            this.radioButton_croatian.UseVisualStyleBackColor = true;
            // 
            // button_confirm
            // 
            resources.ApplyResources(this.button_confirm, "button_confirm");
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_remote);
            this.groupBox1.Controls.Add(this.radioButton_local);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radioButton_remote
            // 
            resources.ApplyResources(this.radioButton_remote, "radioButton_remote");
            this.radioButton_remote.Name = "radioButton_remote";
            this.radioButton_remote.UseVisualStyleBackColor = true;
            // 
            // radioButton_local
            // 
            resources.ApplyResources(this.radioButton_local, "radioButton_local");
            this.radioButton_local.Name = "radioButton_local";
            this.radioButton_local.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // FormConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.groupBox_language);
            this.Controls.Add(this.groupBox_cup);
            this.Controls.Add(this.label_language);
            this.Controls.Add(this.label_cup);
            this.Name = "FormConfig";
            this.groupBox_cup.ResumeLayout(false);
            this.groupBox_cup.PerformLayout();
            this.groupBox_language.ResumeLayout(false);
            this.groupBox_language.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_cup;
        private System.Windows.Forms.RadioButton radioButton_male;
        private System.Windows.Forms.RadioButton radioButton_female;
        private System.Windows.Forms.Label label_language;
        private System.Windows.Forms.GroupBox groupBox_cup;
        private System.Windows.Forms.GroupBox groupBox_language;
        private System.Windows.Forms.RadioButton radioButton_english;
        private System.Windows.Forms.RadioButton radioButton_croatian;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_remote;
        private System.Windows.Forms.RadioButton radioButton_local;
        private System.Windows.Forms.Label label1;
    }
}

