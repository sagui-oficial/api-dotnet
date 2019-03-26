﻿using Sagui.Base.Utils;
using Sagui.Service.Arquivo;
using Sagui.Service.Contracts;
using Sagui.Service.GTO;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ListarGTORequestHandler : IBaseRequestHandler<RequestGTO, ResponseGTO>
    {
        GTOService GTOService;
        ArquivoService arquivoService;
        ProcedimentoService procedimentoService;
        private Business.Validador.GTO.ValidadorGTO validadorGTO { get; set; }

        ResponseGTO responseGTO;

        public ListarGTORequestHandler(GTOService _GTOService, 
                                       ArquivoService _arquivoService, 
                                       ProcedimentoService _procedimentoService)
        {
            GTOService = _GTOService;
            arquivoService = _arquivoService;
            procedimentoService = _procedimentoService;
            validadorGTO = new Business.Validador.GTO.ValidadorGTO();
            responseGTO = new ResponseGTO();
        }

        public async Task<ResponseGTO> Handle(RequestGTO request)
        {
            var ListGTO = GTOService.Listar();

            foreach(var gto in ListGTO)
            {
                gto.Arquivos = arquivoService.ListarArquivoPorGTO(gto);
                gto.Procedimentos = procedimentoService.ListarProcedimentoPorGTO(gto);
            }

            if (ListGTO.Count > 0)
            {
                responseGTO.GTOs = ListGTO;
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Success;
                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ListadoComSucesso, nameof(GTO), Constantes.MensagemGTOListadaComSucesso));
                return responseGTO;
            }
            else
            {
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Error;
                responseGTO.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoListar, nameof(GTO), Constantes.MensagemGTONaoListada));
                return responseGTO;
            }
        }
    }
}
