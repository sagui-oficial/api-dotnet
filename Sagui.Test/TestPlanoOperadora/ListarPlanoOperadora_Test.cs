using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.GTO;
using Sagui.Service.PlanoOperadora;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.TestPlanoOperadora
{
    [TestClass]
    public class ListarPlanoOperadora_Test
    {
        [TestMethod]
        public async Task ListarTodosPlanoOperadoras()
        {
            PlanoOperadoraService planoOperadoraService = new PlanoOperadoraService();

            ListarPlanoOperadoraRequestHandler listarPlanoOperadoraRequestHandler = new ListarPlanoOperadoraRequestHandler(planoOperadoraService);

            RequestPlanoOperadora requestPlanoOperadora = default(RequestPlanoOperadora);

            var response = await listarPlanoOperadoraRequestHandler.Handle(requestPlanoOperadora);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.PlanosOperadoras.Count > 0);
        }

        [TestMethod]
        public async Task ObterPlanoOperadoras()
        {
            PlanoOperadoraService planoOperadoraService = new PlanoOperadoraService();

            ListarPlanoOperadoraRequestHandler listarPlanoOperadoraRequestHandler = new ListarPlanoOperadoraRequestHandler(planoOperadoraService);

            RequestPlanoOperadora requestPlanoOperadora = default(RequestPlanoOperadora);

            var response = await listarPlanoOperadoraRequestHandler.Handle(requestPlanoOperadora);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.PlanosOperadoras.Count > 0);
        }

        [TestMethod]
        public async Task ListarNenhumPlanoOperadora()
        {
            PlanoOperadoraService planoOperadoraService = new PlanoOperadoraService();

            ListarPlanoOperadoraRequestHandler listarPlanoOperadoraRequestHandler = new ListarPlanoOperadoraRequestHandler(planoOperadoraService);

            RequestPlanoOperadora requestPlanoOperadora = default(RequestPlanoOperadora);

            var response = await listarPlanoOperadoraRequestHandler.Handle(requestPlanoOperadora);

            Assert.IsTrue(response.ResponseType == ResponseType.Info);
            Assert.IsTrue(response.PlanosOperadoras.Count == 0);
        }
    }
}
