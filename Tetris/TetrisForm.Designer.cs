using System;
using System.Windows.Forms;

namespace Tetris
{
    partial class TetrisForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.panelGame = new System.Windows.Forms.Panel();
            this.labelGameOver = new System.Windows.Forms.Label();
            this.buttonRestartGame = new System.Windows.Forms.Button();
            this.lableScore = new System.Windows.Forms.Label();
            this.labelHighscore = new System.Windows.Forms.Label();
            this.labelLogInfo = new System.Windows.Forms.Label();
            this.textBoxLoginInfo = new System.Windows.Forms.TextBox();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.textBoxHighscore = new System.Windows.Forms.TextBox();
            this.panelGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1500;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // panelGame
            // 
            this.panelGame.Controls.Add(this.labelGameOver);
            this.panelGame.Location = new System.Drawing.Point(234, 12);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(400, 880);
            this.panelGame.TabIndex = 0;
            // 
            // labelGameOver
            // 
            this.labelGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameOver.Location = new System.Drawing.Point(48, 93);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(293, 65);
            this.labelGameOver.TabIndex = 9;
            this.labelGameOver.Text = "Game Over";
            this.labelGameOver.Visible = false;
            // 
            // buttonRestartGame
            // 
            this.buttonRestartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestartGame.Location = new System.Drawing.Point(59, 673);
            this.buttonRestartGame.Name = "buttonRestartGame";
            this.buttonRestartGame.Size = new System.Drawing.Size(126, 65);
            this.buttonRestartGame.TabIndex = 1;
            this.buttonRestartGame.Text = "Start Game";
            this.buttonRestartGame.UseVisualStyleBackColor = true;
            this.buttonRestartGame.Click += new System.EventHandler(this.buttonRestartGame_Click);
            // 
            // lableScore
            // 
            this.lableScore.AutoSize = true;
            this.lableScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableScore.Location = new System.Drawing.Point(1200, 105);
            this.lableScore.Name = "lableScore";
            this.lableScore.Size = new System.Drawing.Size(51, 20);
            this.lableScore.TabIndex = 2;
            this.lableScore.Text = "Score";
            // 
            // labelHighscore
            // 
            this.labelHighscore.AutoSize = true;
            this.labelHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHighscore.Location = new System.Drawing.Point(1182, 281);
            this.labelHighscore.Name = "labelHighscore";
            this.labelHighscore.Size = new System.Drawing.Size(81, 20);
            this.labelHighscore.TabIndex = 3;
            this.labelHighscore.Text = "Highscore";
            // 
            // labelLogInfo
            // 
            this.labelLogInfo.AutoSize = true;
            this.labelLogInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogInfo.Location = new System.Drawing.Point(56, 119);
            this.labelLogInfo.Name = "labelLogInfo";
            this.labelLogInfo.Size = new System.Drawing.Size(131, 20);
            this.labelLogInfo.TabIndex = 4;
            this.labelLogInfo.Text = "Angemeldet als : ";
            // 
            // textBoxLoginInfo
            // 
            this.textBoxLoginInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLoginInfo.Location = new System.Drawing.Point(59, 142);
            this.textBoxLoginInfo.Name = "textBoxLoginInfo";
            this.textBoxLoginInfo.ReadOnly = true;
            this.textBoxLoginInfo.Size = new System.Drawing.Size(100, 26);
            this.textBoxLoginInfo.TabIndex = 5;
            this.textBoxLoginInfo.Text = "Test";
            // 
            // textBoxScore
            // 
            this.textBoxScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxScore.Location = new System.Drawing.Point(1174, 135);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.ReadOnly = true;
            this.textBoxScore.Size = new System.Drawing.Size(100, 26);
            this.textBoxScore.TabIndex = 6;
            this.textBoxScore.Text = "0";
            // 
            // textBoxHighscore
            // 
            this.textBoxHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHighscore.Location = new System.Drawing.Point(1174, 316);
            this.textBoxHighscore.Name = "textBoxHighscore";
            this.textBoxHighscore.ReadOnly = true;
            this.textBoxHighscore.Size = new System.Drawing.Size(100, 26);
            this.textBoxHighscore.TabIndex = 7;
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 796);
            this.Controls.Add(this.textBoxHighscore);
            this.Controls.Add(this.textBoxScore);
            this.Controls.Add(this.textBoxLoginInfo);
            this.Controls.Add(this.labelLogInfo);
            this.Controls.Add(this.labelHighscore);
            this.Controls.Add(this.lableScore);
            this.Controls.Add(this.buttonRestartGame);
            this.Controls.Add(this.panelGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TetrisForm";
            this.Text = "Tetris";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TetrisForm_FormClosed);
            this.Load += new System.EventHandler(this.TetrisForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisForm_KeyDown);
            this.panelGame.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Panel panelGame;
        private Button buttonRestartGame;
        private Label lableScore;
        private Label labelHighscore;
        private Label labelLogInfo;
        private TextBox textBoxLoginInfo;
        private TextBox textBoxScore;
        private TextBox textBoxHighscore;
        private Label labelGameOver;
    }
}

