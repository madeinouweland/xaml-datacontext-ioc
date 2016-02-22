using System.Collections.Generic;
using System.Linq;

namespace DataContextIoC
{
    public class PersonRepository
    {
        public List<Person> Persons { get; } = new List<Person>();
        public PersonRepository()
        {
            for (int i = 0; i < 5; i++)
            {
                Persons.Add(new Person(i, "Pietje " + i));
            }
        }

        public Person ById(int id)
        {
            return Persons.First(p => p.Id == id);
        }
    }
}
