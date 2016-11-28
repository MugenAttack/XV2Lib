namespace IDBEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbList = new System.Windows.Forms.ComboBox();
            this.cbEffect = new System.Windows.Forms.ComboBox();
            this.lstData = new System.Windows.Forms.ListView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnk3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUnk2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnk1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBuy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSell = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRace = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtExtra = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtVal = new System.Windows.Forms.TextBox();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superSoulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.costumeSetEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raceLockEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // cbList
            // 
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(12, 36);
            this.cbList.Name = "cbList";
            this.cbList.Size = new System.Drawing.Size(202, 21);
            this.cbList.TabIndex = 1;
            this.cbList.SelectedIndexChanged += new System.EventHandler(this.cbList_SelectedIndexChanged);
            // 
            // cbEffect
            // 
            this.cbEffect.FormattingEnabled = true;
            this.cbEffect.Items.AddRange(new object[] {
            "Effect 0",
            "Effect 1",
            "Effect 2"});
            this.cbEffect.Location = new System.Drawing.Point(12, 187);
            this.cbEffect.Name = "cbEffect";
            this.cbEffect.Size = new System.Drawing.Size(140, 21);
            this.cbEffect.TabIndex = 2;
            // 
            // lstData
            // 
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstData.Location = new System.Drawing.Point(12, 250);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(467, 212);
            this.lstData.TabIndex = 3;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Tile;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(12, 90);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(53, 20);
            this.txtID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Star";
            // 
            // txtStar
            // 
            this.txtStar.Location = new System.Drawing.Point(71, 90);
            this.txtStar.Name = "txtStar";
            this.txtStar.Size = new System.Drawing.Size(53, 20);
            this.txtStar.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name ID";
            // 
            // txtNa
            // 
            this.txtNa.Location = new System.Drawing.Point(130, 90);
            this.txtNa.Name = "txtNa";
            this.txtNa.Size = new System.Drawing.Size(53, 20);
            this.txtNa.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Info ID";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(189, 90);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(53, 20);
            this.txtInfo.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "3?";
            // 
            // txtUnk3
            // 
            this.txtUnk3.Location = new System.Drawing.Point(426, 90);
            this.txtUnk3.Name = "txtUnk3";
            this.txtUnk3.Size = new System.Drawing.Size(53, 20);
            this.txtUnk3.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "2?";
            // 
            // txtUnk2
            // 
            this.txtUnk2.Location = new System.Drawing.Point(367, 90);
            this.txtUnk2.Name = "txtUnk2";
            this.txtUnk2.Size = new System.Drawing.Size(53, 20);
            this.txtUnk2.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "1?";
            // 
            // txtUnk1
            // 
            this.txtUnk1.Location = new System.Drawing.Point(308, 90);
            this.txtUnk1.Name = "txtUnk1";
            this.txtUnk1.Size = new System.Drawing.Size(53, 20);
            this.txtUnk1.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(250, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Type";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(249, 90);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(53, 20);
            this.txtType.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Zeni Buy Value";
            // 
            // txtBuy
            // 
            this.txtBuy.Location = new System.Drawing.Point(12, 139);
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.Size = new System.Drawing.Size(112, 20);
            this.txtBuy.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(131, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Zeni Sell Value";
            // 
            // txtSell
            // 
            this.txtSell.Location = new System.Drawing.Point(130, 139);
            this.txtSell.Name = "txtSell";
            this.txtSell.Size = new System.Drawing.Size(112, 20);
            this.txtSell.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Race Lock";
            // 
            // txtRace
            // 
            this.txtRace.Location = new System.Drawing.Point(249, 139);
            this.txtRace.Name = "txtRace";
            this.txtRace.Size = new System.Drawing.Size(112, 20);
            this.txtRace.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(368, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "TP Buy Value";
            // 
            // txtTP
            // 
            this.txtTP.Location = new System.Drawing.Point(367, 139);
            this.txtTP.Name = "txtTP";
            this.txtTP.Size = new System.Drawing.Size(112, 20);
            this.txtTP.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(368, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Blast/Model ID";
            // 
            // txtExtra
            // 
            this.txtExtra.Location = new System.Drawing.Point(367, 187);
            this.txtExtra.Name = "txtExtra";
            this.txtExtra.Size = new System.Drawing.Size(112, 20);
            this.txtExtra.TabIndex = 28;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 224);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(290, 20);
            this.txtName.TabIndex = 30;
            // 
            // txtVal
            // 
            this.txtVal.Location = new System.Drawing.Point(308, 224);
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(171, 20);
            this.txtVal.TabIndex = 31;
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raceLockEditorToolStripMenuItem,
            this.superSoulToolStripMenuItem,
            this.costumeSetEditorToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.modeToolStripMenuItem.Text = "Tools";
            // 
            // superSoulToolStripMenuItem
            // 
            this.superSoulToolStripMenuItem.Name = "superSoulToolStripMenuItem";
            this.superSoulToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.superSoulToolStripMenuItem.Text = "Super Soul Editor";
            // 
            // costumeSetEditorToolStripMenuItem
            // 
            this.costumeSetEditorToolStripMenuItem.Name = "costumeSetEditorToolStripMenuItem";
            this.costumeSetEditorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.costumeSetEditorToolStripMenuItem.Text = "Costume Set Editor";
            // 
            // raceLockEditorToolStripMenuItem
            // 
            this.raceLockEditorToolStripMenuItem.Name = "raceLockEditorToolStripMenuItem";
            this.raceLockEditorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.raceLockEditorToolStripMenuItem.Text = "Race Lock Editor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 472);
            this.Controls.Add(this.txtVal);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtExtra);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTP);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRace);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSell);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBuy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUnk3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUnk2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUnk1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.cbEffect);
            this.Controls.Add(this.cbList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "IDB Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbList;
        private System.Windows.Forms.ComboBox cbEffect;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnk3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUnk2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUnk1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBuy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSell;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRace;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtExtra;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtVal;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superSoulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem costumeSetEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raceLockEditorToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

