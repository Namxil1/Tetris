using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    internal class ModelDatenbank:IModel
    {
        private IView view;
        private IController controller;


        private string connectionString = "server=localhost;uid=root;pwd=;database=tetris";
        MySqlCommand cmd;
        MySqlConnection con;

        IView IModel.View { get => view; set => view = value; }
        IController IModel.Controller { get => controller; set => controller = value; }

        public ModelDatenbank()
        {
            con = new MySqlConnection(connectionString);
        }

        private string PasswordHash(string password)
        {
            SHA256 sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
        int IModel.GetUserID(string username, string pwd)
        {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT COUNT(ID_user) FROM user WHERE username = '" + username + "' AND password = '" + PasswordHash(pwd) + "';";
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count ==1)
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT ID_user FROM user WHERE username = '" + username + "' AND password = '" + PasswordHash(pwd) + "';";
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    return count;
                }
                con.Close();
                return 0;
                
            }
            catch (Exception)
            {
                con.Close();
                return -2;
            }
        }

        int IModel.RegisterUser(string username, string pwd)
        {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT COUNT(username) From user where username = '" + username + "';";
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count ==0)
                {
                    SHA256 sha = SHA256.Create();
                    pwd = PasswordHash(pwd);
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO user (username,password,score) VALUES ('"+username+"','"+pwd+ "',0); SELECT LAST_INSERT_ID();";
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    return result;
                }
                con.Close();
                return -1;
            }
            catch(Exception ) 
            {
                con.Close();
                return -2;
            }
            
        }

        string IModel.getName(int ID)
        {
            
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT username FROM user WHERE ID_User = " + ID + ";";
                MySqlDataReader reader = cmd.ExecuteReader();
                string name = "";
                while (reader.Read())
                {   
                    name = reader.GetString(0);
                }
                con.Close();
                return name;

            }
            catch (Exception )
            {
                con.Close();
            }
            return "";
        }
        void IModel.setHighscore(int ID, int score)
        {
            //int currentHighscore = getHighscore(ID);
            int currentHighscore = 0; //Achtung!! getHighscore ist eine Funktion der Schnittstelle!!!
            //Im Controller erst den Highscor aktuell ermitteln und dann mit übergeben!
            if (currentHighscore < score)
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE user SET score = "+score+" WHERE ID_User = " + ID + ";";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        int IModel.getHighscore(int ID)
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT score FROM user WHERE ID_User = " + ID + ";";
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int score=reader.GetInt32(0);
            con.Close();
            return score;
        }
    }
}
