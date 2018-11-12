using Sagui.Business.Validador.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Procedimentos
{
    public class ValidatorProcedimento : IValidadorBase<Model.Procedimentos>
    {
        ValidadorData validarData = null;
        ValidadorCampo validadorCampo = null;
        List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult = null;

        public ValidatorProcedimento()
        {
            validarData = new ValidadorData();
            validadorCampo = new ValidadorCampo();
            ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();
        }

        public List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Procedimentos procedimento)
        {
            ErrorsResult = validadorCampo.HandleValidation(procedimento.NomeProcedimento, nameof(procedimento.NomeProcedimento), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(procedimento.Codigo, nameof(procedimento.Codigo), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(procedimento.ValorProcedimento, nameof(procedimento.ValorProcedimento), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(procedimento.Anotacoes, nameof(procedimento.Anotacoes), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}



