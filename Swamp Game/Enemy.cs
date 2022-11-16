using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    abstract class Enemy : Character
    {
        [NonSerialized] protected Random rand = new Random();
        protected Enemy(double HP, double Damage, int Y, int X) : base(Y, X, (TileType)1)
        {
            this.HP = HP;
            this.Damage = Damage;
        }
        public override string ToString()
        {
            return this.GetType().Name + " at [" + X.ToString() + "," + Y.ToString() + "] (" + Damage.ToString() + ")" + HP.ToString();
        }
    }
}
