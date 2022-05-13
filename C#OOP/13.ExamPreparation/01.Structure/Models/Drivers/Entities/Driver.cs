using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private bool canParticipate;
        private ICar car;

        public Driver(string name)
        {
            Name = name;
            canParticipate = false;
            
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Car cannot be null.");
                }
                car = value;
                canParticipate = true;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate  // TODO:
        {
            get => canParticipate;


        }

        public void AddCar(ICar car)
        {
            Car = car;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
