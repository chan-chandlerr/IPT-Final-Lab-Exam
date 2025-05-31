// final-project/Form1.Designer.cs
namespace final_project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls from your original design
        private System.Windows.Forms.TextBox txtPlayer1Name;
        private System.Windows.Forms.ComboBox cmbPlayer1Char;
        private System.Windows.Forms.TextBox txtPlayer2Name;
        private System.Windows.Forms.ComboBox cmbPlayer2Char;
        private System.Windows.Forms.Button btnStartBattle;
        private System.Windows.Forms.ListBox lstBattleLog;
        private System.Windows.Forms.Label lblPlayer1Health; // Will be hidden by default in Form1.cs
        private System.Windows.Forms.Label lblPlayer2Health; // Will be hidden by default in Form1.cs
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Label label1; // Static label for P1 Name input
        private System.Windows.Forms.Label label2; // Static label for P1 Char input
        private System.Windows.Forms.Label label3; // Static label for P2 Name input
        private System.Windows.Forms.Label label4; // Static label for P2 Char input
        private System.Windows.Forms.Label lblP1NameDisplay;
        private System.Windows.Forms.Label lblP2NameDisplay;
        private System.Windows.Forms.ProgressBar pbPlayer1Health; // Will be hidden by default in Form1.cs
        private System.Windows.Forms.ProgressBar pbPlayer2Health; // Will be hidden by default in Form1.cs
        private System.Windows.Forms.Label label5; // Static label "PLAYER 1"
        private System.Windows.Forms.Label label6; // Static label "PLAYER 2"

        // Controls for attack choice UI (listBox1 is your existing control)
        private System.Windows.Forms.ListBox listBox1; // This is used as lstAttackChoices
        private System.Windows.Forms.Label lblAttackDescription;
        private System.Windows.Forms.Button btnExecuteAttack;

        // New controls for graphics rendering and effects
        private System.Windows.Forms.Panel pnlBattleScene;
        private System.Windows.Forms.Timer hitEffectTimer;

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
            this.txtPlayer1Name = new System.Windows.Forms.TextBox();
            this.cmbPlayer1Char = new System.Windows.Forms.ComboBox();
            this.txtPlayer2Name = new System.Windows.Forms.TextBox();
            this.cmbPlayer2Char = new System.Windows.Forms.ComboBox();
            this.btnStartBattle = new System.Windows.Forms.Button();
            this.pnlBattleScene = new System.Windows.Forms.Panel();
            this.lblP1NameDisplay = new System.Windows.Forms.Label();
            this.pbPlayer1Health = new System.Windows.Forms.ProgressBar();
            this.lblPlayer1Health = new System.Windows.Forms.Label();
            this.lblP2NameDisplay = new System.Windows.Forms.Label();
            this.pbPlayer2Health = new System.Windows.Forms.ProgressBar();
            this.lblPlayer2Health = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblAttackDescription = new System.Windows.Forms.Label();
            this.btnExecuteAttack = new System.Windows.Forms.Button();
            this.lstBattleLog = new System.Windows.Forms.ListBox();
            this.lblWinner = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.hitEffectTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtPlayer1Name
            // 
            this.txtPlayer1Name.Location = new System.Drawing.Point(95, 30);
            this.txtPlayer1Name.Margin = new System.Windows.Forms.Padding(2);
            this.txtPlayer1Name.Name = "txtPlayer1Name";
            this.txtPlayer1Name.Size = new System.Drawing.Size(130, 20);
            this.txtPlayer1Name.TabIndex = 0;
            this.txtPlayer1Name.Text = "Player 1";
            // 
            // cmbPlayer1Char
            // 
            this.cmbPlayer1Char.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer1Char.FormattingEnabled = true;
            this.cmbPlayer1Char.Location = new System.Drawing.Point(95, 55);
            this.cmbPlayer1Char.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPlayer1Char.Name = "cmbPlayer1Char";
            this.cmbPlayer1Char.Size = new System.Drawing.Size(130, 21);
            this.cmbPlayer1Char.TabIndex = 1;
            this.cmbPlayer1Char.SelectedIndexChanged += new System.EventHandler(this.cmbPlayer1Char_SelectedIndexChanged);
            // 
            // txtPlayer2Name
            // 
            this.txtPlayer2Name.Location = new System.Drawing.Point(455, 30);
            this.txtPlayer2Name.Margin = new System.Windows.Forms.Padding(2);
            this.txtPlayer2Name.Name = "txtPlayer2Name";
            this.txtPlayer2Name.Size = new System.Drawing.Size(130, 20);
            this.txtPlayer2Name.TabIndex = 2;
            this.txtPlayer2Name.Text = "Player 2";
            // 
            // cmbPlayer2Char
            // 
            this.cmbPlayer2Char.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer2Char.FormattingEnabled = true;
            this.cmbPlayer2Char.Location = new System.Drawing.Point(455, 54);
            this.cmbPlayer2Char.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPlayer2Char.Name = "cmbPlayer2Char";
            this.cmbPlayer2Char.Size = new System.Drawing.Size(130, 21);
            this.cmbPlayer2Char.TabIndex = 3;
            // 
            // btnStartBattle
            // 
            this.btnStartBattle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartBattle.Location = new System.Drawing.Point(240, 10);
            this.btnStartBattle.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartBattle.Name = "btnStartBattle";
            this.btnStartBattle.Size = new System.Drawing.Size(120, 35);
            this.btnStartBattle.TabIndex = 4;
            this.btnStartBattle.Text = "Start Battle!";
            this.btnStartBattle.UseVisualStyleBackColor = true;
            this.btnStartBattle.Click += new System.EventHandler(this.btnStartBattle_Click);
            // 
            // pnlBattleScene
            // 
            this.pnlBattleScene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlBattleScene.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBattleScene.Location = new System.Drawing.Point(15, 74);
            this.pnlBattleScene.Name = "pnlBattleScene";
            this.pnlBattleScene.Size = new System.Drawing.Size(570, 261);
            this.pnlBattleScene.TabIndex = 5;
            this.pnlBattleScene.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBattleScene_Paint);
            // 
            // lblP1NameDisplay
            // 
            this.lblP1NameDisplay.AutoSize = true;
            this.lblP1NameDisplay.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1NameDisplay.Location = new System.Drawing.Point(12, 345);
            this.lblP1NameDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblP1NameDisplay.Name = "lblP1NameDisplay";
            this.lblP1NameDisplay.Size = new System.Drawing.Size(63, 14);
            this.lblP1NameDisplay.TabIndex = 13;
            this.lblP1NameDisplay.Text = "Player 1";
            this.lblP1NameDisplay.Click += new System.EventHandler(this.lblP1NameDisplay_Click);
            // 
            // pbPlayer1Health
            // 
            this.pbPlayer1Health.Location = new System.Drawing.Point(15, 500);
            this.pbPlayer1Health.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer1Health.Name = "pbPlayer1Health";
            this.pbPlayer1Health.Size = new System.Drawing.Size(120, 15);
            this.pbPlayer1Health.TabIndex = 15;
            // 
            // lblPlayer1Health
            // 
            this.lblPlayer1Health.AutoSize = true;
            this.lblPlayer1Health.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1Health.Location = new System.Drawing.Point(15, 520);
            this.lblPlayer1Health.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayer1Health.Name = "lblPlayer1Health";
            this.lblPlayer1Health.Size = new System.Drawing.Size(63, 12);
            this.lblPlayer1Health.TabIndex = 6;
            this.lblPlayer1Health.Text = "P1 Health: 0/0";
            // 
            // lblP2NameDisplay
            // 
            this.lblP2NameDisplay.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2NameDisplay.Location = new System.Drawing.Point(400, 345);
            this.lblP2NameDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblP2NameDisplay.Name = "lblP2NameDisplay";
            this.lblP2NameDisplay.Size = new System.Drawing.Size(185, 14);
            this.lblP2NameDisplay.TabIndex = 14;
            this.lblP2NameDisplay.Text = "Player 2";
            this.lblP2NameDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbPlayer2Health
            // 
            this.pbPlayer2Health.Location = new System.Drawing.Point(465, 500);
            this.pbPlayer2Health.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer2Health.Name = "pbPlayer2Health";
            this.pbPlayer2Health.Size = new System.Drawing.Size(120, 15);
            this.pbPlayer2Health.TabIndex = 16;
            // 
            // lblPlayer2Health
            // 
            this.lblPlayer2Health.AutoSize = true;
            this.lblPlayer2Health.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Health.Location = new System.Drawing.Point(465, 520);
            this.lblPlayer2Health.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayer2Health.Name = "lblPlayer2Health";
            this.lblPlayer2Health.Size = new System.Drawing.Size(63, 12);
            this.lblPlayer2Health.TabIndex = 7;
            this.lblPlayer2Health.Text = "P2 Health: 0/0";
            this.lblPlayer2Health.Click += new System.EventHandler(this.lblPlayer2Health_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 370);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(270, 82);
            this.listBox1.TabIndex = 19;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblAttackDescription
            // 
            this.lblAttackDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblAttackDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAttackDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttackDescription.Location = new System.Drawing.Point(290, 370);
            this.lblAttackDescription.Name = "lblAttackDescription";
            this.lblAttackDescription.Padding = new System.Windows.Forms.Padding(3);
            this.lblAttackDescription.Size = new System.Drawing.Size(170, 82);
            this.lblAttackDescription.TabIndex = 20;
            this.lblAttackDescription.Text = "Attack Details...";
            this.lblAttackDescription.Visible = false;
            // 
            // btnExecuteAttack
            // 
            this.btnExecuteAttack.BackColor = System.Drawing.Color.LightCoral;
            this.btnExecuteAttack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteAttack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteAttack.ForeColor = System.Drawing.Color.White;
            this.btnExecuteAttack.Location = new System.Drawing.Point(465, 370);
            this.btnExecuteAttack.Margin = new System.Windows.Forms.Padding(2);
            this.btnExecuteAttack.Name = "btnExecuteAttack";
            this.btnExecuteAttack.Size = new System.Drawing.Size(120, 82);
            this.btnExecuteAttack.TabIndex = 21;
            this.btnExecuteAttack.Text = "ATTACK!";
            this.btnExecuteAttack.UseVisualStyleBackColor = false;
            this.btnExecuteAttack.Visible = false;
            this.btnExecuteAttack.Click += new System.EventHandler(this.btnExecuteAttack_Click);
            // 
            // lstBattleLog
            // 
            this.lstBattleLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lstBattleLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBattleLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBattleLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lstBattleLog.FormattingEnabled = true;
            this.lstBattleLog.Location = new System.Drawing.Point(15, 460);
            this.lstBattleLog.Margin = new System.Windows.Forms.Padding(2);
            this.lstBattleLog.Name = "lstBattleLog";
            this.lstBattleLog.Size = new System.Drawing.Size(570, 93);
            this.lstBattleLog.TabIndex = 9;
            // 
            // lblWinner
            // 
            this.lblWinner.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.Gold;
            this.lblWinner.Location = new System.Drawing.Point(15, 555);
            this.lblWinner.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(570, 26);
            this.lblWinner.TabIndex = 10;
            this.lblWinner.Text = "Winner: ";
            this.lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "P1 Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "P1 Character:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(372, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "P2 Name:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "P2 Character:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "PLAYER 1";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(515, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "PLAYER 2";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // hitEffectTimer
            // 
            this.hitEffectTimer.Interval = 250;
            this.hitEffectTimer.Tick += new System.EventHandler(this.hitEffectTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(600, 585);
            this.Controls.Add(this.pnlBattleScene);
            this.Controls.Add(this.btnExecuteAttack);
            this.Controls.Add(this.lblAttackDescription);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbPlayer2Health);
            this.Controls.Add(this.pbPlayer1Health);
            this.Controls.Add(this.lblP2NameDisplay);
            this.Controls.Add(this.lblP1NameDisplay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.lblPlayer2Health);
            this.Controls.Add(this.lblPlayer1Health);
            this.Controls.Add(this.lstBattleLog);
            this.Controls.Add(this.btnStartBattle);
            this.Controls.Add(this.cmbPlayer2Char);
            this.Controls.Add(this.txtPlayer2Name);
            this.Controls.Add(this.cmbPlayer1Char);
            this.Controls.Add(this.txtPlayer1Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Straw Hat Champions: Battle Sim!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}