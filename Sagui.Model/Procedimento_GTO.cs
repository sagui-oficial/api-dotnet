﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
   public class Procedimento_GTO
    {
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        public int IdGTO { get; set; }
        public int IdProcedimento { get; set; }
        public double ValorProcedimento { get; set; }
        public bool Pago { get; set; }

        //public ICollection<GTO> GTO { get; set; }
        //public ICollection<Procedimentos> Procedimento { get; set; }
    }
}
