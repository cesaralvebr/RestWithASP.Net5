using RestWithASP.Net5.Data.VO;
using RestWithASP.Net5.Model;
using System;
using System.Collections.Generic;

namespace RestWithASP.Net5.Business.InterfacesBusiness
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long Id);
        PersonVO Update(PersonVO person);
        IEnumerable<PersonVO> FindAll();
        void Delete(long Id);

    }
}
