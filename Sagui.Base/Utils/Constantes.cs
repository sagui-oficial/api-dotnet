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
        public static string ListadoComSucesso = "Listado com sucesso!";
        public static string ProblemaAoListar = "Ocorreu um problema ao listar!";
        #endregion

        #region GTO
        public static string MensagemGTONaoListada = "GTOs não listadas!";
        public static string MensagemGTOListadaComSucesso = "GTOs listadas com sucesso!";
        public static string MensagemGTOInseridaComSucesso = "GTO inserida com sucesso!";
        public static string MensagemGTONaoInserida = "GTO não inserida!";
        #endregion

        #region Procedimentos
        public static string MensagemProcedimentosInseridosComSucesso = "Procedimento(s) inserido(s) com sucesso!";
        public static string MensagemProcedimentoNaoInserida = "Procedimento(s) não inserido(s)!";
        public static string MensagemProcedimentoListadaComSucesso = "Procedimentos listados com sucesso!";
        public static string MensagemProcedimentoNaoListado = "Procedimentos não listados!";
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
    }
}
