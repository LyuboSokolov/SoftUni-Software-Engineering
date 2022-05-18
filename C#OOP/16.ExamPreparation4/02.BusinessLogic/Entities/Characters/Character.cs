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

        private double health;

        private double armor;
        private bool isAlive = true;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
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

        public double BaseHealth { get; }


        public double Health
        {
            get => health;
            set
            {
                if (value >= BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
              
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
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
                if (Armor > 0)
                {
                    if (hitPoints <= armor)
                    {

                        this.Armor = Armor - hitPoints;
                        hitPoints = 0;
                    }
                    else
                    {
                        hitPoints = hitPoints - armor;
                        Armor = 0;

                    }

                }
                else
                {
                    armor = 0;
                }



                if (hitPoints > 0)
                {
                    double healt = Health - hitPoints;
                    this.Health = healt;
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