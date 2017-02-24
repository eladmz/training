using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial8
{
    class Warrior
    {
        // Name, Health, Attack Maximum, Block Maximum
        public string Name { get; set; } = "Warrior";
        public int Health { get; set; } = 0;
        public int MaxAttack { get; set; } = 0;
        public int MaxBlock { get; set; } = 0;
        private Random randomGenerator;

        public Warrior(string name = "Warrior", int health = 0, int maxAttack = 0, int maxBlock = 0)
        {
            Name = name;
            Health = health;
            MaxAttack = maxAttack;
            MaxBlock = maxBlock;
            randomGenerator = new Random();
        }
        // Random numbers

        // Attack
        // Generate a random attack value from 1 to maximum
        public int Attack()
        {
            return randomGenerator.Next(1, MaxAttack);
        }

        // Block
        // Generate a random block value from 1 to maximum
        public int Block()
        {
            return randomGenerator.Next(1, MaxBlock);
        }
    }
}
