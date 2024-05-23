using System;
using System.Collections.Generic;
using System.Linq;

namespace praktisktprov
{
    class Player : Character // skapar klassen player som ärver av klassen Character
    {
        public Player(string name, int health, int minAttackPower, int maxAttackPower) : base(name, health, minAttackPower, maxAttackPower) //gör så player kan sätta namn, heatlh/hälsa, min attackvärde och max attackvärde
        {
        }
    }
}