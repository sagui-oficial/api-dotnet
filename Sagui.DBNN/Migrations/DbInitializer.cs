using Microsoft.EntityFrameworkCore;
using Sagui.Data;
using Sagui.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sagui.DB.Migrations
{
    class DbInitializer
    {
        public static void Initialize(Sagui context)
        {

            context.Database.EnsureCreated();

            if (!context.Procedimento.Any())
            {
                var procedimentos = new List<Procedimentos>
                {
                new Procedimentos{Codigo=1,NomeProcedimento="Procedimento 1",Exigencias="AAAAAAAAAAAAA", Anotacoes="AAAAAAAAAAAAA", ValorProcedimento= 1.0},
                new Procedimentos{Codigo=2,NomeProcedimento="Procedimento 2",Exigencias="AAAAAAAAAAAAA", Anotacoes="AAAAAAAAAAAAA", ValorProcedimento= 1.0},
                };


                foreach (Procedimentos p in procedimentos)
                {
                    context.Database.ExecuteSqlCommand(SQL.CreateProcedimento,
                    new SqlParameter("Codigo", p.Codigo),
                    new SqlParameter("NomeProcedimento", p.NomeProcedimento),
                    new SqlParameter("ValorProcedimento", p.ValorProcedimento),
                    new SqlParameter("Exigencias", p.Exigencias),
                    new SqlParameter("Anotacoes", p.Anotacoes));
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
                        new SqlParameter("NomeFantasia", p.NomeFantasia),
                        new SqlParameter("RazaoSocial", p.RazaoSocial),
                        new SqlParameter("CNPJ", p.CNPJ),
                        new SqlParameter("DataEnvioLote", p.DataEnvioLote),
                        new SqlParameter("DataRecebimentoLote", p.DataRecebimentoLote));
                    }



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
                        //context.Database.ExecuteSqlCommand(SQL.CreateUsuarioFuncionario,
                        //new SqlParameter("Nome", p.Nome),
                        //new SqlParameter("Anotacoes", p.Anotacoes),
                        //new SqlParameter("CPF", p.CPF),
                        //new SqlParameter("Email", p.Email),
                        //new SqlParameter("Funcao", p.Funcao),
                        //new SqlParameter("Telefone", p.Telefone),
                        //new SqlParameter("TipoUsuario", p.TipoUsuario));
                    }



                    var dentinstas = new List<Dentinsta>
                {
                new Dentinsta{Nome="Carlos", Anotacoes="AAAAAAAAAAAAA", CPF="00000000002", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",CRO="10000000", TipoUsuario = 2},
                new Dentinsta{Nome="Antonio", Anotacoes="AAAAAAAAAAAAA", CPF="00000000003", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",CRO="20000000", TipoUsuario = 2},
                };

                    foreach (Dentinsta p in dentinstas)
                    {
                        //context.Database.ExecuteSqlCommand(SQL.CreateUsuarioFuncionario,
                        //new SqlParameter("Nome", p.Nome),
                        //new SqlParameter("Anotacoes", p.Anotacoes),
                        //new SqlParameter("CPF", p.CPF),
                        //new SqlParameter("Email", p.Email),
                        //new SqlParameter("Funcao", p.Funcao),
                        //new SqlParameter("Telefone", p.Telefone),
                        //new SqlParameter("TipoUsuario", p.TipoUsuario),
                        //new SqlParameter("CRO", p.CRO));
                    }


                    var pacientes = new List<Paciente>
                {
                new Paciente{Nome="Pedro", Anotacoes="AAAAAAAAAAAAA", CPF="00000000004", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",TipoUsuario = 3},
                new Paciente{Nome="José", Anotacoes="AAAAAAAAAAAAA", CPF="00000000005", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",TipoUsuario = 3},
                };

                    foreach (Paciente p in pacientes)
                    {
                        //context.Database.ExecuteSqlCommand(SQL.CreateUsuarioFuncionario,
                        //new SqlParameter("Nome", p.Nome),
                        //new SqlParameter("Anotacoes", p.Anotacoes),
                        //new SqlParameter("CPF", p.CPF),
                        //new SqlParameter("Email", p.Email),
                        //new SqlParameter("Funcao", p.Funcao),
                        //new SqlParameter("Telefone", p.Telefone),
                        //new SqlParameter("TipoUsuario", p.TipoUsuario));
                    }


                }

            }
        }
    }
}
