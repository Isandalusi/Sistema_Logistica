using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Entrada_Productos
    {
        public int Codigo_ep { get; set; }

        public int Codigo_tde { get; set; }

        public string NroDocumento_ep { get; set; }

        public int Codigo_pv { get; set; }

        public DateTime Fecha_ep { get; set; }

        public int Codigo_al { get; set; }

        public string Observacion { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Iva { get; set; }

        public decimal Importe_Total { get; set; }
    }
}
