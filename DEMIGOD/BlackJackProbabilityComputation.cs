using DEMIGOD.Classes;
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
    public partial class BlackJackProbabilityComputation : Form
    {
        public BlackJackProbabilityComputation()
        {
            InitializeComponent();
        }

        private void BlackJackProbabilityComputation_Load(object sender, EventArgs e)
        {                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string voice = voice_B.Text;
            BlackSecret.GetBankerBust(voice);
            List<BlackSecret.TraverseSet> list = BlackSecret.proHolder;
            string details = String.Empty;
            float sum = 0;
            foreach (BlackSecret.TraverseSet item in list)
            {
                details += item.content;
                sum += item.prob;
            }
            fact_B.Text = sum.ToString();
            truth_RB.Text = details;
        }
    }
}
