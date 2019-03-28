using Sagui.Base.Utils;
using Sagui.Service.Arquivo;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ObterArquivoGTORequestHandler : IBaseRequestHandler<RequestArquivoGTO, ResponseArquivoGTO>
    {
        ArquivoService ArquivoService;

        ResponseArquivoGTO responseArquivo;

        public ObterArquivoGTORequestHandler(ArquivoService _ArquivoService)
        {
            ArquivoService = _ArquivoService;
            responseArquivo = new ResponseArquivoGTO();
        }

        public async Task<ResponseArquivoGTO> Handle(RequestArquivoGTO request)
        {
            var Arquivo = ArquivoService.ObterArquivoGTOPorPublicId(request);



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
