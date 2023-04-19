using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Periodo
    {
        public int IdPeriodo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string textoFechaInicio { get; set; }
        public string textoFechaFin { get; set; }
        public bool Activo { get; set; }
    }
}
