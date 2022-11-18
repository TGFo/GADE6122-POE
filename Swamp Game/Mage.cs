using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class Mage : Enemy
    {
        public Mage(int Y, int X) : base(5, 5, Y, X)
        {
            goldPurse = 3;
            symbol = "M";
        }

        public override Movement ReturnMove(Movement move = Movement.NoMovement)
        {
            return Movement.NoMovement;
        }
        public override bool CheckRange(Character target)
        {
            bool inRange = false;
            if (target.GetY() == Y - 1 || target.GetY() == Y + 1 || target.GetX() == X - 1 || target.GetX() == X + 1)
            {
                if (base.CheckRange(target))
                {
                    inRange = true;
                }
                else if (target.GetY() != Y && target.GetX() != X)
                {
                    inRange = true;
                }
            }
            return inRange;
        }
    }
}
