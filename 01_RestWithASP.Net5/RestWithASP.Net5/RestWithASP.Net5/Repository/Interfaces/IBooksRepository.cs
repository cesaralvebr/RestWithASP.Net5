using RestWithASP.Net5.Model;
using System;
using System.Collections.Generic;

namespace RestWithASP.Net5.Repository.Interfaces
{
    public interface IBooksRepository
    {
        Books Create(Books books);
        Books FindById(long Id);
        Books Update(Books books);
        IEnumerable<Books> FindAll();
        void Delete(long Id);

    }
}
