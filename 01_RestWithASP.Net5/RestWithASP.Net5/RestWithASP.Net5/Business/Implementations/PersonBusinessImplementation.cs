using RestWithASP.Net5.Business.InterfacesBusiness;
using RestWithASP.Net5.Model;
using RestWithASP.Net5.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASP.Net5.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long Id)
        {
            return _repository.FindById(Id);
        }
        public Person Create(Person person)
        {
           
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }     

    }
}
