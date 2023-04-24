using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        protected bool Equals(Position other) 
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position)obj);
        }
    }

    public record Move(int x, int y);
}
