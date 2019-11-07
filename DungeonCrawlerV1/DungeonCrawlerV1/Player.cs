using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerV1
{
    public class Player
    {
        public string Name;
        public int Health;
        public int Mana;
        public int Experience;
        public int Level;
        public int Attack;

        public Player(string Name, int Health, int Mana)
        {
            this.Health = Health;
            this.Mana = Mana;
            this.Experience = 0;
            this.Level = 1;
            this.Name = Name;
        }

        public int getHealth()
        {
            return Health;
        }

        public int getExperience()
        {
            return Experience;
        }

        public string getName()
        {
            return Name;
        }

        public int getMana()
        {
            return Mana;
        }
        public string Introduction()
        {

            return "Welcome " + this.getName() + " on the beginning of your journey\n" +
                "You start with " + this.getHealth() + " Health Points " + this.getMana() + " Mana Points \nand " + this.getExperience() + " Experience\n" +
                "You'll gather more Experience killing monsters\n" +
                "Have fun!";
        }

        public void Heal(ref int CurrentHealth, ref int CurrentMana, int HealAmount, int ManaCost)
        {
            if (CurrentMana != 0)
            {
                CurrentHealth = CurrentHealth + ((HealAmount * this.Level));
                CurrentMana = CurrentMana - ((ManaCost * this.Level) / 2);
                Console.WriteLine("You're healed that costed you {0} Mana", ManaCost);
            }
        }

        public void LevelUp()
        {
            this.Level++;
            this.Mana = this.Mana + (25 * this.Level);
            this.Experience = 0;
        }

        public string Status()
        {
            string Status = "-----Status-----\nYour Level: " + this.Level + "\nYour current Health: " + this.Health + "\nYour current Mana: " + this.Mana + "\nYour current Experience: " + this.Experience;
            return Status;
        }

    }
}
