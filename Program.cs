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
        
        int score = 0; // poängen startar på noll

        while (player.Health > 0)
        {
            Enemy enemy = GenerateRandomEnemy();
        }



        while (player.Health > 0 && currentEnemy.Health > 0) // Medans spelaren och fiende lever gäller detta
        {
            Console.WriteLine("Det är spelarens tur, välj mellan alternativen under"); // skriver ut valen
            Console.WriteLine("1. Attakera"); // väljer man 1 så attackerar man
            Console.WriteLine("2. Visa ditt liv"); // väljer man 2 visar man både ditt och fiendens liv

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

            Console.WriteLine("Vill du fortsätta (ja/nej)");
            string coutinueChoise = Console.ReadLine();
            if (coutinueChoise.ToLower()!= "Yes")
            {
                break;
            }

        }  

        static int RandomScore() // gör så man får random poäng när man vinner
        {
            Random random = new Random(); 
            return random.Next(50, 250); // gör så man får mellan 50-250 poäng när man vinner
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
