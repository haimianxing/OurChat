using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MyQQ
{
    internal class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Database()
        {
            server = "localhost";
            database = "myqq_user";
            uid = "root";
            password = "root";
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password.");
                        break;
                    default:
                        Console.WriteLine(ex.Message);
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
