using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tetris
{
    public partial class ViewLoginForm : Form, IView
    {
        private IModel model;
        private IController controller;
        public ViewLoginForm()
        {
            InitializeComponent();
        }
        private string benutzername = "";
        private string passwort = "";

        IModel IView.Model { get => model; set => model = value; }
        IController IView.Controller { get => controller; set => controller = value; }

        private void buttonAnmelden_Click(object sender, EventArgs e)
        {
            benutzername = textBoxBenutzername.Text;
            passwort = textBoxPasswort.Text;
            int returnlogin = controller.loginUser(benutzername, passwort);
            if (returnlogin > 0)
            {
                //Hide ist hier nicht gut!
                //Das Fenster kann von nirgendwo mehr geschlossen werden!
                //this.close() würde das ganze Programm schließen...
                //this.Hide();
                
                
                //Das kann eine View nicht!
                //TetrisForm tetris = new TetrisForm(returnlogin);
                //tetris.Show();
                
            }else if (returnlogin == -2)
            {
                //Das sollte das Model melden!
                //MessageBox.Show("Verbindung zu Datenbank kann nicht hergestellt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Das sollte der Controller eher zur Anzeige in der View veranlassen...

                //MessageBox.Show("Ungültiger Benutzername oder Passwort!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BenutzerRegistrieren_Click(object sender, EventArgs e)
        {
            benutzername = textBoxBenutzername.Text;
            passwort = textBoxPasswort.Text;
            int[] retrunvalue= controller.registerUser(benutzername, passwort);

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
                    //Das muss über den Controller gesteuert werden!
                    //Hier können auch nicht immer wieder Views erzeugt werden!
                    //Form tetris = new TetrisForm(retrunvalue[1]);
                    //tetris.Show();
                    break;
            }
            
        }

        void IView.hide()
        {
            this.Hide();
        }
    }
}
