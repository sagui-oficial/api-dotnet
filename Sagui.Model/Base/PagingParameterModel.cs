using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Model
{
    public class PagingParameterModel
    {
        public int Status { get; set; } = 1;

        public int pagina { get; set; } = 1;

        public int numeroLinhas { get; set; } = 10;

        public int TotalPaginas { get; set; } = 1;


        public int offset
        {

            get { return pagina * numeroLinhas - numeroLinhas;  }            
        }
               
    }
}
