using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data
{
    public static class SQL
    {
        public static string CreateProcedimentoGTO = @"
                    INSERT INTO dbo.Procedimento_GTO
                       (IdGTO
                       ,IdProcedimento)
                 VALUES
                       (@IdGTO
                       ,@IdProcedimento);

                SELECT SCOPE_IDENTITY();";


        public static string CreateProcedimento = @"
                    INSERT INTO dbo.Procedimento
                               (Codigo
                               ,NomeProcedimento
                               ,ValorProcedimento)
                         VALUES
                               (@Codigo
                               ,@NomeProcedimento
                               ,@ValorProcedimento);

                            SELECT SCOPE_IDENTITY();";

        public static string DeleteGTO = @"AA";

        public static string UpdateGTO = @"";

        public static string CreateGTO = @"
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

        public static string ListGTO = @"
                            SELECT Id
                                  ,Numero
                                  ,Status
                                  ,Operadora
                                  ,Paciente
                                  ,Solicitacao
                                  ,Vencimento
                             FROM sagui.dbo.GTO";
    }
}
