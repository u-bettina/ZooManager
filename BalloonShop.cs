using System;

namespace ZooManager
{
    class BalloonShop : Shop
    {
        public BalloonShop(string shopName, double income, int count, double cost, int stockBar, NewGameFrm frm) : base(shopName, income, count, cost, stockBar, frm)
        {
        }
    }
}
