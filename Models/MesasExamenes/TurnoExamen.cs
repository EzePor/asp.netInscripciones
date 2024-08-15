namespace Inscripciones.Models.MesasExamenes
{
    public class TurnoExamen
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Eliminado { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
