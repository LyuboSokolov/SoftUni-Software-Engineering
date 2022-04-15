using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            data = new List<Racer>();
            Name = name;
            Capacity = capacity;

        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;
        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer currRacer = data.FirstOrDefault(x => x.Name == name);
            if (currRacer == null)
            {
                return false;
            }

            data.Remove(currRacer);
            return true;
        }

        public Racer GetOldestRacer()
        {
            Racer currRacer = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return currRacer;
        }

        public Racer GetRacer(string name)
        {
            Racer currRacer = data.FirstOrDefault(x => x.Name == name);
            return currRacer;
        }

        public Racer GetFastestRacer()
        {
            Racer currRacer = data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
            return currRacer;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var currRacer in data)
            {
                sb.AppendLine($"{currRacer.ToString()}");
            }
            return sb.ToString();

        }
    }
}
