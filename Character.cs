using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Linq;
class Character 
{
    public string Name { get; set; } // karaktärens namn
    public int Health { get; set; } // karaktärens hälsa
    public int MinAttackPower { get; set; } // hämtar minsta attackvärde

    public int MaxAttackPower { get; set; } // hämtar högsta attackvärde

    private static Random random = new Random(); // skapar en instans för attackvärdet
    public Character(string name, int health, int minAttackPower, int maxAttackPower) // instruktor för att initiera karaktären
    {
        Name = name; // sätter karaktärens namn
        Health = health; // sätter karaktärens liv/hälsa
        MinAttackPower = minAttackPower; // sätter minsta attackvärde
        MaxAttackPower = maxAttackPower; // sätter högsta attackvärde
    }
    public virtual void Attack(Character target) // metoden för att kunna göra skada på en annan karaktär
    {
        int damage = random.Next(MinAttackPower, MaxAttackPower + 1); // gör så skadan är mellan minsta skada och maxskada 
        Console.WriteLine($"{Name} attakerar {target.Name} för {damage} skada"); // skriver ut namnet på karaktären och hur mycket den skadar osv
        target.Health -= damage; // är då karaktärens liv minus skadan
        if (target.Health < 0) // när då karaktärens liv är under 0 så är karaktärens liv 0
        {
            target.Health = 0; // om då livet är under noll så blir det noll, alltså karaktären är död
        }
    }
}