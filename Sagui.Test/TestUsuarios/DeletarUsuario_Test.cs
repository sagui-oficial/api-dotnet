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
        public async Task DeletarUsuarioFuncionario()
        {
            RequestUsuarioFuncionario requestusuario = new RequestUsuarioFuncionario();
            MockUsuario mock = new MockUsuario();

            requestusuario = mock.CriarMockUsuarioFuncionario();

            UsuarioFuncionarioService UsuarioService = new UsuarioFuncionarioService();

            DeletarUsuarioFuncionarioRequestHandler deletarUsuarioRequestHandler = new DeletarUsuarioFuncionarioRequestHandler(UsuarioService);

            var response = await deletarUsuarioRequestHandler.Handle(requestusuario);

            Assert.IsNotNull(response.Funcionario);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);

        }

        [TestMethod]
        public async Task DeletarUsuarioDentista()
        {
            RequestUsuarioDentista requestusuario = new RequestUsuarioDentista();
            MockUsuario mock = new MockUsuario();

            requestusuario = mock.CriarMockUsuarioDentista();

            UsuarioDentistaService UsuarioService = new UsuarioDentistaService();

            DeletarUsuarioDentistaRequestHandler deletarUsuarioRequestHandler = new DeletarUsuarioDentistaRequestHandler(UsuarioService);

            var response = await deletarUsuarioRequestHandler.Handle(requestusuario);

            Assert.IsNotNull(response.Dentinsta);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);

        }

        [TestMethod]
        public async Task DeletarUsuarioPaciente()
        {
            RequestUsuarioPaciente requestusuario = new RequestUsuarioPaciente();
            MockUsuario mock = new MockUsuario();

            requestusuario = mock.CriarMockUsuarioPaciente();

            UsuarioPacienteService UsuarioService = new UsuarioPacienteService();

            DeletarUsuarioPacienteRequestHandler deletarUsuarioRequestHandler = new DeletarUsuarioPacienteRequestHandler(UsuarioService);

            var response = await deletarUsuarioRequestHandler.Handle(requestusuario);

            Assert.IsNotNull(response.Paciente);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);

        }
    }
}
