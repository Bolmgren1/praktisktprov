using System;
using System.Collections.Generic;
using System.Linq;
using praktisktprov;
class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Player", 100, 5, 15);
        Enemy enemy = new Enemy("Fiende", 80, 3, 25);
        Enemy enemy1 = new Enemy("Dvärg", 55, 2, 10);
        int score = 0;

        while (player.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine("Det är spelarens tur, välj mellan alternativen under");
            Console.WriteLine("1. Attakera");
            Console.WriteLine("2. Visa ditt liv");

            string val = Console.ReadLine();
            if (val == "1")
            {
                player.Attack(enemy);
                if (enemy.Health > 0)
                {
                    enemy.Attack(player);
                }
            }
            else if (val == "2") 
            {
                Console.WriteLine($"{player.Name} Hp: {player.Health}");
                Console.WriteLine($"{enemy.Name} Hp: {enemy.Health}");
            }
            
        }
        if (player.Health <= 0)
        {
            Console.WriteLine($"Du har dött, fiende hade {enemy.Health} hp kvar!");
            score = 15;
        }
        else if (enemy.Health <= 0)
        {
            Console.WriteLine($"Du vann då du döda fienden, du hade {player.Health} hp kvar!");
            score = 50;
        }  

        Console.WriteLine($"Dina poäng är: {score}");
        SaveScore(score);

        static void SaveScore(int score)
        {
            StreamWriter sw = new StreamWriter("Textfil.txt");
            sw.WriteLine($"Ditt poäng är: {score}");
            sw.Close();
        }

    }
}
