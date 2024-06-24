namespace Inscripciones.Models
{
    public class DetalleInscripcion
    {
        public int Id { get; set; }
        public ModalidadCursadoEnum Modalidadcursado  { get; set; }
        public int InscripcionId { get; set; }
        public Inscripcion? Inscripcion { get; set; }
        public int MateriaId { get; set; }  
        public Materia? Materia { get; set; }

        public override string ToString()
        {
            return$"{ Materia?.Nombre} {Modalidadcursado}" ?? string.Empty;
        }


    }
}
