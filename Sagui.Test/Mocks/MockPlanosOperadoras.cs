using Sagui.Model;
using Sagui.Model.ValueObject;
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
            planoOperadora.Id = 3;
            planoOperadora.NomeFantasia = "AMIL";
            planoOperadora.RazaoSocial = "AMIL";
            planoOperadora.CNPJ = "0000000000191";
            planoOperadora.DataEnvioLote = DateTime.Now;
            planoOperadora.DataRecebimentoLote = DateTime.Now;
            planoOperadora.ListaProcedimentos = new List<Model.Procedimentos>() { mockProcedimento.CriarMockProcedimento() };
            planoOperadora.ListaArquivos = new List<Arquivos>() { mockArquivos.CriarMockArquivo() };
            planoOperadora.Status = StatusPlanoOperadora.Status.Criada.GetHashCode();
            return planoOperadora;
        }

        public RequestPlanoOperadora AtualizarMockPlanoOperadora()
        {
            MockProcedimento mockProcedimento = new MockProcedimento();
            MockArquivos mockArquivos = new MockArquivos();

            RequestPlanoOperadora planoOperadora = new RequestPlanoOperadora();
            planoOperadora.Id = 8;
            planoOperadora.NomeFantasia = "FANTA";
            planoOperadora.RazaoSocial = "COCA";
            planoOperadora.CNPJ = "27664821000189";
            planoOperadora.DataEnvioLote = DateTime.Now;
            planoOperadora.DataRecebimentoLote = DateTime.Now.AddDays(14);
            planoOperadora.ListaProcedimentos = new List<Model.Procedimentos>() { mockProcedimento.CriarMockProcedimento() };
            planoOperadora.ListaArquivos = new List<Arquivos>() { mockArquivos.CriarMockArquivo() };
            planoOperadora.PublicID = new Guid("a99b558a-7e17-11e9-b2e1-705a0f6970c5");
            planoOperadora.Status = StatusPlanoOperadora.Status.Criada.GetHashCode();

            return planoOperadora;
        }

    }
}
