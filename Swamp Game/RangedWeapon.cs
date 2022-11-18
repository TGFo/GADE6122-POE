using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class RangedWeapon : Weapon
    {
        public enum Types
        {
            Rifle,
            Longbow
        };
        public RangedWeapon(int Y, int X, Types rangedWeapon) : base(Y, X)
        {
            switch (rangedWeapon)
            {
                case 0:
                    weaponType = "Rifle";
                    durability = 3;
                    range = 3;
                    damage = 5;
                    cost = 7;
                    symbol = "r";
                    break;
                case (Types)1:
                    weaponType = "Longbow";
                    durability = 4;
                    range = 2;
                    damage = 4;
                    cost = 6;
                    symbol = ")";
                    break;
            }
        }
        /*public RangedWeapon(Types rangedType, int durability) : base(Y, X)
        {

        }*/
        public override int getRange()
        {
            return base.range;
        }
        public override string ToString()
        {
            return weaponType + "(" + cost + ") dmg: " + damage + " durability: " + durability + " range: " + range;
        }
    }
}
