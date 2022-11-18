using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class Obstacle : Tile
    {

        public Obstacle(int Y, int X) : base(Y, X, (TileType)4)
        {
            symbol = "X";
        }
    }
}
