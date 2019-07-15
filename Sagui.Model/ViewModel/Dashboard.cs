using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Model.ViewModel
{
    public class Dashboard
    {
        public Faturamento Faturamento { get; set; }
        public GuiasGlosadas GuiasGlosadas { get; set; }
        public int PacienteAtendidos { get; set; }
        public List<Grafico> Grafico { get; set; }
    }

    public class Faturamento
    {
        public Double Previsto { get; set; }
        public Double Realizado { get; set; }

    }
    public class GuiasGlosadas
    {
        public Double Valor { get; set; }
        public Double Quantidade { get; set; }

    }

    public class Grafico
    {

        public String Operadora { get; set; }
        public Double Total { get; set; }
        public Double Glosadas { get; set; }

    }
}
