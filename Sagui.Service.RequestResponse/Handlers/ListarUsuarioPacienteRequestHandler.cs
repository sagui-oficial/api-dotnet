using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Service.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ListarUsuarioPacienteRequestHandler : IBaseRequestHandler<RequestUsuarioPaciente, ResponseUsuarioPaciente>
    {
        UsuarioPacienteService usuarioPacienteService;
        private Business.Validador.Usuario.ValidatorUsuarioBase validatorUsuarioFuncionario { get; set; }
        ResponseUsuarioPaciente responseUsuarioPaciente;

        public ListarUsuarioPacienteRequestHandler(UsuarioPacienteService _usuarioService)
        {
            usuarioPacienteService = _usuarioService;
            validatorUsuarioFuncionario = new Business.Validador.Usuario.ValidatorUsuarioBase();
            responseUsuarioPaciente = new ResponseUsuarioPaciente();
        }

       
        public async Task<ResponseUsuarioPaciente> Handle(RequestUsuarioPaciente request)
        {
            var ListUsuarioPaciente = usuarioPacienteService.Listar();

            foreach (var paciente in ListUsuarioPaciente)
            {
                paciente.ListaPlanoOperadoraPaciente = usuarioPacienteService.ListarPlanoOperadoraPaciente(paciente);
                
            }

            if (ListUsuarioPaciente.Count > 0)
            {
                responseUsuarioPaciente.Pacientes = ListUsuarioPaciente;
                responseUsuarioPaciente.ExecutionDate = DateTime.Now;
                responseUsuarioPaciente.ResponseType = ResponseType.Success;
                responseUsuarioPaciente.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOListadaComSucesso));
                return responseUsuarioPaciente;
            }
            else
            {
                responseUsuarioPaciente.ExecutionDate = DateTime.Now;
                responseUsuarioPaciente.ResponseType = ResponseType.Info;
                responseUsuarioPaciente.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemProcedimentoNaoListado));
                return responseUsuarioPaciente;
            }
        }
    }
}
