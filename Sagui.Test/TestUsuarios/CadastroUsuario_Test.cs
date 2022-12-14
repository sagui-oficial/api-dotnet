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

            requestUsuarioFuncionario = MockUsuario.CriarMockUsuarioFuncionario();

            UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

            CriarUsuarioFuncionarioRequestHandler criarUsuarioRequestHandler = new CriarUsuarioFuncionarioRequestHandler(usuarioService);

            var response = await criarUsuarioRequestHandler.Handle(requestUsuarioFuncionario);

            Assert.IsNotNull(response.Funcionario);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }


        [TestMethod]
        public async Task CadastrarDentista()
        {
            RequestUsuarioDentista requestUsuario = new RequestUsuarioDentista();

            requestUsuario = MockUsuario.CriarMockUsuarioDentista();

            UsuarioDentistaService usuarioService = new UsuarioDentistaService();

            CriarUsuarioDentistaRequestHandler criarUsuarioRequestHandler = new CriarUsuarioDentistaRequestHandler(usuarioService);

            var response = await criarUsuarioRequestHandler.Handle(requestUsuario);

            Assert.IsNotNull(response.Dentinsta);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }


        [TestMethod]
        public async Task CadastrarPaciente()
        {
            RequestUsuarioPaciente requestUsuario = new RequestUsuarioPaciente();

            requestUsuario = MockUsuario.CriarMockUsuarioPaciente();

            UsuarioPacienteService usuarioService = new UsuarioPacienteService();

            CriarUsuarioPacienteRequestHandler criarUsuarioRequestHandler = new CriarUsuarioPacienteRequestHandler(usuarioService);

            var response = await criarUsuarioRequestHandler.Handle(requestUsuario);

            Assert.IsNotNull(response.Paciente);
            Assert.IsTrue(response.ResponseType == ResponseType.Success);
        }

    }
}
