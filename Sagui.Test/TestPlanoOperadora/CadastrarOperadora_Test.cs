using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.PlanoOperadora;
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

namespace Sagui.Test.TestPlanoOperadora
{
    [TestClass]
    public class CadastrarOperadora_Test
    {
        [TestMethod]
        public async Task CadastrarPlanoOperadora()
        {
            RequestPlanoOperadora requestPlanoOperadora = new RequestPlanoOperadora();
            MockPlanoOperadora mock = new MockPlanoOperadora();

            requestPlanoOperadora = mock.CriarMockPlanoOperadora();

            PlanoOperadoraService planoOperadoraService = new PlanoOperadoraService();

            CriarPlanoOperadoraRequestHandler criarProcedimentoRequestHandler = new CriarPlanoOperadoraRequestHandler(planoOperadoraService);

            var response = await criarProcedimentoRequestHandler.Handle(requestPlanoOperadora);

            Assert.IsNotNull(response.PlanoOperadora);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);

        }
    }
}
