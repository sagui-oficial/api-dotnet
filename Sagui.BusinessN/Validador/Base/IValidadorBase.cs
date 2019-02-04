using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Base
{
    public  interface IValidadorBase<T> where T : class
    {
        List<Tuple<dynamic, dynamic, dynamic>> Validate(T @class);
    }
}
