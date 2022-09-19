using System;
using System.Windows.Forms;

namespace ZooManager
{
    public partial class OverviewFrm : Form
    {
        Income income;
        public int dailyAnimals;
        public int dailyShops;



        public OverviewFrm()
        {
            InitializeComponent();

        }

        public Income Income { get => income; set => income = value; }

        private void OverviewFrm_Load(object sender, EventArgs e)
        {
            shopNumLbl.Text = dailyShops.ToString();
            animalNumLbl.Text = dailyAnimals.ToString();
            dailyIncLbl.Text = income.DailyIncome.ToString("F2");
            dailyExpLbl.Text = income.DailyExpense.ToString("F2");
            dailyProfLbl.Text = (income.DailyExpense + income.DailyIncome).ToString("F2");
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
