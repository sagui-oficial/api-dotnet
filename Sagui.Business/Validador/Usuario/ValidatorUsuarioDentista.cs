using Sagui.Business.Validador.Base;
using Sagui.Model;
using Sagui.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Usuario
{
    public class ValidatorUsuarioDentista : Validador<Model.Dentinsta>
    {
        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Dentinsta usuario)
        {
            ErrorsResult = validadorCampo.HandleValidation(usuario.CRO, nameof(usuario.Anotacoes), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}



