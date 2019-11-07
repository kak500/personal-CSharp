using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiverseArrays
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CebulPunk 2019 ver 0.2";
            Console.ForegroundColor = ConsoleColor.White;

            //Config

            int Health = 100;
            int Mana = 100;

            int HealAmount = 20;
            int HealManaCost = 25;
            int CountRounds = 1;
            int ExperienceAmount = 20;

            // Nadawanie imienia
            string Name;
            Console.Write("Enter your name: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            // Tworzenie gracza
            Player Player = new Player(Name, Health, Mana);
            Console.WriteLine(Player.Introduction());

            Console.WriteLine("Continue");
            Console.ReadKey();
            Console.Clear();

            Random rnd = new Random();

            while (Player.Health != 0)
            {
                Console.WriteLine("-----Fight {0}-----", CountRounds);

                int RandomName = rnd.Next(0, 4);
                int EnemyAttack = rnd.Next(0, 100);

                // Tworzenie przeciwnika
                Enemy Enemy = new Enemy(RandomName, EnemyAttack);


                Console.WriteLine(Enemy.Introduction());

                int PlayerAttack = rnd.Next(0, 100);
                Console.WriteLine("You attack with: {0}", PlayerAttack);
                if (PlayerAttack >= Enemy.getAttack())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congrats you won this fight\nYou gain {0} points of Experience", ExperienceAmount);
                    Console.ForegroundColor = ConsoleColor.White;
                    Player.Experience = Player.Experience + ExperienceAmount;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oh no you lost this fight\nYou loose {0} Health points", Enemy.Attack / 2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Player.Health = Player.Health - (Enemy.Attack / 2);
                }

                CountRounds++; // Licznik rund

                Console.WriteLine(Player.Status());
                //Warunek wygranej
                if (Player.Experience == 100)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Player.LevelUp();
                    //Console.WriteLine("Congrats you beat up the game");
                    Console.WriteLine("Level Up");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                // Warunek przegranej
                if (Player.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("YOU DIED");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                Console.WriteLine("------------");

                // Wybranie działania

                Console.WriteLine("Fight - press any key \nHeal Mana cost = {0}", HealManaCost);
                string Choice = Console.ReadLine();

                // Leczenie
                if (Choice == "Heal" || Choice == "heal")
                {
                    if (Player.Mana == 0)
                    {
                        Console.WriteLine("Your mana is too low to perform heal");
                    }
                    Player.Heal(ref Player.Health, ref Player.Mana, HealAmount, HealManaCost);
                    Console.WriteLine(Player.Status());
                    Console.Write("\nFight\n");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                }
            }
            Console.ReadKey();
        }
    }
}
