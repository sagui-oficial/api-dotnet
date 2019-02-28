using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.Usuario;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ObterUsuarioFuncionarioRequestHandler : IBaseRequestHandler<RequestUsuarioFuncionario, ResponseUsuarioFuncionario>
    {
        UsuarioFuncionarioService UsuarioFuncionarioService;
        private Business.Validador.Procedimentos.ValidatorProcedimento ValidatorProcedimento { get; set; }

        ResponseUsuarioFuncionario responseUsuarioFuncionario;

        public ObterUsuarioFuncionarioRequestHandler(UsuarioFuncionarioService _ProcedimentoService)
        {
            UsuarioFuncionarioService = _ProcedimentoService;
            ValidatorProcedimento = new Business.Validador.Procedimentos.ValidatorProcedimento();
            responseUsuarioFuncionario = new ResponseUsuarioFuncionario();
        }

        public async Task<ResponseUsuarioFuncionario> Handle(RequestUsuarioFuncionario request)
        {
            var procedimento = UsuarioFuncionarioService.(request);

            if (procedimento.IdProcedimento > 0)
            {
                responseProcedimento.Procedimento = procedimento;
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Success;
                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOObtidacomSucesso));
                return responseProcedimento;
            }
            else
            {
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Error;
                responseProcedimento.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemGTONaoObtidacomSucesso));
                return responseProcedimento;
            }
        }
    }
}
