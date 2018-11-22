using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Base
{
    public interface IValidadorBaseCampo
    {
        List<Tuple<dynamic, dynamic, dynamic>> HandleValidation(dynamic value, string namevalue, ref List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult);
    }
}
