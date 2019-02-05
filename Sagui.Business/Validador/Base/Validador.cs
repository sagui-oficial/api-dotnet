using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Base
{
    public class Validador
    {
        protected ValidadorData validarData = null;
        protected ValidadorCampo validadorCampo = null;
        protected List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult = null;

        public Validador()
        {
            validarData = new ValidadorData();
            validadorCampo = new ValidadorCampo();
            ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();
        }
    }
}
