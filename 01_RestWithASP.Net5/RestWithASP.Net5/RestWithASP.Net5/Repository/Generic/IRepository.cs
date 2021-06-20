using RestWithASP.Net5.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Net5.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T person);
        T FindById(long Id);
        T Update(T person);
        IEnumerable<T> FindAll();
        void Delete(long Id);
    }
}
