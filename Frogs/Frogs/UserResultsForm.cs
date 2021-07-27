using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Frogs
{
    public partial class UserResultsForm : Form
    {
        private List<UserResults> userResults;
        private int min;
        private string bestUser = "";
        public UserResultsForm(List<UserResults> userResults)
        {
            InitializeComponent();
            this.userResults = userResults;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserResultsForm_Load(object sender, EventArgs e)
        {
            var results = UserResults.GetResultsFromFile();
            for (int i = 0; i < userResults.Count; i++)
            {
                var userResult = results[i];
                usersDataGridView.Rows.Add(userResult.name, userResult.score);
            }

            min = results[0].score;
            bestUser = results[0].name;
            for (int i = 0; i < userResults.Count; i++)
            {
                var userResult = results[i];
                if (userResult.score < min)
                {
                    min = userResult.score;
                    bestUser = userResult.name;
                }

            }
            bestUserDataGridView.Rows.Add(bestUser, min);
        }
    }
}
