using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Model;
using Sagui.Service.GTO;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Test.Mocks;

namespace Sagui.Test.TestGTO
{
    [TestClass]
    public class DeletarGTO_Test
    {
        [TestMethod]
        public async Task DeletarGTO()
        {
            RequestGTO requestGTO = new RequestGTO();
            MockGTO mock = new MockGTO();

            requestGTO = mock.DeletarMockGTO();

            GTOService gTOService = new GTOService();

            AtualizarGTORequestHandler AtualizarGTORequestHandler = new AtualizarGTORequestHandler(gTOService);

            var response = await AtualizarGTORequestHandler.Handle(requestGTO);

            Assert.IsNotNull(response.GTO);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }
           
      }
}
