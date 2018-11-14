using Sagui.Business.Validador.Base;
using Sagui.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador
{
    public abstract class Validador : IValidadorBase<IBaseModel>
    {
        private ValidadorData validarData;
        private ValidadorCampo validadorCampo;

        public Validador()
        {
            validarData = new ValidadorData();
            validadorCampo = new ValidadorCampo();
        }

        public abstract List<Tuple<dynamic, dynamic, dynamic>> Validate(Validador @class);

    }
}
