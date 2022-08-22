using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
{
    public partial class Rules : Form
    {
        private Opening parent;
        public Rules()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void SetParent(Opening opening)
        {
            this.parent = opening;
        }

        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parent.Show();
        }
    }
}
