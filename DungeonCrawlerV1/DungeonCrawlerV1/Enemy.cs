using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerV1
{
    public class Enemy
    {
        public string Name;
        public int Attack;

        string[] Names = new string[5] { "Skeleton", "Zombie", "Bandit", "Knight", "Wolf" };

        public Enemy(int RandomName, int RandomAttack)
        {
            this.Name = Names[RandomName];
            this.Attack = RandomAttack;
        }

        public string getName()
        {
            return Name;
        }
        public int getNamesLength()
        {
            return Names.Length;
        }

        public int getAttack()
        {
            return Attack;
        }
        public string Introduction()
        {
            string intro = this.getName() + " approaches and attacks you with " + this.getAttack();
            return intro;

        }
    }
}
