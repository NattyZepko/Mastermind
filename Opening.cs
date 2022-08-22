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
    public partial class Opening : Form
    {
        public Opening()
        {
            InitializeComponent();
        }

        private void MainTitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void Opening_Load(object sender, EventArgs e)
        {
            var random = new Random();
            var list = new List<string>() {
                "Simple Edition!",
                "The PURFECT Edition",
                "The COOOOL Edition",
                "This Edition",
                "The NATTY Edition",
                "The edition is untitled",
                "Version 1.1.1.1.1.3.1.1",
                "Better than Skyrim",
                "the \"Lame\" Version",
                "Now with more colors!",
                "Next time on Dragonball Z!",
                "The version version",
                "This isn't a funny headline",
                "The master of mind edition",
                "Next time you read this, I'll change",
                "This time, with RULES!",
                "For the whole family of 1 person",
                "This time without bananas",
                "This headline changes, yes",
                "The 'unique' Edition"
            };
            int editionIndex = random.Next(list.Count);
            EditionLabel.Text = list[editionIndex];
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var game = new Game(RepeatCheckBox.Checked, (int)numericUpDownColorCount.Value, (int)numericUpDownNumberOfGuesses.Value, this);
            game.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HowToPlayButton_Click(object sender, EventArgs e)
        {
            var ruleWindow = new Rules();
            this.Hide();
            ruleWindow.SetParent(this);
            ruleWindow.Show();
        }
    }
}
