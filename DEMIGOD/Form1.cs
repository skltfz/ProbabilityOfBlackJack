using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEMIGOD
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

        private void input_RB_TextChanged(object sender, EventArgs e)
        {

        }

        private void this_Btn_Click(object sender, EventArgs e)
        {
            string input = input_RB.Text;
            string[] split = input.Split(',');
            List<string> sSet = new List<string>();
            foreach (string s in split)
            {
                string ss = s.Trim().Split(' ')[1];
                sSet.Add(string.Format("this.{0}={0};", ss));
            }
            output_RB.Text = String.Join("\n", sSet);
        }
    }
}
