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
        private MySQLContext _mySQLContext;

        public PersonRepositoryImplementation(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }

        public IEnumerable<Person> FindAll()
        {
            return _mySQLContext.People.ToList();
        }



        public Person FindById(long Id)
        {
            return _mySQLContext.People.SingleOrDefault(p => p.Id.Equals(Id));
        }
        public Person Create(Person person)
        {
            try
            {
                _mySQLContext.Add(person);
                _mySQLContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();


            var _result = _mySQLContext.People.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (_result != null)
            {
                try
                {
                    _mySQLContext.Entry(_result).CurrentValues.SetValues(person);
                    _mySQLContext.SaveChanges();
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
            var _result = _mySQLContext.People.SingleOrDefault(p => p.Id.Equals(Id));

            if (_result != null)
            {
                try
                {
                    _mySQLContext.People.Remove(_result);
                    _mySQLContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }     


        private bool Exists(long id)
        {
            return _mySQLContext.People.Any(p => p.Id.Equals(id));
        }
    }
}
