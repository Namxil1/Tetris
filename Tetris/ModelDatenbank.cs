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
    internal class ModelDatenbank
    {
        private string connectionString = "server=localhost;uid=root;pwd=;database=tetris";
        MySqlCommand cmd;
        MySqlConnection con;
        public ModelDatenbank()
        {
            con = new MySqlConnection(connectionString);
        }

        private string PasswordHash(string password)
        {
            SHA256 sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
        public int GetUserID(string username,string pwd)
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
            catch (Exception e)
            {
                con.Close();
                MessageBox.Show(e.ToString(), "Fehler");
                return -2;
            }
        }

            internal int RegisterUser(string username, string pwd)
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
                    cmd.CommandText = "INSERT INTO user (username,password) VALUES ('"+username+"','"+pwd+ "'); SELECT LAST_INSERT_ID();";
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    return result;
                }
                con.Close();
                return -1;
            }
            catch(Exception e) 
            {
                con.Close();
                MessageBox.Show(e.ToString(), "Fehler");
                return -2;
            }
            
        }

        public string getName(int ID)
        {
            
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT username FROM user WHERE ID_User = " + ID + ";";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
                con.Close();

            }
            catch (Exception e)
            {
                con.Close();
            }
            return "";
        }
    }
}
