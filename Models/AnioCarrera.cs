namespace Inscripciones.Models
{
    public class AnioCarrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int CarreraId { get; set;}
        public Carrera? Carrera { get; set;} 

    }
}
