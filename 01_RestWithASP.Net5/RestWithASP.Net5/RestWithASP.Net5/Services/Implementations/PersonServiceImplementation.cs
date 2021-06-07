using RestWithASP.Net5.Model;
using RestWithASP.Net5.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASP.Net5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long Id)
        {
            
        }

        public IEnumerable<Person> FindAll()
        {
            List<Person> people = new List<Person>();

            for(int i=0; i<8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            
            return people;
        }

       

        public Person FindById(long Id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Cesar",
                LastName = "Alves",
                Address = "Araguaina - Tocantins ",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {

            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person Lastname" + i,
                Address = "Some Address " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
