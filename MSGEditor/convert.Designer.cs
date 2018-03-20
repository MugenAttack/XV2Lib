namespace MSGEditor
{
    partial class convert
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
            this.cbType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "0",
            "256",
            "512"});
            this.cbType.Location = new System.Drawing.Point(72, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(120, 21);
            this.cbType.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load and Start Conversion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // convert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 78);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbType);
            this.Name = "convert";
            this.Text = "Convert";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button button1;
    }
}