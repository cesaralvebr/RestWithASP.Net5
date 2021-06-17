using RestWithASP.Net5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Net5.Business.InterfacesBusiness
{
   public interface IBooksBusiness
    {
        Books Create(Books books);
        Books FindById(long Id);
        Books Update(Books books);
        IEnumerable<Books> FindAll();
        void Delete(long Id);
    }
}
