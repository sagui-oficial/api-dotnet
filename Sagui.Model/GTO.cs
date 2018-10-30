﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class GTO
    {   [Key]
        public int IdGTO { get; set; }
        public int NumeroGTO { get; set; }
        public Operadora Operadora { get; set; }
        public Paciente Paciente { get; set; }
        public List<Arquivos> Arquivos { get; set; }
        public DateTime Solicitacao { get; set; }
        public DateTime Vencimento { get; set; }
        public List<Procedimentos> Procedimentos { get; set; }
        public int Status { get; set; }
    }
}
