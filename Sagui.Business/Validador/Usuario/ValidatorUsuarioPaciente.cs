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
    public class ValidatorUsuarioPaciente : Validador<Model.Paciente>
    {
        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Paciente usuario)
        {

            ErrorsResult = validadorCampo.HandleValidation(usuario.PlanoOperadoraId, nameof(usuario.PlanoOperadoraId), ref ErrorsResult);


            return ErrorsResult;
        }
    }
}



