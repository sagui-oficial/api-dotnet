﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Data.Helper
{
    internal static class Parser
    {
        internal static Model.GTO ParseGTO(Npgsql.NpgsqlDataReader reader)
        {
            Model.GTO _GTO = new Model.GTO();
            _GTO.Id = Convert.ToInt32(reader["Id"]);
            _GTO.Numero = Convert.ToString(reader["Numero"]);
            _GTO.Status = Convert.ToInt32(reader["Status"]);
            _GTO.PlanoOperadora = new Model.PlanoOperadora();
            _GTO.PlanoOperadora.Id = Convert.ToInt32(reader["PlanoOperadoraId"]);
            _GTO.PlanoOperadora.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
            _GTO.PlanoOperadora.RazaoSocial = Convert.ToString(reader["RazaoSocial"]);
            _GTO.Paciente = new Model.Paciente();
            _GTO.Paciente.Id = Convert.ToInt32(reader["PacienteId"]);
            _GTO.Paciente.Nome = Convert.ToString(reader["Nome"]);
            _GTO.Solicitacao = Convert.ToDateTime(reader["Solicitacao"]);
            _GTO.Vencimento = Convert.ToDateTime(reader["Vencimento"]);
            _GTO.PublicID = (Guid)reader["PublicID"];
            _GTO.TotalProcedimentos = Convert.ToDouble(reader["TotalProcedimentos"]);
            _GTO.ValorTotalProcedimentos = Convert.ToDouble(reader["ValorTotalProcedimentos"]);

            return _GTO;
        }

        internal static Model.Lote ParseLote(Npgsql.NpgsqlDataReader reader, object model)
        {
            Model.Lote _Lote = new Model.Lote();

            _Lote.Id = Convert.ToInt32(reader["Id"]);
            _Lote.PublicID = (Guid)reader["PublicID"];
            _Lote.Status = Convert.ToInt32(reader["Status"]);
            _Lote.PlanoOperadora = new Model.PlanoOperadora();
            _Lote.PlanoOperadora.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
            _Lote.PlanoOperadora.RazaoSocial = Convert.ToString(reader["RazaoSocial"]);
            _Lote.Funcionario = new Model.Funcionario();
            _Lote.Funcionario.Id = Convert.ToInt32(reader["FuncionarioId"]);
            _Lote.Funcionario.Nome = Convert.ToString(reader["Nome"]);
            _Lote.DataEnvioCorreio = Convert.ToDateTime(reader["DataEnvioCorreio"]);
            _Lote.DataPrevistaRecebimento = Convert.ToDateTime(reader["DataPrevistaRecebimento"]);
            _Lote.TotalGTOLote = Convert.ToInt32(reader["TotalGTOLote"]);
            _Lote.ValorTotalLote = Convert.ToDouble(reader["ValorTotalLote"]);

            return _Lote;
        }

        internal static Model.PlanoOperadora ParsePlanoOperadora(Npgsql.NpgsqlDataReader reader)
        {
            Model.PlanoOperadora _PlanoOperadora = new Model.PlanoOperadora();
            _PlanoOperadora.Id = Convert.ToInt32(reader["Id"]);
            _PlanoOperadora.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
            _PlanoOperadora.RazaoSocial = Convert.ToString(reader["RazaoSocial"]);
            _PlanoOperadora.CNPJ = Convert.ToString(reader["CNPJ"]);
            _PlanoOperadora.DataEnvioLote = Convert.ToDateTime(reader["DataEnvioLote"]);
            _PlanoOperadora.DataRecebimentoLote = Convert.ToDateTime(reader["DataRecebimentoLote"]);
            _PlanoOperadora.PublicID = (Guid)reader["PublicID"];

            return _PlanoOperadora;
        }

        internal static Model.Procedimentos ParseProcedimento(Npgsql.NpgsqlDataReader reader,  bool comValor = false)
        {
            Model.Procedimentos _Procedimento = new Model.Procedimentos();
            _Procedimento.Id = Convert.ToInt32(reader["Id"]);
            _Procedimento.NomeProcedimento = Convert.ToString(reader["NomeProcedimento"]);
            _Procedimento.Codigo = Convert.ToString(reader["Codigo"]);

            if (comValor)
            {
                _Procedimento.ValorProcedimento = Convert.ToDouble(reader["ValorProcedimento"]);
            }

            _Procedimento.Exigencias = Convert.ToString(reader["Exigencias"]);
            _Procedimento.Anotacoes = Convert.ToString(reader["Anotacoes"]);
            _Procedimento.PublicID = (Guid)reader["PublicID"];

            return _Procedimento;
        }
    }
}