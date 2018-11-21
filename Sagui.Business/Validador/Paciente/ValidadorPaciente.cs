using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Model.Base;

namespace Sagui.Business.Validador.Paciente
{
	public class ValidadorPaciente : Validador
	{
        private ValidadorData validarData;
        private ValidadorCampo validadorCampo;
        private List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult;

        public ValidadorPaciente()
        {
            validarData = new ValidadorData();
            validadorCampo = new ValidadorCampo();
            ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();
        }

        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(IBaseModel @class)
        {
            var paciente = @class as Model.Paciente;

            ErrorsResult = validadorCampo.HandleValidation(paciente.NomePaciente, nameof(paciente.NomePaciente), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}
