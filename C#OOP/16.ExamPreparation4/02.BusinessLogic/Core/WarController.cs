using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private List<Item> itemPool;
        public WarController()
        {
            party = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = null;

            if (characterType != "Warrior" && characterType != "Priest")
            {
                throw new ArgumentException($"Invalid character type { characterType }!");
            }
            if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            if (characterType == "Priest")
            {
                character = new Priest(name);
            }

            party.Add(character);
            return $"{name} joined the party!";

        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;

            if (itemName != "HealthPotion" && itemName != "FirePotion")
            {
                throw new ArgumentException($"{itemName} added to pool.");
            }
            if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }

            itemPool.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (party.FirstOrDefault(p => p.Name == characterName) == null) //TODO:
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            Character character = party.FirstOrDefault(p => p.Name == characterName);
            Item lastItem = itemPool[itemPool.Count - 1];
            itemPool.Remove(lastItem);
            character.Bag.AddItem(lastItem);

            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (party.FirstOrDefault(p => p.Name == characterName) == null) //TODO:
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Character character = party.FirstOrDefault(p => p.Name == characterName);
            character.Bag.GetItem(itemName);

            return $"{characterName} used {itemName}.";
        }

        public string GetStats()
        {
            string dasa;
            string sad;
            string result = string.Empty;
            foreach (var character in party.OrderByDescending(p => p.IsAlive == true).ThenByDescending(p => p.Health))
            {
                if (character.IsAlive)
                {
                    result += $"{character.Name} - HP: {character.Health}/{character.BaseHealth}," +
                   $" AP: {character.Armor}/{character.BaseArmor}, Status: Alive"
                           + Environment.NewLine;
                }
                else
                {
                    result += $"{character.Name} - HP: {character.Health}/{character.BaseHealth}," +
                    $" AP: {character.Armor}/{character.BaseArmor}, Status: Dead"
                            + Environment.NewLine;
                }
                
            }

            return result.TrimEnd(); // TODO:
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            if (party.FirstOrDefault(p => p.Name == attackerName) == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (party.FirstOrDefault(p => p.Name == receiverName) == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
           
            Warrior attacker = (Warrior)party.FirstOrDefault(p => p.Name == attackerName);
            Character receiver = party.FirstOrDefault(p => p.Name == receiverName);
            if (attacker.GetType().Name == "Priest")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attacker.Attack(receiver);

            string result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points!" +
                $" {receiverName} has {receiver.Health}/{receiver.BaseHealth}" +
                $" HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (receiver.Health<=0)
            {
                result += Environment.NewLine +$"{receiver.Name} is dead!";
            }
            return result;

        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            if (party.FirstOrDefault(p => p.Name == healerName) == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (party.FirstOrDefault(p => p.Name == healingReceiverName) == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }
            if (party.FirstOrDefault(p => p.Name == healerName).GetType().Name == "Warrior")
            {
                throw new ArgumentException( $"{healerName} cannot heal!");
            }

            Priest healer = (Priest)party.FirstOrDefault(p => p.Name == healerName);
            Character healingReceiver = party.FirstOrDefault(p => p.Name == healingReceiverName);

            healer.Heal(healingReceiver);

            return $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}!" +
                $" {healingReceiver.Name} has {healingReceiver.Health} health now!";
        }
    }
}
