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
            Guia.Paciente.Id = 4;
            Guia.Paciente.Nome = "Paciente 1";
            Guia.Solicitacao = DateTime.Now;
            Guia.Vencimento = DateTime.Now.AddMonths(1);
            Guia.Procedimentos = new List<Model.Procedimentos>();
            Guia.Procedimentos.Add(mockProcedimento.CriarMockProcedimento());
            Guia.Procedimentos.Add(mockProcedimento.CriarMockProcedimentoB());
            Guia.Arquivos = new List<Model.Arquivo_GTO>() { mockArquivos.CriarMockArquivo() };
            Guia.Status = 1;
            Guia.PublicID = new Guid("9ac0756a-7fbe-11e9-a228-705a0f6970c5");

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
            Guia.Paciente.Id = 4;
            Guia.Paciente.Nome = "Paciente 1";
            Guia.Solicitacao = DateTime.Now;
            Guia.Vencimento = DateTime.Now.AddMonths(1);
            Guia.Procedimentos = new List<Model.Procedimentos>() { mockProcedimento.CriarMockProcedimento() };
            Guia.Arquivos = new List<Arquivo_GTO>() { mockArquivos.CriarMockArquivo() };
            Guia.Status = 100;
            Guia.PublicID = new Guid("d52405b8-84a1-11e9-924d-705a0f6970c5");

            List<Procedimentos> procedimentos = new List<Procedimentos>();

            procedimentos.Add(new Procedimentos { Id = 5, ValorProcedimento = 10 });
            procedimentos.Add(new Procedimentos { Id = 3, ValorProcedimento = 50 });
            procedimentos.Add(new Procedimentos { Id = 4, ValorProcedimento = 10 });

            Guia.Procedimentos = procedimentos;

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
            Guia.Arquivos = new List<Arquivo_GTO>() { mockArquivos.CriarMockArquivo() };
            Guia.Status = 99;

            return Guia;
        }

    }
}
