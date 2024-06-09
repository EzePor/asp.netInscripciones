namespace Inscripciones.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int AlumnoId { get; set; }
        public Alumno? Alumno { get; set; }
        public int CarreraId { get; set; }
        public Carrera? Carrera { get; set; }
    }
}
