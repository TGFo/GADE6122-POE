using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class MeleeWeapon : Weapon
    {
        public enum Types
        {
            Dagger,
            Longsword
        }
        public MeleeWeapon(int Y, int X, Types meleeWeapon) : base(Y, X)
        {
            switch (meleeWeapon)
            {
                case 0:
                    weaponType = "Dagger";
                    durability = 10;
                    damage = 3;
                    cost = 3;
                    break;
                case (Types)1:
                    weaponType = "Longsword";
                    durability = 6;
                    damage = 4;
                    cost = 5;
                    break;
            }
        }
        public override int getRange()
        {
            return 1;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
