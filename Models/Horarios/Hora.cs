namespace Inscripciones.Models.Horarios
{
    public class Hora
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool EsRecreo { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
