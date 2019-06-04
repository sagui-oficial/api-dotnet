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
    public class DeeltarProcedimento_Test
    {
        [TestMethod]
        public async Task DeletarProcedimento()
        {
            RequestProcedimento requestProcedimento = new RequestProcedimento();

            requestProcedimento = MockProcedimento.DeletarMockProcedimento();

            ProcedimentoService procedimentoService = new ProcedimentoService();

            DeletarProcedimentoRequestHandler deletarProcedimentoRequestHandler = new DeletarProcedimentoRequestHandler(procedimentoService);

            var response = await deletarProcedimentoRequestHandler.Handle(requestProcedimento);

            Assert.IsNotNull(response.Procedimento);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);

        }
    }
}
