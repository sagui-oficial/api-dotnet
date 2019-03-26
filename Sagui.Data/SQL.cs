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
                   INSERT INTO dbo.Arquivo
                               (Nome
                               ,DataCriacao
                               ,Stream
                               ,PathArquivo)
                         VALUES
                               (@Nome
                               ,@DataCriacao
                               ,@Stream
                               ,@PathArquivo);

                SELECT SCOPE_IDENTITY();";

        public static string CreateArquivoGTO = @"
                   INSERT INTO dbo.Arquivo
                               (Nome
                               ,DataCriacao
                               ,Stream
                               ,PathArquivo)
                         VALUES
                               (@Nome
                               ,@DataCriacao
                               ,@Stream
                               ,@PathArquivo);

                SELECT SCOPE_IDENTITY();";

        public static string CreateArquivoPlanoOperadora = @"
                   INSERT INTO dbo.Arquivo
                               (Nome
                               ,DataCriacao
                               ,Stream
                               ,PathArquivo)
                         VALUES
                               (@Nome
                               ,@DataCriacao
                               ,@Stream
                               ,@PathArquivo);

                SELECT SCOPE_IDENTITY();";


        public static string ObterArquivoGTO = @"
                    SELECT  
	                       b.[Id]
                          ,b.[Nome]
                          ,b.[Stream]
                          ,b.[DataCriacao]
                          ,b.[PathArquivo]
                    FROM Arquivo_GTO a (NOLOCK)
		                    inner join Arquivo b (NOLOCK) ON a.idArquivo = b.Id
                    WHERE idGTO = @idGTO";

        public static string ObterArquivoPlanoOperadora = @"
                    SELECT  
	                       b.[Id]
                          ,b.[Nome]
                          ,b.[Stream]
                          ,b.[DataCriacao]
                          ,b.[PathArquivo]
                    FROM Arquivo_GTO a (NOLOCK)
		                    inner join Arquivo b (NOLOCK) ON a.idArquivo = b.Id
                    WHERE idGTO = @idGTO";

        public static string ListarArquivos = @"
                    SELECT  
	                       b.[Id]
                          ,b.[Nome]
                          ,b.[Stream]
                          ,b.[DataCriacao]
                          ,b.[PathArquivo]
                    FROM Arquivo b (NOLOCK)";
        #endregion

        #region GTO

        public static string CreateProcedimentoGTO = @"
                    INSERT INTO dbo.Procedimento_GTO
                               (IdGTO
                               ,IdProcedimento)
                         VALUES
                               (@IdGTO
                               ,@IdProcedimento);

                        SELECT SCOPE_IDENTITY();";

        public static string ListarProcedimentoGTO = @"
                    SELECT  
	                       b.[IdProcedimento]
                          ,b.[Codigo]
                          ,b.[NomeProcedimento]
                          ,b.[ValorProcedimento]
                          ,b.[Exigencias]
                          ,b.[Anotacoes]
                          ,b.[PublicID]
                    FROM 
                    Procedimento_GTO a (NOLOCK)
		                    inner join Procedimento b ON a.idProcedimento = b.IdProcedimento
                    where idGTO = @idGTO";

        public static string ListarArquivoGTO = @"
                    SELECT  
	                       b.[Id]
                          ,b.[Nome]
                          ,b.[Stream]
                          ,b.[DataCriacao]
                          ,b.[PathArquivo]
                          ,b.PublicID
                    FROM Arquivo_GTO a (NOLOCK)
		                    INNER join Arquivo b (NOLOCK) ON a.idArquivo = b.Id
                    WHERE idGTO = @idGTO";



        public static string DeleteGTO = @" UPDATE dbo.GTO
                                       SET Status = @Status
                                       WHERE publicID = @publicID   ";

        public static string UpdateGTO = @"
                   UPDATE dbo.GTO
                       SET Numero = @Numero
                          ,Solicitacao = @Solicitacao
                          ,Vencimento = @Vencimento
                          ,Status = @Status
                          ,PacienteId = @Paciente
                          ,PlanoOperadoraId = @PlanoOperadora
                     WHERE Id = @Id   ";

        public static string CreateGTO = @"
                INSERT INTO dbo.GTO
                           (Numero
                           , Status
                           , PlanoOperadoraId
                           , PacienteId
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
                                    SELECT  a.Id
                                        ,a.Numero
                                        ,a.Status
                                        ,a.PlanoOperadoraId
		                                ,b.NomeFantasia
		                                ,b.RazaoSocial
                                        ,a.PacienteId
		                                ,c.Nome
                                        ,a.Solicitacao
                                        ,a.Vencimento
                                        ,a.PublicID
                                    FROM sagui.dbo.GTO a (NOLOCK) 
			                                INNER JOIN  PlanoOperadora b (NOLOCK)  ON  a.PlanoOperadoraId = b.Id
			                                INNER JOIN  UsuarioBase c (NOLOCK)  ON  a.PacienteId = c.Id";

        public static string ObterGTObyPublicID = @"
                                     SELECT  a.Id
                                        ,a.Numero
                                        ,a.Status
                                        ,a.PlanoOperadoraId
		                                ,b.NomeFantasia
		                                ,b.RazaoSocial
                                        ,a.PacienteId
		                                ,c.Nome
                                        ,a.Solicitacao
                                        ,a.Vencimento
                                        ,a.PublicID
                                    FROM sagui.dbo.GTO a (NOLOCK) 
			                                INNER JOIN  PlanoOperadora b (NOLOCK)  ON  a.PlanoOperadoraId = b.Id
			                                INNER JOIN  UsuarioBase c (NOLOCK)  ON  a.PacienteId = c.Id
                            WHERE a.PublicID = @PublicID";

        #endregion

        #region procedimento

        public static string CreateProcedimento = @"
                    INSERT INTO dbo.Procedimento
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
                                  ,PublicID
                             FROM sagui.dbo.Procedimento";

        public static string ObterProcedimento = @"
                            SELECT IdProcedimento
                                  ,Codigo
                                  ,NomeProcedimento
                                  ,ValorProcedimento
                                  ,Exigencias
                                  ,Anotacoes
                                  ,PublicID
                             FROM sagui.dbo.Procedimento
                            WHERE PublicID = @PublicID";

        public static string DeleteProcedimento = @"
                            UPDATE sagui.dbo.Procedimentos
                                    SET Status = @Status
                            WHERE PublicID = @PublicID";

        public static string UpdateProcedimento = @"
                            UPDATE  sagui.dbo.Procedimento
                                    SET Codigo = @Codigo
                                      ,NomeProcedimento = @NomeProcedimento
                                      ,ValorProcedimento = @ValorProcedimento
                                      ,Exigencias = @Exigencias
                                      ,Anotacoes = @Anotacoes
                            WHERE PublicID = @PublicID";
        #endregion

        #region usuario


        public static string ObterUsuario = @"
                            SELECT Id
                                  ,Funcao
                                  ,Nome
                                  ,Anotacoes
                                  ,CPF
                                  ,Email
                                  ,Telefone
                                  ,CRO
                                  ,Discriminator
                                  ,PublicId
                              FROM dbo.UsuarioBase 
                            WHERE TipoUsuario = @TipoUsuario
                              AND PublicID = @PublicID";


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
                                  ,PublicId
                              FROM dbo.UsuarioBase 
                            WHERE TipoUsuario = @TipoUsuario";


        public static string CreateUsuarioPaciente = @"
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

        public static string UpdateUsuarioPaciente = @"
                UPDATE dbo.UsuarioBase
                       SET Funcao = @Funcao
                          ,Nome = @Nome
                          ,Anotacoes = @Anotacoes
                          ,CPF = @CPF
                          ,Email = @Email
                          ,Telefone = @Telefone
                          ,Discriminator = @Discriminator
                     WHERE PublicId = @PublicId";



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

        public static string UpdateUsuarioFuncionario = @"
                UPDATE dbo.UsuarioBase
                       SET Funcao = @Funcao
                          ,Nome = @Nome
                          ,Anotacoes = @Anotacoes
                          ,CPF = @CPF
                          ,Email = @Email
                          ,Telefone = @Telefone
                          ,Discriminator = @Discriminator
                     WHERE PublicId = @PublicId";

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

        public static string UpdateUsuarioDentista = @"
                UPDATE dbo.UsuarioBase
                       SET Funcao = @Funcao
                          ,Nome = @Nome
                          ,Anotacoes = @Anotacoes
                          ,CPF = @CPF
                          ,Email = @Email
                          ,Telefone = @Telefone
                          ,CRO = @CRO
                          ,Discriminator = @Discriminator
                     WHERE PublicId = @PublicId";


        public static string DeleteUsuario = @"
                            DELETE FROM sagui.dbo.UsuarioBase
                            WHERE PublicID = @PublicID";

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

        public static string CreatePlanoOperadora = @"
                    INSERT INTO dbo.PlanoOperadora
                       (NomeFantasia
                       ,RazaoSocial
                       ,CNPJ
                       ,DataEnvioLote
                       ,DataRecebimentoLote)
                 VALUES
                       (@NomeFantasia
                       ,@RazaoSocial
                       ,@CNPJ
                       ,@DataEnvioLote
                       ,@DataRecebimentoLote);

                SELECT SCOPE_IDENTITY();";

    }
}
