using System;

namespace ZooManager
{

    public enum HungerList
    {
        
        None,
        Full,
        Satisfied,
        Fine,
        Peckish,
        Hungry ,
        Starving
    }

    public class Animal
    {
        private string animalName;
        internal int hunger;
        internal double cost;
        public int count;
        public double feedPrice;
        private string hungerType;

        public int Hunger
        {
            get => hunger;
            set
            {
                if (value <= 100 && value >= 0)
                {
                    hunger = value;
                }
                else
                {
                    hunger = -1;
                }
            }
        }
        internal string AnimalName { get => animalName; /*set => animalName = value;*/ }
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


        public Animal(string animalName, int hunger, double cost, int count)
        {
            this.animalName = animalName;
            Hunger = hunger;
            Cost = cost;
            Count = count;
        }

        public double FeedPrice(double mealPrice)
        {
            if (Count == 0 || Hunger <= 100 && Hunger >= 90)
            {
                feedPrice = 0;
            }
            else if (Count > 0 && Hunger <= 90 && Hunger >= 75)
            {
                feedPrice = (Count * mealPrice) / 4;
            }
            else if (Count > 0 && Hunger < 75 && Hunger >= 50)
            {
                feedPrice = (Count * mealPrice) / 3;
            }
            else if (Count > 0 && Hunger < 50 && Hunger >= 25)
            {
                feedPrice = (Count * mealPrice) / 2;
            }
            else if (Count > 0 && Hunger < 25 && Hunger >= 0)
            {
                feedPrice = (Count * mealPrice);
            }
            return feedPrice;
        }

        public string HungerType()
        {
            if (Count == 0)
            {
                hungerType = HungerList.None.ToString();
            }
            else if (Count > 0 && Hunger <= 100 && Hunger >= 85)
            {
                hungerType = HungerList.Full.ToString();
            }
            else if (Count > 0 && Hunger < 85 && Hunger >= 75)
            {
                hungerType = HungerList.Satisfied.ToString();
            }
            else if (Count > 0 && Hunger < 75 && Hunger >= 50)
            {
                hungerType = HungerList.Fine.ToString();
            }
            else if (Count > 0 && Hunger < 50 && Hunger >= 35)
            {
                hungerType = HungerList.Peckish.ToString();
            }
            else if (Count > 0 && Hunger < 35 && Hunger >= 20)
            {
                hungerType = HungerList.Hungry.ToString();
            }
            else if (Count > 0 && Hunger < 20 && Hunger >= 0)
            {
                hungerType = HungerList.Starving.ToString();
            }
            return hungerType;
        }

        public void HungerDecrease()
        {
            if (count > 0 && hunger >= 2)
            {
                hunger -= 2;
            }
        }

        public override string ToString()
        {
            return animalName;
        }


    }
}
