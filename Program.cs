using System;

namespace GamePrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character player = new Character("Arthur", 30, 6);

            Console.WriteLine(player.Name);
            Console.WriteLine(player.Health);
            Console.WriteLine(player.MaxHealth);
            Console.WriteLine(player.BaseDamage);
        }
    }

    internal class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int BaseDamage { get; private set; }

        public Character(string name, int maxHealth, int baseDamage)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            BaseDamage = baseDamage;
        }
    }
}


