using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inscripciones.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
        public int AlumnoId { get; set; }
        public Alumno? Alumno { get; set; }
        public int CarreraId { get; set; }
        public Carrera? Carrera { get; set; }
        [NotMapped]
        public string? Inscripto
        {
            get { return Alumno?.ApellidoNombre ?? string.Empty; }
        }
    }
}
