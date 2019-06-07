using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Base.Utils
{
    public static class Constantes
    {
        #region Commom Messages
        public static string InseridoComSucesso = "Inserido com sucesso!";
        public static string ProblemaAoInserir = "Ocorreu um problema ao inserir!";
        public static string AtualizadoComSucesso = "atualizado com sucesso!";
        public static string ProblemaAoAtualizar = "Ocorreu um problema ao atualizar!";
        public static string DeletadaComSucesso = "Deletada com sucesso!";
        public static string ProblemaAoDeletada = "Ocorreu um problema ao Deletar!";


        public static string ObterComSucesso = "Obter com sucesso!";
        public static string ProblemaAoObter = "Ocorreu um problema ao Obter!";

        public static string ListadoComSucesso = "Listado com sucesso!";
        public static string ProblemaAoListar = "Ocorreu um problema ao listar!";
        public static string MensagemTamanhoCPFIncorreto = "O CPF informado tem menos que 11 digítos.";
        public static string MensagemCPFIncorreto = "O CPF informado está incorreto.";
        public static string MensagemTamanhoCNPJIncorreto = "O CNPJ informado tem menos que 11 digítos.";
        public static string MensagemCNPJIncorreto = "O CNPJ informado está incorreto.";
        #endregion

        #region ErrorTypes
        public static string DataNaoPreenchida = "DataNaoPreenchida";
        public static string DataRange = "DataRange";
        public static string _DataRange = "Data Range";
        public static string CampoNaoPreenchido = "CampoNaoPreenchido";
        public static string ArquivosNaoAnexados = "ArquivosNaoAnexados";
        public static string OperadoraNaoinformada = "OperadoraNaoinformada";
        public static string PacienteNaoinformado = "PacienteNaoinformado";
        public static string ProcedimentosNaoInformados = "ProcedimentosNaoInformados";
        public static string CampoIncorreto = "CampoIncorreto";
        #endregion

        #region Error Messages
        public static string MensagemDataIniNaoPreenchida = "Data inicio não preenchida";
        public static string MensagemDataFimNaoPreenchida = "Data fim não preenchida";
        public static string MensagemDataRange = "Data inicio não pode ser maior que a Data fim";
        public static string MensagemDataNaoPreenchida = "Data não preenchida";
        public static string MensagemCampoNaoPreenchida = "Campo não preenchido";
        public static string MensagemArquivosNaoAnexados = "Nenhum arquivo anexado a GTO";
        public static string MensagemOperadoraNaoinformada = "Nenhuma Operadora informada a GTO";
        public static string MensagemPacienteNaoinformado = "Nenhuma paciente informado a GTO";
        public static string MensagemProcedimentosNaoInformados = "Nenhuma procedimento informado a GTO";
        public static string MensagemGTOsNaoEncontradas = "Não foram encontradas GTOs";
        #endregion

        #region Default Messages GRUD

        public static string MensagemNaoListada = "{0}s nao listadas!";
        public static string MensagemListadaComSucesso = "{0}s listadas com sucesso!";
        
        public static string MensagemNaoInserida = "{0} não inserida!";
        public static string MensagemInseridaComSucesso = "{0} inserida com sucesso!";

        public static string MensagemAtualizada = "{0} atualizada!";
        public static string MensagemNaoAtualizado = "{0} não atualizada!";

        public static string MensagemDeletada = "{0} deletada!";
        public static string MensagemNaoDeletada = "{0} não deletada!";

        public static string MensagemObtidacomSucesso = "{0}s obtida com sucesso!";
        public static string MensagemNaoObtidacomSucesso = "{0}s não encontrada! Verifique as informações informadas para pesquisa.";

        #endregion

        #region Arquivos

        //public static string MensagemArquivoNaoListado = "Arquivos não listados!";
        //public static string MensagemArquivoListadoComSucesso = "Arquivos listados com sucesso!";
        //public static string MensagemArquivoInseridoComSucesso = "Arquivo inserido com sucesso!";
        //public static string MensagemArquivoNaoInserido = "Arquivo não inserido!";
        //public static string MensagemArquivoDeletado = "Arquivo deletado!";
        //public static string MensagemArquivoNaoDeletado = "Arquivo não deletado!";
        //public static string MensagemArquivoObtidocomSucesso = "Arquivo obtido com sucesso!";
        //public static string MensagemArquivoNaoObtidocomSucesso = "Arquivo não obtida com sucesso!";

        #endregion

        #region GTO
        //public static string GTODeletada = "GTO deletada!";
        //public static string GTONaoDeletada = "GTO não deletada!";
        //public static string MensagemGTONaoListada = "GTOs nao listadas!";
        //public static string MensagemGTOListadaComSucesso = "GTOs listadas com sucesso!";
        //public static string MensagemGTOInseridaComSucesso = "GTO inserida com sucesso!";
        //public static string MensagemGTONaoInserida = "GTO não inserida!";
        //public static string MensagemGTODeletada = "GTO deletada!";
        //public static string MensagemGTONaoDeletada = "GTO não deletada!";
        //public static string MensagemGTOObtidacomSucesso = "GTOs obtida com sucesso!";
        //public static string MensagemGTONaoObtidacomSucesso = "GTOs não encontrada! Verifique as informações informadas para pesquisa.";
        

        #endregion

        #region Procedimentos
        //public static string MensagemProcedimentosInseridosComSucesso = "Procedimento(s) inserido(s) com sucesso!";
        //public static string MensagemProcedimentoNaoInserida = "Procedimento(s) não inserido(s)!";
        //public static string MensagemProcedimentoListadaComSucesso = "Procedimentos listados com sucesso!";
        //public static string MensagemProcedimentoNaoListado = "Procedimentos não listados!";
        #endregion

        #region PlanoOperadora
        //public static string MensagemPlanoOperadorasInseridosComSucesso = "Plano(s) Operadora(s) inserido(s) com sucesso!";
        //public static string MensagemPlanoOperadoraNaoInserida = "Plano(s) Operadora(s) não inserido(s)!";
        //public static string MensagemPlanoOperadoraNaoListado = "Planos Operadoras não listados!";
        #endregion

        #region Lote
        //public static string MensagemLotesInseridosComSucesso = "Lote(s) inserido(s) com sucesso!";
        //public static string MensagemLoteNaoInserido = "Lote(s) não inserido(s)!";
        //public static string MensagemLoteListadoComSucesso = "Lotes listados com sucesso!";
        //public static string MensagemLoteNaoListado = "Lotes não encontrados!";
        //public static string MensagemLoteDeletado = "Lote deletado!";
        //public static string MensagemLoteNaoDeletado = "Lote não deletado!";
        //public static string MensagemLoteObtidocomSucesso = "Lote obtido com sucesso!";
        //public static string MensagemLoteNaoObtido = "Lote não obtido!";
        #endregion

        #region Usuarios
        //public static string MensagemUsuarioInseridosComSucesso = "Usuario(s) inserido(s) com sucesso!";
        //public static string MensagemUsuarioNaoInserido = "Usuario(s) não inserido(s)!";
        //public static string MensagemUsuarioListadaComSucesso = "Usuarios listados com sucesso!";
        //public static string MensagemUsuarioNaoListado = "Usuarios não listados!";

        //public static string MensagemPacienteObtidoComSucesso = "Paciente obtido com sucesso!";
        //public static string MensagemPacienteNaoEncontrado= "Paciente não encontrado!";
        #endregion

      
    }
}
