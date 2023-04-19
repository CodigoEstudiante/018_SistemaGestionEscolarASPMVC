using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public NivelDetalleCurso oNivelDetalleCurso { get; set; }
        public string DiaSemana { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string TextoHoraInicio { get; set; }
        public string TextoHoraFin { get; set; }
        public bool Activo { get; set; }

    }
}
