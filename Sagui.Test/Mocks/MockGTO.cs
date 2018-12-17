using Sagui.Model;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public class MockGTO
    {
        public RequestGTO CriarMockGTO()
        {
            MockProcedimento mockProcedimento = new MockProcedimento();
            MockArquivos mockArquivos  = new MockArquivos();

            RequestGTO Guia = new RequestGTO();
            Guia.Id = 10;
            Guia.Numero = 1;
            Guia.Operadora = new Operadora();
            Guia.Operadora.IdOperadora = 1;
            Guia.Operadora.NomeOperadora = "Operadora 1";
            Guia.Paciente = new Paciente();
            Guia.Paciente.IdPaciente = 1;
            Guia.Paciente.NomePaciente = "Paciente 1";
            Guia.Solicitacao = DateTime.Now;
            Guia.Vencimento = DateTime.Now.AddMonths(1);
            Guia.Procedimentos = new List<Model.Procedimentos>() { mockProcedimento.CriarMockProcedimento() };
            Guia.Arquivos = new List<Arquivos>() { mockArquivos.CriarMockArquivo() };
            Guia.Status = 1;

            return Guia;
        }
    }
}
