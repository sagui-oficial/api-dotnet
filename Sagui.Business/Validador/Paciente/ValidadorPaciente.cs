using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Paciente
{
	public class ValidadorPaciente
	{
		public static List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Paciente paciente)
		{
			List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();

			ValidadorData validarData = new ValidadorData();
			ValidadorCampo validadorCampo = new ValidadorCampo();

			ErrorsResult = validadorCampo.HandleValidation(paciente.NomePaciente, nameof(paciente.NomePaciente));

			return ErrorsResult;
		}
	}
}
