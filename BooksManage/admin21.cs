﻿using System;
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
    public partial class admin21 : Form
    {
        public admin21()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=""&& textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" )
            {
                Dao dao = new Dao();
                string sql =$"insert into t_book values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}',{textBox5.Text})";
                int n = dao.Execute(sql);
                if (n>0)
                {
                    MessageBox.Show("添加成功！");

                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
                //清空文本框
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

            }
            else
            {
                MessageBox.Show("输入值不允许为空！");
            }


            
            
            
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //清空文本框
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }
    }
}
