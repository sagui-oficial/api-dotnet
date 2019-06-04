using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.Lote;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.TestLote
{

    [TestClass]
    public class ListarLote_Teste
    {
        [TestMethod]
        public async Task ListarTodosLotes()
        {
            LoteService loteService = new LoteService();

            ListarLoteRequestHandler listarLoteRequestHandler = new ListarLoteRequestHandler(loteService);

            RequestLote requestLote = default(RequestLote);

            var response = await listarLoteRequestHandler.Handle(requestLote);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Lotes.Count > 0);
        }


        [TestMethod]
        public async Task ObterLote()
        {
            LoteService loteService = new LoteService();

            ObterLoteRequestHandler ObterGTORequestHandler = new ObterLoteRequestHandler(loteService);

            RequestLote requestLote = default(RequestLote);

            requestLote = MockLote.ObterLoterMock();

            var response = await ObterGTORequestHandler.Handle(requestLote);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Lote.Id > 0);
        }
    }
}
