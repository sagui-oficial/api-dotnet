using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Business.Validador.GTO;
using Sagui.Model;

namespace Sagui.Business.GTO
{
    public class CadastrarGTOBusiness
    {
        public void Cadastrar(Model.GTO gto)
        {
			var errors = ValidadorGTO.Validate(gto);

           
        }
    }
}
