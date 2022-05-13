using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
   public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> models;

        public List<IDriver> Models { get => models; }

        public void Add(IDriver model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return Models.AsReadOnly();
        }

        public IDriver GetByName(string name)
        {
            return models.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IDriver model)
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

