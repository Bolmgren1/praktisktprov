using System;
using System.Collections.Generic;
using System.Linq;
using praktisktprov;
class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Player", 100, 10);
        Enemy enemy = new Enemy("Fiende", 50,8);

        while (player.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine("Det är spelarens tur, välj mellan alternativen under");
            Console.WriteLine("1. Attakera");
            Console.WriteLine("2. Visa ditt liv");

            string val = Console.ReadLine();
            if (val == "1")
            {
                player.Attack(enemy);
            }
            else if (val == "2") 
            {
                Console.WriteLine($"{player.Name} Hp: {player.Health}");
                Console.WriteLine($"{enemy.Name} Hp: {enemy.Health}");
            }
            if (enemy.Health > 0)
            {
                enemy.Attack(player);
            }
        }
        if (player.Health <= 0)
        {
            Console.WriteLine("Du har dött");
        }
        else if (enemy.Health <= 0)
        {
            Console.WriteLine("Du vann då du döda fienden");
        }  

    }
}
