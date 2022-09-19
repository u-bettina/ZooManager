
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ZooManager
{
    public partial class NewGameFrm : Form
    {
        #region Fields
        Chicken chicken;
        Turtle turtle;
        Bear bear;
        Horse horse;
        Rhino rhino;
        Tiger tiger;
        Visitors visitors;
        SnackVendor snackVendor;
        BalloonShop balloonShop;
        BurgerShop burgerShop;
        Cafe cafe;
        GiftShop giftShop;
        Restaurant restaurant;
        DateTime startTime;
        Income income;
        LuckyCard card;
        Random random;
        private int timerTick;
        int appeal;
        private int totalAnimals;
        private int dailyAnimals;
        private int dailyShops;
        private int day;
        public List<Animal> AnimalList = new List<Animal>();
        public List<Shop> ShopList = new List<Shop>();
        XmlHandler xmlHandler;
        #endregion

        #region Properties
        public Visitors Visitors { get => visitors; set => visitors = value; }
        public int TimerTick { get => timerTick; set => timerTick = value; }
        public int TotalAnimals { get => totalAnimals; set => totalAnimals = value; }
        public int DailyAnimals { get => dailyAnimals; set => dailyAnimals = value; }
        public int Day { get => day; set => day = value; }
        public int Appeal { get => appeal; set => appeal = value; }
        public int DailyShops { get => dailyShops; set => dailyShops = value; }
        public Chicken Chicken { get => chicken; set => chicken = value; }
        internal Horse Horse { get => horse; set => horse = value; }
        public Income Income { get => income; set => income = value; }
        #endregion

        #region Contructors
        public NewGameFrm()
        {
            InitializeComponent();

            #region Variables
            appeal = 0;
            timerTick = 0;
            totalAnimals = 0;
            dailyAnimals = 0;
            dailyShops = 0;
            day = 1;
            #endregion

            #region Appearance
            chickenBuyBtn.FlatAppearance.BorderSize = 0;
            turtleBuyBtn.FlatAppearance.BorderSize = 0;
            bearBuyBtn.FlatAppearance.BorderSize = 0;
            horseBuyBtn.FlatAppearance.BorderSize = 0;
            rhinoBuyBtn.FlatAppearance.BorderSize = 0;
            tigerBuyBtn.FlatAppearance.BorderSize = 0;
            snackBuyBtn.FlatAppearance.BorderSize = 0;
            balloonBuyBtn.FlatAppearance.BorderSize = 0;
            burgerBuyBtn.FlatAppearance.BorderSize = 0;
            cafeBuyBtn.FlatAppearance.BorderSize = 0;
            giftBuyBtn.FlatAppearance.BorderSize = 0;
            restBuyBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatAppearance.BorderSize = 0;
            luckyCardBtn.FlatAppearance.BorderSize = 0;
            messageBoard.BorderStyle = BorderStyle.None;
            #endregion

            #region Class instances
            xmlHandler = new XmlHandler(this);
            Chicken = new Chicken("Chicken", 60, 100, 0);
            turtle = new Turtle("Turtle", 60, 250, 0);
            Horse = new Horse("Horse", 60, 500, 0);
            bear = new Bear("Bear", 60, 2000, 0);
            rhino = new Rhino("Rhinoceros", 60, 10000, 0);
            tiger = new Tiger("Tiger", 60, 15000, 0);
            visitors = new Visitors(50, 50, 0);
            snackVendor = new SnackVendor("Snack Vendor", 2, 0, 200, 50, this);
            balloonShop = new BalloonShop("Balloon Shop", 5, 0, 400, 50, this);
            burgerShop = new BurgerShop("Burger Shop", 7, 0, 500, 50, this);
            cafe = new Cafe("Café", 9, 0, 600, 50, this);
            giftShop = new GiftShop("Gift Shop", 10, 0, 800, 50, this);
            restaurant = new Restaurant("Restaurant", 15, 0, 1000, 50, this);
            messageBoard.Text += "Welcome too your zoo!" + Environment.NewLine;
            startTime = new DateTime(2022, 01, 01, 08, 0, 0);
            Income = new Income(5000, 0, 0, 0, 0);
            card = new LuckyCard(this);
            AnimalList.Add(Chicken);
            AnimalList.Add(turtle);
            AnimalList.Add(Horse);
            AnimalList.Add(bear);
            AnimalList.Add(rhino);
            AnimalList.Add(tiger);
            ShopList.Add(snackVendor);
            ShopList.Add(balloonShop);
            ShopList.Add(burgerShop);
            ShopList.Add(cafe);
            ShopList.Add(giftShop);
            ShopList.Add(restaurant);
            #endregion

            #region Components
            chickenCostLbl.Text = "$" + Chicken.Cost.ToString("F");
            turtleCostLbl.Text = "$" + turtle.Cost.ToString("F");
            horseCostLbl.Text = "$" + Horse.Cost.ToString("F");
            bearCostLbl.Text = "$" + bear.Cost.ToString("F");
            rhinoCostLbl.Text = "$" + rhino.Cost.ToString("F");
            tigerCostLbl.Text = "$" + tiger.Cost.ToString("F");
            snackCostLbl.Text = "$" + snackVendor.Cost.ToString("F");
            balloonCostLbl.Text = "$" + balloonShop.Cost.ToString("F");
            burgerCostLbl.Text = "$" + burgerShop.Cost.ToString("F");
            cafeCostLbl.Text = "$" + cafe.Cost.ToString("F");
            giftCostLbl.Text = "$" + giftShop.Cost.ToString("F");
            restCostLbl.Text = "$" + restaurant.Cost.ToString("F");
            #endregion
            

        }
        #endregion

        #region Purchase Buttons
        private void chickenBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < Chicken.Cost)
            {
                MessageBox.Show("You don't have enough money to buy another animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chickenBuyBtn.Enabled = false;
            }
            else if (Chicken.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chickenBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= Chicken.Cost;
                Income.TotalExpense -= Chicken.Cost;
                Income.DailyExpense -= Chicken.Cost;
                Chicken.Count += 1;
                dailyAnimals += 1;
                appeal += 1;
                messageBoard.Text += "You have purchased a chicken. Number of chickens: " + Chicken.Count.ToString() + Environment.NewLine;
            }
        }

        private void turtleBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < turtle.Cost)
            {
                MessageBox.Show("You don't have enough money to buy another animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                turtleBuyBtn.Enabled = false;
            }
            else if (turtle.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                turtleBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= turtle.Cost;
                Income.TotalExpense -= turtle.Cost;
                Income.DailyExpense -= turtle.Cost;
                turtle.Count += 1;
                dailyAnimals += 1;
                appeal += 2;
                messageBoard.Text += "You have purchased a turtle. Number of turtles: " + turtle.Count.ToString() + Environment.NewLine;
            }
        }

        private void horseBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < Horse.Cost)
            {
                MessageBox.Show("You don't have enough money to buy another animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                horseBuyBtn.Enabled = false;
            }
            else if (Horse.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                horseBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= Horse.Cost;
                Income.TotalExpense -= Horse.Cost;
                Income.DailyExpense -= Horse.Cost;
                Horse.Count += 1;
                dailyAnimals += 1;
                appeal += 3;
                messageBoard.Text += "You have purchased a horse. Number of horses: " + Horse.Count.ToString() + Environment.NewLine;
            }
        }

        private void bearBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < bear.Cost)
            {
                MessageBox.Show("You don't have enough money to buy another animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bearBuyBtn.Enabled = false;
            }
            else if (bear.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bearBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= bear.Cost;
                Income.TotalExpense -= bear.Cost;
                Income.DailyExpense -= bear.Cost;
                bear.Count += 1;
                dailyAnimals += 1;
                appeal += 4;
                messageBoard.Text += "You have purchased a bear. Number of bears: " + bear.Count.ToString() + Environment.NewLine;
            }
        }

        private void rhinoBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < rhino.Cost)
            {
                MessageBox.Show("You don't have enough money to buy another animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rhinoBuyBtn.Enabled = false;
            }
            else if (rhino.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rhinoBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= rhino.Cost;
                Income.TotalExpense -= rhino.Cost;
                Income.DailyExpense -= rhino.Cost;
                rhino.Count += 1;
                dailyAnimals += 1;
                appeal += 5;
                messageBoard.Text += "You have purchased a rhinoceros. Number of rhinoceroses: " + rhino.Count.ToString() + Environment.NewLine;
            }
        }

        private void tigerBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < tiger.Cost)
            {
                MessageBox.Show("You don't have enough money to buy another animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tigerBuyBtn.Enabled = false;
            }
            else if (tiger.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this animal!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tigerBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= tiger.Cost;
                Income.TotalExpense -= tiger.Cost;
                Income.DailyExpense -= tiger.Cost;
                tiger.Count += 1;
                dailyAnimals += 1;
                appeal += 6;
                messageBoard.Text += "You have purchased a tiger. Number of tigers: " + tiger.Count.ToString() + Environment.NewLine;
            }
        }

        private void snackBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < snackVendor.Cost)
            {
                MessageBox.Show("You don't have enough money to buy this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                snackBuyBtn.Enabled = false;
            }
            else if (snackVendor.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                snackBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= snackVendor.Cost;
                Income.TotalExpense -= snackVendor.Cost;
                Income.DailyExpense -= snackVendor.Cost;
                snackVendor.Count += 1;
                dailyShops += 1;
                appeal += 1;
                visitors.Hunger = 100;
                messageBoard.Text += "You have purchased a snack vendor. Number of snack vendors: " + snackVendor.Count.ToString() + Environment.NewLine;
            }
        }

        private void balloonBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < balloonShop.Cost)
            {
                MessageBox.Show("You don't have enough money to buy this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                balloonBuyBtn.Enabled = false;
            }
            else if (balloonShop.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                balloonBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= balloonShop.Cost;
                Income.TotalExpense -= balloonShop.Cost;
                Income.DailyExpense -= balloonShop.Cost;
                balloonShop.Count += 1;
                dailyShops += 1;
                appeal += 2;
                visitors.Fun = 100;
                messageBoard.Text += "You have purchased a balloon shop. Number of balloon shops: " + balloonShop.Count.ToString() + Environment.NewLine;

            }
        }

        private void burgerBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < burgerShop.Cost)
            {
                MessageBox.Show("You don't have enough money to buy this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                burgerBuyBtn.Enabled = false;
            }
            else if (burgerShop.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                burgerBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= burgerShop.Cost;
                Income.TotalExpense -= burgerShop.Cost;
                Income.DailyExpense -= burgerShop.Cost;
                burgerShop.Count += 1;
                dailyShops += 1;
                appeal += 3;
                visitors.Hunger = 100;
                messageBoard.Text += "You have purchased a burger shop. Number of burger shops: " + burgerShop.Count.ToString() + Environment.NewLine;
            }
        }

        private void cafeBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < cafe.Cost)
            {
                MessageBox.Show("You don't have enough money to buy this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cafeBuyBtn.Enabled = false;
            }
            else if (cafe.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cafeBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= cafe.Cost;
                Income.TotalExpense -= cafe.Cost;
                Income.DailyExpense -= cafe.Cost;
                cafe.Count += 1;
                dailyShops += 1;
                appeal += 4;
                visitors.Hunger = 100;
                messageBoard.Text += "You have purchased a cafe. Number of cafes: " + cafe.Count.ToString() + Environment.NewLine;
            }
        }

        private void giftBuyBtn_Click(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < giftShop.Cost)
            {
                MessageBox.Show("You don't have enough money to buy this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                giftBuyBtn.Enabled = false;
            }
            else if (giftShop.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                giftBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= giftShop.Cost;
                Income.TotalExpense -= giftShop.Cost;
                Income.DailyExpense -= giftShop.Cost;
                giftShop.Count += 1;
                dailyShops += 1;
                appeal += 5;
                visitors.Fun = 100;
                messageBoard.Text += "You have purchased a gift shop. Number of gift shops: " + giftShop.Count.ToString() + Environment.NewLine;
            }
        }

        private void restBuyBtn_Click_1(object sender, EventArgs e)
        {
            if (Income.CurrentMoney < restaurant.Cost)
            {
                MessageBox.Show("You don't have enough money to buy this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                restBuyBtn.Enabled = false;
            }
            else if (restaurant.Count >= 10)
            {
                MessageBox.Show("You have reached the maximum number of this shop!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                restBuyBtn.Enabled = false;
            }
            else
            {
                Income.CurrentMoney -= restaurant.Cost;
                Income.TotalExpense -= restaurant.Cost;
                Income.DailyExpense -= restaurant.Cost;
                restaurant.Count += 1;
                dailyShops += 1;
                appeal += 6;
                visitors.Hunger = 100;
                messageBoard.Text += "You have purchased a restaurant. Number of restaurants: " + restaurant.Count.ToString() + Environment.NewLine;
            }
        }


        #endregion

        #region Feed Buttons
        private void chickenFeedBtn_Click(object sender, EventArgs e)
        {

            Chicken.hunger = 100;
            Income.DailyExpense -= Chicken.feedPrice;
            Income.TotalExpense -= Chicken.feedPrice;
            Income.CurrentMoney -= Chicken.feedPrice;
        }

        private void turtFeedBtn_Click(object sender, EventArgs e)
        {
            turtle.hunger = 100;
            Income.DailyExpense -= turtle.feedPrice;
            Income.TotalExpense -= turtle.feedPrice;
            Income.CurrentMoney -= turtle.feedPrice;
        }

        private void horseFeedBtn_Click(object sender, EventArgs e)
        {
            Horse.hunger = 100;
            Income.DailyExpense -= Horse.feedPrice;
            Income.TotalExpense -= Horse.feedPrice;
            Income.CurrentMoney -= Horse.feedPrice;
        }
        private void bearFeedBtn_Click(object sender, EventArgs e)
        {
            bear.hunger = 100;
            Income.DailyExpense -= bear.feedPrice;
            Income.TotalExpense -= bear.feedPrice;
            Income.CurrentMoney -= Horse.feedPrice;
        }

        private void rhinoFeedBtn_Click(object sender, EventArgs e)
        {
            rhino.hunger = 100;
            Income.DailyExpense -= rhino.feedPrice;
            Income.TotalExpense -= rhino.feedPrice;
            Income.CurrentMoney -= Horse.feedPrice;
        }

        private void tigerFeedBtn_Click(object sender, EventArgs e)
        {
            tiger.hunger = 100;
            Income.DailyExpense -= tiger.feedPrice;
            Income.TotalExpense -= tiger.feedPrice;
            Income.CurrentMoney -= tiger.feedPrice;
        }
        #endregion

        #region Restock buttons
        private void snackRestock_Click(object sender, EventArgs e)
        {
            Income.DailyExpense -= snackVendor.StockCost(50);
            Income.TotalExpense -= snackVendor.StockCost(50);
            Income.CurrentMoney -= snackVendor.StockCost(50);
            snackVendor.StockBar = 100;
        }

        private void burgerRestock_Click_1(object sender, EventArgs e)
        {
            Income.DailyExpense -= burgerShop.StockCost(150);
            Income.TotalExpense -= burgerShop.StockCost(150);
            Income.CurrentMoney -= burgerShop.StockCost(150);
            burgerShop.StockBar = 100;
        }

        private void cafeRestock_Click(object sender, EventArgs e)
        {
            Income.DailyExpense -= cafe.StockCost(200);
            Income.TotalExpense -= cafe.StockCost(200);
            Income.CurrentMoney -= cafe.StockCost(200);
            cafe.StockBar = 100;
        }

        private void restRestock_Click(object sender, EventArgs e)
        {
            Income.DailyExpense -= restaurant.StockCost(300);
            Income.TotalExpense -= restaurant.StockCost(300);
            Income.CurrentMoney -= restaurant.StockCost(300);
            restaurant.StockBar = 100;
        }

        private void balloonRestock_Click(object sender, EventArgs e)
        {
            Income.DailyExpense -= balloonShop.StockCost(100);
            Income.TotalExpense -= balloonShop.StockCost(100);
            Income.CurrentMoney -= balloonShop.StockCost(100);
            balloonShop.StockBar = 100;
        }

        private void giftRestock_Click(object sender, EventArgs e)
        {
            Income.DailyExpense -= giftShop.StockCost(250);
            Income.TotalExpense -= giftShop.StockCost(250);
            Income.CurrentMoney -= giftShop.StockCost(250);
            giftShop.StockBar = 100;
        }


        #endregion

        #region Release buttons
        private void chickReleaseBtn_Click(object sender, EventArgs e)
        {
            if (Chicken.Count > 0 && appeal >= 1)
            {
                Chicken.Count -= 1;
                Income.DailyIncome += 50;
                Income.TotalIncome += 50;
                Income.CurrentMoney += 50;
                appeal -= 1;
            }
        }

        private void turtReleaseBtn_Click(object sender, EventArgs e)
        {
            if (turtle.Count > 0 && appeal >= 2)
            {
                turtle.Count -= 1;
                Income.DailyIncome += 200;
                Income.TotalIncome += 200;
                Income.CurrentMoney += 200;
                appeal -= 2;
            }

        }

        private void horseReleaseBtn_Click(object sender, EventArgs e)
        {
            if (Horse.Count > 0 && appeal >= 3)
            {
                Horse.Count -= 1;
                Income.DailyIncome += 400;
                Income.TotalIncome += 400;
                Income.CurrentMoney += 400;
                appeal -= 3;
            }
        }

        private void bearReleaseBtn_Click(object sender, EventArgs e)
        {
            if (bear.Count > 0 && appeal >= 4)
            {
                bear.Count -= 1;
                Income.DailyIncome += 1500;
                Income.TotalIncome += 1500;
                Income.CurrentMoney += 1500;
                appeal -= 4;
            }
        }

        private void rhinoReleaseBtn_Click(object sender, EventArgs e)
        {
            if (rhino.Count > 0 && appeal >= 5)
            {
                rhino.Count -= 1;
                Income.DailyIncome += 7000;
                Income.TotalIncome += 7000;
                Income.CurrentMoney += 7000;
                appeal -= 5;
            }
        }

        private void tigReleaseBtn_Click(object sender, EventArgs e)
        {
            if (tiger.Count > 0 && appeal >= 6)
            {
                tiger.Count -= 1;
                Income.DailyIncome += 12000;
                Income.TotalIncome += 12000;
                Income.CurrentMoney += 12000;
                appeal -= 6;
            }
        }
        #endregion

        #region Timers
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            {
                Chicken.FeedPrice(50);
                turtle.FeedPrice(60);
                Horse.FeedPrice(100);
                bear.FeedPrice(150);
                rhino.FeedPrice(200);
                tiger.FeedPrice(250);

                #region Labels
                label7.Text = startTime.ToString("HH:mm");
                totalAnimals = Chicken.Count + turtle.Count + Horse.Count + bear.Count + rhino.Count + tiger.Count;
                visitorFunLbl.Text = totalAnimals.ToString();
                label3.Text = appeal.ToString();
                label4.Text = visitors.Count.ToString();
                totalLbl.Text = "$" + Income.CurrentMoney.ToString("F2");
                label8.Text = "Day " + day.ToString();
                chickHungerLbl.Text = Chicken.HungerType().ToString();
                turtHungerLbl.Text = turtle.HungerType().ToString();
                horseHungerLbl.Text = Horse.HungerType().ToString();
                bearHungerLbl.Text = bear.HungerType().ToString();
                rhinoHungerLbl.Text = rhino.HungerType().ToString();
                tigHungerLbl.Text = tiger.HungerType().ToString();
                visitorHungerLbl.Text = visitors.HungerType().ToString();
                visitorFunLbl.Text = visitors.FunType().ToString();
                chickFeedPriceLbl.Text = "$" + Chicken.feedPrice.ToString("F2");
                turtFeedPriceLbl.Text = "$" + turtle.feedPrice.ToString("F2");
                horseFeedPriceLbl.Text = "$" + Horse.feedPrice.ToString("F2");
                bearFeedPriceLbl.Text = "$" + bear.feedPrice.ToString("F2");
                rhinoFeedPriceLbl.Text = "$" + rhino.feedPrice.ToString("F2");
                tigFeedPriceLbl.Text = "$" + tiger.feedPrice.ToString("F2");
                snackStockLbl.Text = "$" + snackVendor.StockCost(50).ToString("F2");
                balloonStockLbl.Text = "$" + balloonShop.StockCost(100).ToString("F2");
                burgerStockLbl.Text = "$" + burgerShop.StockCost(150).ToString("F2");
                cafeStockLbl.Text = "$" + cafe.StockCost(200).ToString("F2");
                giftStockLbl.Text = "$" + giftShop.StockCost(250).ToString("F2");
                restStockLbl.Text = "$" + restaurant.StockCost(300).ToString("F2");
                chickenCountLbl.Text = Chicken.Count.ToString();
                turtleCountLbl.Text = turtle.Count.ToString();
                horseCountLbl.Text = Horse.Count.ToString();
                bearsCountLbl.Text = bear.Count.ToString();
                rhinoCountLbl.Text = rhino.Count.ToString();
                tigersCountLbl.Text = tiger.Count.ToString();
                #endregion

                #region Feed button enabling
                if (Chicken.count == 0 || Income.CurrentMoney < Chicken.feedPrice || Chicken.feedPrice == 0)
                {
                    chickenFeedBtn.Enabled = false;
                }
                else
                {
                    chickenFeedBtn.Enabled = true;
                }

                if (turtle.count == 0 || Income.CurrentMoney < turtle.feedPrice || turtle.feedPrice == 0)
                {
                    turtFeedBtn.Enabled = false;
                }
                else
                {
                    turtFeedBtn.Enabled = true;
                }

                if (Horse.count == 0 || Income.CurrentMoney < Horse.feedPrice || Horse.feedPrice == 0)
                {
                    horseFeedBtn.Enabled = false;
                }
                else
                {
                    horseFeedBtn.Enabled = true;
                }

                if (bear.count == 0 || Income.CurrentMoney < bear.feedPrice || bear.feedPrice == 0)
                {
                    bearFeedBtn.Enabled = false;
                }
                else
                {
                    bearFeedBtn.Enabled = true;
                }

                if (rhino.count == 0 || Income.CurrentMoney < rhino.feedPrice || rhino.feedPrice == 0)
                {
                    rhinoFeedBtn.Enabled = false;
                }
                else
                {
                    rhinoFeedBtn.Enabled = true;
                }

                if (tiger.count == 0 || Income.CurrentMoney < tiger.feedPrice || tiger.feedPrice == 0)
                {
                    tigerFeedBtn.Enabled = false;
                }
                else
                {
                    tigerFeedBtn.Enabled = true;
                }
                #endregion

                #region Buy button enabling

                if (chicken.Count < 10 || chicken.Cost < income.CurrentMoney)
                {
                    chickenBuyBtn.Enabled = true;
                }
                if (turtle.Count < 10 || turtle.Cost < income.CurrentMoney)
                {
                    turtleBuyBtn.Enabled = true;
                }
                if (horse.Count < 10 || horse.Cost < income.CurrentMoney)
                {
                    horseBuyBtn.Enabled = true;
                }
                if (bear.Count < 10 || bear.Cost < income.CurrentMoney)
                {
                    bearBuyBtn.Enabled = true;
                }
                if (tiger.Count < 10 || tiger.Cost < income.CurrentMoney)
                {
                    tigerBuyBtn.Enabled = true;
                }
                if (rhino.Count < 10 || rhino.Cost < income.CurrentMoney)
                {
                    rhinoBuyBtn.Enabled = true;
                }
                #endregion


                #region Appeal
                if (appeal >= 5)
                {
                    unlockTurtleLbl.Visible = false;
                    heart1.Visible = false;
                    turtleCostLbl.Visible = true;
                    turtleBuyBtn.Visible = true;
                    turtlePic.Visible = true;
                    turtleNameLbl.Visible = true;
                    turtleTopPnl.Visible = true;
                    costLbl2.Visible = true;
                }
                if (appeal >= 10)
                {
                    unlockBalloonLbl.Visible = false;
                    balloonCostLbl.Visible = true;
                    balloonBuyBtn.Visible = true;
                    balloonPic.Visible = true;
                    balloonNameLbl.Visible = true;
                    balloonTopPnl.Visible = true;
                    costLbl8.Visible = true;
                }
                if (appeal >= 15)
                {
                    unlockHorseLbl.Visible = false;
                    heart2.Visible = false;
                    horseTopPnl.Visible = true;
                    horseCostLbl.Visible = true;
                    horseBuyBtn.Visible = true;
                    horsePic.Visible = true;
                    horseNameLbl.Visible = true;
                    horseTopPnl.Enabled = true;
                    costLbl3.Visible = true;
                }
                if (appeal >= 20)
                {
                    burgerTopPnl.Visible = true;
                    burgerCostLbl.Visible = true;
                    burgerBuyBtn.Visible = true;
                    burgerPic.Visible = true;
                    burgerNameLbl.Visible = true;
                    unlockBurgerLbl.Visible = false;
                    costLbl9.Visible = true;
                }
                if (appeal >= 25)
                {
                    unlockBearLbl.Visible = false;
                    heart3.Visible = false;
                    bearTopPnl.Visible = true;
                    bearCostLbl.Visible = true;
                    bearBuyBtn.Visible = true;
                    bearNameLbl.Visible = true;
                    bearPic.Visible = true;
                    costLbl4.Visible = true;
                }
                if (appeal >= 30)
                {
                    unlockCafeLbl.Visible = false;
                    cafeTopPnl.Visible = true;
                    cafeCostLbl.Visible = true;
                    cafeBuyBtn.Visible = true;
                    cafeNameLbl.Visible = true;
                    cafePic.Visible = true;
                    costLbl10.Visible = true;
                }
                if (appeal >= 35)
                {
                    unlockRhinoLbl.Visible = false;
                    heart4.Visible = false;
                    rhinoTopPnl.Visible = true;
                    rhinoCostLbl.Visible = true;
                    rhinoBuyBtn.Visible = true;
                    rhinoNameLbl.Visible = true;
                    rhinoPic.Visible = true;
                    costLbl5.Visible = true;
                }
                if (appeal >= 40)
                {
                    unlockGiftLbl.Visible = false;
                    giftTopPnl.Visible = true;
                    giftCostLbl.Visible = true;
                    giftBuyBtn.Visible = true;
                    giftNameLbl.Visible = true;
                    giftPic.Visible = true;
                    costLbl11.Visible = true;
                }
                if (appeal >= 45)
                {
                    unlockTigerLbl.Visible = false;
                    heart5.Visible = false;
                    tigerTopPnl.Visible = true;
                    tigerCostLbl.Visible = true;
                    tigerBuyBtn.Visible = true;
                    tigerNameLbl.Visible = true;
                    tigerPic.Visible = true;
                    costLbl6.Visible = true;
                }
                if (appeal >= 50)
                {
                    unlockRestLbl.Visible = false;
                    restTopPnl.Visible = true;
                    restCostLbl.Visible = true;
                    restBuyBtn.Visible = true;
                    restNameLbl.Visible = true;
                    restPic.Visible = true;
                    costLbl12.Visible = true;
                }
                #endregion

            }
        }

        private void dateTimer_Tick(object sender, EventArgs e)
        {
            startTime = startTime.AddMinutes(10);
            timerTick++;
            if (timerTick == 60)
            {
                EndDay();
            }

            #region Visitor count 
            if (appeal >= 5 && appeal < 10)
            {
                visitors.Count += 1;
                Income.CurrentMoney += 5;
                Income.DailyIncome += 5;
                Income.TotalIncome += 5;
            }
            else if (appeal >= 10 && appeal < 15)
            {
                visitors.Count += 2;
                Income.CurrentMoney += 12;
                Income.DailyIncome += 12;
                Income.TotalIncome += 12;
            }
            else if (appeal >= 15 && appeal < 20)
            {
                visitors.Count += 2;
                Income.CurrentMoney += 12;
                Income.DailyIncome += 12;
                Income.TotalIncome += 12;
            }
            else if (appeal >= 20 && appeal < 25)
            {
                visitors.Count += 3;
                Income.CurrentMoney += 21;
                Income.DailyIncome += 21;
                Income.TotalIncome += 21;
            }
            else if (appeal >= 25 && appeal < 30)
            {
                visitors.Count += 4;
                Income.CurrentMoney += 32;
                Income.DailyIncome += 32;
                Income.TotalIncome += 32;
            }
            else if (appeal >= 30 && appeal < 35)
            {
                visitors.Count += 5;
                Income.CurrentMoney += 45;
                Income.DailyIncome += 45;
                Income.TotalIncome += 45;
            }
            else if (appeal >= 35 && appeal < 40)
            {
                visitors.Count += 6;
                Income.CurrentMoney += 60;
                Income.DailyIncome += 60;
                Income.TotalIncome += 60;
            }
            else if (appeal >= 40 && appeal < 45)
            {
                visitors.Count += 7;
                Income.CurrentMoney += 77;
                Income.DailyIncome += 77;
                Income.TotalIncome += 77;
            }
            else if (appeal >= 45 && appeal < 50)
            {
                visitors.Count += 8;
                Income.CurrentMoney += 96;
                Income.DailyIncome += 96;
                Income.TotalIncome += 96;
            }
            else if (appeal >= 50)
            {
                visitors.Count += 9;
                Income.CurrentMoney += 117;
                Income.DailyIncome += 117;
                Income.TotalIncome += 117;
            }

            #endregion

            #region Income

            if (snackVendor.Count > 0)
            {
                Income.CurrentMoney += snackVendor.ShopIncome();
                Income.DailyIncome += snackVendor.ShopIncome();
                Income.TotalIncome += snackVendor.ShopIncome();

            }
            if (balloonShop.Count > 0)
            {
                Income.CurrentMoney += balloonShop.ShopIncome();
                Income.DailyIncome += balloonShop.ShopIncome();
                Income.TotalIncome += balloonShop.ShopIncome();

            }
            if (burgerShop.Count > 0)
            {
                Income.CurrentMoney += burgerShop.ShopIncome();
                Income.DailyIncome += burgerShop.ShopIncome();
                Income.TotalIncome += burgerShop.ShopIncome();
            }
            if (cafe.Count > 0)
            {
                Income.CurrentMoney += cafe.ShopIncome();
                Income.DailyIncome += cafe.ShopIncome();
                Income.TotalIncome += cafe.ShopIncome();
            }
            if (giftShop.Count > 0)
            {
                Income.CurrentMoney += giftShop.ShopIncome();
                Income.DailyIncome += giftShop.ShopIncome();
                Income.TotalIncome += giftShop.ShopIncome();
            }
            if (restaurant.Count > 0)
            {
                Income.CurrentMoney += restaurant.ShopIncome();
                Income.DailyIncome += restaurant.ShopIncome();
                Income.TotalIncome += restaurant.ShopIncome();
            }
            #endregion

            #region Animal hunger

            Chicken.HungerDecrease();
            turtle.HungerDecrease();
            Horse.HungerDecrease();
            bear.HungerDecrease();
            rhino.HungerDecrease();
            tiger.HungerDecrease();
            snackVendor.StockDecrease();
            balloonShop.StockDecrease();
            burgerShop.StockDecrease();
            cafe.StockDecrease();
            giftShop.StockDecrease();
            restaurant.StockDecrease();

            if (timerTick % 5 == 0)
            {
                if (Chicken.Count > 0 && Chicken.hunger <= 20 && Chicken.hunger > 0)
                {
                    messageBoard.Text += "Your chickens are starving! If you don't feed them, visitors will start to leave the park." + Environment.NewLine;
                }
                else if (Chicken.Count > 0 && Chicken.hunger == 0 && visitors.Count >= 3)
                {
                    messageBoard.Text += "Your chickens are starving! visitors are leaving the park." + Environment.NewLine;
                    visitors.Count -= 3;
                    appeal -= 1;
                }
                if (turtle.Count > 0 && turtle.hunger <= 20 && turtle.hunger > 0)
                {
                    messageBoard.Text += "Your turtles are starving! If you don't feed them, visitors will start to leave the park." + Environment.NewLine;
                }
                else if (turtle.Count > 0 && turtle.hunger == 0 && visitors.Count >= 3)
                {
                    messageBoard.Text += "Your turtles are starving! visitors are leaving the park." + Environment.NewLine;
                    visitors.Count -= 3;
                    appeal -= 2;
                }
                if (Horse.Count > 0 && Horse.hunger <= 20 && Horse.hunger > 0)
                {
                    messageBoard.Text += "Your horses are starving! If you don't feed them, visitors will start to leave the park." + Environment.NewLine;
                }
                else if (Horse.Count > 0 && Horse.hunger == 0 && visitors.Count >= 3)
                {
                    messageBoard.Text += "Your horses are starving! visitors are leaving the park." + Environment.NewLine;
                    visitors.Count -= 3;
                    appeal -= 3;
                }
                if (bear.Count > 0 && bear.hunger <= 20 && bear.hunger > 0)
                {
                    messageBoard.Text += "Your bears are starving! If you don't feed them, visitors will start to leave the park." + Environment.NewLine;
                }
                else if (bear.Count > 0 && bear.hunger == 0 && visitors.Count >= 3)
                {
                    messageBoard.Text += "Your bears are starving! visitors are leaving the park." + Environment.NewLine;
                    visitors.Count -= 3;
                    appeal -= 4;
                }
                if (rhino.Count > 0 && rhino.hunger <= 20 && rhino.hunger > 0)
                {
                    messageBoard.Text += "Your rhinos are starving! If you don't feed them, visitors will start to leave the park." + Environment.NewLine;
                }
                else if (rhino.Count > 0 && rhino.hunger == 0 && visitors.Count >= 3)
                {
                    messageBoard.Text += "Your rhinos are starving! visitors are leaving the park." + Environment.NewLine;
                    visitors.Count -= 3;
                    appeal -= 5;
                }
                if (tiger.Count > 0 && tiger.hunger <= 20 && tiger.hunger > 0)
                {
                    messageBoard.Text += "Your tigers are starving! If you don't feed them, visitors will start to leave the park." + Environment.NewLine;
                }
                else if (tiger.Count > 0 && tiger.hunger == 0 && visitors.Count >= 3)
                {
                    messageBoard.Text += "Your tigers are starving! visitors are leaving the park." + Environment.NewLine;
                    visitors.Count -= 3;
                    appeal -= 6;
                }
            }

            #endregion
        }

        #endregion

        #region Methods
        public void EndDay()
        {
            timerTick = 0;
            dateTimer.Stop();
            updateTimer.Stop();
            OverviewFrm overviewFrm = new OverviewFrm();
            overviewFrm.Income = this.Income;
            overviewFrm.dailyAnimals = this.dailyAnimals;
            overviewFrm.dailyShops = this.dailyShops;
            if (overviewFrm.ShowDialog() == DialogResult.OK || overviewFrm.ShowDialog() == DialogResult.Cancel)
            {
                startTime = startTime.AddHours(+14);
                day += 1;
                visitors.Count = 0;
                dailyAnimals = 0;
                dailyShops = 0;
                Income.DailyIncome = 0;
                Income.DailyExpense = 0;
                dateTimer.Start();
                updateTimer.Start();
            }
        }
        #endregion

        #region Saving
        private void saveBtn_Click(object sender, EventArgs e)
        {
            xmlHandler.XmlWriting();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the game before you quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                xmlHandler.XmlWriting();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        #endregion

        #region Lucky Card
        private void luckyCardBtn_Click(object sender, EventArgs e)
        {
            luckyCardTimer.Stop();
            random = new Random();
            var i = random.Next(card.luckyCards.Count);
            var draw = card.luckyCards[i];
            /// luckyCard.methods.RemoveAt(i);
            draw();
            luckyCardBtn.Visible = false;
            luckyCardLbl.Visible = false;
            luckyCardTimer.Start();
        }

        private void luckyCardTimer_Tick(object sender, EventArgs e)
        {
            luckyCardBtn.Visible = true;
            luckyCardLbl.Visible = true;
        }
        #endregion
    }
}


