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
    public class CriarLoteRequestHandler : IBaseRequestHandler<RequestLote, ResponseLote>
    {
        LoteService LoteService;
        private Business.Validador.Lote.ValidadorLote ValidatorLote { get; set; }

        ResponseLote responseLote;

        public CriarLoteRequestHandler(LoteService _LoteService)
        {
            LoteService = _LoteService;
            ValidatorLote = new Business.Validador.Lote.ValidadorLote();
            responseLote = new ResponseLote();
        }

        public async Task<ResponseLote> Handle(RequestLote Lotes)
        {
            var errors = ValidatorLote.Validate(Lotes);

            if (errors.Count() == 0)
            {
                var _Lote = LoteService.Cadastrar(Lotes);

                if (_Lote != null)
                {
                    responseLote.Lote = _Lote;
                    responseLote.ExecutionDate = DateTime.Now;
                    responseLote.ResponseType = ResponseType.Success;
                    responseLote.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.InseridoComSucesso,
                                                                                          nameof(Lotes),
                                                                                          Constantes.MensagemLotesInseridosComSucesso));
                    return responseLote;
                }
                else
                {
                    responseLote.ExecutionDate = DateTime.Now;
                    responseLote.ResponseType = ResponseType.Error;
                    responseLote.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoInserir,
                                                                                nameof(Lotes),
                                                                                Constantes.MensagemLoteNaoInserido));
                    return responseLote;
                }
            }
            else
            {
                responseLote.ExecutionDate = DateTime.Now;
                responseLote.ResponseType = ResponseType.Error;
                responseLote.Message = errors;
                return responseLote;
            }
        }
    }
}
