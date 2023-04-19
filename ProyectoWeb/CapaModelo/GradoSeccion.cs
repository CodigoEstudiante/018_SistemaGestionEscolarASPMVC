using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class GradoSeccion
    {
        public int IdGradoSeccion { get; set; }
        public string DescripcionGrado { get; set; }
        public string DescripcionSeccion { get; set; }
        public bool Activo { get; set; }
        public bool Asignado { get; set; }
        public List<Curso> oListaCurso { get; set; }
    }
}
