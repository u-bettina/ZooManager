using System;

namespace ZooManager
{
    class Restaurant : Shop
    {
        public Restaurant(string shopName, double income, int count, double cost, int stockBar, NewGameFrm frm) : base(shopName, income, count, cost, stockBar, frm)
        {
        }
    }
}
