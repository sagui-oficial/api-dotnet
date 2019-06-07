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
    public class ObterArquivoPlanoOperadoraRequestHandler : IBaseRequestHandler<RequestArquivoPlanoOperadora, ResponseArquivoPlanoOperadora>
    {
        ArquivoService ArquivoService;

        ResponseArquivoPlanoOperadora responseArquivo;

        public ObterArquivoPlanoOperadoraRequestHandler(ArquivoService _ArquivoService)
        {
            ArquivoService = _ArquivoService;
            responseArquivo = new ResponseArquivoPlanoOperadora();
        }

        public async Task<ResponseArquivoPlanoOperadora> Handle(RequestArquivoPlanoOperadora request)
        {
            var Arquivo = ArquivoService.ObterArquivoPlanoOperadoraPorPublicId(request);

            if (Arquivo.Id > 0)
            {
                responseArquivo.Arquivo = Arquivo;
                responseArquivo.ExecutionDate = DateTime.Now;
                responseArquivo.ResponseType = ResponseType.Success;
                
                responseArquivo.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ObterComSucesso, nameof(responseArquivo.Arquivo),
                 String.Format(Constantes.MensagemObtidacomSucesso, nameof(responseArquivo.Arquivo))));

                return responseArquivo;
            }
            else
            {
                responseArquivo.ExecutionDate = DateTime.Now;
                responseArquivo.ResponseType = ResponseType.Error;
                
                responseArquivo.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoObter, nameof(responseArquivo.Arquivo),
                 String.Format(Constantes.MensagemNaoObtidacomSucesso, nameof(responseArquivo.Arquivo))));

                return responseArquivo;
            }
        }
    }
}
