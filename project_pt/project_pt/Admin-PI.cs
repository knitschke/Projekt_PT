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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Functions.admin = 0;
            log f = new log();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functions.tcp("pic");
            pictures f = new pictures();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Functions.tcp("vid");
            video f = new video();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Functions.tcp("start");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Functions.tcp("time");
            time f = new time();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Functions.admin == 1)
            {
                add f = new add();
                f.Show();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            change f = new change();
            f.Show();
            this.Hide();
        

        }
    }
}
