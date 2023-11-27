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
            this.Benutzernamentextbox1 = new System.Windows.Forms.TextBox();
            this.Passworttextbox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Benutzer_Anlegen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Benutzernamentextbox1
            // 
            this.Benutzernamentextbox1.Location = new System.Drawing.Point(12, 25);
            this.Benutzernamentextbox1.Name = "Benutzernamentextbox1";
            this.Benutzernamentextbox1.Size = new System.Drawing.Size(253, 20);
            this.Benutzernamentextbox1.TabIndex = 0;
            // 
            // Passworttextbox1
            // 
            this.Passworttextbox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Passworttextbox1.Location = new System.Drawing.Point(12, 62);
            this.Passworttextbox1.Name = "Passworttextbox1";
            this.Passworttextbox1.Size = new System.Drawing.Size(253, 20);
            this.Passworttextbox1.TabIndex = 1;
            this.Passworttextbox1.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Anmelden";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Benutzer_Anlegen
            // 
            this.Benutzer_Anlegen.Location = new System.Drawing.Point(139, 103);
            this.Benutzer_Anlegen.Name = "Benutzer_Anlegen";
            this.Benutzer_Anlegen.Size = new System.Drawing.Size(109, 23);
            this.Benutzer_Anlegen.TabIndex = 3;
            this.Benutzer_Anlegen.Text = "Benutzer_Anlegen";
            this.Benutzer_Anlegen.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 324);
            this.Controls.Add(this.Benutzer_Anlegen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Passworttextbox1);
            this.Controls.Add(this.Benutzernamentextbox1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Benutzernamentextbox1;
        private System.Windows.Forms.TextBox Passworttextbox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Benutzer_Anlegen;
    }
}