using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksManage
{
    public partial class user3 : Form
    {
        public user3()
        {
            InitializeComponent();
            Table();
        }

        //从数据库中读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select no,bid,datetime from t_lend where uid='{Data.UId}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号
            string sql = $"delete from t_lend where no={no};update t_book set number=number+1 where id='{id}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 1)//执行了两条sql语句，大于1说明两条都成功了
            {
                MessageBox.Show("归还成功");
                Table();
            }
        }
    }
}
