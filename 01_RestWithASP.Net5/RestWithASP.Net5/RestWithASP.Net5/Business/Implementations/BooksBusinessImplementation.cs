using RestWithASP.Net5.Business.InterfacesBusiness;
using RestWithASP.Net5.Model;
using RestWithASP.Net5.Repository.Interfaces;
using System.Collections.Generic;

namespace RestWithASP.Net5.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IBooksRepository _repository;

        public BooksBusinessImplementation(IBooksRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Books> FindAll()
        {
            return _repository.FindAll();
        }

        public Books FindById(long Id)
        {
            return _repository.FindById(Id);
        }
        public Books Create(Books books)
        {
            return _repository.Create(books);
        }
        public Books Update(Books books)
        {
            return _repository.Update(books);
        }
        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }


    }
}
