using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.Arquivo;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Arquivo
{
    [TestClass]
    public class ListarArquivos_Test
    {
        [TestMethod]
        public async Task ListarTodasGTO()
        {
            ArquivoService arquivoService = new ArquivoService();

            ListarGTORequestHandler listarGTORequestHandler = new ListarGTORequestHandler(arquivoService);

            RequestGTO requestGTO = default(RequestGTO);

            var response = await listarGTORequestHandler.Handle(requestGTO);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.GTOs.Count > 0);
        }

        [TestMethod]
        public async Task ObterGTO()
        {
            GTOService gTOService = new GTOService();

            ObterGTORequestHandler ObterGTORequestHandler = new ObterGTORequestHandler(gTOService);

            RequestGTO requestGTO = default(RequestGTO);

            var response = await ObterGTORequestHandler.Handle(requestGTO);

            Assert.IsTrue(response.ResponseType == ResponseType.Info);
            Assert.IsTrue(response.GTOs.Count == 0);
        }
    }
}
