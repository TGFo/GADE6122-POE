using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class Gold : Item
    {
        private TileType tile = TileType.Gold;
        private int goldAmount;
        private Random rand = new Random();
        public Gold(int Y, int X) : base(Y, X, (TileType)2)
        {
            goldAmount = rand.Next(1, 6);
        }
        public int GoldAmount()
        {
            return goldAmount;
        }
        public override string ToString()
        {
            return tile.ToString();
        }
    }
}
