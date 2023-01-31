using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaga.Saga
{
    abstract class Character
    {
        public bool isAlive { get => hp > 0; }
        int maxhp;
        protected int hp;
        protected int strength;
        public string name;
        protected bool aused;
        protected bool aactive;

        public Character(int hp, int strength, string name)
        {
            this.maxhp = hp;
            this.strength = strength;
            this.name = name;
        }

        public static Character New(string type, int hp, int strength, string name)
        {
            Character result = null;

            switch (type)
            {
                case "Warrior":
                    result = new Warrior(hp, strength, name);
                    break;
                case "Mage":
                    result = new Mage(hp, strength, name);
                    break;
                case "Archer":
                    result = new Archer(hp, strength, name);
                    break;
                default:
                    //should be dummy
                    break;
            }
            return result;
        }

        public abstract int MakeTurn();
        public void Reset()
        {
            aactive = false;
            aused = false;
            hp = maxhp;
        }
        public virtual int Damage(int damage)
        {
            int res = damage < hp ? damage : hp;
            hp -= res;
            return res;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
