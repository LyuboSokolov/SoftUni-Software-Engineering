using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count => data.Count;


        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet currPet = data.FirstOrDefault(p => p.Name == name);

            if (currPet != null)
            {
                data.Remove(currPet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            if (data.FirstOrDefault(x => x.Name == name && x.Owner == owner) == null)
            {
                return null;
            }

            return data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            string res = "The clinic has the following patients:";
            foreach (var pet in data)
            {
                res += Environment.NewLine + $"Pet {pet.Name} with owner: {pet.Owner}";
            }
            return res;
        }
    }
}

