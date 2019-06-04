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
    public class AtualizarProcedimento_Test
    {
        [TestMethod]
        public async Task AtualizarProcedimento()
        {
            RequestProcedimento requestProcedimento = new RequestProcedimento();

            requestProcedimento = MockProcedimento.AtualizarMockProcedimento();

            ProcedimentoService procedimentoService = new ProcedimentoService();

            AtualizarProcedimentoRequestHandler atualizarProcedimentoRequestHandler = new AtualizarProcedimentoRequestHandler(procedimentoService);

            var response = await atualizarProcedimentoRequestHandler.Handle(requestProcedimento);

            Assert.IsNotNull(response.Procedimento);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);

        }
    }
}
