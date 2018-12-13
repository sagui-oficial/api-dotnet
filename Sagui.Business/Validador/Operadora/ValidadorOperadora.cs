using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Model.Base;

namespace Sagui.Business.Validador.Operadora
{
	public class ValidadorOperadora : Validador<Model.Operadora>
    {
        private ValidadorData validarData;
        private ValidadorCampo validadorCampo;
        private List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult;

        public ValidadorOperadora()
        {
            validarData = new ValidadorData();
            validadorCampo = new ValidadorCampo();
            ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();
        }

        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Operadora operadora)
        {
            ErrorsResult = validadorCampo.HandleValidation(operadora.NomeOperadora, nameof(operadora.NomeOperadora), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}
