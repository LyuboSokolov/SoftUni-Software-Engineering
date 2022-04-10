using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            Familys = new List<Person>();
        }

        public List<Person> Familys { get; set; }



        public void AddMember(Person member)
        {
            Familys.Add(member);
        }

        public Person GetOldestMember()
        {
            return Familys.OrderByDescending(x => x.Age).First();
        }

        public List<Person> GetAllPeopleAbove()
        {
            return Familys.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
        }
    }
}
