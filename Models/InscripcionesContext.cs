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

            string cadenaConexion = "Server=5.57.213.17;Database=smartsof_ezeporche;User=smartsof_porche;Password=porcheeze123;";
                //"Server=127.0.0.1;Database=inscripcionescontext;User=root;Password=;";

            optionsBuilder.UseMySql(cadenaConexion,ServerVersion.AutoDetect(cadenaConexion));
        }


       public virtual DbSet <Alumno> Alumnos { get; set; }

        public virtual DbSet <Carrera> Carreras { get; set; }

        public virtual DbSet <Inscripcion> Inscripciones { get; set; }

        public virtual DbSet <AnioCarrera> AnioCarreras { get; set; }
        public virtual DbSet <Materia> Materias { get; set; }
        public virtual DbSet <DetalleInscripcion> DetalleInscripciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Datos semilla de carreras
            var tsds = new Carrera { Id = 1, Nombre = "Tecnicatura Superior en Desarrollo de Software" };
            var tssi = new Carrera { Id = 2, Nombre = "Tecnicatura Superior en Soporte de Infraestructura" };
            var tsgo = new Carrera { Id = 3, Nombre = "Tecnicatura Superior en Gestion de las Organizaciones" };
            var tse = new Carrera { Id = 4, Nombre = "Tecnicatura Superior en Enfermeria" };
            var pesca = new Carrera { Id = 5, Nombre = "Profesorado de Educación Secundaria en Ciencias de la Administración" };
            var pei = new Carrera { Id = 6, Nombre = "Profesorado de Educación Inicial" };
            var pese = new Carrera { Id = 7, Nombre = "Profesorado de Educación Secundaria en Economía" };
            var pet = new Carrera { Id = 8, Nombre = "Profesorado de Educación Tecnológica" };
            var lcm = new Carrera { Id = 9, Nombre = "Licenciatura en Cooperativismo y Mutualismo" };
            modelBuilder.Entity<Carrera>().HasData(tsds, tssi, tsgo, tse, pesca, pei, pese, pet, lcm);
            #endregion

            #region Datos semillas de AnioCarreras
            //TECNICO SUPERIOR EN DESARROLLO DE SOFTWARE
            var ac1 = new AnioCarrera { Id = 1, CarreraId = 1, Nombre = "Primero" };
            var ac2 = new AnioCarrera { Id = 2, CarreraId = 1, Nombre = "Segundo" };
            var ac3 = new AnioCarrera { Id = 3, CarreraId = 1, Nombre = "Tercero" };
            //Tecnicatura Superior en Soporte de Infraestructura
            var ac4 = new AnioCarrera { Id = 4, CarreraId = 2, Nombre = "Primero" };
            var ac5 = new AnioCarrera { Id = 5, CarreraId = 2, Nombre = "Segundo" };
            var ac6 = new AnioCarrera { Id = 6, CarreraId = 2, Nombre = "Tercero" };
            //Tecnicatura Superior en Gestion de las Organizaciones
            var ac7 = new AnioCarrera { Id = 7, CarreraId = 3, Nombre = "Primero" };
            var ac8 = new AnioCarrera { Id = 8, CarreraId = 3, Nombre = "Segundo" };
            var ac9 = new AnioCarrera { Id = 9, CarreraId = 3, Nombre = "Tercero" };
            //Tecnicatura Superior en Enfermeria
            var ac10 = new AnioCarrera { Id = 10, CarreraId = 4, Nombre = "Primero" };
            var ac11 = new AnioCarrera { Id = 11, CarreraId = 4, Nombre = "Segundo" };
            var ac12 = new AnioCarrera { Id = 12, CarreraId = 4, Nombre = "Tercero" };
            //Profesorado de Educación Secundaria en Ciencias de la Administración
            var ac13 = new AnioCarrera { Id = 13, CarreraId = 5, Nombre = "Primero" };
            var ac14 = new AnioCarrera { Id = 14, CarreraId = 5, Nombre = "Segundo" };
            var ac15 = new AnioCarrera { Id = 15, CarreraId = 5, Nombre = "Tercero" };
            var ac16 = new AnioCarrera { Id = 16, CarreraId = 5, Nombre = "Cuarto" };
            //Profesorado de Educación Inicial
            var ac17 = new AnioCarrera { Id = 17, CarreraId = 6, Nombre = "Primero" };
            var ac18 = new AnioCarrera { Id = 18, CarreraId = 6, Nombre = "Segundo" };
            var ac19 = new AnioCarrera { Id = 19, CarreraId = 6, Nombre = "Tercero" };
            var ac20 = new AnioCarrera { Id = 20, CarreraId = 6, Nombre = "Cuarto" };
            //Profesorado de Educación Secundaria en Economía
            var ac21 = new AnioCarrera { Id = 21, CarreraId = 7, Nombre = "Primero" };
            var ac22 = new AnioCarrera { Id = 22, CarreraId = 7, Nombre = "Segundo" };
            var ac23 = new AnioCarrera { Id = 23, CarreraId = 7, Nombre = "Tercero" };
            var ac24 = new AnioCarrera { Id = 24, CarreraId = 7, Nombre = "Cuarto" };
            //Profesorado de Educación Tecnológica
            var ac25 = new AnioCarrera { Id = 25, CarreraId = 8, Nombre = "Primero" };
            var ac26 = new AnioCarrera { Id = 26, CarreraId = 8, Nombre = "Segundo" };
            var ac27 = new AnioCarrera { Id = 27, CarreraId = 8, Nombre = "Tercero" };
            var ac28 = new AnioCarrera { Id = 28, CarreraId = 8, Nombre = "Cuarto" };

            modelBuilder.Entity<AnioCarrera>().HasData(
                ac1, ac2, ac3, ac4, ac5, ac6, ac7, ac8, ac9, ac10,
                ac11, ac12, ac13, ac14, ac15, ac16, ac17, ac18,
                ac19, ac20, ac21, ac22, ac23, ac24, ac25, ac26,
                ac27, ac28);
            #endregion

            #region datos semilla de materias
            //Profesorado de Educación Tecnológica
            //1er Año
            var ped = new Materia { Id = 1, Nombre = "Pedagogía", AnioCarreraId = 25 };
            var myc = new Materia { Id = 2, Nombre = "Movimiento y Cuerpo", AnioCarreraId = 25 };
            var pd1 = new Materia { Id = 3, Nombre = "Práctica Docente I: Escenarios Educativos", AnioCarreraId = 25 };
            var it = new Materia { Id = 4, Nombre = "Introducción a la Tecnología", AnioCarreraId = 25 };
            var ht = new Materia { Id = 5, Nombre = "Historia de la Tecnología", AnioCarreraId = 25 };
            var dpt = new Materia { Id = 6, Nombre = "Diseño y Producción de la Técnología 1", AnioCarreraId = 25 };
            var mat = new Materia { Id = 7, Nombre = "Matemática", AnioCarreraId = 25 };
            var fis = new Materia { Id = 8, Nombre = "Física", AnioCarreraId = 25 };

            //2do Año
            var pe = new Materia { Id = 9, Nombre = "Psicología de la Educación", AnioCarreraId = 26 };
            var dyc = new Materia { Id = 10, Nombre = "Didáctica y Curriculum", AnioCarreraId = 26 };
            var ie = new Materia { Id = 11, Nombre = "Instituciones Educativas", AnioCarreraId = 26 };
            var pd2 = new Materia { Id = 12, Nombre = "Práctica Docente II: La Institución Escolar", AnioCarreraId = 26 };
            var se1 = new Materia { Id = 13, Nombre = "Sujetos de la Educación I", AnioCarreraId = 26 };
            var te = new Materia { Id = 14, Nombre = "Tic para la Enseñanza", AnioCarreraId = 26 };
            var pp = new Materia { Id = 15, Nombre = "Procesos Productivos", AnioCarreraId = 26 };
            var t2 = new Materia { Id = 16, Nombre = "Tecnológica II", AnioCarreraId = 26 };
            var de1 = new Materia { Id = 17, Nombre = "Didáctica Específica I", AnioCarreraId = 26 };

            modelBuilder.Entity<Materia>().HasData(
                ped, myc, pd1, it, ht, dpt, mat, fis,
                pe, dyc, ie, pd2, se1, te, pp, t2, de1
                );
            #endregion

            #region datos semillas alumnos
            var ale = new Alumno { Id = 1, ApellidoNombre = "Rubén Alejandro Ramirez", Email = "aleramirezsj@gmail.com", Direccion = "Bv Roque Saenz Peña 2942", Telefono = "15447106" };

            modelBuilder.Entity<Alumno>().HasData(ale);
            #endregion


            #region definición de filtros de eliminación
            // (este código no lo habilitamos todavía porque es cuando agregamos un campo Eliminado a las tablas y modificamos los
            // repository para que al mandar a eliminar solo cambien este campo y lo pongan en verdadero, esta configuración de
            // eliminación hace que el sistema ignore los registros que tengan el eliminado en verdadero, así que hace que en
            // apariencia y funcionalidad esté "eliminado", pero van a seguir estando ahí para que podamos observar las eliminaciones que hubo)
            //modelBuilder.Entity<Alumno>().HasQueryFilter(m => !m.Eliminado);
            //modelBuilder.Entity<AnioCarrera>().HasQueryFilter(m => !m.Eliminado);
            //modelBuilder.Entity<Carrera>().HasQueryFilter(m => !m.Eliminado);
            //modelBuilder.Entity<Materia>().HasQueryFilter(m => !m.Eliminado);
            #endregion

        } 



    } 
}
