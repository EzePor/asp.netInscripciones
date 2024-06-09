namespace Inscripciones.Models
{
    public class DetalleInscripcion
    {
        public int Id { get; set; }
        public int Modalidadcursado  { get; set; }
        public int InscripcionId { get; set; }
        public Inscripcion? Inscripcion { get; set; }
        public int MateriaId { get; set; }  
        public Materia? Materia { get; set; }   

    }
}
