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

    public partial class Game : Form
    {
        public enum Colors { Red, Blue, Green, Pink, Gray, Yellow, Brown, Black, White, Orange };
        private bool repeatColors;
        private int colorCount, guessCount;
        private int currentGuessPanel;
        private Opening openingWindow;
        private int[] Answer = { 0, 0, 0, 0 };
        private int[] Guess = { 0, 0, 0, 0 };
        private int currentColorCurser = 0;
        private GuessPanel[] guessPanels;
        private Timer timer;
        private System.Diagnostics.Stopwatch sw;

        public Game()
        {
            InitializeComponent();
        }

        public Game(bool repeatColors, int numberOfColors, int numberOfGuesses, Opening masterWindow)
        {
            InitializeComponent();
            this.repeatColors = repeatColors;
            this.colorCount = numberOfColors;
            this.guessCount = numberOfGuesses;
            this.openingWindow = masterWindow;
            initGameRules();
            initAnswer();
            this.guessPanels = initGuessPanels();
        }
        private GuessPanel[] initGuessPanels()
        {
            // create panels
            GuessPanel[] Guesses = new GuessPanel[12];
            Guesses[0] = new GuessPanel(groupBox1, pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, button1);
            Guesses[1] = new GuessPanel(groupBox2, pictureBox9, pictureBox8, pictureBox7, pictureBox6, pictureBox10, button2);
            Guesses[2] = new GuessPanel(groupBox3, pictureBox14, pictureBox13, pictureBox12, pictureBox11, pictureBox15, button3);
            Guesses[3] = new GuessPanel(groupBox4, pictureBox19, pictureBox18, pictureBox17, pictureBox16, pictureBox20, button4);
            Guesses[4] = new GuessPanel(groupBox5, pictureBox24, pictureBox23, pictureBox22, pictureBox21, pictureBox25, button5);
            Guesses[5] = new GuessPanel(groupBox6, pictureBox29, pictureBox28, pictureBox27, pictureBox26, pictureBox30, button6);
            Guesses[6] = new GuessPanel(groupBox7, pictureBox34, pictureBox33, pictureBox32, pictureBox31, pictureBox35, button7);
            Guesses[7] = new GuessPanel(groupBox8, pictureBox39, pictureBox38, pictureBox37, pictureBox36, pictureBox40, button8);
            Guesses[8] = new GuessPanel(groupBox9, pictureBox44, pictureBox43, pictureBox42, pictureBox41, pictureBox45, button9);
            Guesses[9] = new GuessPanel(groupBox10, pictureBox49, pictureBox48, pictureBox47, pictureBox46, pictureBox50, button10);
            Guesses[10] = new GuessPanel(groupBox11, pictureBox54, pictureBox53, pictureBox52, pictureBox51, pictureBox55, button11);
            Guesses[11] = new GuessPanel(groupBox12, pictureBox59, pictureBox58, pictureBox57, pictureBox56, pictureBox60, button12);

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Guesses[i].colorPictures[j].BackColor = Color.Transparent;
                    Guesses[i].colorPictures[j].MouseClick += Color_on_Click; // Every Row, every picture must be colored when clicked
                }
                Guesses[i].SubmitButton.Click += Make_A_Guess; // Every row - connect the submit Button
                Guesses[i].resultPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage; // Make the result picture stretched (resize correctly)
            }

            // label every panel, and enable only the relvant ones.
            for (int i = 0; i < 12; i++)
            {
                Guesses[i].groupBox.Text = "Guess #" + (guessCount - i);
                if (i < guessCount - 1)
                    Guesses[i].groupBox.Enabled = false;
                if (i > guessCount - 1)
                    Guesses[i].groupBox.Visible = false;
            }
            this.currentGuessPanel = guessCount - 1;
            return Guesses;
        }

        /*
         * Happens upon pressing the Submit Button of a row
         */
        private void Make_A_Guess(object sender, EventArgs e)
        {
            bool valid = true;
            foreach (int i in Guess) // Check if all colors are marked
                if (i == 0)
                    valid = false;

            if (!valid) // Didn't pick 4 colors
            {
                _ = MessageBox.Show("You must pick 4 colors.", "Make a valid guess");
                return;
            }
            // default mouse
            this.Cursor = Cursors.Default;
            this.currentColorCurser = 0;
            // calculate results
            int reds = GetReds();
            int greys = GetGreys();
            ShowGuessResult(reds, greys);

            guessPanels[currentGuessPanel].groupBox.Enabled = false; //make the previous panel unavailable
            if (reds == 4) // If win, return (don't enable another row)
            {
                Winner();
                return;
            }
            // Progress to the next row
            currentGuessPanel--;
            if (currentGuessPanel < 0) // If there are no more rows, return
            {
                Loser();
                return;
            }
            for (int i = 0; i < 4; i++) // reset the current guess
                Guess[i] = 0;
            guessPanels[currentGuessPanel].groupBox.Enabled = true; // Enable the next line

        }

        private void Winner()
        {
            this.sw.Stop();
            this.timer.Stop();
            showAnswer();
            this.Text = "You win";
            MessageBox.Show("Congratulations! YOU WIN!", "Winner");
            this.resultLabel.Text = "CONGRATULATIONS!!!";
            this.resultLabel.Visible = true;
        }
        private void Loser()
        {
            this.sw.Stop();
            this.timer.Stop();
            showAnswer();
            this.Text = "You lose";
            MessageBox.Show("Too bad :(\nTry again!", "Lose");
            this.resultLabel.Text = "You lose";
            this.resultLabel.Enabled = true;
            this.resultLabel.Visible = true;

        }

        private void ShowGuessResult(int reds, int greys)
        {
            switch (reds)
            {
                case 0:
                    switch (greys)
                    {
                        case 0:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._00;
                            break;
                        case 1:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._01;
                            break;
                        case 2:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._02;
                            break;
                        case 3:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._03;
                            break;
                        case 4:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._04;
                            break;
                    }
                    break;
                case 1:
                    switch (greys)
                    {
                        case 0:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._10;
                            break;
                        case 1:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._11;
                            break;
                        case 2:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._12;
                            break;
                        case 3:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._13;
                            break;
                    }
                    break;
                case 2:
                    switch (greys)
                    {
                        case 0:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._20;
                            break;
                        case 1:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._21;
                            break;
                        case 2:
                            guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._22;
                            break;
                    }
                    break;
                case 3:
                    if (greys > 0)
                        guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._31;
                    else
                        guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._30;
                    break;
                case 4:
                    guessPanels[currentGuessPanel].resultPicture.Image = Mastermind.Properties.Resources._40;
                    break;
            }
        }

        private int GetGreys()
        {
            int count = 0;
            List<int> AnswerList = Answer.ToList(), GuessList = Guess.ToList();
            for (int i = 3; i >= 0; i--) // REMOVE ALL 'RED WOULD-BE'
                if (AnswerList[i] == GuessList[i])
                {
                    AnswerList.RemoveAt(i);
                    GuessList.RemoveAt(i);
                }

            for (int i = 0; i < AnswerList.Count; i++) // Count Greys, and remove them from guesslist (no 0's in answer list)
                for (int j = 0; j < GuessList.Count; j++)
                    if (AnswerList[i] == GuessList[j])
                    {
                        count++;
                        GuessList[j] = 0;
                        break;
                    }

            return count;

        }

        private int GetReds()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
                if (Answer[i] == Guess[i])
                    count++;

            return count;
        }


        private void Color_on_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right) // Right click to delete color
            {
                ((PictureBox)sender).Image = Mastermind.Properties.Resources.empty_Circle; // Make it a circle again
                this.currentColorCurser = 0; // No currently picked color
                for (int i = 0; i < 4; i++) // Reset the guess for that slot
                {
                    if (guessPanels[currentGuessPanel].colorPictures[i] == sender)
                        Guess[i] = 0;
                }
                this.Cursor = Cursors.Default; // Make the cursor default
                return;
            }
            if (currentColorCurser != 0)
            {
                if (sender.GetType() == typeof(PictureBox))
                {
                    switch (currentColorCurser)
                    {
                        case 1: ((PictureBox)sender).Image = Mastermind.Properties.Resources.RED; break;
                        case 2: ((PictureBox)sender).Image = Mastermind.Properties.Resources.BLUE; break;
                        case 3: ((PictureBox)sender).Image = Mastermind.Properties.Resources.GREEN; break;
                        case 4: ((PictureBox)sender).Image = Mastermind.Properties.Resources.PINK; break;
                        case 5: ((PictureBox)sender).Image = Mastermind.Properties.Resources.GRAY; break;
                        case 6: ((PictureBox)sender).Image = Mastermind.Properties.Resources.YELLOW; break;
                        case 7: ((PictureBox)sender).Image = Mastermind.Properties.Resources.BROWN; break;
                        case 8: ((PictureBox)sender).Image = Mastermind.Properties.Resources.BLACK; break;
                        case 9: ((PictureBox)sender).Image = Mastermind.Properties.Resources.WHITE; break;
                        case 10: ((PictureBox)sender).Image = Mastermind.Properties.Resources.ORANGE; break;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (guessPanels[currentGuessPanel].colorPictures[i] == sender)
                            Guess[i] = currentColorCurser;
                    }
                }
            }
        }

        private void showAnswer()
        {
            PictureBox[] answerPictures = { answerPictrue1, answerPictrue2, answerPictrue3, answerPictrue4 };
            for (int i = 0; i < 4; i++)
            {
                switch (Answer[i])
                {
                    case 1: answerPictures[i].Image = Mastermind.Properties.Resources.RED; break;
                    case 2: answerPictures[i].Image = Mastermind.Properties.Resources.BLUE; break;
                    case 3: answerPictures[i].Image = Mastermind.Properties.Resources.GREEN; break;
                    case 4: answerPictures[i].Image = Mastermind.Properties.Resources.PINK; break;
                    case 5: answerPictures[i].Image = Mastermind.Properties.Resources.GRAY; break;
                    case 6: answerPictures[i].Image = Mastermind.Properties.Resources.YELLOW; break;
                    case 7: answerPictures[i].Image = Mastermind.Properties.Resources.BROWN; break;
                    case 8: answerPictures[i].Image = Mastermind.Properties.Resources.BLACK; break;
                    case 9: answerPictures[i].Image = Mastermind.Properties.Resources.WHITE; break;
                    case 10: answerPictures[i].Image = Mastermind.Properties.Resources.ORANGE; break;
                    default: break;
                }
            }
        }

        private void initGameRules()
        {
            RulesLabel.Text = "Rules:\nWith";
            if (!repeatColors)
                RulesLabel.Text += "out";
            RulesLabel.Text += " Repeated colors.\n";
            RulesLabel.Text += colorCount + " Colors. ";
            RulesLabel.Text += guessCount + " Guesses.";
            if (colorCount < 10)
                ColorBoxOrange.Visible = false;
            if (colorCount < 9)
                ColorBoxWhite.Visible = false;
            if (colorCount < 8)
                ColorBoxBlack.Visible = false;
            if (colorCount < 7)
                ColorBoxBrown.Visible = false;
        }

        private void initAnswer()
        {
            Random rnd = new Random();
            List<int> randomList = new List<int>();
            int MyNumber = 0;
            if (repeatColors)
            {
                for (int i = 0; i < 4; i++)
                    randomList.Add(rnd.Next(1, colorCount + 1));
            }
            else
                while (randomList.Count < 4)
                {
                    MyNumber = rnd.Next(1, colorCount + 1);
                    if (!randomList.Contains(MyNumber))
                        randomList.Add(MyNumber);
                }
            for (int i = 0; i < 4; i++)
                Answer[i] = randomList[i];
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.resultLabel.Enabled = false;
            this.resultLabel.Visible = false;
            timer = new Timer();
            sw = new System.Diagnostics.Stopwatch();
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer_tick);
            sw.Start();
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            TimerLabel.Text = "Time: ";  //sw.Elap
            if (sw.Elapsed.Hours > 0)
            {
                if (sw.Elapsed.Hours < 10)
                    TimerLabel.Text += 0;
                TimerLabel.Text += sw.Elapsed.Hours + ":";
            }
            if (sw.Elapsed.Minutes > 0)
            {
                if (sw.Elapsed.Minutes < 10)
                    TimerLabel.Text += 0;
                TimerLabel.Text += sw.Elapsed.Minutes + ":";
            }
            if (sw.Elapsed.Seconds < 10)
                TimerLabel.Text += 0;
            TimerLabel.Text += sw.Elapsed.Seconds;
        }


        private void ColorBoxRed_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.RED), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 1;
        }

        private void ColorBoxBlue_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.BLUE), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 2;
        }

        private void ColorBoxGreen_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.GREEN), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 3;
        }

        private void ColorBoxPink_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.PINK), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 4;
        }

        private void ColorBoxGray_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.GRAY), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 5;
        }

        private void ColorBoxYellow_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.YELLOW), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 6;
        }

        private void ColorBoxBrown_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.BROWN), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 7;
        }

        private void ColorBoxBlack_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.BLACK), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 8;
        }

        private void ColorBoxWhite_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.WHITE), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 9;
        }

        private void ColorBoxOrange_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(new Bitmap(Mastermind.Properties.Resources.ORANGE), 16, 16);
            this.Cursor = new Cursor(bm.GetHicon());
            this.currentColorCurser = 10;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void answerPictrue2_Click(object sender, EventArgs e)
        {

        }


        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.openingWindow.Show();
        }


    }

}
