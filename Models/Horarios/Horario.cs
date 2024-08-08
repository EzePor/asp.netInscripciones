using Inscripciones.Models.Commons;
using Inscripciones.Models.Inscripciones;

namespace Inscripciones.Models.Horarios
{
    public class Horario
    {
        public int Id { get; set; }
        public int? MateriaId { get; set; }
        public Materia? Materia { get; set; } = null;
        public int CantidadHoras { get; set; } = 0;
        public int? CicloLectivoId { get; set; }
        public CicloLectivo? CicloLectivo { get; set; }

        public override string ToString()
        {
            return Materia?.Nombre ?? string.Empty;
        }
    }
}
