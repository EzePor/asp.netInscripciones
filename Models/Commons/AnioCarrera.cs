using System.ComponentModel.DataAnnotations.Schema;

namespace Inscripciones.Models.Commons
{
    public class AnioCarrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int CarreraId { get; set; }
        public Carrera? Carrera { get; set; }
        public bool Eliminado { get; set; } = false;
        [NotMapped]
        public string? AñoYCarrera
        {
            get { return $"{Nombre} {Carrera?.Nombre}" ?? string.Empty; }
        }
        public override string ToString()
        {
            return AñoYCarrera;
        }


    }
}
