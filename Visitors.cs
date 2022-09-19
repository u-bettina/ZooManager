using System;

namespace ZooManager
{
    public enum FunList
    {

        None,
        Happy,
        Satisfied,
        Fine,
        Neutral,
        Bored,
        Unhappy
    }
    public class Visitors
    {
        int hunger;
        int fun;
        int count;
        private string hungerType;
        private string funType;
        int spenders;


        public int Hunger { get => hunger; set => hunger = value; }
        public int Fun { get => fun; set => fun = value; }
        public int Count { get => count; set => count = value; }

        public Visitors(int hunger, int fun, int count)
        {
            Hunger = hunger;
            Fun = fun;
            Count = count;
        }

        public int Spenders()
        {
            spenders = count / 2;
            return spenders;
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

        public string FunType()
        {
            if (Count == 0)
            {
                funType = FunList.None.ToString();
            }
            else if (Count > 0 && Fun <= 100 && Fun >= 85)
            {
                funType = FunList.Happy.ToString();
            }
            else if (Count > 0 && Fun < 85 && Fun >= 75)
            {
                funType = FunList.Satisfied.ToString();
            }
            else if (Count > 0 && Fun < 75 && Fun >= 50)
            {
                funType = FunList.Fine.ToString();
            }
            else if (Count > 0 && Fun < 50 && Fun >= 35)
            {
                funType = FunList.Neutral.ToString();
            }
            else if (Count > 0 && Fun < 35 && Fun >= 20)
            {
                funType = FunList.Bored.ToString();
            }
            else if (Count > 0 && Fun < 20 && Fun >= 0)
            {
                funType = FunList.Unhappy.ToString();
            }
            return funType;
        }
    }
}
