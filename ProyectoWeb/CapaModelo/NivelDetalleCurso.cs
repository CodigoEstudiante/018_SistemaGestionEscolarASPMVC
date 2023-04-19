using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class NivelDetalleCurso
    {
        public int IdNivelDetalleCurso { get; set; }
        public NivelDetalle oNivelDetalle { get; set; }
        public Nivel oNivel { get; set; }
        public GradoSeccion oGradoSeccion { get; set; }
        public Curso oCurso { get; set; }
    }
}
