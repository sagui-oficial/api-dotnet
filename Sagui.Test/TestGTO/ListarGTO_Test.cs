using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.Arquivo;
using Sagui.Service.GTO;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.TestGTO
{
    [TestClass]
    public class ListarGTO_Test
    {
        [TestMethod]
        public async Task ListarTodasGTO()
        {
            GTOService gTOService = new GTOService();
            ArquivoService arquivoService = new ArquivoService();
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarGTORequestHandler listarGTORequestHandler = new ListarGTORequestHandler(gTOService, arquivoService, procedimentoService);

            RequestGTO requestGTO = default(RequestGTO);

            var response = await listarGTORequestHandler.Handle(requestGTO);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.GTOs.Count > 0 );
        }

        [TestMethod]
        public async Task ListarNenhumsGTO()
        {
            GTOService gTOService = new GTOService();
            ArquivoService arquivoService = new ArquivoService();
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarGTORequestHandler listarGTORequestHandler = new ListarGTORequestHandler(gTOService, arquivoService, procedimentoService);

            RequestGTO requestGTO = default(RequestGTO);

            var response = await listarGTORequestHandler.Handle(requestGTO);

            Assert.IsTrue(response.ResponseType == ResponseType.Info);
            Assert.IsTrue(response.GTOs.Count == 0);
        }

        [TestMethod]
        public async Task ObterGTO()
        {
            GTOService gTOService = new GTOService();
            ArquivoService arquivoService = new ArquivoService();
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ObterGTORequestHandler ObterGTORequestHandler = new ObterGTORequestHandler(gTOService, arquivoService, procedimentoService);

            RequestGTO requestGTO = default(RequestGTO);

            var response = await ObterGTORequestHandler.Handle(requestGTO);

            Assert.IsTrue(response.ResponseType == ResponseType.Info);
            Assert.IsTrue(response.GTOs.Count == 0);
        }

    }
}
