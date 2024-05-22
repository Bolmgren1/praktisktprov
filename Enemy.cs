using System;
using System.Collections.Generic; 
using System.Linq;

namespace praktisktprov
{
    class Enemy : Character // klassen enemy ärver av klassen Character
    {
        public Enemy(string name, int health, int minAttackPower, int maxAttackPower) : base(name, health, minAttackPower, maxAttackPower)
        {
        }
    }

    


}