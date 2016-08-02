using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Osu_Helper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// run Osu!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOsu_Click(object sender, EventArgs e)
        {
            //run osu!
        }
        
        /// <summary>
        /// exit program
        /// </summary>
        private void exitHelper()
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            exitHelper();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitHelper();
        }
    }
}
