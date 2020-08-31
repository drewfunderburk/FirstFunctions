using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        public float maxHealth;
        public float health;
        public float damage;
        public int level;
        public string name;
        public string combatClass;
        public bool isDead;


        public Player(float maxHealth, float health, float damage, int level, string name, string combatClass)
        {
            this.maxHealth = maxHealth;
            this.damage = damage;
            this.health = health;
            this.level = level;
            this.name = name;
            this.combatClass = combatClass;

            isDead = false;
        }

        public void PrintStats()
        {
            Console.WriteLine("Player Stats:");
            Console.WriteLine(name + ": Level " + level + " " + combatClass);
            Console.WriteLine(health + "/" + maxHealth + "hp | " + damage + "dmg");
        }
    }
}
