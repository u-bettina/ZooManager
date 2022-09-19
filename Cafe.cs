using System;


namespace ZooManager
{
    class Cafe : Shop
    {
        public Cafe(string shopName, double income, int count, double cost, int stockBar, NewGameFrm frm) : base(shopName, income, count, cost, stockBar, frm)
        {
        }
    }
}
