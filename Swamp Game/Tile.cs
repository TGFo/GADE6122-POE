using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Swamp_Game
{
    abstract class Tile
    {
        protected string symbol;
        protected int X;
        protected int Y;
        public enum TileType
        {
            Hero,
            Enemy,
            Gold,
            Weapon,
            Obstruction
        }
        protected TileType tileType;
        public Tile (int Y, int X, TileType tileType)
        {
            this.X = X;
            this.Y = Y;
            this.tileType = tileType;
        }
        public int GetX()
        {
            return X;
        }
        public void SetX(int X)
        {
            this.X = X;
        }
        public int GetY()
        {
            return Y;
        }
        public void SetY(int Y)
        {
            this.Y = Y;
        }
        public TileType GetTileType()
        {
            return tileType;
        }
        public string getSymbol()
        {
            return symbol;
        }
    }
}
