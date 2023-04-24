using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public abstract class WorldObject
    {
        
        protected bool Lootable { get; set; }
        protected bool Removeable { get; set; }
        protected string name { get; set; }

        protected bool StaticObject { get; set; }

        protected Position ObjectPosition { get; set; }

        private LogTracer ts = LogTracer.Instance;

        protected WorldObject(bool loot, bool remove, string name, bool staticObject, Position position)
        {
            this.Lootable = loot;
            this.Removeable = remove;
            this.name = name;
            this.StaticObject = staticObject;
            this.ObjectPosition = position;
        }

        public void RemoveObject(WorldObject? obj)
        {
            if (obj.Removeable != true)
            {
                ts.AddError(483, "Object cannot be removed");
            }
            else
            {
                obj = null;
            }
        }
        //Template method
        public abstract void AddAttack(Creature player);
        public abstract void AddDefense(Creature player);
        
    }
}
