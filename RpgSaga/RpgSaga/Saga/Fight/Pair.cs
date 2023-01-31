using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaga.Saga
{
    class Pair
    {
        Character a;
        Character b;
        bool finished;
        string log;

        public Pair(Character a, Character b)
        {
            finished = false;
            this.a = a;
            a.Reset();
            this.b = b;
            b.Reset();
        }

        public Character GetWinner()
        {
            return a.isAlive ? a : b;
        }

        public void Next()
        {
            if (!(a.isAlive && b.isAlive))
                return;

            int resA = a.MakeTurn();
            b.Damage(resA);
            if (!b.isAlive)
            {
                finished = true;
                return;
            }
            int resB = b.MakeTurn();
            a.Damage(resB);
            if (!a.isAlive)
            {
                finished = true;
                return;
            }
        }

        public void FightTillEnd()
        {
            while (a.isAlive && b.isAlive)
            {
                Next();
            }
        }

        public string GetLog()
        {
            var logBuff = log;
            log = "";
            return logBuff;
        }
    }
}
