using System.ComponentModel.DataAnnotations;

namespace Inscripciones.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }= string.Empty;
        [Display(Name ="Año Carrera")]
        public int AnioCarreraId { get; set; }
        [Display(Name = "Año Carrera")]

        public AnioCarrera? AnioCarrera { get; set;}

        public override string ToString()
        {
            return Nombre;
        }


    }
}
