using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _2DGameFramework
{
    public class World
    {
        /// <summary>
        /// An abstract class made to be the world framework
        /// </summary>
        
        //Declaring objects and giving them get and set methods
        protected int MaxX { get; set; }
        protected int MaxY { get; set; }

        private const string V = "C:\\Users\\AstaOvergaard-Sørens\\source\repos\\2DGameFramework\\2DGameFramework\\config.xml";
        protected List<object> Actors;
        protected List<AttackItem> AttackItems;
        protected List<DefenseItem> DefenseItems;
        protected List<Creature> Creatures;


        private LogTracer ts = LogTracer.Instance;

        public static string configFilePath = V;

        /// <summary>
        /// World constructor with configuration implemented
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public World()
        {
            Configuration conf = new Configuration();

            string fullConfFile = configFilePath;
            if (!File.Exists(fullConfFile))
            {
                ts.AddError(923, "Configuration file not found");
                throw new FileNotFoundException(fullConfFile);
            }

            XmlDocument confFile = new XmlDocument();
            confFile.LoadXml(fullConfFile);

            XmlNode nodeX = confFile.DocumentElement.SelectSingleNode("WorldMaxX");
            if (nodeX != null)
            {
                String str = nodeX.InnerText.Trim();
                conf.WorldX = Convert.ToInt32(str);
            }

            XmlNode nodeY = confFile.DocumentElement.SelectSingleNode("WorldMaxY");
            if (nodeY != null)
            {
                String str = nodeY.InnerText.Trim();
                conf.WorldY = Convert.ToInt32(str);
            }
        }

        public World(int x, int y)
        {
            MaxX = x;
            MaxY = y;
        }

        /// <summary>
        /// Return the value of X when called
        /// </summary>
        /// <returns></returns>
        public int GetX()
        {
            return MaxX;
        }

        /// <summary>
        /// Return the value of X when called
        /// </summary>
        /// <returns></returns>
        public int GetY()
        {
            return MaxY;
        }

        public void AddAttackItem(AttackItem item)
        {
            ts.AddInfo(310, "Attack Item added to list");
            AttackItems.Add(item);
        }

        public void AddDefenseItem(DefenseItem item)
        {
            ts.AddInfo(310, "Defense Item added to list");
            DefenseItems.Add(item);
        }

        public void AddCreature(Creature creature)
        {
            ts.AddInfo(310, "Creature added to list");
            Creatures.Add(creature);
        }

        public void RemoveAttackItem(AttackItem item)
        {
            ts.AddInfo(311, "Attack Item removed from list");
            AttackItems.Remove(item);
        }

        public void RemoveDefenseItem(DefenseItem item)
        {
            ts.AddInfo(311, "Defense Item removed from list");
            DefenseItems.Remove(item);
        }

        public void RemoveCreature(Creature item)
        {
            ts.AddInfo(311, "Creature removed from list");
            Creatures.Remove(item);
        }

        public void GetListOfAttackItemName()
        {

            /*var names = AttackItems.Where(n => n.name);  //!!Viser error ved name. Ved ikke hvordan man ændre det!!
            foreach (var n in names)
            {
                Console.WriteLine(n);
            }*/
        }

    }
}
