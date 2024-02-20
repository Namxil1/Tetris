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
        private IViewTetris viewTetris;
        public ControllerLogin()
        {

        }

        internal IViewTetris ViewTetris { get => viewTetris; set => viewTetris = value; }
        IModel IController.Model { get => model; set => model = value; }
        IView IController.View { get => view; set => view = value; }
        IViewTetris IController.ViewTetris { get => viewTetris; set => viewTetris=value; }

        int IController.loginUser(string username, string password)
        {
            if (username.Length < 4 || password.Length < 4) { return -1; }
            else
            {
                viewTetris.PlayerID = model.GetUserID(username, password);
                viewTetris.PlayerName = model.getName(model.GetUserID(username, password));
                viewTetris.PlayerScore = model.getHighscore(model.GetUserID(username, password));
                view.hide();
                viewTetris.show();
            }
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
