using Sagui.Model;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public class MockPlanoOperadora
    {
        
        public RequestPlanoOperadora CriarMockPlanoOperadora()
        {
            MockProcedimento mockProcedimento = new MockProcedimento();
            MockArquivos mockArquivos = new MockArquivos();

            RequestPlanoOperadora planoOperadora = new RequestPlanoOperadora();
            planoOperadora.Id = 1;
            planoOperadora.NomeFantasia = "AMIL";
            planoOperadora.RazaoSocial = "AMIL";
            planoOperadora.CNPJ = "0000000000191";
            planoOperadora.DataEnvioLote = new DateTime();
            planoOperadora.DataRecebimentoLote = new DateTime();
            planoOperadora.ListaProcedimentos = new List<Model.Procedimentos>() { mockProcedimento.CriarMockProcedimento() };
            planoOperadora.ListaArquivos = new List<Arquivos>() { mockArquivos.CriarMockArquivo() };

            return planoOperadora;
        }
    }
}
