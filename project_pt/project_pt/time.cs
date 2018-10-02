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
    public partial class time : Form
    {
        public time()
        {
            InitializeComponent();
            
            this.textBox1.Text = Functions.time2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Functions.time2 = "";
            Form1 f= new Form1();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functions.date = textBox2.Text;
            Functions.tcp("time2");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
