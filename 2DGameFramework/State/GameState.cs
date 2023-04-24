using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework.State
{
    public class GameState
    {
        public enum PlayerState
        {
            MOVE,
            FIGHT
        };

        public record Move(int x, int y);
        //Seperate game into two states: Move and Fight

        //Move: Move around the board

        //Fight: In a fight scenario


    }
}
