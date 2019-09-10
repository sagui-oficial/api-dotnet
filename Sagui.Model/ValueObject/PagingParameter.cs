using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Model.ValueObject
{
    public class PagingParameter
    {
        public int Status { get; set; } = 1;

        public int Pagina { get; set; } = 1;

        public int Linhas { get; set; } = 10;

        public int TotalPaginas { get; } = 1;


        public int Offset
        {

            get { return Pagina * Linhas - Linhas; }
        }

    }
}
