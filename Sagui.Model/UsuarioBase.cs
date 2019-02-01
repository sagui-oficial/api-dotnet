using Sagui.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class UsuarioBase : BaseModel
    {
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        public string Funcao { get; set; }
        public string Nome { get; set; }
        public string Anotacoes { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int TipoUsuario { get; set; }
    }
}
