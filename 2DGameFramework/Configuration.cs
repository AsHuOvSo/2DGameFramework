using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    internal class Configuration
    {
        public int WorldX { get; set; }
        public int WorldY { get; set; }

        public Configuration()
        {
            WorldX = 400;
            WorldY = 200;
        }
    }
}
