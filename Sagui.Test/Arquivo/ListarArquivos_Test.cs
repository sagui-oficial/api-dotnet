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
        public async Task ObterArquivoGTOPorPublicId()
        {
            ArquivoService arquivoService = new ArquivoService();

            ObterArquivoGTORequestHandler obterArquivoRequestHandler = new ObterArquivoGTORequestHandler(arquivoService);

            RequestArquivoGTO requestArquivo = default(RequestArquivoGTO);



            var response = await obterArquivoRequestHandler.Handle(requestArquivo);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Arquivo != null);
        }


        [TestMethod]
        public async Task ObterArquivoPlanoOperadoraPorPublicId()
        {
            ArquivoService arquivoService = new ArquivoService();

            ObterArquivoPlanoOperadoraRequestHandler obterArquivoRequestHandler = new ObterArquivoPlanoOperadoraRequestHandler(arquivoService);

            RequestArquivoPlanoOperadora requestArquivo = default(RequestArquivoPlanoOperadora);

            var response = await obterArquivoRequestHandler.Handle(requestArquivo);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Arquivo != null);
        }
    }
}
