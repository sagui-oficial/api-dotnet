using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.Arquivo;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
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

            ListarArquivoRequestHandler listarArquivoRequestHandler = new ListarArquivoRequestHandler(arquivoService);

            RequestArquivo requestArquivo = default(RequestArquivo);

            var response = await listarArquivoRequestHandler.Handle(requestArquivo);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Arquivos.Count > 0);
        }

        [TestMethod]
        public async Task ObterGTO()
        {
            ArquivoService arquivoService = new ArquivoService();

            ObterArquivoRequestHandler obterArquivoRequestHandler = new ObterArquivoRequestHandler(arquivoService);

            RequestArquivo requestArquivo = default(RequestArquivo);

            var response = await obterArquivoRequestHandler.Handle(requestArquivo);

            Assert.IsTrue(response.ResponseType == ResponseType.Info);
            Assert.IsTrue(response.GTOs.Count == 0);
        }
    }
}
