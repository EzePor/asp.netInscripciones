namespace Inscripciones.Models
{
    public class Alumno
    {
        public int Id { get; set; } 
        public string ApellidoNombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return ApellidoNombre;
        }

    }


}
