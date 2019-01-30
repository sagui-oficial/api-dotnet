using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data
{
    public static class SQL
    {
        #region arquivos
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

        #endregion

        #region GTR

        public static string CreateProcedimentoGTO = @"
                    INSERT INTO dbo.Procedimento_GTO
                               (IdGTO
                               ,IdProcedimento)
                         VALUES
                               (@IdGTO
                               ,@IdProcedimento);

                        SELECT SCOPE_IDENTITY();";

             

        public static string DeleteGTO = @" UPDATE dbo.GTO
                                       SET Status = @Status
                                       WHERE Id = @Id   ";

        public static string UpdateGTO = @"
                   UPDATE dbo.GTO
                       SET Numero = @Numero
                          ,Solicitacao = @Solicitacao
                          ,Vencimento = @Vencimento
                          ,Status = @Status
                          ,Paciente_Id = @Paciente
                          ,PlanoOperadora_Id = @PlanoOperadora
                     WHERE Id = @Id   ";

        public static string CreateGTO = @"
                INSERT INTO dbo.GTO
                           (Numero
                           , Status
                           , PlanoOperadora_Id
                           , Paciente_Id
                           , Solicitacao
                           , Vencimento)
                     VALUES
                           (@Numero
                           , @Status
                           , @PlanoOperadora
                           , @Paciente
                           , @Solicitacao
                           , @Vencimento);
                
                SELECT SCOPE_IDENTITY()";

        public static string ListGTO = @"
                                     SELECT Id
                                  ,Numero
                                  ,Status
                                  ,PlanoOperadora_Id
                                  ,Paciente_Id
                                  ,Solicitacao
                                  ,Vencimento
                             FROM sagui.dbo.GTO";

        #endregion

        #region procedimento

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
        public static string ListProcedimento = @"
                            SELECT IdProcedimento
                                  ,Codigo
                                  ,NomeProcedimento
                                  ,ValorProcedimento
                                  ,Exigencias
                                  ,Anotacoes
                             FROM sagui.dbo.Procedimentos";

        public static string DeleteProcedimento = @"
                            DELETE FROM sagui.dbo.Procedimentos
                            WHERE IdProcedimento = @IdProcedimento";

        public static string UpdateProcedimento = @"
                            UPDATE  sagui.dbo.Procedimentos
                                    SET Codigo = @Codigo
                                      ,NomeProcedimento = @NomeProcedimento
                                      ,ValorProcedimento = @ValorProcedimento
                                      ,Exigencias = @Exigencias
                                      ,Anotacoes = @Anotacoes
                            WHERE IdProcedimento = @IdProcedimento";
        #endregion

        #region usuario

        
        public static string ListUsuario = @"
                            SELECT Id
                                  ,Funcao
                                  ,Nome
                                  ,Anotacoes
                                  ,CPF
                                  ,Email
                                  ,Telefone
                                  ,CRO
                                  ,Discriminator
                              FROM dbo.UsuarioBase 
                            WHERE TipoUsuario = @TipoUsuario";


        public static string CreateUsuario = @"
                INSERT INTO dbo.UsuarioBase
                               (Funcao
                               ,Nome
                               ,Anotacoes
                               ,CPF
                               ,Email
                               ,Telefone
                               ,TipoUsuario)
                         VALUES
                               (@Funcao
                               ,@Nome
                               ,@Anotacoes
                               ,@CPF
                               ,@Email
                               ,@Telefone
                               ,@TipoUsuario);
                
                SELECT SCOPE_IDENTITY()";



        public static string CreateUsuarioFuncionario = @"
                INSERT INTO dbo.UsuarioBase
                               (Funcao
                               ,Nome
                               ,Anotacoes
                               ,CPF
                               ,Email
                               ,Telefone
                               ,TipoUsuario)
                         VALUES
                               (@Funcao
                               ,@Nome
                               ,@Anotacoes
                               ,@CPF
                               ,@Email
                               ,@Telefone
                               ,@TipoUsuario);
                
                SELECT SCOPE_IDENTITY()";

        public static string CreateUsuarioDentista = @"
                INSERT INTO dbo.UsuarioBase
                               (Funcao
                               ,Nome
                               ,Anotacoes
                               ,CPF
                               ,Email
                               ,Telefone
                               ,TipoUsuario
                               ,CRO)
                         VALUES
                               (@Funcao
                               ,@Nome
                               ,@Anotacoes
                               ,@CPF
                               ,@Email
                               ,@Telefone
                               ,@TipoUsuario
                               ,@CRO);
                
                SELECT SCOPE_IDENTITY()";

        public static string UpdateUsuario = @"
                UPDATE dbo.UsuarioBase
                       SET Funcao = @Funcao
                          ,Nome = @Nome
                          ,Anotacoes = @Anotacoes
                          ,CPF = @CPF
                          ,Email = @Email
                          ,Telefone = @Telefone
                          ,CRO = @CRO
                          ,Discriminator = @Discriminator
                     WHERE Id = @Id";


        public static string DeleteUsuario = @"";

        #endregion

        public static string CreatePlanoOperadoraPaciente = @"
                    INSERT INTO dbo.PlanoOperadoraPaciente
                       (NumeroPlano
                       ,PlanoOperadora_Id
                       ,Paciente_Id)
                 VALUES
                       (@NumeroPlano
                       ,@PlanoOperadora_Id
                       ,@Paciente_Id);

                SELECT SCOPE_IDENTITY();";

    }
}
