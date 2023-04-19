using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Nivel
    {
        public int IdNivel { get; set; }
        public Periodo oPeriodo { get; set; }
        public string DescripcionNivel { get; set; }
        public string DescripcionTurno { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string TextoHoraInicio { get; set; }
        public string TextoHoraFin { get; set; }
        public bool Activo { get; set; }
        public List<GradoSeccion> oListaGradoSeccion { get; set; }
    }
}
