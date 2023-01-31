using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaga.Saga
{
    class Archer : Character
    {
        public Archer(int hp, int strength, string name) : base(hp, strength, name)
        {

        }

        public override int MakeTurn()
        {
            if (!aused)
            {
                aactive = true;
                aused = true;
            }
            else
            {
                return strength + (aactive ? 2 : 0);
            }
            return 0;
        }
    }
}
