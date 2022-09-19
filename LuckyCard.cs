using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ZooManager
{
    class LuckyCard
    {
        Chicken chicken;
        NewGameFrm frm;
        Horse horse;
        Income income;
        public List<Action> luckyCards = new List<Action>();

        

        public NewGameFrm Frm { get => frm; set => frm = value; }

        public LuckyCard(NewGameFrm frm)
        {
            Frm = frm;
            luckyCards.Add(LuckyCard1);
            luckyCards.Add(LuckyCard2);
            luckyCards.Add(LuckyCard3);
            this.chicken = frm.Chicken;
            this.horse = frm.Horse;
            this.income = frm.Income;
        }

        public void LuckyCard1()
        {
            if (MessageBox.Show("You were on your way home from the park, when you saw a chicken and decided to take it in." , 
                "Lucky Card", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (chicken.Count < 10)
                {
                    chicken.Count += 1;
                    frm.messageBoard.Text += "You got lucky and got a free chicken! Your current number of chickens: " + chicken.count.ToString() + Environment.NewLine;
                }
                else
                {
                    frm.messageBoard.Text += "Unfortunately, you realized you don't have a space for another chicken right now so you gave it away to a good home!" + Environment.NewLine;
                }
            }
            else
            {
                return;
            }
        }

        public void LuckyCard2()
            {
                if (MessageBox.Show("A friendly horse approached you on the fields and you decided to take it in.", 
                    "Lucky Card", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (horse.Count < 10)
                    {
                        horse.Count += 1;
                        frm.messageBoard.Text += "You got lucky and got a free horse! Your current number of horses: " + horse.count.ToString() + Environment.NewLine;
                }
                    else
                    {
                    frm.messageBoard.Text += "Unfortunately, you realized you don't have a space for another horse right now so you gave it away to a good home!" + Environment.NewLine;
                    }
            }
                else
                {
                    return;
                }
            }

        public void LuckyCard3()
        {
            if (MessageBox.Show("You won the lottery. Your price is 1000$.",
                "Lucky Card", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                income.DailyIncome += 1000;
                income.TotalIncome += 1000;
                income.CurrentMoney += 1000;
                frm.messageBoard.Text += "You got lucky and won the lottery. Enjoy your prize!" + Environment.NewLine;
            }
            else
            {
                return;
            }
        }
    }
}
