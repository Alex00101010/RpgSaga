using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaga.Saga
{
    class Mage : Character
    {
        public Mage(int hp, int strength, string name) : base(hp, strength, name)
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
            else
            {
                return strength;
            }
            return 0;
        }

        public override int Damage(int damage)
        {
            if (!aactive)
                return base.Damage(damage);
            else
                return 0;
        }
        public override string ToString()
        {
            return "(Mage) " + base.ToString();
        }
    }
}
