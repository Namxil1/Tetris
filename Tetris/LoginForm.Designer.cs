namespace Tetris
{
    partial class LoginForm
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
            this.textBoxBenutzername = new System.Windows.Forms.TextBox();
            this.textBoxPasswort = new System.Windows.Forms.TextBox();
            this.buttonAnmelden = new System.Windows.Forms.Button();
            this.Benutzer_Anlegen = new System.Windows.Forms.Button();
            this.labelBenutzername = new System.Windows.Forms.Label();
            this.labelPasswort = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // textBoxBenutzername
            // 
            this.textBoxBenutzername.Location = new System.Drawing.Point(12, 39);
            this.textBoxBenutzername.Name = "textBoxBenutzername";
            this.textBoxBenutzername.Size = new System.Drawing.Size(253, 20);
            this.textBoxBenutzername.TabIndex = 0;
            // 
            // textBoxPasswort
            // 
            this.textBoxPasswort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxPasswort.Location = new System.Drawing.Point(11, 78);
            this.textBoxPasswort.Name = "textBoxPasswort";
            this.textBoxPasswort.Size = new System.Drawing.Size(253, 20);
            this.textBoxPasswort.TabIndex = 1;
            this.textBoxPasswort.UseSystemPasswordChar = true;
            // 
            // buttonAnmelden
            // 
            this.buttonAnmelden.Location = new System.Drawing.Point(27, 119);
            this.buttonAnmelden.Name = "buttonAnmelden";
            this.buttonAnmelden.Size = new System.Drawing.Size(75, 23);
            this.buttonAnmelden.TabIndex = 2;
            this.buttonAnmelden.Text = "Anmelden";
            this.buttonAnmelden.UseVisualStyleBackColor = true;
            this.buttonAnmelden.Click += new System.EventHandler(this.buttonAnmelden_Click);
            // 
            // Benutzer_Anlegen
            // 
            this.Benutzer_Anlegen.Location = new System.Drawing.Point(138, 119);
            this.Benutzer_Anlegen.Name = "Benutzer_Anlegen";
            this.Benutzer_Anlegen.Size = new System.Drawing.Size(109, 23);
            this.Benutzer_Anlegen.TabIndex = 3;
            this.Benutzer_Anlegen.Text = "Registrieren";
            this.Benutzer_Anlegen.UseVisualStyleBackColor = true;
            this.Benutzer_Anlegen.Click += new System.EventHandler(this.BenutzerRegistrieren_Click);
            // 
            // labelBenutzername
            // 
            this.labelBenutzername.AutoSize = true;
            this.labelBenutzername.Location = new System.Drawing.Point(13, 20);
            this.labelBenutzername.Name = "labelBenutzername";
            this.labelBenutzername.Size = new System.Drawing.Size(75, 13);
            this.labelBenutzername.TabIndex = 4;
            this.labelBenutzername.Text = "Benutzername";
            // 
            // labelPasswort
            // 
            this.labelPasswort.AutoSize = true;
            this.labelPasswort.Location = new System.Drawing.Point(12, 62);
            this.labelPasswort.Name = "labelPasswort";
            this.labelPasswort.Size = new System.Drawing.Size(50, 13);
            this.labelPasswort.TabIndex = 5;
            this.labelPasswort.Text = "Passwort";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 324);
            this.Controls.Add(this.labelPasswort);
            this.Controls.Add(this.labelBenutzername);
            this.Controls.Add(this.Benutzer_Anlegen);
            this.Controls.Add(this.buttonAnmelden);
            this.Controls.Add(this.textBoxPasswort);
            this.Controls.Add(this.textBoxBenutzername);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBenutzername;
        private System.Windows.Forms.TextBox textBoxPasswort;
        private System.Windows.Forms.Button buttonAnmelden;
        private System.Windows.Forms.Button Benutzer_Anlegen;
        private System.Windows.Forms.Label labelBenutzername;
        private System.Windows.Forms.Label labelPasswort;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}