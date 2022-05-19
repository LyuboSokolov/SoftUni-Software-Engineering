using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
     

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
       
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            if (decorationType == "Plant")
            {
                decoration = new Plant();
            }

            decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish currFish = null;

            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            if (fishType == "FreshwaterFish")
            {
                currFish = new FreshwaterFish(fishName,fishSpecies,price);
            }
            if (fishType == "SaltwaterFish")
            {
                currFish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            if (aquariums.FirstOrDefault(p=>p.Name == aquariumName)== null)
            {
                throw new ArgumentException("Nqma takyv akvarium");
            }
            IAquarium aquarium = aquariums.FirstOrDefault(p => p.Name == aquariumName);

            if (aquarium.GetType().Name.StartsWith("Fresh") && fishType.StartsWith("Fresh")) // TODO:
            {
                aquarium.AddFish(currFish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else if (aquarium.GetType().Name.StartsWith("Salt") && fishType.StartsWith("Salt"))
            {
                aquarium.AddFish(currFish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return "Water not suitable.";
            }

        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium= aquariums.FirstOrDefault(p => p.Name == aquariumName);
            decimal allFishPrice = aquarium.Fish.Sum(p => p.Price);
            decimal alldecorationPrice = aquarium.Decorations.Sum(p => p.Price);


            return $"The value of Aquarium {aquariumName} is {(allFishPrice+alldecorationPrice):f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            if (aquariums.FirstOrDefault(p=>p.Name == aquariumName) == null)
            {
                throw new ArgumentException("ne namira akvarium");
            }
            IAquarium aquarium = aquariums.FirstOrDefault(p => p.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count()}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (decorations.Models.FirstOrDefault(p=> p.GetType().Name == decorationType) ==null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            if (aquariums.FirstOrDefault(p=>p.Name == aquariumName) == null)
            {
                throw new InvalidOperationException("lipsva aquarium s takova ime controller");
            }

            IAquarium aquarium = aquariums.FirstOrDefault(p => p.Name == aquariumName);
            var decorationRepository = decorations.FindByType(decorationType);
            aquarium.AddDecoration(decorationRepository);
            decorations.Remove(decorationRepository);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            string result = string.Empty;

            foreach (var aquarim in aquariums)
            {
                result += aquarim.GetInfo() + Environment.NewLine;
            }

            return result.TrimEnd();
        }
    }
}
