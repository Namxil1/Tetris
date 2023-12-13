using System;
using System.Windows.Forms;

namespace Tetris
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
             login = new ControllerLogin();
        }
        ControllerLogin login;
        private string benutzername;
        private string passwort;
        private void buttonAnmelden_Click(object sender, EventArgs e)
        {
            benutzername = textBoxBenutzername.Text;
            passwort = textBoxPasswort.Text;
            int returnlogin = login.loginUser(benutzername, passwort);
            if (returnlogin != 0)
            {
                this.Hide();
                TetrisForm tetris = new TetrisForm();
                tetris.Show();
                
            }else if (returnlogin == -2)
            {
                MessageBox.Show("Verbindung zu Datenbank kann nicht hergestellt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Ungültiger Benutzername oder Passwort!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void BenutzerRegistrieren_Click(object sender, EventArgs e)
        {
            benutzername = textBoxBenutzername.Text;
            passwort = textBoxPasswort.Text;
            int[] retrunvalue= login.registerUser(benutzername, passwort);

            switch (retrunvalue[0])
            {
                case 0:
                    MessageBox.Show("Ungültiger Benutzername oder Passwort!", "Fehler",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case -1:
                    MessageBox.Show("Benutzername schon vergeben!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -2:
                    MessageBox.Show("Verbindung zu Datenbank kann nicht hergestellt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:
                    this.Hide();
                    Form tetris = new TetrisForm();
                    tetris.Show();
                    break;
            }
            
        }
    }
}
