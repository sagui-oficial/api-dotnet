using Sagui.Business.Validador.Base;
using Sagui.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador
{
    public abstract class Validador<T> : IValidadorBase<T> where T : BaseModel
    {
        protected ValidadorData validarData;
        protected ValidadorCampo validadorCampo;
        protected List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult;

        public Validador()
        {
            validarData = new ValidadorData();
            validadorCampo = new ValidadorCampo();
            ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();
        }

        public abstract List<Tuple<dynamic, dynamic, dynamic>> Validate(T @class);
    }
}
