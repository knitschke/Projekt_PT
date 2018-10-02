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
    public partial class change : Form
    {
        public change()
        {
            InitializeComponent();
        }
        //stare
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //nowe
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //zmien
        private void button1_Click(object sender, EventArgs e)
        {
           
            string match = textBox1.Text;
            if (match == Functions.pwd) {
                string sql = "update BoardController set password='" + textBox2.Text +
                "' where login='" + Functions.login + "';";
                SQLiteCommand command = new SQLiteCommand(sql, Functions.m_dbConnection);
                command.ExecuteNonQuery();

                Form1 f = new Form1();
                f.Show();
                this.Hide();

            }
                
            
        }
        //powrot
        private void button2_Click(object sender, EventArgs e)
        {
            
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
