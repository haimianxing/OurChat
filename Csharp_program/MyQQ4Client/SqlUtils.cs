using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ4Client
{
    public class SqlUtils
    {
        Database db = new Database();

        public SqlUtils()
        {


        }

        public SqlUtils(Database db)
        {
            this.db = db;
        }

        public void setDB(Database db)
        {
            this.db = db;
        }


        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public string GetContent()
        {

            if (db.OpenConnection())
            {
                MySqlConnection conn = db.GetConnection();
                string sql = "SELECT qq_user.`name`, qq_user.uid FROM qq_user;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                string result = "";
                while (reader.Read())
                {
                    string nickname = reader.GetString(0);
                    int id = reader.GetInt32(1);
                    result += "Nickname: " + nickname + ", id: " + id + "\n";
                }
                Console.WriteLine(result);
                db.CloseConnection();
                return result;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 查自己id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string getSelfId(String name)
        {

            if (db.OpenConnection())
            {
                MySqlConnection conn = db.GetConnection();
                string sql = "SELECT qq_user.`name`, qq_user.uid FROM qq_user where  qq_user.`name` = '" + name+"' ;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                string result = "";
                while (reader.Read())
                {
                    string nickname = reader.GetString(0);
                    int id = reader.GetInt32(1);
                    result += "Nickname: " + nickname + ", id: " + id + "\n";
                }
                db.CloseConnection();
                return result;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 根据uid 查询出所有朋友用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string getFriend(int uid)
        {

            if (db.OpenConnection())
            {
                MySqlConnection conn = db.GetConnection();
                string sql = "SELECT qq_user.uid,qq_user.`name` FROM qq_user WHERE qq_user.uid IN (SELECT friend_table.sid FROM friend_table WHERE friend_table.pid = " + uid+");";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                string result = "";
                while (reader.Read())
                {
                    string nickname = reader.GetString(1);
                    int id = reader.GetInt32(0);
                    result += "Nickname: " + nickname + ", id: " + id + "\n";
                }
                db.CloseConnection();
                return result;
            }
            else
            {
                return "";
            }
        }


        

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool RegisterUsers(String name, String pwd)
        {
            if (db.OpenConnection())
            {
                MySqlConnection conn = db.GetConnection();
                string sql = "INSERT INTO qq_user (qq_user.`name`, qq_user.pwd) VALUES('" + name + "', '" + pwd + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    db.CloseConnection();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message); db.CloseConnection();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改用户名称
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public bool UpdateUserName(string oldName, string newName)
        {
            if (db.OpenConnection())
            {
                MySqlConnection conn = db.GetConnection();
                string sql = "UPDATE qq_user SET name='" + newName + "' WHERE qq='" + oldName + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                try
                {
                    cmd.ExecuteNonQuery(); db.CloseConnection();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message); db.CloseConnection();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool CheckUser(string name, string pwd)
        {
            if (db.OpenConnection())
            {
                MySqlConnection conn = db.GetConnection();
                string sql = "SELECT COUNT(*) FROM qq_user WHERE `name`='" + name + "' AND `pwd`='" + pwd + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                db.CloseConnection();
                return count > 0;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public bool AddFriend(int pid, int sid)
        {
            if (db.OpenConnection())
            {
                MySqlConnection conn = db.GetConnection();
                string sql = "INSERT INTO friend_table (pid, sid) VALUES ('" + pid + "', '" + sid + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                try
                {
                    cmd.ExecuteNonQuery(); db.CloseConnection();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message); db.CloseConnection();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
