using System.Windows.Forms;

namespace Tetris
{
    internal interface IController
    {
        IModel Model { get ; set; }
        IView View { get; set; }
        int[] registerUser(string username, string password);
        int loginUser(string username, string password);
    }
}