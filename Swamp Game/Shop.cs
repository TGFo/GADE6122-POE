using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class Shop
    {
        private Weapon[] weapons =  new Weapon[3];
        private Random rand;
        private Character buyer;
        public Shop(Character buyer) 
        {
            this.buyer = buyer;
            rand = new Random();
            for(int i = 0; i < weapons.Length; i++)
            {
                weapons[i] = RandomWeapon();
            }
        }
        private Weapon RandomWeapon()
        {
            Weapon weapon = null;
            int weaponType = rand.Next(0, 4);
            switch(weaponType)
            {
                case 0:
                    weapon = new MeleeWeapon(200, 200, 0);
                    break;
                case 1:
                    weapon = new MeleeWeapon(200, 200, (MeleeWeapon.Types)1);
                    break;
                case 2:
                    weapon = new RangedWeapon(200, 200, 0);
                    break;
                case 3:
                    weapon = new RangedWeapon(200, 200, (RangedWeapon.Types)1);
                    break;
            }
            return weapon;
        }
        public bool CanBuy(int num)
        {
            bool canBuy = false;
            if(buyer.AccessGoldPurse() >= weapons[num].getCost())
            {
                canBuy = true;
            }
            return canBuy;
        }
        public void Buy(int num)
        {
            buyer.SetGold(buyer.AccessGoldPurse() - weapons[num].getCost());
            buyer.Pickup(weapons[num]);
            weapons[num] = RandomWeapon();
        }
        public string DisplayWeapon(int num)
        {
            return "Buy " + weapons[num].getWeaponType() + " (" + weapons[num].getCost() + " Gold)";
        }

    }
}
