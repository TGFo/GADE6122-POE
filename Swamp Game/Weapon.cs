using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    abstract class Weapon : Item
    {
        protected double damage;
        protected int range;
        protected int durability;
        protected int cost;
        protected string weaponType;
        protected Weapon(int Y, int X) : base(Y, X, TileType.Weapon)
        {
        }
        public double getWeaponDamage() 
        { return damage; }
        public virtual int getRange() 
        { return range; }
        public int getDurability() 
        { return durability; }
        public int getCost() 
        { return cost; }
        public void setWeaponDamage(double damage) 
        { this.damage = damage; }
        public virtual void setRange(int range) 
        { this.range = range; }
        public void setDurability(int durability)
        { this.durability = durability; }
        public void setCost(int cost) 
        { this.cost = cost; }
        public string getWeaponType()
        { return weaponType; }
        public void setWeaponType(string weaponType)
        { this.weaponType = weaponType;}

    }
}
