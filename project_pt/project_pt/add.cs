using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_pt
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }
        //log
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //psw
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            string sql= "insert into BoardController(login, password) values('" +
            textBox1.Text+"', '" + textBox2.Text + "');";
            SQLiteCommand command = new SQLiteCommand(sql, Functions.m_dbConnection);
            command.ExecuteNonQuery();
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
        //del
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "delete from BoardController where login='" + textBox1.Text + "';";
            SQLiteCommand command = new SQLiteCommand(sql, Functions.m_dbConnection);
            command.ExecuteNonQuery();
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
        //back
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
