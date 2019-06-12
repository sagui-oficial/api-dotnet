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
    public static class MockPlanoOperadora
    {
        
        public static RequestPlanoOperadora CriarMockPlanoOperadora()
        {
            RequestPlanoOperadora planoOperadora = new RequestPlanoOperadora();
            planoOperadora.Id = 1;
            planoOperadora.NomeFantasia = "AMIL";
            planoOperadora.RazaoSocial = "AMIL";
            planoOperadora.CNPJ = "0000000000191";
            planoOperadora.DataEnvioLote = DateTime.Now;
            planoOperadora.DataRecebimentoLote = DateTime.Now;
            planoOperadora.Procedimentos = new List<Model.Procedimentos>() { MockProcedimento.CriarMockProcedimento() };
            planoOperadora.Arquivos = new List<Arquivos>() { MockArquivos.CriarMockArquivo() };
            planoOperadora.Status = Status.PlanoOperadora.Criada.GetHashCode();
            return planoOperadora;
        }

        public static RequestPlanoOperadora AtualizarMockPlanoOperadora()
        {
            RequestPlanoOperadora planoOperadora = new RequestPlanoOperadora();
            planoOperadora.Id = 1;
            planoOperadora.NomeFantasia = "FANTA";
            planoOperadora.RazaoSocial = "COCA";
            planoOperadora.CNPJ = "27664821000189";
            planoOperadora.DataEnvioLote = DateTime.Now;
            planoOperadora.DataRecebimentoLote = DateTime.Now.AddDays(14);
            planoOperadora.Procedimentos = new List<Model.Procedimentos>() { MockProcedimento.CriarMockProcedimento() };
            planoOperadora.Arquivos = new List<Arquivos>() { MockArquivos.CriarMockArquivo() };
            planoOperadora.PublicID = new Guid("65477444-8859-11e9-a07d-705a0f6970c5");
            planoOperadora.Status = Status.PlanoOperadora.Criada.GetHashCode();

            return planoOperadora;
        }

    }
}
