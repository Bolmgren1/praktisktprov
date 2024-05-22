using System;
using System.Collections.Generic;
using System.Linq;
using praktisktprov;
class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Player", 100, 5, 15); // Skapar spelaren
        Enemy enemy = new Enemy("Fiende", 80, 3, 25); // skapar fiende
        Enemy enemy1 = new Enemy("Hobbit", 55, 2, 10); // gör möjlighet för ett till fiende som är hobbit
        int score = 0;

        while (player.Health > 0 && enemy.Health > 0) // Medans spelaren och fiende lever gäller detta
        {
            Console.WriteLine("Det är spelarens tur, välj mellan alternativen under"); // skriver ut valen
            Console.WriteLine("1. Attakera");
            Console.WriteLine("2. Visa ditt liv");

            string val = Console.ReadLine(); //läser om du väljer val 1 eller 2
            if (val == "1") // när man väljer 1
            {
                player.Attack(enemy);// spelaren attakerar fiende
                if (enemy.Health > 0) // om fiende lever gäller detta
                {
                    enemy.Attack(player); //fiende attakerar spelare
                }
            }
            else if (val == "2")  // om man valde val 2
            {
                Console.WriteLine($"{player.Name} Hp: {player.Health}"); //skriver ut spelarens liv
                Console.WriteLine($"{enemy.Name} Hp: {enemy.Health}"); // skriver ut fiendens liv
            }
            
        }
        if (player.Health <= 0) // om spelarens liv är 0 eller under noll så händer detta 
        {
            Console.WriteLine($"Du har dött, fiende hade {enemy.Health} hp kvar!"); // skriver ut att du har dött
            score = 15; // poängen du får om du förlorar
        }
        else if (enemy.Health <= 0) // om spelaren dödar fienden händer detta
        {
            Console.WriteLine($"Du vann då du döda fienden, du hade {player.Health} hp kvar!"); // Skriver ut spelaren liv och att du dödade fienden
            score = 50; // poängen du får för att vinna
        }  

        Console.WriteLine($"Dina poäng är: {score}"); // Skriver ut dina poäng du får
        SaveScore(score); // sparar poängen

        static void SaveScore(int score) // För att lägga upp poängen i en fil
        {
            StreamWriter sw = new StreamWriter("Textfil.txt"); // Väljer vilken fil som poängen läggs till i
            sw.WriteLine($"Ditt poäng är: {score}"); // Skriver ut ditt poäng i text filen
            sw.Close(); // stänger filen
        }

    }
}
