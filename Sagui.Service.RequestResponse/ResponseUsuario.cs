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
        public Model.Funcionario Funcionario { get; set; }
        public List<Model.Funcionario> Funcionarios { get; set; }
    }

    public class ResponseUsuarioDentista : ResponseBase
    {
        public Model.Dentinsta Dentinsta { get; set; }
        public List<Model.Dentinsta> Dentinstas { get; set; }
    }

    public class ResponseUsuarioPaciente : ResponseBase
    {
        public Model.Paciente Paciente { get; set; }
        public List<Model.Paciente> Pacientes { get; set; }
    }
}
