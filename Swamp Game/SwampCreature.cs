using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class SwampCreature : Enemy
    {
        public SwampCreature(int Y, int X) : base(10.0, 1.0, Y, X)
        {
            //SetDamage(1);
            //SetHP(10);
            equipped = new MeleeWeapon(Y, X, 0);
            goldPurse = 1;
            symbol = "S";
        }

        public override Movement ReturnMove(Movement move)
        {
            int moves;
            bool change = false;
            do
            {
                moves = rand.Next(1, 5);
                if (vision[moves - 1] == null)
                {
                    change = true;
                }
            }while (change == false);
            return (Movement)moves;
        }
    }
}
