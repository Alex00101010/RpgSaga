using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaga.Saga
{
    class Arena
    {
        List<Character> characters;
        string[] names = { "Atos", "Portos", "Aramis", "Dart Vader", "Dartanian", "Gendalf", "Goliaf", "David" };

        public Arena(int count, int seed) //random
        {
            Random random = new Random(seed);
            string[] types = { "Warrior", "Mage", "Archer" };
            characters = new List<Character>();
            for (int i = 0; i < count; i++)
            {
                int type = random.Next(0, 3);
                int hp = random.Next(80, 120);
                int strength = random.Next(20, 30);
                int name = random.Next(names.Length);

                characters.Add(Character.New(types[type], hp, strength, names[name]));
            }
        }

        Character? winner;
        public string Start()
        {
            string log = "";
            List <Character> players = characters;
            while (players.Count > 1)
            {
                List<Character> passed = new List<Character>();
                List<Pair> pairs = new List<Pair>();
                int pcount = players.Count / 2;
                for (int i = 0; i < pcount; i++)
                {
                    pairs.Add(new Pair(players[i*2], players[i*2+1]));
                }
                foreach (var pair in pairs)
                {
                    pair.FightTillEnd();
                    log += pair.GetLog();
                    var lw = pair.GetWinner();
                    log += $">----[{lw.ToString()} wins]----<\n";
                    passed.Add(lw);
                }
                players = passed;
                log += $">>>----[End of round. Players left: {players.Count}]----<<<\n\n";
            }
            winner = players[0];
            return log;
        }

        public string GetWinner()
        {
            if (winner == null)
                return "None";
            else
                return winner.ToString();
        }
    }
}
