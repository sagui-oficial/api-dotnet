using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data
{
    public static class SQL
    {
        public static string DeleteGTO = @"";

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
