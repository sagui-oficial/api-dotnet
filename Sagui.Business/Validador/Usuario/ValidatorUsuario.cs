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
    public class ValidatorUsuario : Validador<Model.Usuario>
    {
        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Usuario usuario)
        {
            ErrorsResult = validadorCampo.HandleValidation(usuario.Anotacoes, nameof(usuario.Anotacoes), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(usuario.Funcao, nameof(usuario.Funcao), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(usuario.Nome, nameof(usuario.Nome), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(usuario.CPF, nameof(usuario.CPF), ref ErrorsResult);

            ErrorsResult = validadorCampo.HandleValidation(usuario.Email, nameof(usuario.Email), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}



