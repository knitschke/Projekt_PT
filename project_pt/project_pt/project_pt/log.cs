using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (Functions.pwd == "12345") {
                Functions.tcp("x");
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
