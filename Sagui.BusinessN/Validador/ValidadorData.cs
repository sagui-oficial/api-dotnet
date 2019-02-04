using Sagui.Base.Utils;
using Sagui.Business.Validador.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador
{
	public class ValidadorData : ValidadorBase
	{
		public override List<Tuple<dynamic, dynamic, dynamic>> HandleValidation(dynamic value, string namevalue, ref List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult)
		{
			if (value == DateTime.MinValue)
			{
				ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.DataNaoPreenchida, namevalue, Constantes.MensagemDataNaoPreenchida));
			}

			return ErrorsResult;
		}

		public override List<Tuple<dynamic, dynamic, dynamic>> HandleValidation(dynamic value1, dynamic value2)
		{
			if (value1 <= value2)
			{
				ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.DataRange, Constantes._DataRange, Constantes.MensagemDataRange));
			}

			return ErrorsResult;
		}
	}
}
