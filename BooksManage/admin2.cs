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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
            
        }

        private void admin2_Load(object sender, EventArgs e)
        {
            Table();

        }
        //从数据库中读取数据显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from t_book";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取第0行第0列的值 转换成字符串模式   此处为获取书号；
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除吗？","信息提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (dr==DialogResult.OK)
                {
                    string sql = $"delete from t_book where id={id}";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败" + sql);
                    }

                    dao.DaoClose();
                }


            }
            catch
            {
                MessageBox.Show("请先在表格中选中要删除的图书！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+"-"+dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin21 a = new admin21();
            a.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string press = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string number = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                admin22 a22 = new admin22(id,name,author,press,number);
                a22.ShowDialog();
                Table();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            
        }

        public void TableID()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from t_book where id='{textBox1.Text}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        public void TableName()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from t_book where name like '%{textBox2.Text}%'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            TableID();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            TableName();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
            //刷新时候清空文本框
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
