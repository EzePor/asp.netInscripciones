using Inscripciones.Models.Commons;

namespace Inscripciones.Models.Horarios
{
    public class IntegranteHorario
    {
        public int Id { get; set; }
        public int? HorarioId { get; set; }
        public Horario? Horario { get; set; } = null;
        public int? DocenteId { get; set; }
        public Docente? Docente { get; set; }

        public override string ToString()
        {
            return $"{Docente?.Nombre} {Horario?.Materia?.Nombre}" ?? string.Empty;
        }
    }
}
