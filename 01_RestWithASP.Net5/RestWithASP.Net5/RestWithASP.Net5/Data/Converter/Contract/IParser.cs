using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Net5.Data.Converter.Contract
{
    interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> Parse(IEnumerable<O> origin);
    }
}
