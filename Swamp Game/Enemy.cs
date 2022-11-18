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
        protected Random rand = new Random();
        protected Enemy(double HP, double Damage, int Y, int X) : base(Y, X, (TileType)1)
        {
            this.HP = HP;
            this.Damage = Damage;
        }
        public override string ToString()
        {
            string hasWeapon = "Bare Handed";
            string equippedWeapon = "";
            if(equipped != null)
            {
                hasWeapon = "Equipped: ";
                equippedWeapon = "with " + equipped.getWeaponType().ToString() + "(" + equipped.getDurability() + "x" + equipped.getWeaponDamage() + ")";
            }
            return hasWeapon + this.GetType().Name + "(" + HP.ToString() + "/" + MaxHP.ToString() + "HP) at [" + X.ToString() + "," + Y.ToString() + "] " + equippedWeapon;
        }
    }
}
