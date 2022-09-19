using System;
using System.Windows.Forms;

namespace ZooManager
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            newGameBtn.FlatAppearance.BorderSize = 0;
            loadBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatAppearance.BorderSize = 0;

        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewGameFrm newGame = new NewGameFrm();
            newGame.ShowDialog();
            this.Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
