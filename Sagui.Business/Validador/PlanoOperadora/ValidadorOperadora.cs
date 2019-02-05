using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Model.Base;

namespace Sagui.Business.Validador.PlanoOperadora
{
	public class ValidadorPlanoOperadora : Validador<Model.PlanoOperadora>
    {
        private ValidadorData validarData;
        private ValidadorCampo validadorCampo;
        private List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult;

        public ValidadorPlanoOperadora()
        {
            validarData = new ValidadorData();
            validadorCampo = new ValidadorCampo();
            ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();
        }

        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.PlanoOperadora planoOperadora)
        {
            ErrorsResult = validadorCampo.HandleValidation(planoOperadora.NomeFantasia, nameof(planoOperadora.NomeFantasia), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(planoOperadora.RazaoSocial, nameof(planoOperadora.RazaoSocial), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(planoOperadora.CNPJ, nameof(planoOperadora.CNPJ), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(planoOperadora.DataEnvioLote, nameof(planoOperadora.DataEnvioLote), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(planoOperadora.DataRecebimentoLote, nameof(planoOperadora.DataRecebimentoLote), ref ErrorsResult);
            
            return ErrorsResult;
        }
    }
}
