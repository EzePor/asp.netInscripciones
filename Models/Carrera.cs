using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;

namespace Inscripciones.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public override string ToString()
        {
            return Nombre;
        }
    }
}
