using System;
using System.Xml;

namespace ZooManager
{
    class XmlHandler
    {
        NewGameFrm frm;

        public NewGameFrm Frm { get => frm; set => frm = value; }

        public XmlHandler(NewGameFrm frm)
        {
            Frm = frm;
        }

        public void XmlWriting()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            using (XmlWriter writer = XmlWriter.Create("animals.xml", settings))
            {
                writer.WriteStartElement("Animals");
                writer.WriteString("\n");
                foreach (Animal animal in frm.AnimalList)
                {
                    writer.WriteElementString("Name", animal.ToString());
                    writer.WriteString("\n");
                    writer.WriteElementString("Hunger", animal.hunger.ToString());
                    writer.WriteString("\n");
                    writer.WriteElementString("Cost", animal.cost.ToString());
                    writer.WriteString("\n");
                    writer.WriteElementString("Count", animal.count.ToString());
                    writer.WriteString("\n");
                }
                writer.WriteEndElement();
                writer.WriteString("\n");
                writer.WriteStartElement("Shops");
                writer.WriteString("\n");
                foreach (Shop shop in frm.ShopList)
                {
                    writer.WriteElementString("Name", shop.ShopName);
                    writer.WriteString("\n");
                    writer.WriteElementString("Income", shop.Income.ToString());
                    writer.WriteString("\n");
                    writer.WriteElementString("Count", shop.Count.ToString());
                    writer.WriteString("\n");
                    writer.WriteElementString("Cost", shop.Cost.ToString());
                    writer.WriteString("\n");
                    writer.WriteElementString("Stockbar", shop.StockBar.ToString());
                    writer.WriteString("\n");
                    writer.WriteElementString("Frm", shop.Frm.ToString());
                    writer.WriteString("\n");
                }
                writer.WriteEndElement();
                writer.WriteString("\n");
                writer.WriteStartElement("Visitors");
                writer.WriteString("\n");
                writer.WriteElementString("Hunger", frm.Visitors.Hunger.ToString());
                writer.WriteString("\n");
                writer.WriteElementString("Fun", frm.Visitors.Fun.ToString());
                writer.WriteString("\n");
                writer.WriteElementString("Count", frm.Visitors.Count.ToString());
                writer.WriteString("\n");
                writer.WriteEndElement();
                writer.WriteString("\n");
                writer.WriteStartElement("FormVariables");
                writer.WriteString("\n");
                writer.WriteElementString("TimerTick", frm.TimerTick.ToString());
                writer.WriteString("\n");
                writer.WriteElementString("Appeal", frm.Appeal.ToString());
                writer.WriteString("\n");
                writer.WriteElementString("TotalAnimals", frm.TotalAnimals.ToString());
                writer.WriteString("\n");
                writer.WriteElementString("DailyAnimals", frm.DailyAnimals.ToString());
                writer.WriteString("\n");
                writer.WriteElementString("DailyShops", frm.DailyShops.ToString());
                writer.WriteString("\n");
                writer.WriteElementString("Day", frm.Day.ToString());
                writer.WriteString("\n");
                writer.WriteElementString("AnimalList", frm.AnimalList.ToString());
                writer.WriteString("\n");
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
        }
    }
}
