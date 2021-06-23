using RestWithASP.Net5.Business.InterfacesBusiness;
using RestWithASP.Net5.Data.Converter.Implementations;
using RestWithASP.Net5.Data.VO;
using RestWithASP.Net5.Model;
using RestWithASP.Net5.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASP.Net5.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public IEnumerable<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());          
        }

        public PersonVO FindById(long Id)
        {
            return _converter.Parse(_repository.FindById(Id));
        }
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }     

    }
}
