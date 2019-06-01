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
                          FROM public.""Arquivo"" arq
                    INNER JOIN public.""Arquivo_GTO"" agto
                       ON arq.Id = agto.""idGTO""";


        public static string ListarArquivoGTO = @"
                      SELECT arq.""Id""
                          ,arq.""Nome""
                          ,arq.""Stream""
                          ,arq.""DataCriacao""
                          ,arq.""PathArquivo""
                          ,agto.""idArquivo_GTO""
                          ,arq.""PublicID""
                          FROM public.""Arquivo"" arq
                    INNER JOIN public.""Arquivo_GTO"" agto
                       ON arq.""Id"" = agto.""idGTO""
                    WHERE agto.""idGTO"" = @idGTO";


        public static string ObterArquivoGTOPorPublicID = @"
                    SELECT arq.""Id""
                          ,arq.""Nome""
                          ,arq.""Stream""
                          ,arq.""DataCriacao""
                          ,arq.""PathArquivo""
                          ,arq.""Extensao""
	                      ,agto.""idArquivo_GTO""
                          ,agto.""PublicID""
                          FROM public.""Arquivo"" arq
                    INNER JOIN public.""Arquivo_GTO"" agto
                       ON arq.""Id"" = agto.""idGTO""
                    WHERE agto.""PublicID""::uuid = @PublicID";



        public static string ObterArquivoGTO = @"
                    SELECT  
	                       b.""Id""
                          ,b.""Nome""
                          ,b.""Stream""
                          ,b.""DataCriacao""
                          ,b.""PathArquivo""
                    FROM ""Arquivo_GTO"" a (NOLOCK)
		                    inner join ""Arquivo"" b ON a.""idArquivo"" = b.""Id""
                    WHERE ""idGTO"" = @idGTO";

        #endregion

        #region ArquivoPlanoOperadora

        public static string ObterArquivoPlanoOperadoraPorPublicID = @"
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
		                    inner join ""Arquivo"" b ON a.""idArquivo"" = b.""Id""
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

        public static string DeleteProcedimentoGTO = @"
                    DELETE FROM  public.""Procedimento_GTO""
                          WHERE ""IdGTO"" = @IdGTO";

        public static string ListarProcedimentoGTO = @"
                     SELECT  
	                       b.""Id""
                          ,b.""Codigo""
                          ,b.""NomeProcedimento""
                          ,b.""ValorProcedimento""
                          ,b.""Exigencias""
                          ,b.""Anotacoes""
                          ,b.""PublicID""
                    FROM ""Procedimento_GTO"" a 
		                    inner join ""Procedimento"" b ON a.""IdProcedimento"" = b.""Id""
                    where a.""IdGTO"" = @idGTO";

      



        public static string DeleteGTO = @" UPDATE public.""GTO""
                                       SET ""Status"" = @Status
                                       WHERE ""PublicID""::text = @PublicID   ";

        public static string UpdateGTO = @"
                   UPDATE public.""GTO""
                       SET ""Numero"" = @Numero
                          ,""Solicitacao"" = @Solicitacao
                          ,""Vencimento"" = @Vencimento
                          ,""Status"" = @Status
                          ,""PacienteId"" = @Paciente
                          ,""PlanoOperadoraId"" = @PlanoOperadora
                      WHERE ""PublicID""::uuid = @PublicID   ";

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
                                    SELECT  a.""Id""
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
                                    FROM public.""GTO"" a 
			                                INNER JOIN  ""PlanoOperadora"" b  ON  a.""PlanoOperadoraId"" = b.""Id""
			                                INNER JOIN  ""UsuarioBase"" c  ON  a.""PacienteId"" = c.""Id""
                                    WHERE a.""Status"" <>  99 ";

        public static string ObterGTObyPublicID = @"
                                     SELECT  a.""Id""
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
                                    FROM public.""GTO"" a 
			                                INNER JOIN  ""PlanoOperadora"" b  ON  a.""PlanoOperadoraId"" = b.""Id""
			                                INNER JOIN  ""UsuarioBase"" c  ON  a.""PacienteId"" = c.""Id""
                            WHERE a.""PublicID""::text = @PublicID";

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
                            RETURNING ""Id"";";
        public static string ListProcedimento = @"
                            SELECT ""Id"", 
                                   ""Codigo"", 
                                   ""NomeProcedimento"", 
                                   ""ValorProcedimento"", 
                                   ""Exigencias"", 
                                   ""Anotacoes"", 
                                   ""PublicID""
	                        FROM public.""Procedimento""
                            WHERE ""Status"" <>  99 ";

        public static string ObterProcedimento = @"
                            SELECT ""Id""
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
                            WHERE ""PublicID""::text = @PublicID";

        public static string UpdateProcedimento = @"
                            UPDATE  public.""Procedimento""
                                    SET ""Codigo"" = @Codigo
                                  ,""NomeProcedimento""  = @NomeProcedimento
                                  ,""ValorProcedimento"" = @ValorProcedimento
                                  ,""Exigencias"" = @Exigencias
                                  ,""Anotacoes"" = @Anotacoes
                                  ,""Status"" = @Status
            
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
                                  ,""NumeroPlano""
                                  ,""PlanoOperadoraId""
                                  ,""PublicID""
                              FROM public.""UsuarioBase""
                            WHERE ""TipoUsuario"" = @TipoUsuario
                              AND ""PublicID""::text = @PublicID";


        public static string ListUsuario = @"
                             SELECT ""Id""
                                  ,""Funcao""
                                  ,""Nome""
                                  ,""Anotacoes""
                                  ,""CPF""
                                  ,""Email""
                                  ,""Telefone""
                                  ,""CRO""
                                  ,""NumeroPlano""
                                  ,""PlanoOperadoraId""
                                  ,""PublicID""
                              FROM public.""UsuarioBase""
                            WHERE ""TipoUsuario"" = @TipoUsuario
                            AND ""Status"" <>  99 ";


        public static string CreateUsuarioPaciente = @"
                INSERT INTO public.""UsuarioBase""
                               (""Funcao""
                               ,""Nome""
                               ,""Anotacoes""
                               ,""CPF""
                               ,""Email""
                               ,""Telefone""
                                ,""PlanoOperadoraId""
                                ,""NumeroPlano""
                               ,""TipoUsuario"")
                         VALUES
                               (@Funcao
                               ,@Nome
                               ,@Anotacoes
                               ,@CPF
                               ,@Email
                               ,@Telefone
                               ,@PlanoOperadoraId
                               ,@NumeroPlano
                               ,@TipoUsuario
                                ) 
                        RETURNING ""Id"";";

        public static string UpdateUsuarioPaciente = @"
                UPDATE public.""UsuarioBase""
                       SET ""Funcao"" = @Funcao
                          ,""Nome"" = @Nome
                          ,""Anotacoes"" = @Anotacoes
                          ,""CPF"" = @CPF
                          ,""Email"" = @Email
                          ,""Telefone"" = @Telefone
                        ,""PlanoOperadoraId"" = @PlanoOperadoraId
                        ,""NumeroPlano"" = @NumeroPlano
                          
                     WHERE ""PublicID""::uuid = @PublicID";



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
                          
                     WHERE ""PublicID""::uuid = @PublicID";

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
                     WHERE ""PublicID""::uuid = @PublicID";


        public static string DeleteUsuario = @"
                            DELETE FROM public.""UsuarioBase""
                            WHERE ""PublicID""::uuid = @PublicID";

        public static string CreatePlanoOperadoPaciente = @"
                    INSERT INTO public.""PlanoOperadoraPaciente""
                               (""PacienteId""
                               ,""PlanoOperadoraId""
                               ,""NumeroPlano"")
                         VALUES
                               (@PacienteId
                               ,@PlanoOperadoraId
                               ,@NumeroPlano)
                            RETURNING ""PacienteId"";";

        public static string ListarPlanoOperadoPaciente = @"
                    SELECT  
	                       a.""PacienteId""
                          ,a.""PlanoOperadoraId""
                          ,a.""NumeroPlano""
                    FROM 
                    ""PlanoOperadoraPaciente"" a 
                    where ""PacienteId"" = @PacienteId";

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
                                ,""PublicID""
                              FROM public.""PlanoOperadora"" 
                            WHERE ""PublicID""::text = @PublicID";


        public static string ListPlanoOperadora = @"
                             SELECT 
                                 ""Id""
                                ,""NomeFantasia""
                                ,""RazaoSocial""
                                ,""CNPJ""
                                ,""DataEnvioLote""
                                ,""DataRecebimentoLote""
                                ,""PublicID""
                              FROM public.""PlanoOperadora""
                              WHERE ""Status"" <>  99 ";

        public static string UpdatePlanoOperadora = @"
                UPDATE public.""PlanoOperadora""
                       SET ""NomeFantasia"" = @NomeFantasia
                          ,""RazaoSocial"" = @RazaoSocial
                          ,""CNPJ"" = @CNPJ
                          ,""DataEnvioLote"" = @DataEnvioLote
                          ,""DataRecebimentoLote"" = @DataRecebimentoLote
                          ,""Status"" = @Status
                     WHERE ""PublicID""::uuid = @PublicID";


        public static string DeletePlanoOperadora = @"
                           UPDATE public.""PlanoOperadora""
                       SET ""Status"" = @Status
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
                       ,""Status""
                       ,""FuncionarioId"")
                 VALUES
                       (@PlanoOperadora
                       ,@TotalGTOLote
                       ,@ValorTotalLote
                       ,@DataEnvioCorreio
                       ,@DataPrevistaRecebimento
                       ,@Status
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
                                ,""PublicID""
                              FROM public.""PlanoOperadora""
                              WHERE ""Status"" <>  99 ";

        public static string UpdateLote = @"
                UPDATE public.""PlanoOperadora""
                       SET ""NomeFantasia"" = @NomeFantasia
                          ,""RazaoSocial"" = @RazaoSocial
                          ,""CNPJ"" = @CNPJ
                          ,""DataEnvioLote"" = @DataEnvioLote
                          ,""DataRecebimentoLote"" = @DataRecebimentoLote
                     WHERE ""PublicID""::uuid = @PublicID";


        public static string DeleteLote = @"
                            DELETE FROM public.""Lote""
                            WHERE ""PublicID""::uuid = @PublicID";

        #endregion
    }
}
