using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Model;
using Sagui.Service.GTO;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Test.Mocks;

namespace Sagui.Test.TestUsuarios
{
    [TestClass]
    public class CadastroUsuario_Test
    {
        [TestMethod]
        public void CadastrarUsuario()
        {
            RequestUsuario requestUsuario = new RequestUsuario();
            MockUsuario mock = new MockUsuario();

            requestUsuario = mock.CriarMockUsuario();

            UsuarioService usuarioService = new UsuarioService();

            CriarUsuarioRequestHandler criarUsuarioRequestHandler = new CriarUsuarioRequestHandler(usuarioService);

            var response = criarUsuarioRequestHandler.Cadastrar(requestUsuario);

            Assert.IsNotNull(response.Usuario);
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
