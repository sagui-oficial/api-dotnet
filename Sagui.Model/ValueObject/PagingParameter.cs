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

        public int TotalPaginas { get; set; } = 1;

        public string Pesquisa { get; set; }


        public int Offset
        {

            get { return Pagina * Linhas - Linhas; }
        }

    }
}
