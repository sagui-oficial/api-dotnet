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
    public class AtualizarUsuario_Test
    {
        [TestMethod]
        public async Task AtualizarFuncionario()
        {
            RequestUsuarioFuncionario requestUsuarioFuncionario = new RequestUsuarioFuncionario();
            MockUsuario mock = new MockUsuario();

            requestUsuarioFuncionario = mock.CriarMockUsuarioFuncionario();

            UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

            AtualizarUsuarioFuncionarioRequestHandler atualizarUsuarioRequestHandler = new AtualizarUsuarioFuncionarioRequestHandler(usuarioService);

            var response = await atualizarUsuarioRequestHandler.Handle(requestUsuarioFuncionario);

            Assert.IsNotNull(response.Funcionario);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }


        [TestMethod]
        public async Task AtualizarDentista()
        {
            RequestUsuarioDentista requestUsuario = new RequestUsuarioDentista();
            MockUsuario mock = new MockUsuario();

            requestUsuario = mock.CriarMockUsuarioDentista();

            UsuarioDentistaService usuarioService = new UsuarioDentistaService();

            AtualizarUsuarioDentistaRequestHandler atualizarUsuarioRequestHandler = new AtualizarUsuarioDentistaRequestHandler(usuarioService);

            var response = await atualizarUsuarioRequestHandler.Handle(requestUsuario);

            Assert.IsNotNull(response.Dentinsta);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }


        [TestMethod]
        public async Task AtualizarPaciente()
        {
            RequestUsuarioPaciente requestUsuario = new RequestUsuarioPaciente();
            MockUsuario mock = new MockUsuario();

            requestUsuario = mock.CriarMockUsuarioPaciente();

            UsuarioPacienteService usuarioService = new UsuarioPacienteService();

            AtualizarUsuarioPacienteRequestHandler atualizarUsuarioRequestHandler = new AtualizarUsuarioPacienteRequestHandler(usuarioService);

            var response = await atualizarUsuarioRequestHandler.Handle(requestUsuario);

            Assert.IsNotNull(response.Paciente);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }

    }
}
