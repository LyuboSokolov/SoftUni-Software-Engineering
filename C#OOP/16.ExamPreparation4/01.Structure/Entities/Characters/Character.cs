using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double baseHealt;
        private double health;
        private double baseArmor;
        private double armor;
        private bool isAlive = true;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            baseHealt = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth
        {
            get => baseHealt;
        }

        public double Health
        {
            get => health;
             set
            {
                if (value >= baseHealt)
                {
                    health = baseHealt;
                }
                else if (value < 0)
                {
                    health = 0;
                }
            }
        }

        public double BaseArmor { get => baseArmor; }

        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    armor = 0;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive
        {
            get => isAlive;
            set
            {
                isAlive = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                hitPoints -= this.armor;
                this.armor -= hitPoints;
                

                if (hitPoints > 0)
                {
                    this.Health -= hitPoints;
                    if (this.Health <= 0)
                    {
                        Health = 0;
                        IsAlive = false;
                    }
                }
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
        }



        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}