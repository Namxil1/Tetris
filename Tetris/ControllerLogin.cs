using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tetris
{
    public class ControllerLogin:IController
    {
        private IModel model;
        private IView view;
        public ControllerLogin()
        {

        }

        IModel IController.Model { get => model; set => model = value; }
        IView IController.View { get => view; set => view = value; }

        int IController.loginUser(string username, string password)
        {
            if (username.Length < 4) { return -1; }
            if (password.Length < 4) { return -1; }
            return model.GetUserID(username, password);
        }

        int[] IController.registerUser(string username, string password)
        {
            int[] resultarray = new int[2];
            if (username.Length < 4) { return resultarray; }
            if (password.Length < 4) { return resultarray; }

            int returnvalue = model.RegisterUser(username, password);

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
    }
}
