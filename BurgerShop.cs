using System;


namespace ZooManager
{
    class BurgerShop : Shop
    {
        public BurgerShop(string shopName, double income, int count, double cost, int stockBar, NewGameFrm frm) : base(shopName, income, count, cost, stockBar, frm)
        {
        }
    }
}
