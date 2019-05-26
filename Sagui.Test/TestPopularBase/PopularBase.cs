using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using Sagui.Data;
using Sagui.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Sagui.Test.TestPopularBase
{
    [TestClass]
   public class PopularBase
    {

        [TestMethod]
        public void popular() {

            try
            {

           
                 var optionsBuilder = new DbContextOptions<Sagui.Postgres.Sagui>();
                 var context = new Sagui.Postgres.Sagui(optionsBuilder);


                if (!context.Procedimento.Any())
                {
                    var procedimentos = new List<Procedimentos>
                        {
                        new Procedimentos{Id = 1, Codigo="1",NomeProcedimento="Procedimento 1",Exigencias="AAAAAAAAAAAAA", Anotacoes="AAAAAAAAAAAAA", ValorProcedimento= 1.0, Status= 1},
                        new Procedimentos{Id = 2, Codigo="2",NomeProcedimento="Procedimento 2",Exigencias="AAAAAAAAAAAAA", Anotacoes="AAAAAAAAAAAAA", ValorProcedimento= 1.0, Status= 1},
                        };


                    foreach (Procedimentos p in procedimentos)
                    {
                        try
                        {
                            context.Database.ExecuteSqlCommand(SQL.CreateProcedimento,
                        new NpgsqlParameter("Codigo", p.Codigo),
                        new NpgsqlParameter("NomeProcedimento", p.NomeProcedimento),
                        new NpgsqlParameter("ValorProcedimento", p.ValorProcedimento),
                        new NpgsqlParameter("Exigencias", p.Exigencias),
                        new NpgsqlParameter("Anotacoes", p.Anotacoes));
                        }
                        catch (Exception e)
                        {

                            throw;
                        }

                        
                    }


                }

                if (!context.Arquivo.Any())
                {
                    var sevenItems = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
                    var arquivo = new List<Arquivos>
                    {
                     
                    new Arquivos{Id= 1, Nome= "Arquivo 01", Stream = sevenItems, PathArquivo = "C:\\teste01.jpg", DataCriacao = DateTime.Parse("2019-09-01") },
                    new Arquivos{Id= 2, Nome= "Arquivo 02", Stream = sevenItems, PathArquivo = "C:\\teste02.jpg", DataCriacao = DateTime.Parse("2019-09-01") },
                
                    };

                    

                    foreach (Arquivos p in arquivo)
                    {
                        context.Database.ExecuteSqlCommand(SQL.CreateArquivo,
                        new NpgsqlParameter("Id", p.Id),
                        new NpgsqlParameter("Nome", p.Nome),
                        new NpgsqlParameter("Stream", p.Stream),
                        new NpgsqlParameter("PathArquivo", p.PathArquivo),
                        new NpgsqlParameter("DataCriacao", p.DataCriacao));
                    }


                }

                if (!context.PlanoOperadora.Any())
                {
                    var planoOperadora = new List<PlanoOperadora>
                    {
                    new PlanoOperadora{NomeFantasia="Plano 1", RazaoSocial="Plano numero 1", CNPJ="00000000000000", DataEnvioLote=DateTime.Parse("2019-09-01"),DataRecebimentoLote=DateTime.Parse("2019-09-01")},
                    new PlanoOperadora{NomeFantasia="Plano 2", RazaoSocial="Plano numero 2", CNPJ="00000000000001", DataEnvioLote=DateTime.Parse("2019-09-01"),DataRecebimentoLote=DateTime.Parse("2019-09-01")},
                    };


                    foreach (PlanoOperadora p in planoOperadora)
                    {
                        context.Database.ExecuteSqlCommand(SQL.CreatePlanoOperadora,
                        new NpgsqlParameter("NomeFantasia", p.NomeFantasia),
                        new NpgsqlParameter("RazaoSocial", p.RazaoSocial),
                        new NpgsqlParameter("CNPJ", p.CNPJ),
                        new NpgsqlParameter("DataEnvioLote", p.DataEnvioLote),
                        new NpgsqlParameter("DataRecebimentoLote", p.DataRecebimentoLote));
                    }

                    if (!context.UsuarioBase.Any())
                    {



                        var funcionarios = new List<Funcionario>
                        {
                           new Funcionario{Nome="João", Anotacoes="AAAAAAAAAAAAA", CPF="00000000000", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",TipoUsuario = 1},
                           new Funcionario{Nome="Mauro", Anotacoes="AAAAAAAAAAAAA", CPF="00000000001", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000", TipoUsuario = 1},
                        };

                        foreach (Funcionario p in funcionarios)
                        {
                            context.Database.ExecuteSqlCommand(SQL.CreateUsuarioFuncionario,
                            new NpgsqlParameter("Nome", p.Nome),
                            new NpgsqlParameter("Anotacoes", p.Anotacoes),
                            new NpgsqlParameter("CPF", p.CPF),
                            new NpgsqlParameter("Email", p.Email),
                            new NpgsqlParameter("Funcao", p.Funcao),
                            new NpgsqlParameter("Telefone", p.Telefone),
                            new NpgsqlParameter("TipoUsuario", p.TipoUsuario));
                        }



                        var dentinstas = new List<Dentinsta>
                        {
                        new Dentinsta{Nome="Carlos", Anotacoes="AAAAAAAAAAAAA", CPF="00000000002", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",CRO="10000000", TipoUsuario = 2},
                        new Dentinsta{Nome="Antonio", Anotacoes="AAAAAAAAAAAAA", CPF="00000000003", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",CRO="20000000", TipoUsuario = 2},
                        };

                        foreach (Dentinsta p in dentinstas)
                        {
                            context.Database.ExecuteSqlCommand(SQL.CreateUsuarioFuncionario,
                            new NpgsqlParameter("Nome", p.Nome),
                            new NpgsqlParameter("Anotacoes", p.Anotacoes),
                            new NpgsqlParameter("CPF", p.CPF),
                            new NpgsqlParameter("Email", p.Email),
                            new NpgsqlParameter("Funcao", p.Funcao),
                            new NpgsqlParameter("Telefone", p.Telefone),
                            new NpgsqlParameter("TipoUsuario", p.TipoUsuario),
                            new NpgsqlParameter("CRO", p.CRO));
                        }


                        var pacientes = new List<Paciente>
                        {
                        new Paciente{Nome="Pedro", Anotacoes="AAAAAAAAAAAAA", CPF="00000000004", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",TipoUsuario = 3},
                        new Paciente{Nome="José", Anotacoes="AAAAAAAAAAAAA", CPF="00000000005", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",TipoUsuario = 3},
                        };

                        foreach (Paciente p in pacientes)
                        {
                            context.Database.ExecuteSqlCommand(SQL.CreateUsuarioFuncionario,
                            new NpgsqlParameter("Nome", p.Nome),
                            new NpgsqlParameter("Anotacoes", p.Anotacoes),
                            new NpgsqlParameter("CPF", p.CPF),
                            new NpgsqlParameter("Email", p.Email),
                            new NpgsqlParameter("Funcao", p.Funcao),
                            new NpgsqlParameter("Telefone", p.Telefone),
                            new NpgsqlParameter("TipoUsuario", p.TipoUsuario));
                        }


                    }

                }
                
              
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
                throw;
            }


        }

    }
}
