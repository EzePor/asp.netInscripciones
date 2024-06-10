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
            var ac1 = new AnioCarrera { Id = 1, CarreraId = 1, Nombre = "1er año" };
            var ac2 = new AnioCarrera { Id = 2, CarreraId = 1, Nombre = "2do año" };
            var ac3 = new AnioCarrera { Id = 3, CarreraId = 1, Nombre = "3er año" };
            //Tecnicatura Superior en Soporte de Infraestructura
            var ac4 = new AnioCarrera { Id = 4, CarreraId = 2, Nombre = "1er año" };
            var ac5 = new AnioCarrera { Id = 5, CarreraId = 2, Nombre = "2do año" };
            var ac6 = new AnioCarrera { Id = 6, CarreraId = 2, Nombre = "3er año" };
            //Tecnicatura Superior en Gestion de las Organizaciones
            var ac7 = new AnioCarrera { Id = 7, CarreraId = 3, Nombre = "1er año" };
            var ac8 = new AnioCarrera { Id = 8, CarreraId = 3, Nombre = "2do año" };
            var ac9 = new AnioCarrera { Id = 9, CarreraId = 3, Nombre = "3er año" };
            //Tecnicatura Superior en Enfermeria
            var ac10 = new AnioCarrera { Id = 10, CarreraId = 4, Nombre = "1er año" };
            var ac11 = new AnioCarrera { Id = 11, CarreraId = 4, Nombre = "2do año" };
            var ac12 = new AnioCarrera { Id = 12, CarreraId = 4, Nombre = "3er año" };
            //Profesorado de Educación Secundaria en Ciencias de la Administración
            var ac13 = new AnioCarrera { Id = 13, CarreraId = 5, Nombre = "1er año" };
            var ac14 = new AnioCarrera { Id = 14, CarreraId = 5, Nombre = "2do año" };
            var ac15 = new AnioCarrera { Id = 15, CarreraId = 5, Nombre = "3er año" };
            var ac16 = new AnioCarrera { Id = 16, CarreraId = 5, Nombre = "4to año" };
            //Profesorado de Educación Inicial
            var ac17 = new AnioCarrera { Id = 17, CarreraId = 6, Nombre = "1er año" };
            var ac18 = new AnioCarrera { Id = 18, CarreraId = 6, Nombre = "2do año" };
            var ac19 = new AnioCarrera { Id = 19, CarreraId = 6, Nombre = "3er año" };
            var ac20 = new AnioCarrera { Id = 20, CarreraId = 6, Nombre = "4to año" };
            //Profesorado de Educación Secundaria en Economía
            var ac21 = new AnioCarrera { Id = 21, CarreraId = 7, Nombre = "1er año" };
            var ac22 = new AnioCarrera { Id = 22, CarreraId = 7, Nombre = "2do año" };
            var ac23 = new AnioCarrera { Id = 23, CarreraId = 7, Nombre = "3er año" };
            var ac24 = new AnioCarrera { Id = 24, CarreraId = 7, Nombre = "4to año" };
            //Profesorado de Educación Tecnológica
            var ac25 = new AnioCarrera { Id = 25, CarreraId = 8, Nombre = "1er año" };
            var ac26 = new AnioCarrera { Id = 26, CarreraId = 8, Nombre = "2do año" };
            var ac27 = new AnioCarrera { Id = 27, CarreraId = 8, Nombre = "3er año" };
            var ac28 = new AnioCarrera { Id = 28, CarreraId = 8, Nombre = "4to año" };

            modelBuilder.Entity<AnioCarrera>().HasData(
                ac1, ac2, ac3, ac4, ac5, ac6, ac7, ac8, ac9, ac10,
                ac11, ac12, ac13, ac14, ac15, ac16, ac17, ac18,
                ac19, ac20, ac21, ac22, ac23, ac24, ac25, ac26,
                ac27, ac28);
            #endregion



            #region Datos semilla de Materias

            // PROFESORADO DE EDUCACIÓN SECUNDARIA EN ECONOMÍA
            var materiasEconomia = new[]
            {
               new Materia { Id = 1, Nombre = "Pedagogía", AnioCarreraId = 21 },
               new Materia { Id = 2, Nombre = "UCCV Sociología", AnioCarreraId = 21 },
               new Materia { Id = 3, Nombre = "Administración General", AnioCarreraId = 21 },
               new Materia { Id = 4, Nombre = "Economía I", AnioCarreraId = 21 },
               new Materia { Id = 5, Nombre = "Geografía Económica", AnioCarreraId = 21 },
               new Materia { Id = 6, Nombre = "Historia Económica", AnioCarreraId = 21 },
               new Materia { Id = 7, Nombre = "Construcción de Ciudadanía", AnioCarreraId = 21 },
               new Materia { Id = 8, Nombre = "Sistema de Información Contable I", AnioCarreraId = 21 },
               new Materia { Id = 9, Nombre = "Matemática", AnioCarreraId = 21 },
               new Materia { Id = 10, Nombre = "Práctica Docente I", AnioCarreraId = 21 },
               new Materia { Id = 11, Nombre = "Instituciones Educativas", AnioCarreraId = 22 },
               new Materia { Id = 12, Nombre = "Didáctica y Curriculum", AnioCarreraId = 22 },
               new Materia { Id = 13, Nombre = "Psicología y Educación", AnioCarreraId = 22 },
               new Materia { Id = 14, Nombre = "Economía II", AnioCarreraId = 22 },
               new Materia { Id = 15, Nombre = "Sistema de Información Contable II", AnioCarreraId = 22 },
               new Materia { Id = 16, Nombre = "Derecho I", AnioCarreraId = 22 },
               new Materia { Id = 17, Nombre = "Estadística Aplicada", AnioCarreraId = 22 },
               new Materia { Id = 18, Nombre = "Didáctica de la Economía I", AnioCarreraId = 22 },
               new Materia { Id = 19, Nombre = "Práctica Docente II", AnioCarreraId = 22 },
               new Materia { Id = 20, Nombre = "Historia y Política de la Educación Argentina", AnioCarreraId = 23 },
               new Materia { Id = 21, Nombre = "Filosofía", AnioCarreraId = 23 },
               new Materia { Id = 22, Nombre = "Metodología de la Investigación", AnioCarreraId = 23 },
               new Materia { Id = 23, Nombre = "Economía III", AnioCarreraId = 23 },
               new Materia { Id = 24, Nombre = "Finanzas Públicas", AnioCarreraId = 23 },
               new Materia { Id = 25, Nombre = "Derecho II", AnioCarreraId = 23 },
               new Materia { Id = 26, Nombre = "Sujetos de la Educación Secundaria", AnioCarreraId = 23 },
               new Materia { Id = 27, Nombre = "Práctica Docente III", AnioCarreraId = 23 },
               new Materia { Id = 28, Nombre = "Producción de los Recursos Didácticos I", AnioCarreraId = 23 },
               new Materia { Id = 29, Nombre = "Ética y Trabajo Docente", AnioCarreraId = 24 },
               new Materia { Id = 30, Nombre = "Educación Sexual Integral", AnioCarreraId = 24 },
               new Materia { Id = 31, Nombre = "UCCV Comunicación Social", AnioCarreraId = 24 },
               new Materia { Id = 32, Nombre = "Economía Social y Sostenible", AnioCarreraId = 24 },
               new Materia { Id = 33, Nombre = "Economía Argentina Latinoamericana e Internacional", AnioCarreraId = 24 },
               new Materia { Id = 34, Nombre = "Prácticas de Investigación", AnioCarreraId = 24 },
               new Materia { Id = 35, Nombre = "Práctica Docente IV (Residencia)", AnioCarreraId = 24 },
               new Materia { Id = 36, Nombre = "Producción de los Recursos Didácticos II", AnioCarreraId = 24 },
               new Materia { Id = 37, Nombre = "Unidad de Definición Institucional", AnioCarreraId = 24 }
           };

            // PROFESORADO DE EDUCACIÓN TECNOLÓGICA
            var materiasTecnologica = new[]
            {
               new Materia { Id = 38, Nombre = "Pedagogía", AnioCarreraId = 25 },
               new Materia { Id = 39, Nombre = "Movimiento y Cuerpo", AnioCarreraId = 25 },
               new Materia { Id = 40, Nombre = "Práctica Docente I: Escenarios Educativos", AnioCarreraId = 25 },
               new Materia { Id = 41, Nombre = "Introducción a la Tecnología", AnioCarreraId = 25 },
               new Materia { Id = 42, Nombre = "Historia de la Tecnología", AnioCarreraId = 25 },
               new Materia { Id = 43, Nombre = "Diseño y Producción de la Tecnología I", AnioCarreraId = 25 },
               new Materia { Id = 44, Nombre = "Matemática", AnioCarreraId = 25 },
               new Materia { Id = 45, Nombre = "Física", AnioCarreraId = 25 },
               new Materia { Id = 46, Nombre = "Psicología de la Educación", AnioCarreraId = 26 },
               new Materia { Id = 47, Nombre = "Didáctica y Curriculum", AnioCarreraId = 26 },
               new Materia { Id = 48, Nombre = "Instituciones Educativas", AnioCarreraId = 26 },
               new Materia { Id = 49, Nombre = "Práctica Docente II: La Institución Escolar", AnioCarreraId = 26 },
               new Materia { Id = 50, Nombre = "Sujetos de la Educación I", AnioCarreraId = 26 },
               new Materia { Id = 51, Nombre = "Tics para la Enseñanza", AnioCarreraId = 26 },
               new Materia { Id = 52, Nombre = "Procesos Productivos", AnioCarreraId = 26 },
               new Materia { Id = 53, Nombre = "Diseño y Producción Tecnológica II", AnioCarreraId = 26 },
               new Materia { Id = 54, Nombre = "Didáctica Específica I", AnioCarreraId = 26 },
               new Materia { Id = 55, Nombre = "Filosofía y Educación", AnioCarreraId = 27 },
               new Materia { Id = 56, Nombre = "Historia Social de la Educación", AnioCarreraId = 27 },
               new Materia { Id = 57, Nombre = "Metodología de la Investigación", AnioCarreraId = 27 },
               new Materia { Id = 58, Nombre = "Práctica Docente III: La Clase", AnioCarreraId = 27 },
               new Materia { Id = 59, Nombre = "Sujetos de la Educación II", AnioCarreraId = 27 },
               new Materia { Id = 60, Nombre = "Materiales", AnioCarreraId = 27 },
               new Materia { Id = 61, Nombre = "Química", AnioCarreraId = 27 },
               new Materia { Id = 62, Nombre = "Procesos de Control", AnioCarreraId = 27 },
               new Materia { Id = 63, Nombre = "Tecnologías Regionales", AnioCarreraId = 27 },
               new Materia { Id = 64, Nombre = "Diseño y Producción Tecnológica III", AnioCarreraId = 27 },
               new Materia { Id = 65, Nombre = "Didáctica Específica II", AnioCarreraId = 27 },
               new Materia { Id = 66, Nombre = "Ética y Trabajo Docente", AnioCarreraId = 28 },
               new Materia { Id = 67, Nombre = "Educación Sexual Integral", AnioCarreraId = 28 },
               new Materia { Id = 68, Nombre = "Unidades de Definición Institucional I", AnioCarreraId = 28 },
               new Materia { Id = 69, Nombre = "Unidades de Definición Institucional II", AnioCarreraId = 28 },
               new Materia { Id = 70, Nombre = "Prácticas de Investigación", AnioCarreraId = 28 },
               new Materia { Id = 71, Nombre = "Práctica Docente IV: El Rol Docente y su Práctica", AnioCarreraId = 28 },
               new Materia { Id = 72, Nombre = "Biotecnología", AnioCarreraId = 28 },
               new Materia { Id = 73, Nombre = "Procesos de Comunicación", AnioCarreraId = 28 },
               new Materia { Id = 74, Nombre = "Problemáticas Sociotécnicas", AnioCarreraId = 28 },
               new Materia { Id = 75, Nombre = "Diseño y Producción Tecnológica IV", AnioCarreraId = 28 },
               new Materia { Id = 76, Nombre = "Taller de Producción Didáctica", AnioCarreraId = 28 }
           };

            // TÉCNICO SUPERIOR EN DESARROLLO DE SOFTWARE
            var materiasSoftware = new[]
            {
               new Materia { Id = 77, Nombre = "Comunicación (1° cuat.)", AnioCarreraId = 1 },
               new Materia { Id = 78, Nombre = "Unidad de definición Institucional (2° cuat.)", AnioCarreraId = 1 },
               new Materia { Id = 79, Nombre = "Matemática", AnioCarreraId = 1 },
               new Materia { Id = 80, Nombre = "Inglés Técnico I", AnioCarreraId = 1 },
               new Materia { Id = 81, Nombre = "Administración", AnioCarreraId = 1 },
               new Materia { Id = 82, Nombre = "Tecnología de la Información", AnioCarreraId = 1 },
               new Materia { Id = 83, Nombre = "Lógica y Estructura de Datos", AnioCarreraId = 1 },
               new Materia { Id = 84, Nombre = "Ingeniería de Software I", AnioCarreraId = 1 },
               new Materia { Id = 85, Nombre = "Sistemas Operativos", AnioCarreraId = 1 },
               new Materia { Id = 86, Nombre = "Problemáticas Socio Contemporáneas (1° cuat.)", AnioCarreraId = 2 },
               new Materia { Id = 87, Nombre = "Unidad de definición Institucional (2° cuat.)", AnioCarreraId = 2 },
               new Materia { Id = 88, Nombre = "Inglés Técnico II", AnioCarreraId = 2 },
               new Materia { Id = 89, Nombre = "Innovación y Desarrollo Emprendedor", AnioCarreraId = 2 },
               new Materia { Id = 90, Nombre = "Estadística", AnioCarreraId = 2 },
               new Materia { Id = 91, Nombre = "Programación I", AnioCarreraId = 2 },
               new Materia { Id = 92, Nombre = "Ingeniería de Software II", AnioCarreraId = 2 },
               new Materia { Id = 93, Nombre = "Base de Datos I", AnioCarreraId = 2 },
               new Materia { Id = 94, Nombre = "Práctica Profesionalizante I", AnioCarreraId = 2 },
               new Materia { Id = 95, Nombre = "Ética y Responsabilidad Social", AnioCarreraId = 3 },
               new Materia { Id = 96, Nombre = "Derecho y Legislación Laboral", AnioCarreraId = 3 },
               new Materia { Id = 97, Nombre = "Redes y Comunicación", AnioCarreraId = 3 },
               new Materia { Id = 98, Nombre = "Programación II", AnioCarreraId = 3 },
               new Materia { Id = 99, Nombre = "Gestión de Proyectos de Software", AnioCarreraId = 3 },
               new Materia { Id = 100, Nombre = "Base de Datos II", AnioCarreraId = 3 },
               new Materia { Id = 101, Nombre = "Práctica Profesionalizante II", AnioCarreraId = 3 }
           };

            // TÉCNICO SUPERIOR EN ENFERMERÍA
            var materiasEnfermeria = new[]
            {
               new Materia { Id = 102, Nombre = "Comunicación", AnioCarreraId = 10 },
               new Materia { Id = 103, Nombre = "Unidad de Definición Institucional I", AnioCarreraId = 10 },
               new Materia { Id = 104, Nombre = "Salud Pública", AnioCarreraId = 10 },
               new Materia { Id = 105, Nombre = "Biología Humana I", AnioCarreraId = 10 },
               new Materia { Id = 106, Nombre = "Sujeto, Cultura y Sociedad", AnioCarreraId = 10 },
               new Materia { Id = 107, Nombre = "Fundamentos del Cuidado en Enfermería", AnioCarreraId = 10 },
               new Materia { Id = 108, Nombre = "Cuidados de Enfermería en la Comunidad y en la Familia", AnioCarreraId = 10 },
               new Materia { Id = 109, Nombre = "Práctica Profesionalizante I", AnioCarreraId = 10 },
               new Materia { Id = 110, Nombre = "Problemáticas Socio Contemporáneas", AnioCarreraId = 11 },
               new Materia { Id = 111, Nombre = "Unidad de Definición Institucional II", AnioCarreraId = 11 },
               new Materia { Id = 112, Nombre = "Informática en Salud", AnioCarreraId = 11 },
               new Materia { Id = 113, Nombre = "Sujeto, Cultura y Sociedad II", AnioCarreraId = 11 },
               new Materia { Id = 114, Nombre = "Biología Humana II", AnioCarreraId = 11 },
               new Materia { Id = 115, Nombre = "Bioseguridad y Medio Ambiente en el Trabajo", AnioCarreraId = 11 },
               new Materia { Id = 116, Nombre = "Farmacología en Enfermería", AnioCarreraId = 11 },
               new Materia { Id = 117, Nombre = "Cuidados de Enfermería a los Adultos y Adultos Mayores", AnioCarreraId = 11 },
               new Materia { Id = 118, Nombre = "Práctica Profesionalizante II", AnioCarreraId = 11 },
               new Materia { Id = 119, Nombre = "Ética y Responsabilidad Social", AnioCarreraId = 12 },
               new Materia { Id = 120, Nombre = "Derecho y Legislación Laboral", AnioCarreraId = 12 },
               new Materia { Id = 121, Nombre = "Inglés Técnico", AnioCarreraId = 12 },
               new Materia { Id = 122, Nombre = "Organización y Gestión en Instituciones de Salud", AnioCarreraId = 12 },
               new Materia { Id = 123, Nombre = "Investigación en Enfermería", AnioCarreraId = 12 },
               new Materia { Id = 124, Nombre = "Cuidados de Enfermería en Salud Mental", AnioCarreraId = 12 },
               new Materia { Id = 125, Nombre = "Cuidados de Enfermería al Niño y al Adolescente", AnioCarreraId = 12 },
               new Materia { Id = 126, Nombre = "Práctica Profesionalizante III", AnioCarreraId = 12 }
           };

            // TÉCNICO SUPERIOR EN GESTIÓN DE LAS ORGANIZACIONES
            var materiasOrganizaciones = new[]
            {
               new Materia { Id = 127, Nombre = "Comunicación (1º cuatr.)", AnioCarreraId = 7 },
               new Materia { Id = 128, Nombre = "Unidad de Definición Institucional (2º cuatr.)", AnioCarreraId = 7 },
               new Materia { Id = 129, Nombre = "Economía", AnioCarreraId = 7 },
               new Materia { Id = 130, Nombre = "Matemática y Estadística", AnioCarreraId = 7 },
               new Materia { Id = 131, Nombre = "Contabilidad", AnioCarreraId = 7 },
               new Materia { Id = 132, Nombre = "Informática", AnioCarreraId = 7 },
               new Materia { Id = 133, Nombre = "Administración", AnioCarreraId = 7 },
               new Materia { Id = 134, Nombre = "Gestión de la Producción", AnioCarreraId = 7 },
               new Materia { Id = 135, Nombre = "Gestión del Talento Humano", AnioCarreraId = 7 },
               new Materia { Id = 136, Nombre = "Problemáticas Contemporáneas (1º cuatr.)", AnioCarreraId = 8 },
               new Materia { Id = 137, Nombre = "Unidad de Definición Institucional (2º cuatr.)", AnioCarreraId = 8 },
               new Materia { Id = 138, Nombre = "Innovación y Desarrollo Emprendedor", AnioCarreraId = 8 },
               new Materia { Id = 139, Nombre = "Inglés Técnico", AnioCarreraId = 8 },
               new Materia { Id = 140, Nombre = "Legislación Comercial y Tributaria", AnioCarreraId = 8 },
               new Materia { Id = 141, Nombre = "Gestión de Comercialización e Investigación Comercial", AnioCarreraId = 8 },
               new Materia { Id = 142, Nombre = "Gestión de Costos", AnioCarreraId = 8 },
               new Materia { Id = 143, Nombre = "Gestión Contable", AnioCarreraId = 8 },
               new Materia { Id = 144, Nombre = "Práctica Profesionalizante I", AnioCarreraId = 8 },
               new Materia { Id = 145, Nombre = "Gestión de Seguridad, Salud Ocupacional y Medio Ambiente", AnioCarreraId = 9 },
               new Materia { Id = 146, Nombre = "Ética y Responsabilidad Social", AnioCarreraId = 9 },
               new Materia { Id = 147, Nombre = "Legislación Laboral", AnioCarreraId = 9 },
               new Materia { Id = 148, Nombre = "Estrategia Empresarial", AnioCarreraId = 9 },
               new Materia { Id = 149, Nombre = "Sistema de Información para la Gestión de las Organizaciones", AnioCarreraId = 9 },
               new Materia { Id = 150, Nombre = "Gestión Financiera", AnioCarreraId = 9 },
               new Materia { Id = 151, Nombre = "Evaluación y Administración de Proyectos de Inversión", AnioCarreraId = 9 },
               new Materia { Id = 152, Nombre = "Control de Gestión", AnioCarreraId = 9 },
               new Materia { Id = 153, Nombre = "Prácticas Profesionalizantes II", AnioCarreraId = 9 }
           };

            // TÉCNICO SUPERIOR EN SOPORTE DE INFRAESTRUCTURA DE TECNOLOGÍA DE LA INFORMACIÓN
            var materiasInfraestructura = new[]
            {
               new Materia { Id = 154, Nombre = "Comunicación (1° cuat.)", AnioCarreraId = 4 },
               new Materia { Id = 155, Nombre = "Unidad de definición Institucional (2° cuat.)", AnioCarreraId = 4 },
               new Materia { Id = 156, Nombre = "Matemática", AnioCarreraId = 4 },
               new Materia { Id = 157, Nombre = "Física Aplicada a las Tecnologías de la Información", AnioCarreraId = 4 },
               new Materia { Id = 158, Nombre = "Administración", AnioCarreraId = 4 },
               new Materia { Id = 159, Nombre = "Inglés Técnico", AnioCarreraId = 4 },
               new Materia { Id = 160, Nombre = "Arquitectura de las Computadoras", AnioCarreraId = 4 },
               new Materia { Id = 161, Nombre = "Lógica y Programación", AnioCarreraId = 4 },
               new Materia { Id = 162, Nombre = "Infraestructura de Redes I", AnioCarreraId = 4 },
               new Materia { Id = 163, Nombre = "Problemáticas Socio Contemporáneas (1° cuat.)", AnioCarreraId = 5 },
               new Materia { Id = 164, Nombre = "Unidad de definición Institucional (2° cuat.)", AnioCarreraId = 5 },
               new Materia { Id = 165, Nombre = "Innovación y Desarrollo Emprendedor", AnioCarreraId = 5 },
               new Materia { Id = 166, Nombre = "Estadística", AnioCarreraId = 5 },
               new Materia { Id = 167, Nombre = "Sistemas Operativos", AnioCarreraId = 5 },
               new Materia { Id = 168, Nombre = "Algoritmos y Estructuras de Datos", AnioCarreraId = 5 },
               new Materia { Id = 169, Nombre = "Base de Datos", AnioCarreraId = 5 },
               new Materia { Id = 170, Nombre = "Infraestructura de Redes II", AnioCarreraId = 5 },
               new Materia { Id = 171, Nombre = "Práctica Profesionalizante I", AnioCarreraId = 5 },
               new Materia { Id = 172, Nombre = "Ética y Responsabilidad Social", AnioCarreraId = 6 },
               new Materia { Id = 173, Nombre = "Derecho y Legislación Laboral", AnioCarreraId = 6 },
               new Materia { Id = 174, Nombre = "Administración de Base de Datos", AnioCarreraId = 6 },
               new Materia { Id = 175, Nombre = "Integridad y Migración de Datos", AnioCarreraId = 6 },
               new Materia { Id = 176, Nombre = "Seguridad de los Sistemas", AnioCarreraId = 6 },
               new Materia { Id = 177, Nombre = "Administración de Sistemas Operativos y Redes", AnioCarreraId = 6 },
               new Materia { Id = 178, Nombre = "Práctica Profesionalizante II", AnioCarreraId = 6 }
           };

            modelBuilder.Entity<Materia>().HasData(materiasEconomia);
            modelBuilder.Entity<Materia>().HasData(materiasTecnologica);
            modelBuilder.Entity<Materia>().HasData(materiasSoftware);
            modelBuilder.Entity<Materia>().HasData(materiasEnfermeria);
            modelBuilder.Entity<Materia>().HasData(materiasOrganizaciones);
            modelBuilder.Entity<Materia>().HasData(materiasInfraestructura);

            #region Datos semilla de Materias - Profesorado de Educación Inicial

            // Primer Año
            var m1 = new Materia { Id = 179, AnioCarreraId = 17, Nombre = "Psicología y Educación" };
            var m2 = new Materia { Id = 180, AnioCarreraId = 17, Nombre = "Pedagogía" };
            var m3 = new Materia { Id = 181, AnioCarreraId = 17, Nombre = "Sociología de la Educación" };
            var m4 = new Materia { Id = 182, AnioCarreraId = 17, Nombre = "Historia Argentina y Latinoamericana (1º cuatr.)" };
            var m5 = new Materia { Id = 183, AnioCarreraId = 17, Nombre = "Movimiento y Cuerpo I" };
            var m6 = new Materia { Id = 184, AnioCarreraId = 17, Nombre = "Taller de Práctica I" };
            var m7 = new Materia { Id = 185, AnioCarreraId = 17, Nombre = "Problemáticas Contemporáneas de la Educación Inicial I" };
            var m8 = new Materia { Id = 186, AnioCarreraId = 17, Nombre = "Comunicación y Expresión Oral y Escrita" };
            var m9 = new Materia { Id = 187, AnioCarreraId = 17, Nombre = "Resolución de Problemas y Creatividad (1º cuatr.)" };
            var m10 = new Materia { Id = 188, AnioCarreraId = 17, Nombre = "Ambiente y Sociedad (2º cuatr.)" };
            var m11 = new Materia { Id = 189, AnioCarreraId = 17, Nombre = "Área Estético-Expresiva I" };
            var m12 = new Materia { Id = 190, AnioCarreraId = 17, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m13 = new Materia { Id = 191, AnioCarreraId = 17, Nombre = "Producción Pedagógica" };

            // Segundo Año
            var m14 = new Materia { Id = 192, AnioCarreraId = 18, Nombre = "Didáctica General" };
            var m15 = new Materia { Id = 193, AnioCarreraId = 18, Nombre = "Filosofía de la Educación (1º cuatr.)" };
            var m16 = new Materia { Id = 194, AnioCarreraId = 18, Nombre = "Conocimiento y Educación (2º cuatr.)" };
            var m17 = new Materia { Id = 195, AnioCarreraId = 18, Nombre = "Movimiento y Cuerpo II" };
            var m18 = new Materia { Id = 196, AnioCarreraId = 18, Nombre = "Taller de Práctica II: Seminario de lo Grupal y los Grupos de Aprendizaje" };
            var m19 = new Materia { Id = 197, AnioCarreraId = 18, Nombre = "Sujeto de la Educación Inicial" };
            var m20 = new Materia { Id = 198, AnioCarreraId = 18, Nombre = "Didáctica de Educación Inicial I" };
            var m21 = new Materia { Id = 199, AnioCarreraId = 18, Nombre = "Matemática y su Didáctica I" };
            var m22 = new Materia { Id = 200, AnioCarreraId = 18, Nombre = "Literatura y su Didáctica" };
            var m23 = new Materia { Id = 201, AnioCarreraId = 18, Nombre = "Ciencias Naturales y su Didáctica" };
            var m24 = new Materia { Id = 202, AnioCarreraId = 18, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m25 = new Materia { Id = 203, AnioCarreraId = 18, Nombre = "Producción Pedagógica" };

            // Tercer Año
            var m26 = new Materia { Id = 204, AnioCarreraId = 19, Nombre = "Tecnologías de la Información y de la Comunicación" };
            var m27 = new Materia { Id = 205, AnioCarreraId = 19, Nombre = "Historia Social de la Educación y Política Educativa Argentina" };
            var m28 = new Materia { Id = 206, AnioCarreraId = 19, Nombre = "Trayecto de Práctica III: Seminario de Instituciones Educativas" };
            var m29 = new Materia { Id = 207, AnioCarreraId = 19, Nombre = "Matemática y su Didáctica II" };
            var m30 = new Materia { Id = 208, AnioCarreraId = 19, Nombre = "Lengua y su Didáctica (1º cuatr.)" };
            var m31 = new Materia { Id = 209, AnioCarreraId = 19, Nombre = "Alfabetización Inicial (2º cuatr.)" };
            var m32 = new Materia { Id = 210, AnioCarreraId = 19, Nombre = "Ciencias Sociales y su Didáctica" };
            var m33 = new Materia { Id = 211, AnioCarreraId = 19, Nombre = "Área Estético-Expresiva II" };
            var m34 = new Materia { Id = 212, AnioCarreraId = 19, Nombre = "Problemáticas Contemporáneas de la Educación Inicial II (1º cuatr.)" };
            var m35 = new Materia { Id = 213, AnioCarreraId = 19, Nombre = "Didáctica de la Educación Inicial II (2º cuatr.)" };
            var m36 = new Materia { Id = 214, AnioCarreraId = 19, Nombre = "Espacios de Definición Institucional (1º cuatr.)" };
            var m37 = new Materia { Id = 215, AnioCarreraId = 19, Nombre = "Espacios de Definición Institucional (2º cuatr.)" };
            var m38 = new Materia { Id = 216, AnioCarreraId = 19, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m39 = new Materia { Id = 217, AnioCarreraId = 19, Nombre = "Producción Pedagógica" };

            // Cuarto Año
            var m40 = new Materia { Id = 218, AnioCarreraId = 20, Nombre = "Ética, Trabajo Docente, Derechos Humanos y Ciudadanos" };
            var m41 = new Materia { Id = 219, AnioCarreraId = 20, Nombre = "Taller de Práctica IV" };
            var m42 = new Materia { Id = 220, AnioCarreraId = 20, Nombre = "Ateneo: (Matemática- Ambiente y Sociedad (Ciencias Naturales- Ciencias Sociales) Lengua y Literatura- Formación Ética y Ciudadana)" };
            var m43 = new Materia { Id = 221, AnioCarreraId = 20, Nombre = "Sexualidad Humana y Educación (1º cuatr.)" };
            var m44 = new Materia { Id = 222, AnioCarreraId = 20, Nombre = "Itinerarios por el Mundo de la Cultura" };
            var m45 = new Materia { Id = 223, AnioCarreraId = 20, Nombre = "Producción Pedagógica" };

            modelBuilder.Entity<Materia>().HasData(
                m1, m2, m3, m4, m5, m6, m7, m8, m9, m10,
                m11, m12, m13, m14, m15, m16, m17, m18,
                m19, m20, m21, m22, m23, m24, m25, m26,
                m27, m28, m29, m30, m31, m32, m33, m34,
                m35, m36, m37, m38, m39, m40, m41, m42,
                m43, m44, m45);

            #endregion

            #region Datos semillas de Materias para Profesorado de Educación Secundaria en Ciencias de la Administración

            // Primer Año
            var mm1 = new Materia { Id = 224, AnioCarreraId = 13, Nombre = "Pedagogía" };
            var mm2 = new Materia { Id = 225, AnioCarreraId = 13, Nombre = "UCCV Sociología" };
            var mm3 = new Materia { Id = 226, AnioCarreraId = 13, Nombre = "Administración General" };
            var mm4 = new Materia { Id = 227, AnioCarreraId = 13, Nombre = "Administración I" };
            var mm5 = new Materia { Id = 228, AnioCarreraId = 13, Nombre = "Sistema de Información Contable I" };
            var mm6 = new Materia { Id = 229, AnioCarreraId = 13, Nombre = "Construcción de Ciudadanía" };
            var mm7 = new Materia { Id = 230, AnioCarreraId = 13, Nombre = "Historia Económica" };
            var mm8 = new Materia { Id = 231, AnioCarreraId = 13, Nombre = "Matemática" };
            var mm9 = new Materia { Id = 232, AnioCarreraId = 13, Nombre = "Práctica Docente I" };

            // Segundo Año
            var mm10 = new Materia { Id = 233, AnioCarreraId = 14, Nombre = "Instituciones Educativas" };
            var mm11 = new Materia { Id = 234, AnioCarreraId = 14, Nombre = "Didáctica y Curriculum" };
            var mm12 = new Materia { Id = 235, AnioCarreraId = 14, Nombre = "Psicología y Educación" };
            var mm13 = new Materia { Id = 236, AnioCarreraId = 14, Nombre = "Administración II" };
            var mm14 = new Materia { Id = 237, AnioCarreraId = 14, Nombre = "Sistema de Información Contable II" };
            var mm15 = new Materia { Id = 238, AnioCarreraId = 14, Nombre = "Derecho I" };
            var mm16 = new Materia { Id = 239, AnioCarreraId = 14, Nombre = "Economía" };
            var mm17 = new Materia { Id = 240, AnioCarreraId = 14, Nombre = "Estadística Aplicada" };
            var mm18 = new Materia { Id = 241, AnioCarreraId = 14, Nombre = "Didáctica de la Administración I" };
            var mm19 = new Materia { Id = 242, AnioCarreraId = 14, Nombre = "Práctica Docencia II" };

            // Tercer Año
            var mm20 = new Materia { Id = 243, AnioCarreraId = 15, Nombre = "Historia y Política de la Educación Argentina" };
            var mm21 = new Materia { Id = 244, AnioCarreraId = 15, Nombre = "Filosofía" };
            var mm22 = new Materia { Id = 245, AnioCarreraId = 15, Nombre = "Metodología de la Investigación" };
            var mm23 = new Materia { Id = 246, AnioCarreraId = 15, Nombre = "Administración III" };
            var mm24 = new Materia { Id = 247, AnioCarreraId = 15, Nombre = "Sistema de Información Contable III" };
            var mm25 = new Materia { Id = 248, AnioCarreraId = 15, Nombre = "Práctica Impositiva y Laboral" };
            var mm26 = new Materia { Id = 249, AnioCarreraId = 15, Nombre = "Derecho II" };
            var mm27 = new Materia { Id = 250, AnioCarreraId = 15, Nombre = "Didáctica de la Administración II" };
            var mm28 = new Materia { Id = 251, AnioCarreraId = 15, Nombre = "Sujetos de la Educación Secundaria" };
            var mm29 = new Materia { Id = 252, AnioCarreraId = 15, Nombre = "Práctica Docente III" };
            var mm30 = new Materia { Id = 253, AnioCarreraId = 15, Nombre = "Producción de los Recursos Didácticos I" };

            // Cuarto Año
            var mm31 = new Materia { Id = 254, AnioCarreraId = 16, Nombre = "Ética y Trabajo Docente" };
            var mm32 = new Materia { Id = 255, AnioCarreraId = 16, Nombre = "Educación Sexual Integral" };
            var mm33 = new Materia { Id = 256, AnioCarreraId = 16, Nombre = "UCCV Comunicación Social" };
            var mm34 = new Materia { Id = 257, AnioCarreraId = 16, Nombre = "Administración IV" };
            var mm35 = new Materia { Id = 258, AnioCarreraId = 16, Nombre = "Gestión Organizacional" };
            var mm36 = new Materia { Id = 259, AnioCarreraId = 16, Nombre = "Matemática Financiera" };
            var mm37 = new Materia { Id = 260, AnioCarreraId = 16, Nombre = "Prácticas de Investigación" };
            var mm38 = new Materia { Id = 261, AnioCarreraId = 16, Nombre = "Práctica Docente IV (Residencia)" };
            var mm39 = new Materia { Id = 262, AnioCarreraId = 16, Nombre = "Producción de los Recursos Didácticos II" };
            var mm40 = new Materia { Id = 263, AnioCarreraId = 16, Nombre = "Unidad de Definición Institucional" };

            modelBuilder.Entity<Materia>().HasData(
                mm1, mm2, mm3, mm4, mm5, mm6, mm7, mm8, mm9, mm10,
                mm11, mm12, mm13, mm14, mm15, mm16, mm17, mm18, mm19, mm20,
                mm21, mm22, mm23, mm24, mm25, mm26, mm27, mm28, mm29, mm30,
                mm31, mm32, mm33, mm34, mm35, mm36, mm37, mm38, mm39, mm40
            );
            #endregion
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
