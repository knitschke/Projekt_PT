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
    public partial class pictures : Form
    {
        public pictures()
        {
            InitializeComponent();
            if (Functions.pic.Count() != 0)
                for (int i = 0; i < Functions.pic.Count(); i++)
                    if (Functions.pic[i] != " ")
                        listBox1.Items.Add(Functions.pic[i]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            //Console.WriteLine(Functions.target);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> selectedList = new List<string>();
            foreach (var item in listBox1.SelectedItems)
            {
                Functions.target += (item.ToString() + ':');
            }
           
            Console.WriteLine(Functions.target);
            Functions.time = textBox1.Text;
            Functions.tcp("spic");
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
