using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Model.Base;

namespace Sagui.Business.Validador.Lote
{
	public class ValidadorLote : Validador<Model.Lote>
    {
        private ValidadorData validarData;
        private ValidadorCampo validadorCampo;
        private List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult;

        public ValidadorLote()
        {
            validarData = new ValidadorData();
            validadorCampo = new ValidadorCampo();
            ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();
        }

        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Lote Lote)
        {
            ErrorsResult = validadorCampo.HandleValidation(Lote.DataEnvioCorreio, nameof(Lote.DataEnvioCorreio), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(Lote.DataPrevistaRecebimento, nameof(Lote.DataPrevistaRecebimento), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(Lote.Funcionario, nameof(Lote.Funcionario), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(Lote.PlanoOperadora, nameof(Lote.PlanoOperadora), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(Lote.StatusLote, nameof(Lote.StatusLote), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(Lote.TotalGTOLote, nameof(Lote.TotalGTOLote), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(Lote.ValorTotalLote, nameof(Lote.ValorTotalLote), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}
