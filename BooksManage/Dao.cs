using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BooksManage
{
    class Dao
    {
        MySqlConnection sc;
        public MySqlConnection connect()
        {
            String str = "server=127.0.0.1;port=3306;user=root;password=root; database=bookdb;Charset=utf8;";
            // server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以不写
            MySqlConnection sc = new MySqlConnection(str);//创建数据库对象
            sc.Open();

            return sc;
            //try
            //{
            //    conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
            //    Console.WriteLine("已经建立连接");
            //    //在这里使用代码对数据库进行增删查改
            //}
            //catch (MySqlException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}
           

        }

        public MySqlCommand command(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, connect());
            return cmd;
        }

        public int Execute(string sql)//更新操作
        {
            return command(sql).ExecuteNonQuery();
        }

        public MySqlDataReader read(string sql)//读取操作
        {
            return  command(sql).ExecuteReader();
        }


        public void DaoClose()
        {
            if (sc != null)
            {
                sc.Close();
            }
            
            
        }
    }
}
