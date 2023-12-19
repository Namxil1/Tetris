using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tetris
{
    internal class ControllerLogin
    {
        private ModelDatenbank db = new ModelDatenbank();
        public ControllerLogin()
        {

        }
        public int[] registerUser(string username, string password)
        {
            int[] resultarray = new int[2];
            if (username.Length < 4) { return resultarray; }
            if (password.Length < 4) { return resultarray; }

            int returnvalue = db.RegisterUser(username,password);

            if (returnvalue > 0)
            {
                resultarray[0] = 1;
                resultarray[1] = returnvalue;
            }
            else
            {
                resultarray[0] = returnvalue;
            }

            
            return resultarray;
        }

        internal int loginUser(string benutzername, string passwort)
        {
            if (benutzername.Length < 4) { return -1; }
            if (passwort.Length < 4) { return -1; }
            return db.GetUserID(benutzername,passwort);
        }
    }
}
