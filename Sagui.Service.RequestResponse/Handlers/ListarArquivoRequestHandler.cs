using Sagui.Base.Utils;
using Sagui.Service.Arquivo;
using Sagui.Service.Contracts;
using Sagui.Service.GTO;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ListarArquivoRequestHandler : IBaseRequestHandler<RequestArquivo, ResponseArquivo>
    {
        ArquivoService ArquivoService;
        ResponseArquivo responseArquivo;

        public ListarArquivoRequestHandler(ArquivoService _ArquivoService)
        {
            ArquivoService = _ArquivoService;
            responseArquivo = new ResponseArquivo();
        }

        public async Task<ResponseArquivo> Handle(RequestArquivo request)
        {
            var ListArquivo = ArquivoService.Listar();

            if (ListArquivo.Count > 0)
            {
                responseArquivo.Arquivos = ListArquivo;
                responseArquivo.ExecutionDate = DateTime.Now;
                responseArquivo.ResponseType = ResponseType.Success;
                responseArquivo.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(Arquivo), Constantes.MensagemArquivoListadoComSucesso));
                return responseArquivo;
            }
            else
            {
                responseArquivo.ExecutionDate = DateTime.Now;
                responseArquivo.ResponseType = ResponseType.Error;
                responseArquivo.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(Arquivo), Constantes.MensagemArquivoNaoListado));
                return responseArquivo;
            }
        }
    }
}
