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
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
        }

        private void 图书查看和借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user2 u2 = new user2();
            u2.ShowDialog();
        }
        private void 我的借阅记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user3 u3 = new user3();
            u3.ShowDialog();
        }


        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HELLP");
        }

        private void 联系管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("管理员联系方式：100 0123 4567");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
