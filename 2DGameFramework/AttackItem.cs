using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class AttackItem : WorldObject
    {
        private LogTracer ts = LogTracer.Instance;
        public int attackPoints { get; set; }
        public int itemRange { get; set; }
        public AttackItem(bool loot, bool remove, string name, bool staticObject, Position position, int attack, int range) 
            : base(loot, remove, name, staticObject, position)
        {
            attackPoints = attack;
            itemRange = range;
            loot = true;
        }

        //Template method
        public override void AddAttack(Creature player)
        {
            ts.AddInfo(297, "Attack added to $player");
            player.totalAttack = player.totalAttack + attackPoints;
        }

        public override void AddDefense(Creature player)
        {
            //Do nothing : Attack item does not add defense
        }
    }
}
