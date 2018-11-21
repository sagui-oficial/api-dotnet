using Sagui.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class Paciente : IBaseModel
    {
        public int IdPaciente { get; set; }
        public string NomePaciente { get; set; }
    }
}
