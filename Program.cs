using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using praktisktprov;
class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Player", 100, 5, 15); // Skapar spelaren
        Enemy currentEnemy = null; // visar att just nu är det ingen fiende vald
        int score = 0; // poängen startar på noll


        Console.WriteLine("Välj vilen fiende du vill möta"); // här får man välja vilken fiende man ska möta
        Console.WriteLine("1. Skelett");
        Console.WriteLine("2. Hobbit ");

        string enemyVal = Console.ReadLine(); // läser vilket val man gör

        if (enemyVal == "1") // om man väljer val 1
        {
            currentEnemy = new Skelett(); // visar att fienden är skelett
        }
        else // om man inte väljer 1 så blir det denna automatiskt
        {
            currentEnemy = new Hobbit(); // visar att fienden är hobbit
        }


        while (player.Health > 0 && currentEnemy.Health > 0) // Medans spelaren och fiende lever gäller detta
        {
            Console.WriteLine("Det är spelarens tur, välj mellan alternativen under"); // skriver ut valen
            Console.WriteLine("1. Attakera");
            Console.WriteLine("2. Visa ditt liv");

            string val = Console.ReadLine(); //läser om du väljer val 1 eller 2
            if (val == "1") // när man väljer 1
            {
                player.Attack(currentEnemy);// spelaren attakerar fiende
                if (currentEnemy.Health > 0) // om fiende lever gäller detta
                {
                    currentEnemy.Attack(player); //fiende attakerar spelare
                }
            }
            else if (val == "2")  // om man valde val 2
            {
                Console.WriteLine($"{player.Name} Hp: {player.Health}"); //skriver ut spelarens liv
                Console.WriteLine($"{currentEnemy.Name} Hp: {currentEnemy.Health}"); // skriver ut fiendens liv
            }
            
        }
        if (player.Health <= 0) // om spelarens liv är 0 eller under noll så händer detta 
        {
            Console.WriteLine($"Du har dött, fiende hade {currentEnemy.Health} hp kvar!"); // skriver ut att du har dött
            score = 15; // poängen du får om du förlorar
        }
        else if (currentEnemy.Health <= 0) // om spelaren dödar fienden händer detta
        {
            Console.WriteLine($"Du vann då du döda fienden, du hade {player.Health} hp kvar!"); // Skriver ut spelaren liv och att du dödade fienden
            
            score = RandomScore();// poängen du får för att vinna

        }  

        static int RandomScore()
        {
            Random random = new Random();
            return random.Next(50, 250);
        }

        Console.WriteLine($"Dina poäng är: {score}"); // Skriver ut dina poäng du får
        SaveScore(score); // sparar poängen

        static void SaveScore(int score) // För att lägga upp poängen i en fil
        {
            StreamWriter sw = new StreamWriter("Textfil.txt",true); // Väljer vilken fil som poängen läggs till i
            sw.WriteLine($"Ditt poäng är: {score}"); // Skriver ut ditt poäng i text filen
            sw.Close(); // stänger filen
        }

    }
}
