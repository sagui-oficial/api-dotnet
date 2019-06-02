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
    public class ValidatorUsuarioBase : Validador<Model.UsuarioBase>
    {
        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.UsuarioBase usuario)
        {
            ErrorsResult = validadorCampo.HandleValidation(usuario.Funcao, nameof(usuario.Funcao), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(usuario.Nome, nameof(usuario.Nome), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(usuario.CPF, nameof(usuario.CPF), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(usuario.Email, nameof(usuario.Email), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(usuario.Email, nameof(usuario.Telefone), ref ErrorsResult);

            Sagui.Base.Utils.ValidadorCPF.Validar(usuario.CPF, nameof(usuario.CPF), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}



