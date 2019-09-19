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
            var ListUsuarioPaciente = usuarioPacienteService.Listar(request);

            //foreach (var paciente in ListUsuarioPaciente)
            //{
            //    paciente.ListaPlanoOperadoraPaciente = usuarioPacienteService.ListarPlanoOperadoraPaciente(paciente);
                
            //}

            if (ListUsuarioPaciente.Count > 0)
            {
                responseUsuarioPaciente.paging = ListUsuarioPaciente[0].paging;

                foreach (Model.Paciente p in ListUsuarioPaciente)
                {
                    p.paging = null;

                }
                                
                responseUsuarioPaciente.Pacientes = ListUsuarioPaciente;
                responseUsuarioPaciente.ExecutionDate = DateTime.Now;
                responseUsuarioPaciente.ResponseType = ResponseType.Success;
                responseUsuarioPaciente.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(responseUsuarioPaciente.Paciente),
                       String.Format(Constantes.MensagemListadaComSucesso, nameof(responseUsuarioPaciente.Paciente))));

                
                return responseUsuarioPaciente;
            }
            else
            {
                responseUsuarioPaciente.ExecutionDate = DateTime.Now;
                responseUsuarioPaciente.ResponseType = ResponseType.Info;
                

                responseUsuarioPaciente.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(responseUsuarioPaciente.Paciente),
                       String.Format(Constantes.MensagemNaoListada, nameof(responseUsuarioPaciente.Paciente))));

                return responseUsuarioPaciente;
            }
        }
    }
}
