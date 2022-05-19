using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty."); //TODO IsNullOrEmtry ?
                }
                //TODO: all name are unique
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort { get => decorations.Sum(p => p.Comfort); }

        public ICollection<IDecoration> Decorations { get => decorations;}

        public ICollection<IFish> Fish { get => fish; }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count >= Capacity) //TODO:
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            
            foreach (var currFish in this.fish)
            {
                currFish.Eat();
            }
        }

        public string GetInfo()
        {
            string resultFish = string.Empty;

            if (this.fish.Count == 0)
            {
                 resultFish = "none";
            }
            else
            {
                List<string> names = this.fish.Select(p => p.Name).ToList();
                resultFish = $"{string.Join(", ", names).TrimEnd()}";
            }
            // "{aquariumName} ({aquariumType}):
            //Fish: { fishName1}, { fishName2}, { fishName3} (…) / none
            //Decorations: { decorationsCount}
            // Comfort: { aquariumComfort}"

            string result = $"{ this.Name} ({this.GetType().Name}):" + Environment.NewLine +
                $"Fish: {resultFish}" + Environment.NewLine +
                $"Decorations: {decorations.Count}" + Environment.NewLine +
                $"Comfort: {Comfort}";

            return result.TrimEnd();

        }

        public bool RemoveFish(IFish fish)
        {
            if (this.fish.Contains(fish))
            {
                this.fish.Remove(fish);
                return true;
            }
            return false;
        }
    }
}
