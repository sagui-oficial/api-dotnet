using Sagui.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class RequestUsuarioFuncionario : Model.Funcionario
    {

    }

    public class RequestUsuarioDentista : Model.Dentinsta
    {

    }

    public class RequestUsuarioPaciente : Model.Paciente
    {
      public PagingParameter paging;
    }
}
