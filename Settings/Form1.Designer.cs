namespace Settings
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMSG = new System.Windows.Forms.TextBox();
            this.btnFMSG = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xenoverse 2 Folder";
            // 
            // txtMSG
            // 
            this.txtMSG.Location = new System.Drawing.Point(15, 25);
            this.txtMSG.Name = "txtMSG";
            this.txtMSG.Size = new System.Drawing.Size(150, 20);
            this.txtMSG.TabIndex = 1;
            this.txtMSG.TextChanged += new System.EventHandler(this.txtMSG_TextChanged);
            // 
            // btnFMSG
            // 
            this.btnFMSG.Location = new System.Drawing.Point(171, 25);
            this.btnFMSG.Name = "btnFMSG";
            this.btnFMSG.Size = new System.Drawing.Size(75, 20);
            this.btnFMSG.TabIndex = 2;
            this.btnFMSG.Text = "Find";
            this.btnFMSG.UseVisualStyleBackColor = true;
            this.btnFMSG.Click += new System.EventHandler(this.btnFMSG_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Language";
            // 
            // cbLang
            // 
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Items.AddRange(new object[] {
            "ca - ",
            "de - German",
            "en - English",
            "es - Spanish",
            "fr - French",
            "it - Italian",
            "pl - Polish",
            "pt - portugueese",
            "ru - Russian"});
            this.cbLang.Location = new System.Drawing.Point(12, 70);
            this.cbLang.Name = "cbLang";
            this.cbLang.Size = new System.Drawing.Size(234, 21);
            this.cbLang.TabIndex = 4;
            this.cbLang.SelectedIndexChanged += new System.EventHandler(this.cbLang_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 128);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbLang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFMSG);
            this.Controls.Add(this.txtMSG);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMSG;
        private System.Windows.Forms.Button btnFMSG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.Button button1;
    }
}

