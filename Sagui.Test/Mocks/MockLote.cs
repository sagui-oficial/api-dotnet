﻿using Sagui.Model;
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

            // Lote.PublicID = new Guid("");

            return Lote;
        }

        public static RequestLote AtualizarMockGTO()
        {
            RequestLote Lote = new RequestLote();
            Lote.Id = 1;
            Lote.PlanoOperadora = new PlanoOperadora();
            Lote.PlanoOperadora.Id = 1;
            Lote.PlanoOperadora.NomeFantasia = "Operadora 1";
            Lote.Funcionario = new Funcionario();
            Lote.Funcionario.Id = 2;
            Lote.Funcionario.Nome = "Funcionario 2";
            Lote.DataEnvioCorreio = DateTime.Now;
            Lote.DataPrevistaRecebimento = DateTime.Now.AddMonths(1);
            Lote.TotalGTOLote = 12;
            Lote.ValorTotalLote = 7000;
            Lote.Status = 2;
            Lote.PublicID = new Guid("b597e110-7ff6-11e9-b649-705a0f6970c5");

            return Lote;
        }

        public static RequestGTO DeletarMockGTO()
        {
            MockProcedimento mockProcedimento = new MockProcedimento();
            MockArquivos mockArquivos = new MockArquivos();

            RequestGTO Lote = new RequestGTO();
            Lote.Id = 1;
            Lote.Numero = "1";
            Lote.PlanoOperadora = new PlanoOperadora();
            Lote.PlanoOperadora.Id = 1;
            Lote.PlanoOperadora.NomeFantasia = "Operadora 1";
            Lote.Paciente = new Paciente();
            Lote.Paciente.Id = 2;
            Lote.Paciente.Nome = "Paciente 1";
            Lote.Solicitacao = DateTime.Now;
            Lote.Vencimento = DateTime.Now.AddMonths(1);
            Lote.Procedimentos = new List<Model.Procedimentos>() { mockProcedimento.CriarMockProcedimento() };
            Lote.Arquivos = new List<Arquivo_GTO>() { mockArquivos.CriarMockArquivo() };
            Lote.Status = 99;
            Lote.PublicID = new Guid("b597e110-7ff6-11e9-b649-705a0f6970c5");

            return Lote;
        }

    }
}
