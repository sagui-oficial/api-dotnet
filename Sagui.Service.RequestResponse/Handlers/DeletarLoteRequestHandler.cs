using Sagui.Base.Utils;
using Sagui.Service.Contracts;
using Sagui.Service.Lote;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class DeletarLoteRequestHandler : IBaseRequestHandler<RequestLote, ResponseLote>
    {
        private LoteService LoteService;

        private Business.Validador.Lote.ValidadorLote validadorLote { get; set; }

        ResponseLote responseLote;

        public DeletarLoteRequestHandler(LoteService _LoteService)
        {
            LoteService = _LoteService;
            validadorLote = new Business.Validador.Lote.ValidadorLote();
            responseLote = new ResponseLote();
        }

        public async Task<ResponseLote> Handle(RequestLote Lote)
        {
            var errors = new object(); //validadorLote.Validate(Lote);

            //if (errors.Count() == 0)
            //{
                var _Lote = LoteService.Deletar(Lote);

                if (_Lote.PublicID != null)
                {
                    responseLote.ExecutionDate = DateTime.Now;
                    responseLote.ResponseType = ResponseType.Success;
                    responseLote.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.DeletadaComSucesso, nameof(responseLote.Lote),
                        String.Format(Constantes.MensagemDeletada, nameof(responseLote.Lote))));
                    return responseLote;


            }
                else
                {
                    responseLote.ExecutionDate = DateTime.Now;
                    responseLote.ResponseType = ResponseType.Error;
                    responseLote.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoDeletada, nameof(responseLote.Lote),
                               String.Format(Constantes.MensagemNaoDeletada, nameof(responseLote.Lote))));
                    return responseLote;


            }
            //}
            //else
            //{
            //    responseLote.ExecutionDate = DateTime.Now;
            //    responseLote.ResponseType = ResponseType.Info;
            //    responseLote.Message = errors;
            //    return responseLote;
            //}
        }
    }
}
