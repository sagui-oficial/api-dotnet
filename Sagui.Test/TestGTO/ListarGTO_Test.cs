using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.GTO;
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
    public class ListarGTO_Test
    {
        [TestMethod]
        public void ListarTodasGTO()
        {
            GTOService gTOService = new GTOService();

            ListarGTORequestHandler listarGTORequestHandler = new ListarGTORequestHandler(gTOService);

            var response = listarGTORequestHandler.Listar();

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.GTOs.Count > 0 );
        }

        [TestMethod]
        public void ListarNenhumsGTO()
        {
            GTOService gTOService = new GTOService();

            ListarGTORequestHandler listarGTORequestHandler = new ListarGTORequestHandler(gTOService);

            var response = listarGTORequestHandler.Listar();

            Assert.IsTrue(response.ResponseType == ResponseType.Info);
            Assert.IsTrue(response.GTOs.Count == 0);
        }
    }
}
