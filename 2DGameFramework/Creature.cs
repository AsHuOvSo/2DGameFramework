using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using _2DGameFramework.State;

namespace _2DGameFramework
{
    public class Creature : WorldObject
    {
        public int HitPoints { get; set; }
        public int baseAttack { get; set; }
        public int totalAttack;
        public int baseDefense { get; set; }
        public int totalDefense;
        public Position pos { get; set; }

        public DefenseItem defItem;
        public AttackItem attItem;

        private LogTracer ts = LogTracer.Instance;
        public Creature(bool loot, bool remove, string name, bool staticObject, Position position, int hp, int attack, int defense) 
            : base(loot, remove, name, staticObject, position)
        {
            HitPoints = hp;
            baseAttack = attack;
            baseDefense = defense;
            pos = position;
            totalAttack = attack;
            totalDefense = defense;
        }

        public void Move(Move direction)
        {
            SetNewPosition(direction);
        }

        private void SetNewPosition(Move move)
        {
            pos.X += move.x;
            pos.Y += move.y;
        }

        public void GetHit(Creature attacker)
        {
            ReceiveHit(totalDefense, attacker.totalAttack);
        }

        public void ReceiveHit(int defense, int attack)
        {
            int damage = attack - defense;
            if(damage <= 0)
            {
                HitPoints = HitPoints;
            } else if(damage > 0 && HitPoints - damage > 0)
            {
                HitPoints = HitPoints - damage;
            } else if(damage > 0 && HitPoints - damage <= 0)
            {
                Die();
            } else
            {
                ts.AddError(392, "Out of scope");
            }
        }

        public void Die()
        {
            HitPoints = 0;
            totalAttack = baseAttack;
            totalDefense = baseDefense;
            Console.WriteLine("Died!");
        }

        public void Loot(WorldObject item)
        {
            bool isItem = pos.Equals(item);
            if(isItem)
            {
                if(item.Equals(attItem))
                {
                    attItem.AddAttack(this);
                } else if(item.Equals(defItem))
                {
                    defItem.AddDefense(this);
                }
            } else if(!isItem)
            {
                //Do nothing
            } else
            {
                ts.AddError(393, "Object out of scope");
            }
        }

        public override void AddAttack(Creature player)
        {
            //Do nothing : Creatures don't add attack to another creature
        }

        public override void AddDefense(Creature player)
        {
            //Do nothing : Creatures don't add defense to another creature
        }
    }
}
