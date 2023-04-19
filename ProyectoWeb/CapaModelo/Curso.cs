using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{

    public class Curso
    {
        public int IdCurso { get; set; }
        public string Descripcion { get; set; }
        public bool Asignado { get; set; }
        public bool Activo { get; set; }

    }
}
