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
    public class AtualizarGTO_Test
    {
        [TestMethod]
        public async Task AtualizarGTO()
        {
            RequestGTO requestGTO = new RequestGTO();
            MockGTO mock = new MockGTO();

            requestGTO = mock.AtualizarMockGTO();

            GTOService gTOService = new GTOService();

            AtualizarGTORequestHandler criarGTORequestHandler = new AtualizarGTORequestHandler(gTOService);

            var response = await criarGTORequestHandler.Handle(requestGTO);

            Assert.IsNotNull(response.GTO);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }


        //     [TestMethod]
        //     public void CadastrarGTO_SemDataSolicitacao()
        //     {
        ////         GTO Guia = new GTO();
        ////         MockGTO mock = new MockGTO();
        ////         Guia = mock.CriarMockGTO();
        ////         Guia.Solicitacao = DateTime.MinValue;
        ////Guia.Vencimento = DateTime.MinValue;

        ////         Business.GTO.CadastrarGTOBusiness gtoBusiness = new Business.GTO.CadastrarGTOBusiness();
        ////         gtoBusiness.Cadastrar(Guia);
        //     }

        //     [TestMethod]
        //     public void CadastrarGTO_SemDataVencimento()
        //     {
        ////         GTO Guia = new GTO();
        ////         MockGTO mock = new MockGTO();
        ////         Guia = mock.CriarMockGTO();
        ////         Guia.Solicitacao = DateTime.MinValue;
        ////Guia.Vencimento = DateTime.MinValue;

        ////         Business.GTO.CadastrarGTOBusiness gtoBusiness = new Business.GTO.CadastrarGTOBusiness();
        ////         gtoBusiness.Cadastrar(Guia);
        //     }


    }
}
