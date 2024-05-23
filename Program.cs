using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using praktisktprov;
class Program
{
    List<Enemy> enemies;

    static void Main()
    {
        Program program = new Program();
        program.MainGameLoop();
    }
    public void MainGameLoop()
    {
        Player player = new Player("Player", 100, 5, 15); // Skapar spelaren
        
        enemies = new List<Enemy>();
        {
            new Skelett();
            new Hobbit();
        }
        
        Console.Write(enemies.Count);
        int score = 0; // poängen startar på noll

        Random random = new Random();
        
        while (player.Health > 0 && enemies[0].Health> 0)
        {
            
            Console.WriteLine($"Du ska slåss mot {enemies[0].Name}");

            while(player.Health > 0 && enemies[0].Health > 0) // Medans spelaren och fiende lever gäller detta
            {
                Console.WriteLine("Det är spelarens tur, välj mellan alternativen under"); // skriver ut valen
                Console.WriteLine("1. Attakera"); // väljer man 1 så attackerar man
                Console.WriteLine("2. Visa ditt liv"); // väljer man 2 visar man både ditt och fiendens liv

                string val = Console.ReadLine(); //läser om du väljer val 1 eller 2
                if (val == "1") // när man väljer 1
                {
                    player.Attack(enemies[0]);// spelaren attakerar fiende
                    if (enemies[0].Health > 0) // om fiende lever gäller detta
                    {
                        enemies[0].Attack(player); //fiende attakerar spelare
                    }
                }
                else if (val == "2")  // om man valde val 2
                {
                    Console.WriteLine($"{player.Name} Hp: {player.Health}"); //skriver ut spelarens liv
                    Console.WriteLine($"{enemies[0].Name} Hp: {enemies[0].Health}"); // skriver ut fiendens liv
                }
                if (player.Health <= 0) // om spelarens liv är 0 eller under noll så händer detta 
                {
                    Console.WriteLine($"Du har dött"); // skriver ut att du har dött
                    score = 15; // poängen du får om du förlorar
                    break;
                }
                else if (enemies[0].Health <= 0) // om spelaren dödar fienden händer detta
                {
                    Console.WriteLine($"Du vann då du döda fienden, du hade {player.Health} hp kvar!"); // Skriver ut spelaren liv och att du dödade fienden
            
                    score = random.Next(50, 250);// poängen du får för att vinna
                    enemies.RemoveAt(0);
                    
                    Console.WriteLine(enemies[0].Health + "Vill du fortsätta (ja/nej)");
                    string continueChoise = Console.ReadLine();
                    if (continueChoise.ToLower()!= "ja")
                    {
                        break;
                    }
                    
                }  
            }
            
        }

        if (player.Health > 0 && enemies.Count == 0)
        {
            Console.WriteLine("Du har dödat alla fiender");
        }

        Console.WriteLine($"Dina poäng är: {score}"); // Skriver ut dina poäng du får
        SaveScore(score); // sparar poängen
    }

    

    static void SaveScore(int score) // För att lägga upp poängen i en fil
    {
        StreamWriter sw = new StreamWriter("Textfil.txt",true); // Väljer vilken fil som poängen läggs till i
        sw.WriteLine($"Ditt poäng är: {score}"); // Skriver ut ditt poäng i text filen
        sw.Close(); // stänger filen
    }

}

