using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Linq;
class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int MinAttackPower { get; set; }

    public int MaxAttackPower { get; set; }

    private static Random random = new Random();
    public Character(string name, int health, int minAttackPower, int maxAttackPower)
    {
        Name = name;
        Health = health;
        MinAttackPower = minAttackPower;
        MaxAttackPower = maxAttackPower;
    }
    public virtual void Attack(Character target)
    {
        int damage = random.Next(MinAttackPower, MaxAttackPower + 1);
        Console.WriteLine($"{Name} attakerar {target.Name} för {damage} skada");
        target.Health -= damage;
        if (target.Health < 0)
        {
            target.Health = 0;
        }
    }
}