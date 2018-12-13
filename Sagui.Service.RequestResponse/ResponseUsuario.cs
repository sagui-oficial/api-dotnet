using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponseUsuario : ResponseBase
    {
        public Model.Usuario Usuario { get; set; }
        public List<Model.Usuario> Usuarios { get; set; }
    }
}
