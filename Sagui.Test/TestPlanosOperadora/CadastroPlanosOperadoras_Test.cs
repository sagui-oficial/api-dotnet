using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.PlanoOperadora;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.TestPlanosOperadora
{
    [TestClass]
    public class CadastroPlanoOperadora_Test
    {
        [TestMethod]
        public async Task CadastrarPlanos()
        {
            RequestPlanoOperadora requestPlanoOperadora = new RequestPlanoOperadora();
            MockPlanoOperadora mock = new MockPlanoOperadora();

            requestPlanoOperadora = mock.CriarMockPlanoOperadora();

            PlanoOperadoraService planoOperadoraService = new PlanoOperadoraService();

            CriarPlanoOperadoraRequestHandler criarUsuarioRequestHandler = new CriarPlanoOperadoraRequestHandler(planoOperadoraService);

            var response = await criarUsuarioRequestHandler.Handle(requestPlanoOperadora);

            Assert.IsNotNull(response.PlanoOperadora);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }
    }
}
