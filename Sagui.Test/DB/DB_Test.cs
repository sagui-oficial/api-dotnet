using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sagui.Model;
using Sagui.Data;
using System.Data.SqlClient;
using SaguiDB;

namespace Sagui.Test.DB
{
    /// <summary>
    /// Descrição resumida para DB_Test
    /// </summary>
    [TestClass]
    public class DB_Test
    {
       
        [TestMethod]
        public void TestMethod1()
        {
            //Sagui.Sagui context;

            //var funcionarios = new List<Funcionario>
            //    {
            //    new Funcionario{Nome="João", Anotacoes="AAAAAAAAAAAAA", CPF="00000000000", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000",TipoUsuario = 1},
            //    new Funcionario{Nome="Mauro", Anotacoes="AAAAAAAAAAAAA", CPF="00000000001", Email="email@email.com.br",Funcao="Usuario", Telefone="11-00000-0000", TipoUsuario = 1},
            //    };

            //foreach (Funcionario p in funcionarios)
            //{
            //    context.Database.ExecuteSqlCommand(SQL.CreateUsuarioFuncionario,
            //    new SqlParameter("Nome", p.Nome),
            //    new SqlParameter("Anotacoes", p.Anotacoes),
            //    new SqlParameter("CPF", p.CPF),
            //    new SqlParameter("Email", p.Email),
            //    new SqlParameter("Funcao", p.Funcao),
            //    new SqlParameter("Telefone", p.Telefone),
            //    new SqlParameter("TipoUsuario", p.TipoUsuario));
            //}

        }
    }
}
