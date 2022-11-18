using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    abstract class Character : Tile
    {
        protected double HP;
        protected double MaxHP;
        protected double Damage;
        private Gold gold;
        protected int goldPurse = 0;
        public Tile[] vision = new Tile[4];
        protected Weapon equipped;

        public enum Movement
        {
            NoMovement,
            Up,
            Down,
            Left,
            Right,
        }

        public Character(int Y,int X, TileType type) : base(Y, X, type)
        {
            HP = MaxHP;
        }
        public double GetHP()
        {
            return HP;
        }
        public void SetHP(double HP)
        {
            this.HP = HP;
        }
        public double GetMaxHP()
        {
            return HP;
        }
        public void SetMaxHP(double MaxHP)
        {
            this.MaxHP = MaxHP;
        }
        public double GetDamage()
        {
            return HP;
        }
        public void SetDamage(double Damage)
        {
            this.Damage = Damage;
        }
        public virtual void Attack(Character target)
        {
            if(target != null)
            {
                target.HP = target.HP - Damage;
            }
        }
        public bool IsDead()
        {
            bool isDead = false;
            if(HP <= 0)
            {
                isDead = true;
            }
            return isDead;
        }
        public virtual bool CheckRange(Character target)
        {
            bool inRange;
            if (DistanceTo(target) == 1)
            {
                inRange = true;
            }
            else inRange = false;
            return inRange;
        }
        private int DistanceTo(Character target)
        {
            int distance = 0;
            distance = Math.Abs((target.X - X) + (target.Y - Y));
            return distance;
        }
        public void Move(Movement move)
        {
            switch (move)
            {
                case Movement.NoMovement:
                    break;
                case Movement.Up:
                    Y = Y - 1;
                    break;
                case Movement.Down:
                    Y = Y + 1;
                    break;
                case Movement.Left:
                    X = X - 1;
                    break;
                case Movement.Right:
                    X = X + 1;
                    break;
            }
        }
        public int AccessGoldPurse()
        {
            return goldPurse;
        }
        public void SetGold(int gold)
        {
            goldPurse = gold;
        }
        public void Pickup(Item I)
        {
            if(I != null && I.GetTileType() == (TileType)2)
            {
                gold = (Gold)I;
                goldPurse += gold.GoldAmount();
            }
        }
        public abstract Movement ReturnMove(Movement move = 0);
        public abstract override string ToString();
    }
}
