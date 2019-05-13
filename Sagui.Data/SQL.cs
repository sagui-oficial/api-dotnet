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


        #region ArquivoGTO

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

        public static string ListarArquivosGTO = @"
                    SELECT arq.Id
                          ,arq.Nome
                          ,arq.Stream
                          ,arq.DataCriacao
                          ,arq.PathArquivo
                          ,arq.Extensao
	                      ,agto.idArquivo_GTO
                          ,agto.PublicID
                          FROM dbo.Arquivo (NOLOCK) arq
                    INNER JOIN dbo.Arquivo_GTO (NOLOCK) agto
                       ON arq.Id = agto.idGTO";


        public static string ListarArquivoGTO = @"
                    SELECT arq.Id
                          ,arq.Nome
                          ,arq.Stream
                          ,arq.DataCriacao
                          ,arq.PathArquivo
                          ,arq.Extensao
	                      ,agto.idArquivo_GTO
                          ,agto.PublicID
                          FROM dbo.Arquivo arq
                    INNER JOIN dbo.Arquivo_GTO agto
                       ON arq.Id = agto.idGTO
                    WHERE agto.idGTO = @idGTO";


        public static string ObterArquivoGTOPorPublicId = @"
                    SELECT arq.Id
                          ,arq.Nome
                          ,arq.Stream
                          ,arq.DataCriacao
                          ,arq.PathArquivo
                          ,arq.Extensao
	                      ,agto.idArquivo_GTO
                          ,agto.PublicID
                          FROM dbo.Arquivo arq
                    INNER JOIN dbo.Arquivo_GTO agto
                       ON arq.Id = agto.idGTO
                    WHERE agto.PublicID = @PublicID";



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

        #endregion

        #region ArquivoPlanoOperadora

        public static string ObterArquivoPlanoOperadoraPorPublicId = @"
                    SELECT arq.Id
                          ,arq.Nome
                          ,arq.Stream
                          ,arq.DataCriacao
                          ,arq.PathArquivo
                          ,arq.Extensao
	                      ,apo.idArquivo_GTO
                          ,apo.PublicID
                          FROM dbo.Arquivo arq
                    INNER JOIN dbo.Arquivo_PlanoOperadora apo
                       ON arq.Id = apo.idPlanoOperadora
                    WHERE apo.PublicID = @PublicID";


        public static string ListarArquivoPlanoOperadora = @"
                    SELECT arq.Id
                          ,arq.Nome
                          ,arq.Stream
                          ,arq.DataCriacao
                          ,arq.PathArquivo
                          ,arq.Extensao
	                      ,apo.idArquivo_GTO
                          ,apo.PublicID
                          FROM dbo.Arquivo arq
                    INNER JOIN dbo.Arquivo_PlanoOperadora apo
                       ON arq.Id = apo.idPlanoOperadora
                    WHERE apo.idPlanoOperadora = @idPlanoOperadora";


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

        #endregion

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
                    INSERT INTO public.""Procedimento""
                               (""Codigo""
                               ,""NomeProcedimento""
                               ,""ValorProcedimento""
                               ,""Exigencias""
                               ,""Anotacoes"")
                         VALUES
                               (@Codigo
                               ,@NomeProcedimento
                               ,@ValorProcedimento
                               ,@Exigencias
                               ,@Anotacoes)
                            RETURNING ""IdProcedimento"";";
        public static string ListProcedimento = @"
                            SELECT ""IdProcedimento"", 
                                   ""Codigo"", 
                                   ""NomeProcedimento"", 
                                   ""ValorProcedimento"", 
                                   ""Exigencias"", 
                                   ""Anotacoes"", 
                                   ""PublicID""
	                        FROM public.""Procedimento""";

        public static string ObterProcedimento = @"
                            SELECT ""IdProcedimento""
                                  ,""Codigo""
                                  ,""NomeProcedimento""
                                  ,""ValorProcedimento""
                                  ,""Exigencias""
                                  ,""Anotacoes""
                                  ,""PublicID""
                             FROM public.""Procedimento""
                            WHERE ""PublicID""::""text"" = @PublicID";
        public static string DeleteProcedimento = @"
                            UPDATE public.""Procedimento""
                                    SET ""Status"" = @Status
                            WHERE ""PublicID""::""text"" = @PublicID";

        public static string UpdateProcedimento = @"
                            UPDATE  public.""Procedimento""
                                    SET ""Codigo = @Codigo
                                      ,""NomeProcedimento"" = @NomeProcedimento
                                      ,""ValorProcedimento"" = @ValorProcedimento
                                      ,""Exigencias"" = @Exigencias
                                      ,""Anotacoes"" = @Anotacoes
                            WHERE ""PublicID""::""text"" = @PublicID";
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

        #region PlanoOperadora
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


        public static string ObterPlanoOperadora = @"
                            SELECT Id
                                ,NomeFantasia
                                ,RazaoSocial
                                ,CNPJ
                                ,DataEnvioLote
                                ,DataRecebimentoLote
                                ,PublicId
                              FROM dbo.PlanoOperadora 
                            WHERE PublicID = @PublicID";


        public static string ListPlanoOperadora = @"
                            SELECT Id
                                ,NomeFantasia
                                ,RazaoSocial
                                ,CNPJ
                                ,DataEnvioLote
                                ,DataRecebimentoLote
                                ,PublicId
                              FROM dbo.PlanoOperadora";

        public static string UpdatePlanoOperadora = @"
                UPDATE dbo.PlanoOperadora
                       SET NomeFantasia = @NomeFantasia
                          ,RazaoSocial = @RazaoSocial
                          ,CNPJ = @CNPJ
                          ,DataEnvioLote = @DataEnvioLote
                          ,DataRecebimentoLote = @DataRecebimentoLote
                     WHERE PublicId = @PublicId";


        public static string DeletePlanoOperadora = @"
                            DELETE FROM dbo.PlanoOperadora
                            WHERE PublicID = @PublicID";

        #endregion

        #region Lote
        public static string CreateLote = @"
                    INSERT INTO dbo.Lote
                       (PlanoOperadoraId
                       ,TotalGTOLote
                       ,ValorTotalLote
                       ,DataEnvioCorreio
                       ,DataPrevistaRecebimento
                       ,StatusLote
                       ,FuncionarioId)
                 VALUES
                       (@PlanoOperadora
                       ,@TotalGTOLote
                       ,@ValorTotalLote
                       ,@DataEnvioCorreio
                       ,@DataPrevistaRecebimento
                       ,@StatusLote
                       ,@Funcionario);

                SELECT SCOPE_IDENTITY();";

        public static string ListLote = @"
                            SELECT Id
                                ,NomeFantasia
                                ,RazaoSocial
                                ,CNPJ
                                ,DataEnvioLote
                                ,DataRecebimentoLote
                                ,PublicId
                              FROM dbo.PlanoOperadora";

        public static string UpdateLote = @"
                UPDATE dbo.PlanoOperadora
                       SET NomeFantasia = @NomeFantasia
                          ,RazaoSocial = @RazaoSocial
                          ,CNPJ = @CNPJ
                          ,DataEnvioLote = @DataEnvioLote
                          ,DataRecebimentoLote = @DataRecebimentoLote
                     WHERE PublicId = @PublicId";


        public static string DeleteLote = @"
                            DELETE FROM dbo.Lote
                            WHERE PublicID = @PublicID";

        #endregion
    }
}
