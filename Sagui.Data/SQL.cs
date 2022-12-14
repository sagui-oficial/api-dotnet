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
                      INSERT INTO public.""Arquivo_GTO""
                               (""idGTO""
                               ,""idArquivo"")
                         VALUES
                               (@idGTO
                               ,@idArquivo) RETURNING ""Id"";";

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
                               ,""IdProcedimento""
                               ,""ValorProcedimento""
                               ,""Pago""
                                )
                         VALUES
                               (@IdGTO
                               ,@IdProcedimento
                               ,@ValorProcedimento
                               ,@Pago
                            )
                            RETURNING ""Id"";";

        public static string DeleteProcedimentoGTO = @"
                    DELETE FROM  public.""Procedimento_GTO""
                          WHERE ""IdGTO"" = @IdGTO";

        public static string PagarProcedimentoGTO = @"
                    UPDATE public.""Procedimento_GTO""
                            SET ""Pago"" = @Pago
                          WHERE ""IdGTO"" = @IdGTO";

        public static string ListarProcedimentoGTO = @"
                     SELECT  
	                       b.""Id""
                          ,b.""Codigo""
                          ,b.""NomeProcedimento""
                          ,a.""ValorProcedimento""
                          ,b.""Exigencias""
                          ,b.""Anotacoes""
                          ,b.""PublicID""
                          ,a.""Pago""
                    FROM ""Procedimento_GTO"" a 
		                    inner join ""Procedimento"" b ON a.""IdProcedimento"" = b.""Id""
                    where a.""IdGTO"" = @idGTO";


        public static string ListarProcedimentoPlanoOperadora = @"
                     SELECT  
	                       b.""Id""
                          ,b.""Codigo""
                          ,b.""NomeProcedimento""
                          ,a.""ValorProcedimento""
                          ,b.""Exigencias""
                          ,b.""Anotacoes""
                          ,b.""PublicID""
                          ,false ""Pago""
                    FROM ""PlanoOperadora"" c 
                            inner join ""Procedimento_PlanoOperadora"" a on a.""IdPlanoOperadora"" = c.""Id""
		                    inner join ""Procedimento"" b ON a.""IdProcedimento"" = b.""Id""
                    where c.""PublicID""::uuid = @PublicID";





        public static string DeleteGTO = @" UPDATE public.""GTO""
                                       SET ""Status"" = @Status
                                       WHERE ""PublicID""::uuid = @PublicID   ";

        public static string UpdateGTO = @"
                   UPDATE public.""GTO""
                       SET ""Numero"" = @Numero
                          ,""Solicitacao"" = @Solicitacao
                          ,""Vencimento"" = @Vencimento
                          ,""Status"" = @Status
                          ,""PacienteId"" = @Paciente
                          ,""PlanoOperadoraId"" = @PlanoOperadora
                          ,""TotalProcedimentos"" = @TotalProcedimentos
                          ,""ValorTotalProcedimentos"" = @ValorTotalProcedimentos
                      WHERE ""PublicID""::uuid = @PublicID   ";

        

        public static string UpdateGTOStatus = @"
                   UPDATE public.""GTO""
                       SET ""Status"" = @Status
                      WHERE ""PublicID""::uuid = @PublicID   ";

        public static string CreateGTO = @"
                INSERT INTO public.""GTO""
                           ( ""Numero""
                           , ""Status""
                           , ""PlanoOperadoraId""
                           , ""PacienteId""
                           , ""Solicitacao""
                           , ""Vencimento""
                           , ""TotalProcedimentos""
                           , ""ValorTotalProcedimentos"")
                     VALUES
                           (@Numero
                           , @Status
                           , @PlanoOperadora
                           , @Paciente
                           , @Solicitacao
                           , @Vencimento
                           , @TotalProcedimentos
                           , @ValorTotalProcedimentos)
                
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
                                        ,a.""TotalProcedimentos""
                                        ,a.""ValorTotalProcedimentos""
                                        ,b.""PublicID"" ""PlanoOperadoraPublicID""
                                        ,c.""PublicID"" ""UsuarioBasePublicID""
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
                                        ,a.""TotalProcedimentos""
                                        ,a.""ValorTotalProcedimentos""
                                        ,b.""PublicID"" ""PlanoOperadoraPublicID""
                                        ,c.""PublicID"" ""UsuarioBasePublicID""
                                    FROM public.""GTO"" a 
			                                INNER JOIN  ""PlanoOperadora"" b  ON  a.""PlanoOperadoraId"" = b.""Id""
			                                INNER JOIN  ""UsuarioBase"" c  ON  a.""PacienteId"" = c.""Id""
                            WHERE a.""PublicID""::uuid = @PublicID";

        #endregion

        #region procedimento

        public static string CreateProcedimento = @"
                    INSERT INTO public.""Procedimento""
                               (""Codigo""
                               ,""NomeProcedimento""
                               ,""Exigencias""
                               ,""Anotacoes"")
                         VALUES
                               (@Codigo
                               ,@NomeProcedimento
                               ,@Exigencias
                               ,@Anotacoes)
                            RETURNING ""Id"";";
        public static string ListProcedimento = @"
                            SELECT ""Id"", 
                                   ""Codigo"", 
                                   ""NomeProcedimento"", 
                                   ""Exigencias"", 
                                   ""Anotacoes"", 
                                   ""PublicID""
                            FROM public.""Procedimento""
                            WHERE ""Status"" <> 99";

        public static string ObterProcedimento = @"
                            SELECT ""Id""
                                  ,""Codigo""
                                  ,""NomeProcedimento""
                                  ,""Exigencias""
                                  ,""Anotacoes""
                                  ,""PublicID""
                             FROM public.""Procedimento""
                            WHERE ""PublicID""::uuid = @PublicID";

        public static string DeleteProcedimento = @"
                            UPDATE public.""Procedimento""
                                    SET ""Status"" = @Status
                            WHERE ""PublicID""::uuid = @PublicID";

        public static string UpdateProcedimento = @"
                            UPDATE  public.""Procedimento""
                                    SET ""Codigo"" = @Codigo
                                  ,""NomeProcedimento""  = @NomeProcedimento
                                  ,""Exigencias"" = @Exigencias
                                  ,""Anotacoes"" = @Anotacoes
                                  ,""Status"" = @Status
            
                            WHERE ""PublicID""::uuid = @PublicID";
        #endregion

        #region usuario


        public static string ObterUsuario = @"
                            SELECT a.""Id""
                                  ,a.""Funcao""
                                  ,a.""Nome""
                                  ,a.""Anotacoes""
                                  ,a.""CPF""
                                  ,a.""Email""
                                  ,a.""Telefone""
                                  ,a.""CRO""
                                  ,a.""NumeroPlano""
                                  ,a.""PlanoOperadoraId""
                                  ,a.""PublicID""
                                  ,b.""NomeFantasia""
                                  ,b.""PublicID"" ""PublicIDPlanoOperadora""
                              FROM public.""UsuarioBase"" a
                                    LEFT JOIN ""PlanoOperadora"" b on a.""PlanoOperadoraId"" = b.""Id""
                            WHERE a.""TipoUsuario"" = @TipoUsuario
                              AND a.""PublicID""::uuid = @PublicID";


        public static string ListUsuario = @"
                             SELECT a.""Id""
                                  ,a.""Funcao""
                                  ,a.""Nome""
                                  ,a.""Anotacoes""
                                  ,a.""CPF""
                                  ,a.""Email""
                                  ,a.""Telefone""
                                  ,a.""CRO""
                                  ,a.""NumeroPlano""
                                  ,a.""PlanoOperadoraId""
                                  ,a.""PublicID""
                                  ,b.""NomeFantasia""
                                  ,b.""PublicID"" ""PublicIDPlanoOperadora""
                                  ,(select COUNT(*) FROM public.""UsuarioBase"" z where z.""TipoUsuario"" = @TipoUsuario AND z.""Status"" = @Status ) / 10 +1 TotalPaginas
                              FROM public.""UsuarioBase"" a
                                    LEFT JOIN ""PlanoOperadora"" b on a.""PlanoOperadoraId"" = b.""Id""
                            WHERE a.""TipoUsuario"" = @TipoUsuario
                            AND a.""Status"" = @Status
                            LIMIT @Linhas OFFSET @Offset;   ";


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
                            UPDATE public.""UsuarioBase""
                       SET ""Status"" = @Status
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
                            WHERE ""PublicID""::uuid = @PublicID";


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


        public static string CreateProcedimento_PlanoOperadora = @"
                    INSERT INTO public.""Procedimento_PlanoOperadora""
                               (""IdPlanoOperadora""
                               ,""IdProcedimento""
                               ,""ValorProcedimento""
                                )
                         VALUES
                               (@IdPlanoOperadora
                               ,@IdProcedimento
                               ,@ValorProcedimento
                               )
                            RETURNING ""Id"";";


        public static string DeleteProcedimento_PlanoOperadora = @"
                    DELETE FROM  public.""Procedimento_PlanoOperadora""
                          WHERE ""IdPlanoOperadora"" = @IdPlanoOperadora";



        #endregion

        #region Lote
        public static string CreateLote = @"
                    INSERT INTO public.""Lote""
                       (""PlanoOperadoraId""
                       ,""TotalGTOLote""
                       ,""ValorTotalLote""
                       ,""DataEnvioCorreio""
                       ,""DataPrevistaRecebimento""
                       ,""FuncionarioId"")
                 VALUES
                       (@PlanoOperadora
                       ,@TotalGTOLote
                       ,@ValorTotalLote
                       ,@DataEnvioCorreio
                       ,@DataPrevistaRecebimento
                       ,@Funcionario)
                        RETURNING ""Id"";";

        public static string ListLote = @"
                             SELECT a.""Id"",
	                                a.""PublicID"",
	                                a.""Status"",
	                                a.""PlanoOperadoraId"",
	                                a.""TotalGTOLote"",
	                                a.""ValorTotalLote"",
	                                a.""DataEnvioCorreio"",
	                                a.""DataPrevistaRecebimento"",
	                                a.""FuncionarioId"",
                                    b.""Id"",
                                    b.""NomeFantasia"",
		                            b.""RazaoSocial"",
		                            c.""Id"",
                                    c.""Nome""
                                    ,b.""PublicID"" ""PlanoOperadoraPublicID""
                                    ,c.""PublicID"" ""UsuarioBasePublicID""
                                    ,(select COALESCE(SUM(e.""ValorProcedimento""), 0 ) from  ""GTO_Lote"" d 
                                                                                INNER JOIN ""Procedimento_GTO"" e ON e.""IdGTO"" = d.""IdGTO""
                                                                            where e.""Pago"" = true AND d.""IdLote"" = a.""Id"" ) ValorTotalPagoLote
                                FROM public.""Lote"" a
			                INNER JOIN  ""PlanoOperadora"" b  ON  a.""PlanoOperadoraId"" = b.""Id""
			                INNER JOIN  ""UsuarioBase"" c  ON  a.""FuncionarioId"" = c.""Id""
                                 WHERE a.""Status"" <>  99 ";


        public static string UpdateLote = @"
                UPDATE public.""Lote""
                       SET ""DataEnvioCorreio"" = @DataEnvioCorreio
                          ,""DataPrevistaRecebimento"" = @DataPrevistaRecebimento
                          ,""PlanoOperadoraId"" = @PlanoOperadoraId
                          ,""FuncionarioId"" = @FuncionarioId
                          ,""Status"" = @Status
                          ,""TotalGTOLote"" = @TotalGTOLote
                          ,""ValorTotalLote"" = @ValorTotalLote
                     WHERE ""PublicID""::uuid = @PublicID";


        public static string DeleteLote = @"
                             UPDATE public.""Lote""
                       SET ""Status"" = @Status
                     WHERE ""PublicID""::uuid = @PublicID";


        public static string CreateLoteGTO = @"
                    INSERT INTO public.""GTO_Lote""
                       (""IdLote""
                       ,""IdGTO"")
                 VALUES
                       (@IdLote
                       ,@IdGTO)
                        RETURNING ""Id"";";

        public static string DeleteLoteGTO = @"
                    DELETE FROM  public.""GTO_Lote""
                          WHERE ""IdLote"" = @IdLote";

        public static string ObterLotebyPublicID = @"
                                   SELECT a.""Id"",
	                                      a.""PublicID"",
	                                      a.""Status"",
	                                      a.""PlanoOperadoraId"",
	                                      a.""TotalGTOLote"",
	                                      a.""ValorTotalLote"",
	                                      a.""DataEnvioCorreio"",
	                                      a.""DataPrevistaRecebimento"",
	                                      a.""FuncionarioId"",
                                          b.""Id"",
                                          b.""NomeFantasia"",
		                                  b.""RazaoSocial"",
		                                  c.""Id"",
                                          c.""Nome""
                                         ,b.""PublicID"" ""PlanoOperadoraPublicID""
                                         ,c.""PublicID"" ""UsuarioBasePublicID""
                                        ,(select COALESCE(SUM(e.""ValorProcedimento""), 0 ) from  ""GTO_Lote"" d 
                                                                                INNER JOIN ""Procedimento_GTO"" e ON e.""IdGTO"" = d.""IdGTO""
                                                                            where e.""Pago"" = true AND d.""IdLote"" = a.""Id"" ) ValorTotalPagoLote
	                                    FROM public.""Lote"" a
			                      INNER JOIN  ""PlanoOperadora"" b  ON  a.""PlanoOperadoraId"" = b.""Id""
			                      INNER JOIN  ""UsuarioBase"" c  ON  a.""FuncionarioId"" = c.""Id""
		                               WHERE a.""PublicID""::uuid = @PublicID";


        public static string ListarGTOLote = @"SELECT a.""Id""
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
	                                                 ,a.""TotalProcedimentos""
	                                                 ,a.""ValorTotalProcedimentos""
                                                     ,b.""PublicID"" ""PlanoOperadoraPublicID""
                                                     ,c.""PublicID"" ""UsuarioBasePublicID""
                                                 FROM  ""Lote"" l 
                                                        INNER JOIN ""GTO_Lote"" gl ON l.""Id"" = gl.""IdLote""
                                                        INNER JOIN public.""GTO"" a ON gl.""IdGTO"" = a.""Id"" 
                                                        INNER JOIN  ""PlanoOperadora"" b  ON a.""PlanoOperadoraId"" = b.""Id""
                                                        INNER JOIN  ""UsuarioBase"" c  ON  a.""PacienteId"" = c.""Id""
                                                WHERE l.""PublicID""::uuid = @PublicID ";

        public static string ListarGTOPlanoOperadora = @"
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
                                        ,a.""TotalProcedimentos""
                                        ,a.""ValorTotalProcedimentos""
                                        ,b.""PublicID"" ""PlanoOperadoraPublicID""
                                        ,c.""PublicID"" ""UsuarioBasePublicID""
                                    FROM public.""GTO"" a 
			                                INNER JOIN  ""PlanoOperadora"" b  ON  a.""PlanoOperadoraId"" = b.""Id""
			                                INNER JOIN  ""UsuarioBase"" c  ON  a.""PacienteId"" = c.""Id""
                            WHERE b.""PublicID""::uuid = @PublicID
                            AND a.""Status"" = 2 ";

        #endregion

        #region Dashboard

        public static string DashboardFaturamento = @"
                                SELECT  COALESCE(SUM(a.""ValorTotalProcedimentos""),0) previsto
		                                ,SUM((SELECT COALESCE(SUM(b.""ValorProcedimento""),0) FROM ""Procedimento_GTO"" b where b.""IdGTO"" = a.""Id"" AND ""Pago"" = true)) realizado
                                    FROM ""GTO"" a 
                                    WHERE a.""Vencimento"" BETWEEN @Inicio AND @Fim 
                                    AND a.""Status"" <> 99
                                ";

        public static string DashboardGuiasGlosadas = @"
                               SELECT  COALESCE(count(a.""ValorTotalProcedimentos""),0) Quantidade
		                                ,SUM((SELECT COALESCE(SUM(b.""ValorProcedimento""),0) FROM ""Procedimento_GTO"" b where b.""IdGTO"" = a.""Id"" AND ""Pago"" = false)) valor
                                   FROM ""GTO"" a
                                WHERE a.""Vencimento"" BETWEEN @Inicio AND @Fim
                                AND a.""Status"" = 4
                                ";

        public static string DashboardPacienteAtendidos = @"
                               SELECT  COUNT(*) PacientesAtendidos
                                FROM ""UsuarioBase""
                                where ""Id"" in(
                                SELECT ""Id""
		                           FROM ""GTO"" a
                                WHERE a.""Vencimento"" BETWEEN @Inicio AND @Fim AND a.""Status"" <> 99)
                                ";

        public static string DashboardGrafico = @"
                               SELECT ""NomeFantasia"" operadora
                                    ,COALESCE(SUM(b.""ValorTotalProcedimentos""),0) total
                                    ,SUM((SELECT COALESCE(SUM(c.""ValorProcedimento""),0) FROM ""Procedimento_GTO"" c where c.""IdGTO"" = b.""Id"" AND ""Pago"" = false)) glosadas
                                    from ""PlanoOperadora"" a
                                            left JOIN ""GTO"" b ON a.""Id"" = b.""PlanoOperadoraId"" AND b.""Vencimento"" BETWEEN @Inicio AND @Fim AND a.""Status"" <> '99' 
                                    WHERE a.""Status"" <> '99' 
                                    GROUP by a.""NomeFantasia""
                                ";

        #endregion

    }
}
