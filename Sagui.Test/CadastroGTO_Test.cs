using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Model;
using System.Collections.Generic;
using Sagui.Business;
using Sagui.Test.Mocks;

namespace Sagui.Test
{
    [TestClass]
    public class CadastroGTO_Test
    {
        [TestMethod]
        public void CadastrarGTO()
        {
            GTO Guia = new GTO();
            MockGTO mock = new MockGTO();
            Guia = mock.CriarMockGTO();
            
            Business.GTO.CadastrarGTOBusiness gtoBusiness = new Business.GTO.CadastrarGTOBusiness();
            gtoBusiness.Cadastrar(Guia);
        }


        [TestMethod]
        public void CadastrarGTO_SemDataSolicitacao()
        {
            GTO Guia = new GTO();
            MockGTO mock = new MockGTO();
            Guia = mock.CriarMockGTO();
            Guia.Solicitacao = DateTime.MinValue;
			Guia.Vencimento = DateTime.MinValue;

            Business.GTO.CadastrarGTOBusiness gtoBusiness = new Business.GTO.CadastrarGTOBusiness();
            gtoBusiness.Cadastrar(Guia);
        }
    }
}
