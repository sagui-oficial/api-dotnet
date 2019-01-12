using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Model;
using Sagui.Service.Usuario;
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
        public async Task CadastrarFuncionario()
        {
            RequestUsuarioFuncionario requestUsuarioFuncionario = new RequestUsuarioFuncionario();
            MockUsuario mock = new MockUsuario();

            requestUsuarioFuncionario = mock.CriarMockUsuarioFuncionario();

            UsuarioService usuarioService = new UsuarioService();

            CriarUsuarioFuncionarioRequestHandler criarUsuarioRequestHandler = new CriarUsuarioFuncionarioRequestHandler(usuarioService);

            var response = await criarUsuarioRequestHandler.Handle(requestUsuarioFuncionario);

            Assert.IsNotNull(response.Usuario);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }


        [TestMethod]
        public async Task CadastrarDentista()
        {
            RequestUsuarioDentista requestUsuario = new RequestUsuarioDentista();
            MockUsuario mock = new MockUsuario();

            requestUsuario = mock.CriarMockUsuarioDentista();

            UsuarioService usuarioService = new UsuarioService();

            CriarUsuarioDentistaRequestHandler criarUsuarioRequestHandler = new CriarUsuarioDentistaRequestHandler(usuarioService);

            var response = await criarUsuarioRequestHandler.Handle(requestUsuario);

            Assert.IsNotNull(response.Usuario);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }

    }
}
