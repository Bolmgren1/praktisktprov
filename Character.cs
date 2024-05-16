using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Linq;
class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public Character(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }
    public virtual void Attack(Character target)
    {
        Console.WriteLine($"{Name} attakerar {target.Name} för {AttackPower} skada");
        target.Health -= AttackPower;
        if (target.Health < 0)
        {
            target.Health = 0;
        }
    }
}