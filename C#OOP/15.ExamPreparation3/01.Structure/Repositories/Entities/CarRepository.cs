using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public List<ICar> Models { get => models; }

        public void Add(ICar model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return Models.AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            return models.FirstOrDefault(p => p.Model == name);
        }

        public bool Remove(ICar model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
