using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using praktisktprov;
class Program
{
    
    static void Main(string[] args)
    { 
        Player player = new Player($"Player", 100, 5, 15); // skapar spelaren
        
        List<Enemy> enemies = new List<Enemy> // skapar listan för fienden
        {
            new Skelett(), // skapar fienden skelett
            new Hobbit() // skapar fienden hobbit
            
        };

        int score = 0; // poängen startar på noll

        Random random = new Random(); // skapar en random instans
        while (player.Health > 0 && enemies.Count > 0) // när spelaren och fienden lever gäller denna loop
        {
            Enemy currentEnemy = enemies[0]; // väljer första fienden i listan
            Console.WriteLine($"Du ska slåss mot {currentEnemy.Name}"); // skriver ut vilken fiende jag ska slåss mot

            while(player.Health > 0 && currentEnemy.Health > 0) // Medans spelaren och fiende lever gäller detta
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
                if (player.Health <= 0) // om spelarens liv är 0 eller under noll så händer detta 
                {
                    Console.WriteLine($"Du har dött"); // skriver ut att du har dött
                    score = 15; // poängen du får om du förlorar
                    break;
                }
                else if (currentEnemy.Health <= 0) // om spelaren dödar fienden händer detta
                {
                    Console.WriteLine($"Du vann då du döda fienden, du hade {player.Health} hp kvar!"); // Skriver ut spelaren liv och att du dödade fienden
            
                    score = random.Next(50, 250);// poängen du får för att vinna
                    enemies.RemoveAt(0); // tar bort fienden jag besegrat
                    
                    Console.WriteLine("Vill du fortsätta (ja/nej)"); // här kan man fortsätta mot nästa fiende
                    string continueChoise = Console.ReadLine(); // läser spelaren val
                    if (continueChoise.ToLower()!= "ja") // om valet inte är ja går detta igenom
                    {
                        break; // alsutar loopen
                    }
                    
                }  
            }
            
        }

        if (player.Health > 0 && enemies.Count == 0) // om spelaren är vid liv och fiende är inte vid liv
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

