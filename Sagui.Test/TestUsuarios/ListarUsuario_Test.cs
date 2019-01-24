using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.GTO;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Service.Usuario;
using Sagui.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.TestGTO
{
    [TestClass]
    public class ListarUsuario_Test
    {
        [TestMethod]
        public async Task ListarTodosFuncionarios()
        {
            UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

            ListarUsuarioFuncionarioRequestHandler listarFuncionarioRequestHandler = new ListarUsuarioFuncionarioRequestHandler(usuarioService);

            RequestUsuarioFuncionario requestUsuario = default(RequestUsuarioFuncionario);

            var response = await listarFuncionarioRequestHandler.Handle(requestUsuario);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Funcionarios.Count > 0);
        }

        [TestMethod]
        public async Task ListarTodosPacientes()
        {
            UsuarioPacienteService usuarioService = new UsuarioPacienteService();

            ListarUsuarioPacienteRequestHandler listarFuncionarioRequestHandler = new ListarUsuarioPacienteRequestHandler(usuarioService);

            RequestUsuarioPaciente requestUsuario = default(RequestUsuarioPaciente);

            var response = await listarFuncionarioRequestHandler.Handle(requestUsuario);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Pacientes.Count > 0);
        }

        public async Task ListarTodosDentistas()
        {
            UsuarioDentistaService usuarioService = new UsuarioDentistaService();

            ListarUsuarioDentistaRequestHandler listarFuncionarioRequestHandler = new ListarUsuarioDentistaRequestHandler(usuarioService);

            RequestUsuarioDentista requestUsuario = default(RequestUsuarioDentista);

            var response = await listarFuncionarioRequestHandler.Handle(requestUsuario);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Dentinstas.Count > 0);
        }

    }
}
