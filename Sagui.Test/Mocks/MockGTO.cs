using Sagui.Model;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public static class MockGTO
    {
        public static RequestGTO CriarMockGTO()
        {
            RequestGTO Guia = new RequestGTO();
            Guia.Id = 1;
            Guia.Numero = "1";
            Guia.PlanoOperadora = new PlanoOperadora();
            Guia.PlanoOperadora.Id = 1;
            Guia.PlanoOperadora.NomeFantasia = "Operadora 1";
            Guia.Paciente = new Paciente();
            Guia.Paciente.Id = 1;
            Guia.Paciente.Nome = "Paciente 1";
            Guia.Solicitacao = DateTime.Now;
            Guia.Vencimento = DateTime.Now.AddMonths(1);
            Guia.Procedimentos = new List<Model.Procedimentos>();
            Guia.Procedimentos.Add(MockProcedimento.CriarMockProcedimento());
            Guia.Procedimentos.Add(MockProcedimento.CriarMockProcedimentoB());
            Guia.Arquivos = new List<Model.Arquivo_GTO>() { MockArquivos.CriarMockArquivo() };
            Guia.Status = 1;
            Guia.ValorTotalProcedimentos = 100;
            Guia.PublicID = new Guid("12671800-8e31-11e9-8f2c-705a0f6970c5");

            return Guia;
        }

        public static RequestGTO CriarMockGTO_A()
        {
            RequestGTO Guia = new RequestGTO();
            Guia.Id = 2;
            Guia.Numero = "1";
            Guia.PlanoOperadora = new PlanoOperadora();
            Guia.PlanoOperadora.Id = 1;
            Guia.PlanoOperadora.NomeFantasia = "Operadora 1";
            Guia.Paciente = new Paciente();
            Guia.Paciente.Id = 1;
            Guia.Paciente.Nome = "Paciente 1";
            Guia.Solicitacao = DateTime.Now;
            Guia.Vencimento = DateTime.Now.AddMonths(1);
            Guia.Procedimentos = new List<Model.Procedimentos>();
            Guia.Procedimentos.Add(MockProcedimento.CriarMockProcedimento());
            Guia.Procedimentos.Add(MockProcedimento.CriarMockProcedimentoB());
            Guia.Arquivos = new List<Model.Arquivo_GTO>() { MockArquivos.CriarMockArquivo() };
            Guia.Status = 1;
            Guia.ValorTotalProcedimentos = 50;
            Guia.PublicID = new Guid("46e570b8-8e95-11e9-82dc-705a0f6970c5");

            return Guia;
        }

        public static RequestGTO AtualizarMockGTO()
        {
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
            Guia.Procedimentos = new List<Model.Procedimentos>() { MockProcedimento.CriarMockProcedimento() };
            Guia.Arquivos = new List<Arquivo_GTO>() { MockArquivos.CriarMockArquivo() };
            Guia.Status = 100;
            Guia.PublicID = new Guid("d52405b8-84a1-11e9-924d-705a0f6970c5");

            List<Procedimentos> procedimentos = new List<Procedimentos>();

            procedimentos.Add(new Procedimentos { Id = 5, ValorProcedimento = 10 });
            procedimentos.Add(new Procedimentos { Id = 3, ValorProcedimento = 50 });
            procedimentos.Add(new Procedimentos { Id = 4, ValorProcedimento = 10 });

            Guia.Procedimentos = procedimentos;

            return Guia;
        }

        public static RequestGTO DeletarMockGTO()
        {
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
            Guia.Procedimentos = new List<Model.Procedimentos>() { MockProcedimento.CriarMockProcedimento() };
            Guia.Arquivos = new List<Arquivo_GTO>() { MockArquivos.CriarMockArquivo() };
            Guia.Status = 99;

            return Guia;
        }

    }
}
