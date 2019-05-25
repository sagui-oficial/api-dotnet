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
                   INSERT INTO public.""Arquivo""
                               (""Nome""
                               ,""DataCriacao""
                               ,""Stream""
                               ,""PathArquivo"")
                         VALUES
                               (@Nome
                               ,@DataCriacao
                               ,@Stream
                               ,@PathArquivo) RETURNING ""Id"";";


        #region ArquivoGTO

        public static string CreateArquivoGTO = @"
                      INSERT INTO public.""Arquivo""
                               (""Nome""
                               ,""DataCriacao""
                               ,""Stream""
                               ,""PathArquivo"")
                         VALUES
                               (@Nome
                               ,@DataCriacao
                               ,@Stream
                               ,@PathArquivo) RETURNING ""Id"";";

        public static string ListarArquivosGTO = @"
                    SELECT arq.""Id""
                          ,arq.""Nome""
                          ,arq.""Stream""
                          ,arq.""DataCriacao""
                          ,arq.""PathArquivo""
                          ,arq.""Extensao""
	                      ,agto.""idArquivo_GTO""
                          ,agto.""PublicID""
                          FROM public.""Arquivo"" (NOLOCK) arq
                    INNER JOIN public.""Arquivo_GTO"" (NOLOCK) agto
                       ON arq.Id = agto.""idGTO""";


        public static string ListarArquivoGTO = @"
                      SELECT arq.""Id""
                          ,arq.""Nome""
                          ,arq.""Stream""
                          ,arq.""DataCriacao""
                          ,arq.""PathArquivo""
                          ,arq.""Extensao""
	                      ,agto.""idArquivo_GTO""
                          ,agto.""PublicID""
                          FROM public.""Arquivo"" (NOLOCK) arq
                    INNER JOIN public.""Arquivo_GTO"" (NOLOCK) agto
                       ON arq.Id = agto.""idGTO""
                    WHERE agto.idGTO = @idGTO";


        public static string ObterArquivoGTOPorPublicId = @"
                    SELECT arq.""Id""
                          ,arq.""Nome""
                          ,arq.""Stream""
                          ,arq.""DataCriacao""
                          ,arq.""PathArquivo""
                          ,arq.""Extensao""
	                      ,agto.""idArquivo_GTO""
                          ,agto.""PublicID""
                          FROM public.""Arquivo"" (NOLOCK) arq
                    INNER JOIN public.""Arquivo_GTO"" (NOLOCK) agto
                       ON arq.Id = agto.""idGTO""
                    WHERE agto.""PublicID""::uuid = @PublicID";



        public static string ObterArquivoGTO = @"
                    SELECT  
	                       b.""Id""
                          ,b.""Nome""
                          ,b.""Stream""
                          ,b.""DataCriacao""
                          ,b.""PathArquivo""
                    FROM ""Arquivo_GTO"" a (NOLOCK)
		                    inner join ""Arquivo"" b (NOLOCK) ON a.""idArquivo"" = b.""Id""
                    WHERE ""idGTO"" = @idGTO";

        #endregion

        #region ArquivoPlanoOperadora

        public static string ObterArquivoPlanoOperadoraPorPublicId = @"
                    SELECT arq.""Id""
                          ,arq.""Nome""
                          ,arq.""Stream""
                          ,arq.""DataCriacao""
                          ,arq.""PathArquivo""
                          ,arq.""Extensao""
	                      ,apo.""idArquivo_GTO""
                          ,apo.""PublicID""
                          FROM public.""Arquivo"" arq
                    INNER JOIN public.""Arquivo_PlanoOperadora"" apo
                       ON arq.Id = apo.""idPlanoOperadora""
                    WHERE apo.""PublicID""::uuid = @PublicID";


        public static string ListarArquivoPlanoOperadora = @"
                    SELECT arq.""Id""
                          ,arq.""Nome""
                          ,arq.""Stream""
                          ,arq.""DataCriacao""
                          ,arq.""PathArquivo""
                          ,arq.""Extensao""
	                      ,apo.""idArquivo_GTO""
                          ,apo.""PublicID""
                          FROM public.""Arquivo"" arq
                    INNER JOIN public.""Arquivo_PlanoOperadora"" apo
                       ON arq.Id = apo.""idPlanoOperadora""";


        public static string CreateArquivoPlanoOperadora = @"
                   INSERT INTO public.""Arquivo""
                               (""Nome""
                               ,""DataCriacao""
                               ,""Stream""
                               ,""PathArquivo"")
                         VALUES
                               (@Nome
                               ,@DataCriacao
                               ,@Stream
                               ,@PathArquivo)RETURNING ""Id"";";


        public static string ObterArquivoPlanoOperadora = @"
                    SELECT  
	                       b.""Id""
                          ,b.""Nome""
                          ,b.""Stream""
                          ,b.""DataCriacao""
                          ,b.""PathArquivo""
                    FROM ""Arquivo_GTO"" a (NOLOCK)
		                    inner join ""Arquivo"" b (NOLOCK) ON a.""idArquivo"" = b.""Id""
                    WHERE ""idGTO"" = @idGTO";

        #endregion

        #endregion

        #region GTO

        public static string CreateProcedimentoGTO = @"
                    INSERT INTO public.""Procedimento_GTO""
                               (""IdGTO""
                               ,""IdProcedimento"")
                         VALUES
                               (@IdGTO
                               ,@IdProcedimento)
                            RETURNING ""IdGTO"";";

        public static string ListarProcedimentoGTO = @"
                    SELECT  
	                       b.""IdProcedimento""
                          ,b.""Codigo""
                          ,b.""NomeProcedimento""
                          ,b.""ValorProcedimento""
                          ,b.""Exigencias""
                          ,b.""Anotacoes""
                          ,b.""PublicID""
                    FROM 
                    ""Procedimento_GTO"" a (NOLOCK)
		                    inner join ""Procedimento"" b ON a.""idProcedimento"" = b.""IdProcedimento""
                    where idGTO = @idGTO";

      



        public static string DeleteGTO = @" UPDATE public.""GTO""
                                       SET ""Status"" = @Status
                                       WHERE ""PublicID""::uuid = @publicID   ";

        public static string UpdateGTO = @"
                   UPDATE public.GTO
                       SET ""Numero"" = @Numero
                          ,""Solicitacao"" = @Solicitacao
                          ,""Vencimento"" = @Vencimento
                          ,""Status"" = @Status
                          ,""PacienteId"" = @Paciente
                          ,""PlanoOperadoraId"" = @PlanoOperadora
                      WHERE ""PublicID""::uuid = @publicID   ";

        public static string CreateGTO = @"
                INSERT INTO public.""GTO""
                           ( ""Numero""
                           , ""Status""
                           , ""PlanoOperadoraId""
                           , ""PacienteId""
                           , ""Solicitacao""
                           , ""Vencimento"")
                     VALUES
                           (@Numero
                           , @Status
                           , @PlanoOperadora
                           , @Paciente
                           , @Solicitacao
                           , @Vencimento)
                
                 RETURNING ""Id"";";

        public static string ListGTO = @"
                                    SELECT  a.Id
                                        ,a.""Numero""
                                        ,a.""Status""
                                        ,a.""PlanoOperadoraId""
		                                ,b.""NomeFantasia""
		                                ,b.""RazaoSocial""
                                        ,a.""PacienteId""
		                                ,c.""Nome""
                                        ,a.""Solicitacao""
                                        ,a.""Vencimento""
                                        ,a.""PublicID""
                                    FROM public.""GTO"" a (NOLOCK) 
			                                INNER JOIN  ""PlanoOperadora"" b (NOLOCK)  ON  a.""PlanoOperadoraId"" = b.""Id""
			                                INNER JOIN  ""UsuarioBase"" c (NOLOCK)  ON  a.""PacienteId"" = c.""Id";

        public static string ObterGTObyPublicID = @"
                                     SELECT  a.Id
                                        ,a.""Numero""
                                        ,a.""Status""
                                        ,a.""PlanoOperadoraId""
		                                ,b.""NomeFantasia""
		                                ,b.""RazaoSocial""
                                        ,a.""PacienteId""
		                                ,c.""Nome""
                                        ,a.""Solicitacao""
                                        ,a.""Vencimento""
                                        ,a.""PublicID""
                                    FROM public.""GTO"" a (NOLOCK) 
			                                INNER JOIN  ""PlanoOperadora"" b (NOLOCK)  ON  a.""PlanoOperadoraId"" = b.""Id""
			                                INNER JOIN  ""UsuarioBase"" c (NOLOCK)  ON  a.""PacienteId"" = c.""Id
                            WHERE a.""PublicID""::uuid = @PublicID";

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
                            WHERE ""PublicID""::text = @PublicID";
        public static string DeleteProcedimento = @"
                            UPDATE public.""Procedimento""
                                    SET ""Status"" = @Status
                            WHERE ""PublicID""::uuid = @PublicID";

        public static string UpdateProcedimento = @"
                            UPDATE  public.""Procedimento""
                                    SET ""Status"" = @Status                                      
                            WHERE ""PublicID""::text = @PublicID";
        #endregion

        #region usuario


        public static string ObterUsuario = @"
                            SELECT ""Id""
                                  ,""Funcao""
                                  ,""Nome""
                                  ,""Anotacoes""
                                  ,""CPF""
                                  ,""Email""
                                  ,""Telefone""
                                  ,""CRO""
                                  ,""Discriminator""
                                  ,""PublicId""
                              FROM public.""UsuarioBase""
                            WHERE ""TipoUsuario"" = @TipoUsuario
                              AND ""PublicID""::uuid = @PublicID";


        public static string ListUsuario = @"
                             SELECT ""Id""
                                  ,""Funcao""
                                  ,""Nome""
                                  ,""Anotacoes""
                                  ,""CPF""
                                  ,""Email""
                                  ,""Telefone""
                                  ,""CRO""
                                  ,""Discriminator""
                                  ,""PublicId""
                              FROM public.""UsuarioBase""
                            WHERE ""TipoUsuario"" = @TipoUsuario";


        public static string CreateUsuarioPaciente = @"
                INSERT INTO public.""UsuarioBase""
                               (""Funcao""
                               ,""Nome""
                               ,""Anotacoes""
                               ,""CPF""
                               ,""Email""
                               ,""Telefone""
                               ,""TipoUsuario"")
                         VALUES
                               (@Funcao
                               ,@Nome
                               ,@Anotacoes
                               ,@CPF
                               ,@Email
                               ,@Telefone
                               ,@TipoUsuario) 
                        RETURNING ""Id"";";

        public static string UpdateUsuarioPaciente = @"
                UPDATE public.""UsuarioBase""
                       SET ""Funcao"" = @Funcao
                          ,""Nome"" = @Nome
                          ,""Anotacoes"" = @Anotacoes
                          ,""CPF"" = @CPF
                          ,""Email"" = @Email
                          ,""Telefone"" = @Telefone
                          
                     WHERE ""PublicID""::uuid = @PublicId";



        public static string CreateUsuarioFuncionario = @"
                INSERT INTO public.""UsuarioBase""
                               (""Funcao""
                               ,""Nome""
                               ,""Anotacoes""
                               ,""CPF""
                               ,""Email""
                               ,""Telefone""
                               ,""TipoUsuario"")
                         VALUES
                               (@Funcao
                               ,@Nome
                               ,@Anotacoes
                               ,@CPF
                               ,@Email
                               ,@Telefone
                               ,@TipoUsuario) 
                        RETURNING ""Id"";";

        public static string UpdateUsuarioFuncionario = @"
                UPDATE public.""UsuarioBase""
                       SET ""Funcao"" = @Funcao
                          ,""Nome"" = @Nome
                          ,""Anotacoes"" = @Anotacoes
                          ,""CPF"" = @CPF
                          ,""Email"" = @Email
                          ,""Telefone"" = @Telefone
                          
                     WHERE ""PublicID""::uuid = @PublicId";

        public static string CreateUsuarioDentista = @"
                INSERT INTO public.""UsuarioBase""
                               (""Funcao""
                               ,""Nome""
                               ,""Anotacoes""
                               ,""CPF""
                               ,""Email""
                               ,""Telefone""
                               ,""TipoUsuario""
                               ,""CRO"")
                         VALUES
                               (@Funcao
                               ,@Nome
                               ,@Anotacoes
                               ,@CPF
                               ,@Email
                               ,@Telefone
                               ,@TipoUsuario
                               ,@CRO)
                        RETURNING ""Id""";

        public static string UpdateUsuarioDentista = @"
                UPDATE public.""UsuarioBase""
                       SET ""Funcao"" = @Funcao
                          ,""Nome"" = @Nome
                          ,""Anotacoes"" = @Anotacoes
                          ,""CPF"" = @CPF
                          ,""Email"" = @Email
                          ,""Telefone"" = @Telefone
                          ,""CRO"" = @CRO                        
                     WHERE ""PublicID""::uuid = @PublicId";


        public static string DeleteUsuario = @"
                            DELETE FROM public.""UsuarioBase""
                            WHERE ""PublicID""::uuid = @PublicID";

        #endregion

        #region PlanoOperadora
        public static string CreatePlanoOperadoraPaciente = @"
                    INSERT INTO public.""PlanoOperadoraPaciente""
                       (""NumeroPlano""
                       ,""PlanoOperadora_Id""
                       ,""Paciente_Id"")
                 VALUES
                       (@NumeroPlano
                       ,@PlanoOperadora_Id
                       ,@Paciente_Id)
                        RETURNING ""Id"";";

        public static string CreatePlanoOperadora = @"
                    INSERT INTO public.""PlanoOperadora""
                       (""NomeFantasia""
                       ,""RazaoSocial""
                       ,""CNPJ""
                       ,""DataEnvioLote""
                       ,""DataRecebimentoLote"")
                 VALUES
                       (@NomeFantasia
                       ,@RazaoSocial
                       ,@CNPJ
                       ,@DataEnvioLote
                       ,@DataRecebimentoLote)
                        RETURNING ""Id"";";


        public static string ObterPlanoOperadora = @"
                            SELECT 
                                 ""Id""
                                ,""NomeFantasia""
                                ,""RazaoSocial""
                                ,""CNPJ""
                                ,""DataEnvioLote""
                                ,""DataRecebimentoLote""
                                ,""PublicId""
                              FROM public.""PlanoOperadora"" 
                            WHERE ""PublicID""::uuid = @PublicID";


        public static string ListPlanoOperadora = @"
                             SELECT 
                                 ""Id""
                                ,""NomeFantasia""
                                ,""RazaoSocial""
                                ,""CNPJ""
                                ,""DataEnvioLote""
                                ,""DataRecebimentoLote""
                                ,""PublicId""
                              FROM public.""PlanoOperadora""";

        public static string UpdatePlanoOperadora = @"
                UPDATE public.""PlanoOperadora""
                       SET ""NomeFantasia"" = @NomeFantasia
                          ,""RazaoSocial"" = @RazaoSocial
                          ,""CNPJ"" = @CNPJ
                          ,""DataEnvioLote"" = @DataEnvioLote
                          ,""DataRecebimentoLote"" = @DataRecebimentoLote
                     WHERE ""PublicID""::uuid = @PublicId";


        public static string DeletePlanoOperadora = @"
                            DELETE FROM public.""PlanoOperadora""
                            WHERE ""PublicID""::uuid = @PublicID";

        #endregion

        #region Lote
        public static string CreateLote = @"
                    INSERT INTO public.""Lote""
                       (""PlanoOperadoraId""
                       ,""TotalGTOLote""
                       ,""ValorTotalLote""
                       ,""DataEnvioCorreio""
                       ,""DataPrevistaRecebimento""
                       ,""StatusLote""
                       ,""FuncionarioId"")
                 VALUES
                       (@PlanoOperadora
                       ,@TotalGTOLote
                       ,@ValorTotalLote
                       ,@DataEnvioCorreio
                       ,@DataPrevistaRecebimento
                       ,@StatusLote
                       ,@Funcionario)
                        RETURNING ""Id"";";

        public static string ListLote = @"
                            SELECT 
                                 ""Id""
                                ,""NomeFantasia""
                                ,""RazaoSocial""
                                ,""CNPJ""
                                ,""DataEnvioLote""
                                ,""DataRecebimentoLote""
                                ,""PublicId""
                              FROM public.""PlanoOperadora""";

        public static string UpdateLote = @"
                UPDATE public.""PlanoOperadora""
                       SET ""NomeFantasia"" = @NomeFantasia
                          ,""RazaoSocial"" = @RazaoSocial
                          ,""CNPJ"" = @CNPJ
                          ,""DataEnvioLote"" = @DataEnvioLote
                          ,""DataRecebimentoLote"" = @DataRecebimentoLote
                     WHERE ""PublicID""::uuid = @PublicId";


        public static string DeleteLote = @"
                            DELETE FROM public.""Lote""
                            WHERE ""PublicID""::uuid = @PublicID";

        #endregion
    }
}
