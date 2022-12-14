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

            requestProcedimento = MockProcedimento.ObterMockProcedimento();

            var response = await obterProcedimentoRequestHandler.Handle(requestProcedimento);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Procedimento.Id > 0);
        }

        [TestMethod]
        public async Task ListarTodosProcedimento_PlanoOperadora()
        {
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarProcedimento_PlanoOperadoraRequestHandler listarProcedimentoRequestHandler = new ListarProcedimento_PlanoOperadoraRequestHandler(procedimentoService);

            RequestPlanoOperadora requestPlanoOperadora = default(RequestPlanoOperadora);
            requestPlanoOperadora = MockPlanoOperadora.AtualizarMockPlanoOperadora();

            var response = await listarProcedimentoRequestHandler.Handle(requestPlanoOperadora);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Procedimentos.Count > 0);
        }

        //[TestMethod]
        //public async Task ListarNenhumProcedimento()
        //{
        //    ProcedimentoService procedimentoService = new ProcedimentoService();

        //    ListarProcedimentoRequestHandler listarProcedimentoRequestHandler = new ListarProcedimentoRequestHandler(procedimentoService);

        //    RequestProcedimento requestProcedimento = default(RequestProcedimento);

        //    var response = await listarProcedimentoRequestHandler.Handle(requestProcedimento);

        //    Assert.IsTrue(response.ResponseType == ResponseType.Info);
        //    Assert.IsTrue(response.Procedimentos.Count == 0);
        //}
    }
}
