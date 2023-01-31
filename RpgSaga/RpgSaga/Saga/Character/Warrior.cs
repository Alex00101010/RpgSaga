using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaga.Saga
{
    class Warrior : Character
    {
        public Warrior(int hp, int strength, string name) : base(hp, strength, name)
        {

        }

        public override int MakeTurn()
        {
            aactive = false;
            if (!aused)
            {
                aactive = true;
                aused = true;
            }
            return strength + (int)(aactive ? 1 : 0 * strength * 0.3f);
        }
    }
}
