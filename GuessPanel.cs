using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Mastermind
{
    internal class GuessPanel
    {
        public GroupBox groupBox;
        public PictureBox[] colorPictures = new PictureBox[4];
        public PictureBox resultPicture;
        public Button SubmitButton;
        public GuessPanel(GroupBox GP, PictureBox C0, PictureBox C1, PictureBox C2, PictureBox C3, PictureBox AnswerPic, Button SubmitBut)
        {
            this.groupBox = GP;
            this.colorPictures[0] = C0;
            this.colorPictures[1] = C1;
            this.colorPictures[2] = C2;
            this.colorPictures[3] = C3;
            this.resultPicture = AnswerPic;
            this.SubmitButton = SubmitBut;
        }
    }
}
