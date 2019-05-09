using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class ListarProcedimento_Test
    {
        [TestMethod]
        public async Task ListarTodosProcedimentos()
        {
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarProcedimentoRequestHandler listarProcedimentoRequestHandler = new ListarProcedimentoRequestHandler(procedimentoService);

            RequestProcedimento requestProcedimento = default(RequestProcedimento);

            var response = await listarProcedimentoRequestHandler.Handle(requestProcedimento);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Procedimentos.Count > 0);
        }

        [TestMethod]
        public async Task ObterProcedimentos()
        {
            ProcedimentoService procedimentoService = new ProcedimentoService();
           

            ObterProcedimentoRequestHandler obterProcedimentoRequestHandler = new ObterProcedimentoRequestHandler(procedimentoService);

            RequestProcedimento requestProcedimento = default(RequestProcedimento);
            MockProcedimento mock = new MockProcedimento();

            requestProcedimento = mock.ObterMockProcedimento();

            var response = await obterProcedimentoRequestHandler.Handle(requestProcedimento);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Procedimento.IdProcedimento > 0);
        }

        [TestMethod]
        public async Task ListarNenhumProcedimento()
        {
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarProcedimentoRequestHandler listarProcedimentoRequestHandler = new ListarProcedimentoRequestHandler(procedimentoService);

            RequestProcedimento requestProcedimento = default(RequestProcedimento);

            var response = await listarProcedimentoRequestHandler.Handle(requestProcedimento);

            Assert.IsTrue(response.ResponseType == ResponseType.Info);
            Assert.IsTrue(response.Procedimentos.Count == 0);
        }
    }
}
