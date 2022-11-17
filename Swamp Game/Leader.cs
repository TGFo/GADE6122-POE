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
            int shortDistance = Math.Abs((target.GetX() - vision[0].GetX()) + (target.GetY() - vision[0].GetY()));
            int movement = 0;
            for (int i = 0; i >= 3; i++)
            {
                if (vision[i] == null)
                {
                    distance = Math.Abs((target.GetX() - vision[i].GetX()) + (target.GetY() - vision[i].GetY()));
                    if(distance < shortDistance)
                    {
                        shortDistance= distance;
                        movement = i + 1;
                    }
                }
            }
            return (Movement)movement;
        }
    }
}
