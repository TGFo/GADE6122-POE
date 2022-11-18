namespace Swamp_Game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtField = new System.Windows.Forms.RichTextBox();
            this.txtDisplay = new System.Windows.Forms.RichTextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.BtnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnAttack = new System.Windows.Forms.Button();
            this.listEnemies = new System.Windows.Forms.ListBox();
            this.lblEnemyInfo = new System.Windows.Forms.Label();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.btnSaveGame = new System.Windows.Forms.Button();
            this.btnItem1 = new System.Windows.Forms.Button();
            this.btnItem2 = new System.Windows.Forms.Button();
            this.btnItem3 = new System.Windows.Forms.Button();
            this.lblShop = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtField
            // 
            this.txtField.Font = new System.Drawing.Font("Monospac821 BT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtField.Location = new System.Drawing.Point(26, 21);
            this.txtField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(642, 519);
            this.txtField.TabIndex = 0;
            this.txtField.Text = "";
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(688, 17);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(187, 125);
            this.txtDisplay.TabIndex = 1;
            this.txtDisplay.Text = "";
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(833, 253);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(94, 25);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // BtnUp
            // 
            this.BtnUp.Location = new System.Drawing.Point(833, 177);
            this.BtnUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(94, 25);
            this.BtnUp.TabIndex = 3;
            this.BtnUp.Text = "Up";
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(758, 217);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(94, 25);
            this.btnLeft.TabIndex = 4;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(905, 217);
            this.btnRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(94, 25);
            this.btnRight.TabIndex = 5;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(881, 55);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(77, 23);
            this.btnAttack.TabIndex = 6;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // listEnemies
            // 
            this.listEnemies.FormattingEnabled = true;
            this.listEnemies.ItemHeight = 15;
            this.listEnemies.Location = new System.Drawing.Point(999, 12);
            this.listEnemies.Name = "listEnemies";
            this.listEnemies.Size = new System.Drawing.Size(407, 94);
            this.listEnemies.TabIndex = 7;
            this.listEnemies.SelectedIndexChanged += new System.EventHandler(this.listEnemies_SelectedIndexChanged);
            // 
            // lblEnemyInfo
            // 
            this.lblEnemyInfo.AutoSize = true;
            this.lblEnemyInfo.Location = new System.Drawing.Point(881, 127);
            this.lblEnemyInfo.Name = "lblEnemyInfo";
            this.lblEnemyInfo.Size = new System.Drawing.Size(112, 15);
            this.lblEnemyInfo.TabIndex = 8;
            this.lblEnemyInfo.Text = "                                   ";
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.Location = new System.Drawing.Point(999, 558);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(86, 25);
            this.btnLoadGame.TabIndex = 9;
            this.btnLoadGame.Text = "Load";
            this.btnLoadGame.UseVisualStyleBackColor = true;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Location = new System.Drawing.Point(902, 558);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(91, 25);
            this.btnSaveGame.TabIndex = 10;
            this.btnSaveGame.Text = "Save";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnItem1
            // 
            this.btnItem1.Location = new System.Drawing.Point(1075, 177);
            this.btnItem1.Name = "btnItem1";
            this.btnItem1.Size = new System.Drawing.Size(253, 23);
            this.btnItem1.TabIndex = 11;
            this.btnItem1.Text = "button1";
            this.btnItem1.UseVisualStyleBackColor = true;
            this.btnItem1.Click += new System.EventHandler(this.btnItem1_Click);
            // 
            // btnItem2
            // 
            this.btnItem2.Location = new System.Drawing.Point(1075, 206);
            this.btnItem2.Name = "btnItem2";
            this.btnItem2.Size = new System.Drawing.Size(253, 23);
            this.btnItem2.TabIndex = 12;
            this.btnItem2.Text = "button2";
            this.btnItem2.UseVisualStyleBackColor = true;
            this.btnItem2.Click += new System.EventHandler(this.btnItem2_Click);
            // 
            // btnItem3
            // 
            this.btnItem3.Location = new System.Drawing.Point(1075, 235);
            this.btnItem3.Name = "btnItem3";
            this.btnItem3.Size = new System.Drawing.Size(253, 23);
            this.btnItem3.TabIndex = 13;
            this.btnItem3.Text = "button3";
            this.btnItem3.UseVisualStyleBackColor = true;
            this.btnItem3.Click += new System.EventHandler(this.btnItem3_Click);
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Location = new System.Drawing.Point(1181, 145);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(34, 15);
            this.lblShop.TabIndex = 14;
            this.lblShop.Text = "Shop";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 690);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.btnItem3);
            this.Controls.Add(this.btnItem2);
            this.Controls.Add(this.btnItem1);
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.btnLoadGame);
            this.Controls.Add(this.lblEnemyInfo);
            this.Controls.Add(this.listEnemies);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.BtnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.txtField);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox txtField;
        private RichTextBox txtDisplay;
        private Button btnDown;
        private Button BtnUp;
        private Button btnLeft;
        private Button btnRight;
        private Button btnAttack;
        private ListBox listEnemies;
        private Label lblEnemyInfo;
        private Button btnLoadGame;
        private Button btnSaveGame;
        private Button btnItem1;
        private Button btnItem2;
        private Button btnItem3;
        private Label lblShop;
    }
}