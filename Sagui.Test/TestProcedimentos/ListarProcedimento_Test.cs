using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.GTO;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using Sagui.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.TestGTO
{
    [TestClass]
    public class ListarProcedimento_Test
    {
        [TestMethod]
        public void ListarTodosProcedimentos()
        {
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarProcedimentoRequestHandler listarProcedimentoRequestHandler = new ListarProcedimentoRequestHandler(procedimentoService);

            var response = listarProcedimentoRequestHandler.Listar();

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Procedimentos.Count > 0 );
        }

        [TestMethod]
        public void ListarNenhumProcedimento()
        {
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarProcedimentoRequestHandler listarProcedimentoRequestHandler = new ListarProcedimentoRequestHandler(procedimentoService);

            var response = listarProcedimentoRequestHandler.Listar();

            Assert.IsTrue(response.ResponseType == ResponseType.Info);
            Assert.IsTrue(response.Procedimentos.Count == 0);
        }
    }
}
