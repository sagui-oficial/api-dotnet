using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Base
{
    public interface IValidador<T> where T : class
    {
        List<Tuple<dynamic, dynamic, dynamic>> HandleValidation(dynamic value, string valname, ref List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult);

        List<Tuple<dynamic, dynamic, dynamic>> HandleValidation(dynamic value1, dynamic value2);

        void SetSuccessor(T successor);
    }
}
