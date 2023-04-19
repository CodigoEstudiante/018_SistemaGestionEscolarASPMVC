using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class NivelDetalle
    {
        public int IdNivelDetalle { get; set; }
        public Nivel oNivel { get; set; }
        public GradoSeccion oGradoSeccion { get; set; }
        public int TotalVacantes { get; set; }
        public int VacantesDisponibles { get; set; }
        public int VacantesOcupadas { get; set; }
        public bool Activo { get; set; }
    }
}
