using System;
using System.Windows.Forms;

namespace Frogs
{
    public partial class WinForm : Form
    {
        private UserName user;
        public WinForm(UserName user)
        {
            InitializeComponent();
            this.user = user;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void WinForm_Load(object sender, EventArgs e)
        {
            resultScoreLabel.Text = user.score.ToString();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
