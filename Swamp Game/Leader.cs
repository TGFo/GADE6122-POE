using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class Leader : Enemy
    {
        private Tile target;
        public Leader(int Y, int X) : base(20, 2, Y, X)
        {
            equipped = new MeleeWeapon(Y, X, (MeleeWeapon.Types)1);
            goldPurse = 2;
            symbol = "L";
        }
        public Tile getTarget()
        {
            return target;
        }
        public void setTarget(Tile target)
        {
            this.target = target;
        }
        public override Movement ReturnMove(Movement move = Movement.NoMovement)
        {
            int distance;
            int shortDistance = 0;
            int movement = 0;
            if (vision[0] == null)
            {
                distance = Math.Abs((target.GetX() - X) + (target.GetY() - (Y - 1)));
                if(distance < shortDistance)
                {
                    shortDistance = distance;
                    movement = 0 + 1;
                }
            }
            if (vision[1] == null)
            {
                distance = Math.Abs((target.GetX() - X) + (target.GetY() - (Y + 1)));
                if (distance < shortDistance)
                {
                    shortDistance = distance;
                    movement = 1 + 1;
                }
            }
            if (vision[2] == null)
            {
                distance = Math.Abs((target.GetX() - (X - 1)) + (target.GetY() - Y));
                if (distance < shortDistance)
                {
                    shortDistance = distance;
                    movement = 2 + 1;
                }
            }
            if (vision[3] == null)
            {
                distance = Math.Abs((target.GetX() - (X + 1)) + (target.GetY() - (Y - 1)));
                if (distance < shortDistance)
                {
                    shortDistance = distance;
                    movement = 3 + 1;
                }
            }
            return (Movement)movement;
        }
    }
}
