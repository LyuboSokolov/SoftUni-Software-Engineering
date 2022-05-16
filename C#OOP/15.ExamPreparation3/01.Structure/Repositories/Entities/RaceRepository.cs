using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public List<IRace> Models { get => models; }

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return Models.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            return models.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IRace model)
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

