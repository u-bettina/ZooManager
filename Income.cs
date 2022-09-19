using System;

namespace ZooManager
{
    public class Income
    {
        double currentMoney;
        double totalIncome;
        double dailyIncome;
        double totalExpense;
        double dailyExpense;

        public double CurrentMoney { get => currentMoney; set => currentMoney = value; }
        public double TotalIncome { get => totalIncome; set => totalIncome = value; }
        public double DailyIncome { get => dailyIncome; set => dailyIncome = value; }
        public double TotalExpense { get => totalExpense; set => totalExpense = value; }
        public double DailyExpense { get => dailyExpense; set => dailyExpense = value; }

        public Income(double currentMoney, double totalIncome, double dailyIncome, double totalExpense, double dailyExpense)
        {
            CurrentMoney = currentMoney;
            TotalIncome = totalIncome;
            DailyIncome = dailyIncome;
            TotalExpense = totalExpense;
            DailyExpense = dailyExpense;
        }
    }
}
