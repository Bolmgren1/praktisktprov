using System;
using System.Collections.Generic;
using System.Linq;

namespace praktisktprov
{
    class Player : Character
    {
        public Player(string name, int health, int minAttackPower, int maxAttackPower) : base(name, health, minAttackPower, maxAttackPower)
        {
        }
    }
}