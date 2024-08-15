using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;

namespace Inscripciones.Models.Commons
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public bool Eliminado { get; set; } = false;
        public override string ToString()
        {
            return Nombre;
        }
    }
}
