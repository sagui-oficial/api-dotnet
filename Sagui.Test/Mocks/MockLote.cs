using Sagui.Model;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public static class MockLote
    {
        public static RequestLote CriarMockLote()
        {
            RequestLote Lote = new RequestLote();
            Lote.Id = 1;
            Lote.PlanoOperadora = new PlanoOperadora();
            Lote.PlanoOperadora.Id = 1;
            Lote.PlanoOperadora.NomeFantasia = "Operadora 1";
            Lote.Funcionario = new Funcionario();
            Lote.Funcionario.Id = 1;
            Lote.Funcionario.Nome = "Funcionario 1";
            Lote.DataEnvioCorreio = DateTime.Now;
            Lote.DataPrevistaRecebimento = DateTime.Now.AddMonths(1);
            Lote.TotalGTOLote = 0;
            Lote.ValorTotalLote = 0;
            Lote.Status = 1;
            Lote.ListaGTO = new List<GTO>();
            Lote.ListaGTO.Add(MockGTO.CriarMockGTO());
            Lote.ListaGTO.Add(MockGTO.CriarMockGTO_A());
            Lote.PublicID = new Guid("75bd6e88-87ea-11e9-b59f-74867af96707");

            return Lote;
        }

        public static RequestLote AtualizarMockLote()
        {
            RequestLote Lote = new RequestLote();
            Lote.Id = 1;
            Lote.PlanoOperadora = new PlanoOperadora();
            Lote.PlanoOperadora.Id = 1;
            Lote.PlanoOperadora.NomeFantasia = "Operadora 1";
            Lote.Funcionario = new Funcionario();
            Lote.Funcionario.Id = 1;
            Lote.Funcionario.Nome = "Funcionario 1";
            Lote.DataEnvioCorreio = DateTime.Now;
            Lote.DataPrevistaRecebimento = DateTime.Now.AddMonths(1);
            Lote.TotalGTOLote = 0;
            Lote.ValorTotalLote = 0;
            Lote.Status = 1;
            Lote.ListaGTO = new List<GTO>();
            Lote.ListaGTO.Add(MockGTO.CriarMockGTO());
            Lote.ListaGTO.Add(MockGTO.CriarMockGTO_A());
            Lote.PublicID = new Guid("65401e50-8e95-11e9-8efb-705a0f6970c5");

            return Lote;
        }

        public static RequestLote DeletarMockLote()
        {
            RequestLote Lote = new RequestLote();
            Lote.Id = 1;
            Lote.PublicID = new Guid("b597e110-7ff6-11e9-b649-705a0f6970c5");

            return Lote;
        }

        public static RequestLote ObterLoterMock()
        {
            RequestLote Lote = new RequestLote();
            Lote.Id = 1;
            Lote.PublicID = new Guid("b597e110-7ff6-11e9-b649-705a0f6970c5");

            return Lote;
        }
    }
}
