using RestWithASP.Net5.Model;
using System;
using System.Collections.Generic;

namespace RestWithASP.Net5.Services.Interfaces
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long Id);
        Person Update(Person person);
        IEnumerable<Person> FindAll();
        void Delete(long Id);
    }
}
