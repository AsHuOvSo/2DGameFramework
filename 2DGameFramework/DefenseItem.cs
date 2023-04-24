using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class DefenseItem : WorldObject
    {
        public int increaseDefense { get; set; }

        private LogTracer ts = LogTracer.Instance;
        public DefenseItem(bool loot, bool remove, string name, bool staticObject, Position position, int defPlus) 
            : base(loot, remove, name, staticObject, position)
        {
            increaseDefense = defPlus;
            loot = true;
        }

        //Template method
        public override void AddDefense(Creature player)
        {
            ts.AddInfo(298, "Defense added to $player");
            player.totalDefense = player.totalDefense + increaseDefense;
        }

        public override void AddAttack(Creature player)
        {
            //Do nothing : Defense items do not add attack
        }
    }
}
