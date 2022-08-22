namespace Mastermind
{
    partial class Opening
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opening));
            this.MainTitleLabel = new System.Windows.Forms.Label();
            this.EditionLabel = new System.Windows.Forms.Label();
            this.RepeatCheckBox = new System.Windows.Forms.CheckBox();
            this.numericUpDownColorCount = new System.Windows.Forms.NumericUpDown();
            this.NumberOfColorsLabel = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfGuesses = new System.Windows.Forms.NumericUpDown();
            this.NumberOfGuessesLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.HowToPlayButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfGuesses)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTitleLabel
            // 
            this.MainTitleLabel.AutoSize = true;
            this.MainTitleLabel.Font = new System.Drawing.Font("Stencil", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTitleLabel.Location = new System.Drawing.Point(90, 9);
            this.MainTitleLabel.Name = "MainTitleLabel";
            this.MainTitleLabel.Size = new System.Drawing.Size(278, 44);
            this.MainTitleLabel.TabIndex = 0;
            this.MainTitleLabel.Text = "Mastermind!";
            this.MainTitleLabel.Click += new System.EventHandler(this.MainTitleLabel_Click);
            // 
            // EditionLabel
            // 
            this.EditionLabel.AutoSize = true;
            this.EditionLabel.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditionLabel.Location = new System.Drawing.Point(361, 31);
            this.EditionLabel.Name = "EditionLabel";
            this.EditionLabel.Size = new System.Drawing.Size(89, 16);
            this.EditionLabel.TabIndex = 1;
            this.EditionLabel.Text = "Simple Edition";
            // 
            // RepeatCheckBox
            // 
            this.RepeatCheckBox.AutoSize = true;
            this.RepeatCheckBox.Checked = true;
            this.RepeatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RepeatCheckBox.Location = new System.Drawing.Point(132, 84);
            this.RepeatCheckBox.Name = "RepeatCheckBox";
            this.RepeatCheckBox.Size = new System.Drawing.Size(133, 17);
            this.RepeatCheckBox.TabIndex = 2;
            this.RepeatCheckBox.Text = "Allow Repeated Colors";
            this.RepeatCheckBox.UseVisualStyleBackColor = true;
            // 
            // numericUpDownColorCount
            // 
            this.numericUpDownColorCount.Location = new System.Drawing.Point(132, 107);
            this.numericUpDownColorCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownColorCount.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownColorCount.Name = "numericUpDownColorCount";
            this.numericUpDownColorCount.ReadOnly = true;
            this.numericUpDownColorCount.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownColorCount.TabIndex = 3;
            this.numericUpDownColorCount.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // NumberOfColorsLabel
            // 
            this.NumberOfColorsLabel.AutoSize = true;
            this.NumberOfColorsLabel.Location = new System.Drawing.Point(178, 109);
            this.NumberOfColorsLabel.Name = "NumberOfColorsLabel";
            this.NumberOfColorsLabel.Size = new System.Drawing.Size(87, 13);
            this.NumberOfColorsLabel.TabIndex = 4;
            this.NumberOfColorsLabel.Text = "Number of colors";
            // 
            // numericUpDownNumberOfGuesses
            // 
            this.numericUpDownNumberOfGuesses.Location = new System.Drawing.Point(132, 134);
            this.numericUpDownNumberOfGuesses.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownNumberOfGuesses.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownNumberOfGuesses.Name = "numericUpDownNumberOfGuesses";
            this.numericUpDownNumberOfGuesses.ReadOnly = true;
            this.numericUpDownNumberOfGuesses.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownNumberOfGuesses.TabIndex = 5;
            this.numericUpDownNumberOfGuesses.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // NumberOfGuessesLabel
            // 
            this.NumberOfGuessesLabel.AutoSize = true;
            this.NumberOfGuessesLabel.Location = new System.Drawing.Point(178, 136);
            this.NumberOfGuessesLabel.Name = "NumberOfGuessesLabel";
            this.NumberOfGuessesLabel.Size = new System.Drawing.Size(100, 13);
            this.NumberOfGuessesLabel.TabIndex = 6;
            this.NumberOfGuessesLabel.Text = "Number of Guesses";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(307, 83);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 65);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start the game!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "By Natty Zepko";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(413, 125);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // HowToPlayButton
            // 
            this.HowToPlayButton.Location = new System.Drawing.Point(413, 84);
            this.HowToPlayButton.Name = "HowToPlayButton";
            this.HowToPlayButton.Size = new System.Drawing.Size(75, 38);
            this.HowToPlayButton.TabIndex = 10;
            this.HowToPlayButton.Text = "How to play";
            this.HowToPlayButton.UseVisualStyleBackColor = true;
            this.HowToPlayButton.Click += new System.EventHandler(this.HowToPlayButton_Click);
            // 
            // Opening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 203);
            this.Controls.Add(this.HowToPlayButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NumberOfGuessesLabel);
            this.Controls.Add(this.numericUpDownNumberOfGuesses);
            this.Controls.Add(this.NumberOfColorsLabel);
            this.Controls.Add(this.numericUpDownColorCount);
            this.Controls.Add(this.RepeatCheckBox);
            this.Controls.Add(this.EditionLabel);
            this.Controls.Add(this.MainTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Opening";
            this.Text = "Mastermind";
            this.Load += new System.EventHandler(this.Opening_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfGuesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainTitleLabel;
        private System.Windows.Forms.Label EditionLabel;
        private System.Windows.Forms.CheckBox RepeatCheckBox;
        private System.Windows.Forms.NumericUpDown numericUpDownColorCount;
        private System.Windows.Forms.Label NumberOfColorsLabel;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfGuesses;
        private System.Windows.Forms.Label NumberOfGuessesLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button HowToPlayButton;
    }
}