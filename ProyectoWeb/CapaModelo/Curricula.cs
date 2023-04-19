using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Curricula
    {
        public int IdCurricula { get; set; }
        public int IdDocenteNivelDetalleCurso { get; set; }
        public string Descripcion { get; set; }
        public DocenteCurso oDocenteCurso { get; set; }
    }
}
