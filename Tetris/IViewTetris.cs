using System.Windows.Forms;

namespace Tetris
{
    internal interface IViewTetris
    {
        int PlayerID { get ; set; }
        string PlayerName { get ; set ; }
        int PlayerScore { get ; set ; }

        IModel Model { get ; set; }

        void show();
    }
}