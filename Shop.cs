using System;


namespace ZooManager
{
    public class Shop
    {
        string shopName;
        double income;
        double cost;
        int count;
        double stockPrice;
        int stockBar;
        double shopIncome;
        Visitors visitors;
        NewGameFrm frm;

        public string ShopName { get => shopName; set => shopName = value; }
        public double Income 
        { 
            get => income;
            set
            {
                if (value > 0)
                {
                    income = value;
                }
                else
                {
                    income = -1;
                }
            }
        }
        public int Count 
        { 
            get => count;
            set
            {
                if (value >= 0 && value <= 10)
                {
                    count = value;
                }
                else
                {
                    value = -1;
                }
            }
        }
        public double Cost 
        { 
            get => cost;
            set
            {
                if (value > 0)
                {
                    cost = value;
                }
                else
                {
                    cost = -1;
                }
            }
        }
        public int StockBar 
        { 
            get => stockBar;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    stockBar = value;
                }
                else
                {
                    stockBar = -1;
                }

            }
        }
        public NewGameFrm Frm { get => frm; set => frm = value; }

        public Shop(string shopName, double income, int count, double cost, int stockBar, NewGameFrm frm)
        {
            this.shopName = shopName;
            Income = income;
            Count = count;
            Cost = cost;
            StockBar = stockBar;
            Frm = frm;
            this.visitors = frm.Visitors;
        }

        public double ShopIncome()
        {
            shopIncome = (income * count) * visitors.Spenders();
            return shopIncome;
        }

        public double StockCost(double shopPrice)
        {
            if (Count > 0 && stockBar <= 100 && stockBar >= 85)
            {
                stockPrice = 0;
            }
            else if (Count > 0 && stockBar < 85 && stockBar >= 75)
            {
                stockPrice = (Count * (shopPrice / 10));
            }
            else if (Count > 0 && stockBar < 75 && stockBar >= 50)
            {
                stockPrice = (Count * (shopPrice / 8));
            }
            else if (Count > 0 && stockBar < 50 && stockBar >= 35)
            {
                stockPrice = (Count * (shopPrice / 6));
            }
            else if (Count > 0 && stockBar < 35 && stockBar >= 20)
            {
                stockPrice = (Count * (shopPrice / 4));
            }
            else if (Count > 0 && stockBar < 20 && stockBar > 0)
            {
                stockPrice = (Count * shopPrice);
            }
            else if (Count > 0 && stockBar == 0)
            {
                stockPrice = (Count * shopPrice);
            }
            else if (Count == 0)
            {
                stockPrice = 0;
            }
            return stockPrice;
        }

        public void StockDecrease()
        {
            if (visitors.Count > 0 && visitors.Count <= 20 && count > 0 && stockBar >= 1)
            {
                stockBar -= 1;
            }
            else if (visitors.Count > 20 && visitors.Count <= 50 && count > 0 && stockBar >= 2)
            {
                stockBar -= 2;
            }
            else if (visitors.Count > 50 && visitors.Count <= 80 && count > 0 && stockBar >= 3)
            {
                stockBar -= 3;
            }
            else if (visitors.Count > 80 && count > 0 && stockBar >= 4)
            {
                stockBar -= 4;
            }
        }
    }
}
