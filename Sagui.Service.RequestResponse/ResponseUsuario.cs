using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponseUsuarioFuncionario : ResponseBase
    {
        public Model.Funcionario Usuario { get; set; }
        public List<Model.Funcionario> Usuarios { get; set; }
    }

    public class ResponseUsuarioDentista : ResponseBase
    {
        public Model.Dentinsta Usuario { get; set; }
        public List<Model.Dentinsta> Usuarios { get; set; }
    }
}
