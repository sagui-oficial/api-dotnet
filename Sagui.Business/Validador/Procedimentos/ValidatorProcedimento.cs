using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Procedimentos
{
    public class ValidatorProcedimento
    {
        public static List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Procedimentos procedimento)
        {
            List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();

            ValidadorData validarData = new ValidadorData();
            ValidadorCampo validadorCampo = new ValidadorCampo();

            ErrorsResult = validadorCampo.HandleValidation(procedimento.NomeProcedimento, nameof(procedimento.NomeProcedimento), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(procedimento.Codigo, nameof(procedimento.Codigo), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(procedimento.ValorProcedimento, nameof(procedimento.ValorProcedimento), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(procedimento.Anotacoes, nameof(procedimento.Anotacoes), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}



