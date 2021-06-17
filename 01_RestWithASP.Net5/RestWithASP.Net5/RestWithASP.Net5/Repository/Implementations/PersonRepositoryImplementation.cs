using RestWithASP.Net5.Context;
using RestWithASP.Net5.Model;
using RestWithASP.Net5.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP.Net5.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private readonly MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext mySQLContext)
        {
            _context = mySQLContext;
        }

        public IEnumerable<Person> FindAll()
        {
            return _context.People.ToList();
        }



        public Person FindById(long Id)
        {
            return _context.People.SingleOrDefault(p => p.Id.Equals(Id));
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var _result = _context.People.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (_result != null)
            {
                try
                {
                    _context.Entry(_result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return person;
        }


        public void Delete(long Id)
        {
            var _result = _context.People.SingleOrDefault(p => p.Id.Equals(Id));

            if (_result != null)
            {
                try
                {
                    _context.People.Remove(_result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }     


        private bool Exists(long id)
        {
            return _context.People.Any(p => p.Id.Equals(id));
        }
    }
}
