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


        [TestMethod]
        public void CadastrarUsuarioEspecialista()
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

    }
}
