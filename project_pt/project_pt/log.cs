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
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
        }

        private void log_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            Functions.ip = textBox1.Text;
            Functions.pwd = textBox2.Text;
            Functions.login = textBox3.Text;

            string sql = "select * from Administrator where login ='" + Functions.login +
                "' and password='" + Functions.pwd + "';";
            string sql2= "select * from BoardController where login ='" + Functions.login +
                "' and password='" + Functions.pwd + "';";
            SQLiteCommand command = new SQLiteCommand(sql, Functions.m_dbConnection);
            SQLiteCommand command2 = new SQLiteCommand(sql2, Functions.m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
           
            while (reader.Read())
            {
                if (reader["login"].ToString() != null)
                {
                    Functions.admin = 1;
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }
            }
            reader.Close();
            SQLiteDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2["login"].ToString() != null)
                {
                    Functions.admin = 0;
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //login
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
