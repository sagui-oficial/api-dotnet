using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Base
{
	public abstract class ValidadorBase
	{
		protected ValidadorBase Successor { get; private set; }

		protected List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult { get; set; }

		protected ValidadorBase()
		{
			ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();
		}

		public abstract List<Tuple<dynamic, dynamic, dynamic>> HandleValidation(dynamic value, string valname, ref List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult);

		public abstract List<Tuple<dynamic, dynamic, dynamic>> HandleValidation(dynamic value1, dynamic value2);

		/// <summary>
		/// Set next validation
		/// </summary>
		/// <param name="successor"></param>
		public void SetSuccessor(ValidadorBase successor)
		{
			this.Successor = successor;
		}
	}
}
