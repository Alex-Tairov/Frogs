using System;
using System.Windows.Forms;

namespace Frogs
{
    public partial class UserInfoForm : Form
    {
        public UserInfoForm()
        {
            InitializeComponent();
        }

                     

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {
            if (userTextBox.Text.Length == 0)
            {

                OKbutton.Enabled = false;

            }
            else
            {

                OKbutton.Enabled = true;

            }
        }
    }
}
