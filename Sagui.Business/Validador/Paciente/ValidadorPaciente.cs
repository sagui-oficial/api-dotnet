using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Model.Base;

namespace Sagui.Business.Validador.Paciente
{
	public class ValidadorPaciente : Validador<Model.Paciente>
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

        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Paciente paciente)
        {
            ErrorsResult = validadorCampo.HandleValidation(paciente.Nome, nameof(paciente.Nome), ref ErrorsResult);

            return ErrorsResult;
        }
    }
}
