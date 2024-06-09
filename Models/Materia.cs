namespace Inscripciones.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }= string.Empty;
        public int AnioCarreraId { get; set; }
        public AnioCarrera? AnioCarrera { get; set;} 
       
    }
}
