using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sagui.Model
{
   public class GTO_Lote
    {
        [Key]
        public int Id { get; set; }
        public int IdLote { get; set; }
        public int IdGTO { get; set; }
    }
}
