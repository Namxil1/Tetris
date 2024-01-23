using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal interface IModel
    {
        int GetUserID(string username, string pwd);

        int RegisterUser(string username, string pwd);

        string getName(int ID);
        void setHighscore(int ID, int score);

        int getHighscore(int ID);
    }
}
