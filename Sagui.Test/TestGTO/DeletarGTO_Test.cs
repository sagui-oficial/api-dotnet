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

            requestGTO = MockGTO.DeletarMockGTO();

            GTOService gTOService = new GTOService();

            DeletarGTORequestHandler DeletarGTORequestHandler = new DeletarGTORequestHandler(gTOService);

            var response = await DeletarGTORequestHandler.Handle(requestGTO);

            Assert.IsNotNull(response.GTO);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }
           
      }
}
