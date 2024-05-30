using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inscripciones.Models
{
    public class InscripcionesContext : DbContext
    {
        public InscripcionesContext(DbContextOptions<InscripcionesContext>options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;
            //           Database = InscripcionesContext;
            //           User Id = sa; Password = 123;
            //           MultipleActiveResultSets = True;
            //           Encrypt = false
            // ");

            string cadenaConexion = "Server=127.0.0.1;Database=inscripcionescontext;User=root;Password=;";

            optionsBuilder.UseMySql(cadenaConexion,ServerVersion.AutoDetect(cadenaConexion));
        }


       public virtual DbSet <Alumno> Alumnos { get; set; }

        public virtual DbSet <Carrera> Carreras { get; set; }


       
    }
}
