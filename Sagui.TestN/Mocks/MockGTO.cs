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
            Guia.Numero = "1";
            Guia.PlanoOperadora = new PlanoOperadora();
            Guia.PlanoOperadora.Id = 1;
            Guia.PlanoOperadora.NomeFantasia = "Operadora 1";
            Guia.Paciente = new Paciente();
            Guia.Paciente.Id = 2;
            Guia.Paciente.Nome = "Paciente 1";
            Guia.Solicitacao = DateTime.Now;
            Guia.Vencimento = DateTime.Now.AddMonths(1);
            Guia.Procedimentos = new List<Model.Procedimentos>() { mockProcedimento.CriarMockProcedimento() };
            Guia.Arquivos = new List<Arquivos>() { mockArquivos.CriarMockArquivo() };
            Guia.Status = 1;

            return Guia;
        }

         public RequestGTO AtualizarMockGTO()
        {
            MockProcedimento mockProcedimento = new MockProcedimento();
            MockArquivos mockArquivos  = new MockArquivos();

            RequestGTO Guia = new RequestGTO();
            Guia.Id = 1;
            Guia.Numero = "1";
            Guia.PlanoOperadora = new PlanoOperadora();
            Guia.PlanoOperadora.Id = 1;
            Guia.PlanoOperadora.NomeFantasia = "Operadora 1";
            Guia.Paciente = new Paciente();
            Guia.Paciente.Id = 2;
            Guia.Paciente.Nome = "Paciente 1";
            Guia.Solicitacao = DateTime.Now;
            Guia.Vencimento = DateTime.Now.AddMonths(1);
            Guia.Procedimentos = new List<Model.Procedimentos>() { mockProcedimento.CriarMockProcedimento() };
            Guia.Arquivos = new List<Arquivos>() { mockArquivos.CriarMockArquivo() };
            Guia.Status = 10;

            return Guia;
        }

        public RequestGTO DeletarMockGTO()
        {
            MockProcedimento mockProcedimento = new MockProcedimento();
            MockArquivos mockArquivos = new MockArquivos();

            RequestGTO Guia = new RequestGTO();
            Guia.Id = 1;
            Guia.Numero = "1";
            Guia.PlanoOperadora = new PlanoOperadora();
            Guia.PlanoOperadora.Id = 1;
            Guia.PlanoOperadora.NomeFantasia = "Operadora 1";
            Guia.Paciente = new Paciente();
            Guia.Paciente.Id = 2;
            Guia.Paciente.Nome = "Paciente 1";
            Guia.Solicitacao = DateTime.Now;
            Guia.Vencimento = DateTime.Now.AddMonths(1);
            Guia.Procedimentos = new List<Model.Procedimentos>() { mockProcedimento.CriarMockProcedimento() };
            Guia.Arquivos = new List<Arquivos>() { mockArquivos.CriarMockArquivo() };
            Guia.Status = 99;

            return Guia;
        }

    }
}
