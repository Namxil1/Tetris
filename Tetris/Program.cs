using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    internal static class Program
    {
        private static IModel model;
        private static IView view;
        private static IController controller;
        private static IViewTetris viewTetris;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            model = new ModelXML();
            view = new ViewLoginForm();
            controller = new ControllerLogin();
            viewTetris=new TetrisForm();


            view.Controller = controller;
            view.Model = model;

            viewTetris.Model = model;

            controller.Model = model;
            controller.View = view;
            controller.ViewTetris = viewTetris;

            model.Controller = controller;
            model.View= view;

            Application.Run((Form)view);

        }
    }
}
