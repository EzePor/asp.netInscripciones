using Microsoft.EntityFrameworkCore;

namespace Inscripciones.Models
{
    public class InscripcionesContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;
                       Database = InscripcionesContext;
                       User Id = sa; Password = 123;
                       MultipleActiveResultSets = True;
                       Encrypt = false
             ");
        }


       public virtual DbSet <Alumno> Alumnos { get; set; }
    }
}
