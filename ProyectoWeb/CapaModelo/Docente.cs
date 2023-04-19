using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Docente
    {
        public int IdDocente { get; set; }
        public int ValorCodigo { get; set; }
        public string Codigo { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TextoFechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string GradoEstudio { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string NumeroTelefono { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<Nivel> oListaNivel { get; set; }
    }
}
