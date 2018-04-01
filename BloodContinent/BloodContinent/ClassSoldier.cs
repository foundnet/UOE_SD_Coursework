using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodContinent
{
    class Stats
    {
        public int move;
        public int flight;
        public int shoot;
        public int armour;
        public int morale;
        public int health;
        public int cost;

        public Stats()
        {
            Random rd = new Random();
            move = rd.Next(1, 100);
            flight = rd.Next(1, 100);
            shoot = rd.Next(1, 100);
            armour = rd.Next(1, 100);
            morale = rd.Next(1, 100);
            health = 100;
            cost = rd.Next(1, 100);
         }
    }

    // The base class of Captain and Hero
    class ClassSoldier
    {
        public Stats stats;
        public string notes;

        public ClassSoldier()
        {
            stats = new Stats();
        }
    }
}
