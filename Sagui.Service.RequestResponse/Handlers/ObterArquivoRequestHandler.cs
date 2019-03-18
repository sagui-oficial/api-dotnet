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
    public class ObterArquivoRequestHandler : IBaseRequestHandler<RequestArquivo, ResponseArquivo>
    {
        ArquivoService ArquivoService;

        ResponseArquivo responseArquivo;

        public ObterArquivoRequestHandler(ArquivoService _ArquivoService)
        {
            ArquivoService = _ArquivoService;
            responseArquivo = new ResponseArquivo();
        }

        public async Task<ResponseArquivo> Handle(RequestArquivo request)
        {
            var Arquivo = ArquivoService.Obter(request);

            if (Arquivo.Id > 0)
            {
                responseArquivo.Arquivo = Arquivo;
                responseArquivo.ExecutionDate = DateTime.Now;
                responseArquivo.ResponseType = ResponseType.Success;
                responseArquivo.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(Arquivo), Constantes.MensagemArquivoObtidocomSucesso));
                return responseArquivo;
            }
            else
            {
                responseArquivo.ExecutionDate = DateTime.Now;
                responseArquivo.ResponseType = ResponseType.Error;
                responseArquivo.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(Arquivo), Constantes.MensagemArquivoNaoObtidocomSucesso));
                return responseArquivo;
            }
        }
    }
}
