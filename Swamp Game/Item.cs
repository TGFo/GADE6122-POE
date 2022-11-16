using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    abstract class Item : Tile
    {
        public Item(int Y, int X, TileType type) : base (Y, X, type)
        {
        }
        public abstract override string ToString();
    }
}
