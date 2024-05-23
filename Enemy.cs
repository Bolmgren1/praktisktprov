using System;
using System.Collections.Generic; 
using System.Linq;

namespace praktisktprov
{
    class Enemy : Character // klassen enemy som är fiendens bas-klass ärver av klassen Character
    {
        public Enemy(string name, int health, int minAttackPower, int maxAttackPower) : base(name, health, minAttackPower, maxAttackPower) // gör så fiende kan sätta namn, health, minsta attackvärde och max attackvärde
        {
        }
    }

    


}