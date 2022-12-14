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
            ErrorsResult = validarData.HandleValidation(Lote.DataEnvioCorreio, nameof(Lote.DataEnvioCorreio), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(Lote.DataPrevistaRecebimento, nameof(Lote.DataPrevistaRecebimento), ref ErrorsResult);
            //ErrorsResult = validadorCampo.HandleValidation(Lote.Status, nameof(Lote.Status), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}
