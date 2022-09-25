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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("请输入账号和密码！");
            }
        }

        //登录方法，验证是否允许登录，允许为真
        public void Login()
        {
            //用户
            if (radioButton1User.Checked == true)
            {
                Dao dao = new Dao();
                string sql = "select * from t_user where id='" + textBox1.Text + "' and psw='" + textBox2.Text + "'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UId = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();

                    MessageBox.Show("登录成功");
                    user1 user = new user1();//新建窗体对象
                    this.Hide();//隐藏当前旧窗体login
                    user.ShowDialog();//弹出新窗体user
                    this.Show();//user窗体关闭，login重新显示
                }
                else
                {
                    MessageBox.Show("账号或密码错误，登录失败");
                }
                dao.DaoClose();
            }

            //管理员
            if (radioButton2Admin.Checked == true)
            {

                Dao dao = new Dao();
                string sql = "select * from t_admin where id='" + textBox1.Text + "' and psw='" + textBox2.Text + "'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    admin1 a = new admin1();
                    this.Hide();
                    a.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("账号或密码错误，登录失败");
                }
                dao.DaoClose();


            }



         

        }


    }
}
