﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Service.GTO;
using Sagui.Service.RequestResponse;
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
    public class ListarGTO_Test
    {
        [TestMethod]
        public void ListarTodasGTO()
        {
            RequestGTO requestGTO = new RequestGTO();

            MockGTO mock = new MockGTO();
            requestGTO = mock.CriarMockGTO();

            GTOService gtoService = new GTOService();
            var response = gtoService.ListGTOs();

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.GTOs.Count >= 0);
        }
    }
}
