using Microsoft.VisualStudio.TestTools.UnitTesting;
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

namespace Sagui.Test.TestProcedimentos
{
    [TestClass]
    public class CadastrarProcedimento_Test
    {
        [TestMethod]
        public async Task CadastrarProcedimento()
        {
            RequestProcedimento requestProcedimento = new RequestProcedimento();

            requestProcedimento = MockProcedimento.CriarMockProcedimento();

            ProcedimentoService procedimentoService = new ProcedimentoService();

            CriarProcedimentoRequestHandler criarProcedimentoRequestHandler = new CriarProcedimentoRequestHandler(procedimentoService);

            var response = await criarProcedimentoRequestHandler.Handle(requestProcedimento);

            Assert.IsNotNull(response.Procedimento);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);

        }
    }
}
