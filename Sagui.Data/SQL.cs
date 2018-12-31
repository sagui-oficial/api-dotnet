using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data
{
    public static class SQL
    {
        public static string CreateArquivo = @"
                   INSERT INTO dbo.Arquivos
                               (Nome
                               ,DataCriacao
                               ,Stream)
                         VALUES
                               (@Nome
                               ,@DataCriacao
                               ,@Stream);

                SELECT SCOPE_IDENTITY();";


        public static string CreateProcedimentoGTO = @"
                    INSERT INTO dbo.Procedimento_GTO
                               (IdGTO
                               ,IdProcedimento)
                         VALUES
                               (@IdGTO
                               ,@IdProcedimento);

                        SELECT SCOPE_IDENTITY();";


        public static string CreateProcedimento = @"
                    INSERT INTO dbo.Procedimentos
                               (Codigo
                               ,NomeProcedimento
                               ,ValorProcedimento
                               ,Exigencias
                               ,Anotacoes)
                         VALUES
                               (@Codigo
                               ,@NomeProcedimento
                               ,@ValorProcedimento
                               ,@Exigencias
                               ,@Anotacoes);

                            SELECT SCOPE_IDENTITY();";

        public static string DeleteGTO = @"AA";

        public static string UpdateGTO = @"";

        public static string CreateGTO = @"
                INSERT INTO dbo.GTO
                           (Numero
                           , Status
                           , Operadora_IdOperadora
                           , Paciente_IdPaciente
                           , Solicitacao
                           , Vencimento)
                     VALUES
                           (@Numero
                           , @Status
                           , @Operadora
                           , @Paciente
                           , @Solicitacao
                           , @Vencimento);
                
                SELECT SCOPE_IDENTITY()";

        public static string ListGTO = @"
                            SELECT Id
                                  ,Numero
                                  ,Status
                                  ,Operadora_IdOperadora
                                  ,Paciente_IdPaciente
                                  ,Solicitacao
                                  ,Vencimento
                             FROM sagui.dbo.GTO";

        public static string ListProcedimento = @"
                            SELECT IdProcedimento
                                  ,Codigo
                                  ,NomeProcedimento
                                  ,ValorProcedimento
                                  ,Exigencias
                                  ,Anotacoes
                             FROM sagui.dbo.Procedimentos";

        public static string ListUsuario = @"
                            SELECT *
                             FROM sagui.dbo.usuarios";

        public static string CreateUsuario = @"
                INSERT INTO dbo.GTO
                           (Numero
                           , Status
                           , Operadora
                           , Paciente
                           , Solicitacao
                           , Vencimento)
                     VALUES
                           (@Numero
                           , @Status
                           , @Operadora
                           , @Paciente
                           , @Solicitacao
                           , @Vencimento);
                
                SELECT SCOPE_IDENTITY()";

    }
}
