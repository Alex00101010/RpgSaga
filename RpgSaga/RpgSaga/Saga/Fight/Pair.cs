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
            log = $">>--[{a.ToString()} vs {b.ToString()}]--<<\n";
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
            int pbdmg = b.Damage(resA);
            log += $"{a.ToString()} dealt {pbdmg} damage to {b.ToString()}\n";
            if (!b.isAlive)
            {
                finished = true;
                return;
            }
            int resB = b.MakeTurn();
            int padmg = a.Damage(resB);
            log += $"{b.ToString()} dealt {pbdmg} damage to {a.ToString()}\n";
            if (!a.isAlive)
            {
                finished = true;
                return;
            }
        }

        public void FightTillEnd()
        {
            a.Reset();
            b.Reset();
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
