using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawlerV1
{
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
