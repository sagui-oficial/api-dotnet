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
    public class CadastrarPlanoOperadora_Test
    {
        [TestMethod]
        public async Task CadastrarPlanoOperadora()
        {
            RequestPlanoOperadora requestPlanoOperadora = new RequestPlanoOperadora();

            requestPlanoOperadora = MockPlanoOperadora.CriarMockPlanoOperadora();

            PlanoOperadoraService planoOperadoraService = new PlanoOperadoraService();

            CriarPlanoOperadoraRequestHandler criarPlanoOperadoraRequestHandler = new CriarPlanoOperadoraRequestHandler(planoOperadoraService);

            var response = await criarPlanoOperadoraRequestHandler.Handle(requestPlanoOperadora);

            Assert.IsNotNull(response.PlanoOperadora);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);

        }
    }
}
