using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.PlanoOperadora;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ListarPlanoOperadoraRequestHandler : IBaseRequestHandler<RequestPlanoOperadora, ResponsePlanoOperadora>
    {
        PlanoOperadoraService planoOperadoraService;
        private Business.Validador.PlanoOperadora.ValidadorPlanoOperadora validatorPlanoOperadora{ get; set; }

        ResponsePlanoOperadora responsePlanoOperadora;

        public ListarPlanoOperadoraRequestHandler(PlanoOperadoraService _planoOperadoraService)
        {
            planoOperadoraService = _planoOperadoraService;
            validatorPlanoOperadora = new Business.Validador.PlanoOperadora.ValidadorPlanoOperadora();
            responsePlanoOperadora = new ResponsePlanoOperadora();
        }

        public async Task<ResponsePlanoOperadora> Handle(RequestPlanoOperadora request)
        {
            var ListPlanoOperadora = planoOperadoraService.Listar();

            if (ListPlanoOperadora.Count > 0)
            {
                responsePlanoOperadora.PlanosOperadoras = ListPlanoOperadora;
                responsePlanoOperadora.ExecutionDate = DateTime.Now;
                responsePlanoOperadora.ResponseType = ResponseType.Success;
                responsePlanoOperadora.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOListadaComSucesso));
                return responsePlanoOperadora;
            }
            else
            {
                responsePlanoOperadora.ExecutionDate = DateTime.Now;
                responsePlanoOperadora.ResponseType = ResponseType.Info;
                responsePlanoOperadora.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemPlanoOperadoraNaoListado));
                return responsePlanoOperadora;
            }
        }
    }
}
