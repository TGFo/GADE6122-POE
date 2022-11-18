using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class Hero : Character
    {
        public Hero(int Y, int X, double HP, double MaxHP) : base(Y, X, 0)
        {
            this.HP = HP;
            this.MaxHP = MaxHP;
            Damage = 2;
            symbol = "H";
        }

        public override Movement ReturnMove(Movement move)
        {
            if (move != 0 && vision[(int)move - 1] != null && vision[(int)move - 1].GetTileType() != (TileType)2 && vision[(int)move - 1].GetTileType() != (TileType)3)
            {
                move = 0;
            }
            return move;
        }

        public override string ToString()
        {
            string weaponType = "Bare Hands";
            int weaponRange = 1;
            if(equipped != null)
            {
                weaponType = equipped.getWeaponType();
                weaponRange = equipped.getRange();
            }
            return "Player stats: \nHP: " + HP + "/" + MaxHP + "\nCurrent Weapon: " + weaponType + "Weapon Range: " + weaponRange + "\nDamage: " + Damage + "\nGold: " + goldPurse + "\n[" + X + "," + Y + "]";
        }
    }
}
