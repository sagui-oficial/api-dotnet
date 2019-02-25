using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.Usuario;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.TestProcedimentos
{
    [TestClass]
    public class DeletarUsuario_Test
    {
        [TestMethod]
        public async Task DeletarUsuario()
        {
            RequestUsuarioFuncionario requestusuario = new RequestUsuarioFuncionario();
            MockUsuario mock = new MockUsuario();

            requestusuario = mock.CriarMockUsuarioFuncionario();

            UsuarioFuncionarioService UsuarioService = new UsuarioFuncionarioService();

            DeletarUsuarioRequestHandler deletarUsuarioRequestHandler = new DeletarUsuarioRequestHandler(UsuarioService);

            var response = await deletarUsuarioRequestHandler.Handle(requestusuario);

            Assert.IsNotNull(response.Funcionario);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);

        }
    }
}
