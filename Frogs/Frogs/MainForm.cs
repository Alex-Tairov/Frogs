using System;
using System.Windows.Forms;

namespace Frogs
{
    public partial class MainForm : Form
    {
        private int emptyPictureBoxBeginLocationX;
        private UserName user;
        private Game game;

        private System.Drawing.Point leftFrogLocation1;
        private System.Drawing.Point leftFrogLocation2;
        private System.Drawing.Point leftFrogLocation3;
        private System.Drawing.Point leftFrogLocation4;

        private System.Drawing.Point rightFrogLocation1;
        private System.Drawing.Point rightFrogLocation2;
        private System.Drawing.Point rightFrogLocation3;
        private System.Drawing.Point rightFrogLocation4;

        private System.Drawing.Point emptyLocation;
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
                    
        }


        private void FrogPictureBox_Click(object sender, EventArgs e)
        {
            var clickedPictureBox = (PictureBox)sender;
            var emptyLocationX = emptyPictureBox.Location.X;
            var distance = Math.Abs(clickedPictureBox.Location.X - emptyLocationX);
            var normalizedDistance = distance / emptyPictureBox.Size.Width;

            if (normalizedDistance > 2)
            {
                MessageBox.Show("Так прыгать нельзя!");
                return;
            }

            var emptyLocation = emptyPictureBox.Location;
            emptyPictureBox.Location = clickedPictureBox.Location;
            clickedPictureBox.Location = emptyLocation;

            user.score++;
            
            ShowStepCount();

            if (IsWin())
            {
                game.SaveResult();
                ShowWin();
            }
        }

        private bool IsWin()
        {
            return (emptyPictureBox.Location.X == emptyPictureBoxBeginLocationX) &&
                (leftFrogPictureBox1.Location.X > emptyPictureBoxBeginLocationX) &&
                (leftFrogPictureBox2.Location.X > emptyPictureBoxBeginLocationX) &&
                (leftFrogPictureBox3.Location.X > emptyPictureBoxBeginLocationX) &&
                (leftFrogPictureBox4.Location.X > emptyPictureBoxBeginLocationX);
        }

        private void ShowWin()
        {
            var winForm = new WinForm();
            if (winForm.ShowDialog(this) == DialogResult.OK)
            {
                SwapLocations();
                user.score = 0;
                ShowStepCount();
            }
            else
            {
                Close();
            }

        }
        private void ShowStepCount()
        {
            stepCountLabel.Text = "Количество ходов - " + user.score;
        }

        //Кнопка "Выход"
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Кнопка "Рестарт"
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user.score = 0;
            ShowStepCount();
            emptyPictureBox.Location = emptyLocation;

            leftFrogPictureBox1.Location = leftFrogLocation1;
            leftFrogPictureBox2.Location = leftFrogLocation2;
            leftFrogPictureBox3.Location = leftFrogLocation3;
            leftFrogPictureBox4.Location = leftFrogLocation4;

            rightFrogPictureBox1.Location = rightFrogLocation1;
            rightFrogPictureBox2.Location = rightFrogLocation2;
            rightFrogPictureBox3.Location = rightFrogLocation3;
            rightFrogPictureBox4.Location = rightFrogLocation4;

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            var userInfoFrom = new UserInfoForm();
            
            
            if (userInfoFrom.ShowDialog(this) == DialogResult.OK)
            {
                var userName = userInfoFrom.userTextBox.Text;
                user = new UserName(userName);
                game = new Game(user);

                emptyPictureBoxBeginLocationX = emptyPictureBox.Location.X;

                emptyLocation = emptyPictureBox.Location;
                
                leftFrogLocation1 =leftFrogPictureBox1.Location ;
                leftFrogLocation2= leftFrogPictureBox2.Location;
                leftFrogLocation3=leftFrogPictureBox3.Location;
                leftFrogLocation4= leftFrogPictureBox4.Location;

                rightFrogLocation1= rightFrogPictureBox1.Location;
                rightFrogLocation2= rightFrogPictureBox2.Location;
                rightFrogLocation3= rightFrogPictureBox3.Location;
                rightFrogLocation4= rightFrogPictureBox4.Location;
            }
            else
            {
                Close();
            }
            
        }
        //Кнопка "Рекорды"
        private void рекордыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultsForm = new UserResultsForm(UserResults.GetResultsFromFile());
            resultsForm.Show();
        }

        private void SwapLocations()
        {
            var tmp1 = leftFrogPictureBox1.Location;
            leftFrogPictureBox1.Location = rightFrogPictureBox1.Location;
            rightFrogPictureBox1.Location = tmp1;

            tmp1 = leftFrogPictureBox2.Location;
            leftFrogPictureBox2.Location = rightFrogPictureBox2.Location;
            rightFrogPictureBox2.Location = tmp1;

            tmp1 = leftFrogPictureBox3.Location;
            leftFrogPictureBox3.Location = rightFrogPictureBox3.Location;
            rightFrogPictureBox3.Location = tmp1;

            tmp1 = leftFrogPictureBox4.Location;
            leftFrogPictureBox4.Location = rightFrogPictureBox4.Location;
            rightFrogPictureBox4.Location = tmp1;
        }

        private void GameRoolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нужно переставить лягушки с одной стороны на другую");
        }
    }
}
