using Inscripciones.Models.Commons;

namespace Inscripciones.Models.MesasExamenes
{
    public class MesaExamen
    {
        public int Id { get; set; }
        public DateTime Llamado1 { get; set; }
        public DateTime Llamado2 { get; set; }
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }
        public string Horario { get; set; } = string.Empty;
        public int TurnoExamenId { get; set; }
        public TurnoExamen? TurnoExamen { get; set; }

        public ICollection<DetalleMesaExamen> DetallesMesaExamen { get; set; }

        public override string ToString()
        {
            return $"{Materia?.Nombre} {Llamado1.Date} / {Llamado2.Date}" ?? string.Empty;
        }
    }
}
