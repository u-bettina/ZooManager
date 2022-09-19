using System;

namespace ZooManager
{
    class SnackVendor : Shop
    {
        public SnackVendor(string shopName, double income, int count, double cost, int stockBar, NewGameFrm frm) : base(shopName, income, count, cost, stockBar, frm)
        {
        }
    }
}
