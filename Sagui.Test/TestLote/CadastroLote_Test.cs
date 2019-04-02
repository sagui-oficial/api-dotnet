using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Model;
using Sagui.Service.Lote;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Test.Mocks;

namespace Sagui.Test.TestLote
{
    [TestClass]
    public class CadastroLote_Test
    {
        [TestMethod]
        public async Task CadastrarLote()
        {
            RequestLote requestLote = new RequestLote();
            MockLote mock = new MockLote();

            requestLote = mock.CriarMockLote();

            LoteService LoteService = new LoteService();

            CriarLoteRequestHandler criarLoteRequestHandler = new CriarLoteRequestHandler(LoteService);

            var response = await criarLoteRequestHandler.Handle(requestLote);

            Assert.IsNotNull(response.Lote);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }


        //     [TestMethod]
        //     public void CadastrarLote_SemDataSolicitacao()
        //     {
        ////         Lote Guia = new Lote();
        ////         MockLote mock = new MockLote();
        ////         Guia = mock.CriarMockLote();
        ////         Guia.Solicitacao = DateTime.MinValue;
        ////Guia.Vencimento = DateTime.MinValue;

        ////         Business.Lote.CadastrarLoteBusiness LoteBusiness = new Business.Lote.CadastrarLoteBusiness();
        ////         LoteBusiness.Cadastrar(Guia);
        //     }

        //     [TestMethod]
        //     public void CadastrarLote_SemDataVencimento()
        //     {
        ////         Lote Guia = new Lote();
        ////         MockLote mock = new MockLote();
        ////         Guia = mock.CriarMockLote();
        ////         Guia.Solicitacao = DateTime.MinValue;
        ////Guia.Vencimento = DateTime.MinValue;

        ////         Business.Lote.CadastrarLoteBusiness LoteBusiness = new Business.Lote.CadastrarLoteBusiness();
        ////         LoteBusiness.Cadastrar(Guia);
        //     }


    }
}
