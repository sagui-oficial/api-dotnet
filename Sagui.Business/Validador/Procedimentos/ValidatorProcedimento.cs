using Sagui.Business.Validador.Base;
using Sagui.Model;
using Sagui.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Procedimentos
{
    public class ValidatorProcedimento : Validador<Model.Procedimentos>
    {
        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Procedimentos procedimento)
        {
            ErrorsResult = validadorCampo.HandleValidation(procedimento.NomeProcedimento, nameof(procedimento.NomeProcedimento), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(procedimento.Codigo, nameof(procedimento.Codigo), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(procedimento.ValorProcedimento, nameof(procedimento.ValorProcedimento), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(procedimento.Anotacoes, nameof(procedimento.Anotacoes), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}



