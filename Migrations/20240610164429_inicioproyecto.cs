using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inscripciones.Migrations
{
    /// <inheritdoc />
    public partial class inicioproyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApellidoNombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AnioCarreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarreraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnioCarreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnioCarreras_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnioCarreraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_AnioCarreras_AnioCarreraId",
                        column: x => x.AnioCarreraId,
                        principalTable: "AnioCarreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleInscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Modalidadcursado = table.Column<int>(type: "int", nullable: false),
                    InscripcionId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleInscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleInscripciones_Inscripciones_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleInscripciones_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "Id", "ApellidoNombre", "Direccion", "Email", "Telefono" },
                values: new object[] { 1, "Rubén Alejandro Ramirez", "Bv Roque Saenz Peña 2942", "aleramirezsj@gmail.com", "15447106" });

            migrationBuilder.InsertData(
                table: "Carreras",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Tecnicatura Superior en Desarrollo de Software" },
                    { 2, "Tecnicatura Superior en Soporte de Infraestructura" },
                    { 3, "Tecnicatura Superior en Gestion de las Organizaciones" },
                    { 4, "Tecnicatura Superior en Enfermeria" },
                    { 5, "Profesorado de Educación Secundaria en Ciencias de la Administración" },
                    { 6, "Profesorado de Educación Inicial" },
                    { 7, "Profesorado de Educación Secundaria en Economía" },
                    { 8, "Profesorado de Educación Tecnológica" },
                    { 9, "Licenciatura en Cooperativismo y Mutualismo" }
                });

            migrationBuilder.InsertData(
                table: "AnioCarreras",
                columns: new[] { "Id", "CarreraId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "1er año" },
                    { 2, 1, "2do año" },
                    { 3, 1, "3er año" },
                    { 4, 2, "1er año" },
                    { 5, 2, "2do año" },
                    { 6, 2, "3er año" },
                    { 7, 3, "1er año" },
                    { 8, 3, "2do año" },
                    { 9, 3, "3er año" },
                    { 10, 4, "1er año" },
                    { 11, 4, "2do año" },
                    { 12, 4, "3er año" },
                    { 13, 5, "1er año" },
                    { 14, 5, "2do año" },
                    { 15, 5, "3er año" },
                    { 16, 5, "4to año" },
                    { 17, 6, "1er año" },
                    { 18, 6, "2do año" },
                    { 19, 6, "3er año" },
                    { 20, 6, "4to año" },
                    { 21, 7, "1er año" },
                    { 22, 7, "2do año" },
                    { 23, 7, "3er año" },
                    { 24, 7, "4to año" },
                    { 25, 8, "1er año" },
                    { 26, 8, "2do año" },
                    { 27, 8, "3er año" },
                    { 28, 8, "4to año" }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "AnioCarreraId", "Nombre" },
                values: new object[,]
                {
                    { 1, 21, "Pedagogía" },
                    { 2, 21, "UCCV Sociología" },
                    { 3, 21, "Administración General" },
                    { 4, 21, "Economía I" },
                    { 5, 21, "Geografía Económica" },
                    { 6, 21, "Historia Económica" },
                    { 7, 21, "Construcción de Ciudadanía" },
                    { 8, 21, "Sistema de Información Contable I" },
                    { 9, 21, "Matemática" },
                    { 10, 21, "Práctica Docente I" },
                    { 11, 22, "Instituciones Educativas" },
                    { 12, 22, "Didáctica y Curriculum" },
                    { 13, 22, "Psicología y Educación" },
                    { 14, 22, "Economía II" },
                    { 15, 22, "Sistema de Información Contable II" },
                    { 16, 22, "Derecho I" },
                    { 17, 22, "Estadística Aplicada" },
                    { 18, 22, "Didáctica de la Economía I" },
                    { 19, 22, "Práctica Docente II" },
                    { 20, 23, "Historia y Política de la Educación Argentina" },
                    { 21, 23, "Filosofía" },
                    { 22, 23, "Metodología de la Investigación" },
                    { 23, 23, "Economía III" },
                    { 24, 23, "Finanzas Públicas" },
                    { 25, 23, "Derecho II" },
                    { 26, 23, "Sujetos de la Educación Secundaria" },
                    { 27, 23, "Práctica Docente III" },
                    { 28, 23, "Producción de los Recursos Didácticos I" },
                    { 29, 24, "Ética y Trabajo Docente" },
                    { 30, 24, "Educación Sexual Integral" },
                    { 31, 24, "UCCV Comunicación Social" },
                    { 32, 24, "Economía Social y Sostenible" },
                    { 33, 24, "Economía Argentina Latinoamericana e Internacional" },
                    { 34, 24, "Prácticas de Investigación" },
                    { 35, 24, "Práctica Docente IV (Residencia)" },
                    { 36, 24, "Producción de los Recursos Didácticos II" },
                    { 37, 24, "Unidad de Definición Institucional" },
                    { 38, 25, "Pedagogía" },
                    { 39, 25, "Movimiento y Cuerpo" },
                    { 40, 25, "Práctica Docente I: Escenarios Educativos" },
                    { 41, 25, "Introducción a la Tecnología" },
                    { 42, 25, "Historia de la Tecnología" },
                    { 43, 25, "Diseño y Producción de la Tecnología I" },
                    { 44, 25, "Matemática" },
                    { 45, 25, "Física" },
                    { 46, 26, "Psicología de la Educación" },
                    { 47, 26, "Didáctica y Curriculum" },
                    { 48, 26, "Instituciones Educativas" },
                    { 49, 26, "Práctica Docente II: La Institución Escolar" },
                    { 50, 26, "Sujetos de la Educación I" },
                    { 51, 26, "Tics para la Enseñanza" },
                    { 52, 26, "Procesos Productivos" },
                    { 53, 26, "Diseño y Producción Tecnológica II" },
                    { 54, 26, "Didáctica Específica I" },
                    { 55, 27, "Filosofía y Educación" },
                    { 56, 27, "Historia Social de la Educación" },
                    { 57, 27, "Metodología de la Investigación" },
                    { 58, 27, "Práctica Docente III: La Clase" },
                    { 59, 27, "Sujetos de la Educación II" },
                    { 60, 27, "Materiales" },
                    { 61, 27, "Química" },
                    { 62, 27, "Procesos de Control" },
                    { 63, 27, "Tecnologías Regionales" },
                    { 64, 27, "Diseño y Producción Tecnológica III" },
                    { 65, 27, "Didáctica Específica II" },
                    { 66, 28, "Ética y Trabajo Docente" },
                    { 67, 28, "Educación Sexual Integral" },
                    { 68, 28, "Unidades de Definición Institucional I" },
                    { 69, 28, "Unidades de Definición Institucional II" },
                    { 70, 28, "Prácticas de Investigación" },
                    { 71, 28, "Práctica Docente IV: El Rol Docente y su Práctica" },
                    { 72, 28, "Biotecnología" },
                    { 73, 28, "Procesos de Comunicación" },
                    { 74, 28, "Problemáticas Sociotécnicas" },
                    { 75, 28, "Diseño y Producción Tecnológica IV" },
                    { 76, 28, "Taller de Producción Didáctica" },
                    { 77, 1, "Comunicación (1° cuat.)" },
                    { 78, 1, "Unidad de definición Institucional (2° cuat.)" },
                    { 79, 1, "Matemática" },
                    { 80, 1, "Inglés Técnico I" },
                    { 81, 1, "Administración" },
                    { 82, 1, "Tecnología de la Información" },
                    { 83, 1, "Lógica y Estructura de Datos" },
                    { 84, 1, "Ingeniería de Software I" },
                    { 85, 1, "Sistemas Operativos" },
                    { 86, 2, "Problemáticas Socio Contemporáneas (1° cuat.)" },
                    { 87, 2, "Unidad de definición Institucional (2° cuat.)" },
                    { 88, 2, "Inglés Técnico II" },
                    { 89, 2, "Innovación y Desarrollo Emprendedor" },
                    { 90, 2, "Estadística" },
                    { 91, 2, "Programación I" },
                    { 92, 2, "Ingeniería de Software II" },
                    { 93, 2, "Base de Datos I" },
                    { 94, 2, "Práctica Profesionalizante I" },
                    { 95, 3, "Ética y Responsabilidad Social" },
                    { 96, 3, "Derecho y Legislación Laboral" },
                    { 97, 3, "Redes y Comunicación" },
                    { 98, 3, "Programación II" },
                    { 99, 3, "Gestión de Proyectos de Software" },
                    { 100, 3, "Base de Datos II" },
                    { 101, 3, "Práctica Profesionalizante II" },
                    { 102, 10, "Comunicación" },
                    { 103, 10, "Unidad de Definición Institucional I" },
                    { 104, 10, "Salud Pública" },
                    { 105, 10, "Biología Humana I" },
                    { 106, 10, "Sujeto, Cultura y Sociedad" },
                    { 107, 10, "Fundamentos del Cuidado en Enfermería" },
                    { 108, 10, "Cuidados de Enfermería en la Comunidad y en la Familia" },
                    { 109, 10, "Práctica Profesionalizante I" },
                    { 110, 11, "Problemáticas Socio Contemporáneas" },
                    { 111, 11, "Unidad de Definición Institucional II" },
                    { 112, 11, "Informática en Salud" },
                    { 113, 11, "Sujeto, Cultura y Sociedad II" },
                    { 114, 11, "Biología Humana II" },
                    { 115, 11, "Bioseguridad y Medio Ambiente en el Trabajo" },
                    { 116, 11, "Farmacología en Enfermería" },
                    { 117, 11, "Cuidados de Enfermería a los Adultos y Adultos Mayores" },
                    { 118, 11, "Práctica Profesionalizante II" },
                    { 119, 12, "Ética y Responsabilidad Social" },
                    { 120, 12, "Derecho y Legislación Laboral" },
                    { 121, 12, "Inglés Técnico" },
                    { 122, 12, "Organización y Gestión en Instituciones de Salud" },
                    { 123, 12, "Investigación en Enfermería" },
                    { 124, 12, "Cuidados de Enfermería en Salud Mental" },
                    { 125, 12, "Cuidados de Enfermería al Niño y al Adolescente" },
                    { 126, 12, "Práctica Profesionalizante III" },
                    { 127, 7, "Comunicación (1º cuatr.)" },
                    { 128, 7, "Unidad de Definición Institucional (2º cuatr.)" },
                    { 129, 7, "Economía" },
                    { 130, 7, "Matemática y Estadística" },
                    { 131, 7, "Contabilidad" },
                    { 132, 7, "Informática" },
                    { 133, 7, "Administración" },
                    { 134, 7, "Gestión de la Producción" },
                    { 135, 7, "Gestión del Talento Humano" },
                    { 136, 8, "Problemáticas Contemporáneas (1º cuatr.)" },
                    { 137, 8, "Unidad de Definición Institucional (2º cuatr.)" },
                    { 138, 8, "Innovación y Desarrollo Emprendedor" },
                    { 139, 8, "Inglés Técnico" },
                    { 140, 8, "Legislación Comercial y Tributaria" },
                    { 141, 8, "Gestión de Comercialización e Investigación Comercial" },
                    { 142, 8, "Gestión de Costos" },
                    { 143, 8, "Gestión Contable" },
                    { 144, 8, "Práctica Profesionalizante I" },
                    { 145, 9, "Gestión de Seguridad, Salud Ocupacional y Medio Ambiente" },
                    { 146, 9, "Ética y Responsabilidad Social" },
                    { 147, 9, "Legislación Laboral" },
                    { 148, 9, "Estrategia Empresarial" },
                    { 149, 9, "Sistema de Información para la Gestión de las Organizaciones" },
                    { 150, 9, "Gestión Financiera" },
                    { 151, 9, "Evaluación y Administración de Proyectos de Inversión" },
                    { 152, 9, "Control de Gestión" },
                    { 153, 9, "Prácticas Profesionalizantes II" },
                    { 154, 4, "Comunicación (1° cuat.)" },
                    { 155, 4, "Unidad de definición Institucional (2° cuat.)" },
                    { 156, 4, "Matemática" },
                    { 157, 4, "Física Aplicada a las Tecnologías de la Información" },
                    { 158, 4, "Administración" },
                    { 159, 4, "Inglés Técnico" },
                    { 160, 4, "Arquitectura de las Computadoras" },
                    { 161, 4, "Lógica y Programación" },
                    { 162, 4, "Infraestructura de Redes I" },
                    { 163, 5, "Problemáticas Socio Contemporáneas (1° cuat.)" },
                    { 164, 5, "Unidad de definición Institucional (2° cuat.)" },
                    { 165, 5, "Innovación y Desarrollo Emprendedor" },
                    { 166, 5, "Estadística" },
                    { 167, 5, "Sistemas Operativos" },
                    { 168, 5, "Algoritmos y Estructuras de Datos" },
                    { 169, 5, "Base de Datos" },
                    { 170, 5, "Infraestructura de Redes II" },
                    { 171, 5, "Práctica Profesionalizante I" },
                    { 172, 6, "Ética y Responsabilidad Social" },
                    { 173, 6, "Derecho y Legislación Laboral" },
                    { 174, 6, "Administración de Base de Datos" },
                    { 175, 6, "Integridad y Migración de Datos" },
                    { 176, 6, "Seguridad de los Sistemas" },
                    { 177, 6, "Administración de Sistemas Operativos y Redes" },
                    { 178, 6, "Práctica Profesionalizante II" },
                    { 179, 17, "Psicología y Educación" },
                    { 180, 17, "Pedagogía" },
                    { 181, 17, "Sociología de la Educación" },
                    { 182, 17, "Historia Argentina y Latinoamericana (1º cuatr.)" },
                    { 183, 17, "Movimiento y Cuerpo I" },
                    { 184, 17, "Taller de Práctica I" },
                    { 185, 17, "Problemáticas Contemporáneas de la Educación Inicial I" },
                    { 186, 17, "Comunicación y Expresión Oral y Escrita" },
                    { 187, 17, "Resolución de Problemas y Creatividad (1º cuatr.)" },
                    { 188, 17, "Ambiente y Sociedad (2º cuatr.)" },
                    { 189, 17, "Área Estético-Expresiva I" },
                    { 190, 17, "Itinerarios por el Mundo de la Cultura" },
                    { 191, 17, "Producción Pedagógica" },
                    { 192, 18, "Didáctica General" },
                    { 193, 18, "Filosofía de la Educación (1º cuatr.)" },
                    { 194, 18, "Conocimiento y Educación (2º cuatr.)" },
                    { 195, 18, "Movimiento y Cuerpo II" },
                    { 196, 18, "Taller de Práctica II: Seminario de lo Grupal y los Grupos de Aprendizaje" },
                    { 197, 18, "Sujeto de la Educación Inicial" },
                    { 198, 18, "Didáctica de Educación Inicial I" },
                    { 199, 18, "Matemática y su Didáctica I" },
                    { 200, 18, "Literatura y su Didáctica" },
                    { 201, 18, "Ciencias Naturales y su Didáctica" },
                    { 202, 18, "Itinerarios por el Mundo de la Cultura" },
                    { 203, 18, "Producción Pedagógica" },
                    { 204, 19, "Tecnologías de la Información y de la Comunicación" },
                    { 205, 19, "Historia Social de la Educación y Política Educativa Argentina" },
                    { 206, 19, "Trayecto de Práctica III: Seminario de Instituciones Educativas" },
                    { 207, 19, "Matemática y su Didáctica II" },
                    { 208, 19, "Lengua y su Didáctica (1º cuatr.)" },
                    { 209, 19, "Alfabetización Inicial (2º cuatr.)" },
                    { 210, 19, "Ciencias Sociales y su Didáctica" },
                    { 211, 19, "Área Estético-Expresiva II" },
                    { 212, 19, "Problemáticas Contemporáneas de la Educación Inicial II (1º cuatr.)" },
                    { 213, 19, "Didáctica de la Educación Inicial II (2º cuatr.)" },
                    { 214, 19, "Espacios de Definición Institucional (1º cuatr.)" },
                    { 215, 19, "Espacios de Definición Institucional (2º cuatr.)" },
                    { 216, 19, "Itinerarios por el Mundo de la Cultura" },
                    { 217, 19, "Producción Pedagógica" },
                    { 218, 20, "Ética, Trabajo Docente, Derechos Humanos y Ciudadanos" },
                    { 219, 20, "Taller de Práctica IV" },
                    { 220, 20, "Ateneo: (Matemática- Ambiente y Sociedad (Ciencias Naturales- Ciencias Sociales) Lengua y Literatura- Formación Ética y Ciudadana)" },
                    { 221, 20, "Sexualidad Humana y Educación (1º cuatr.)" },
                    { 222, 20, "Itinerarios por el Mundo de la Cultura" },
                    { 223, 20, "Producción Pedagógica" },
                    { 224, 13, "Pedagogía" },
                    { 225, 13, "UCCV Sociología" },
                    { 226, 13, "Administración General" },
                    { 227, 13, "Administración I" },
                    { 228, 13, "Sistema de Información Contable I" },
                    { 229, 13, "Construcción de Ciudadanía" },
                    { 230, 13, "Historia Económica" },
                    { 231, 13, "Matemática" },
                    { 232, 13, "Práctica Docente I" },
                    { 233, 14, "Instituciones Educativas" },
                    { 234, 14, "Didáctica y Curriculum" },
                    { 235, 14, "Psicología y Educación" },
                    { 236, 14, "Administración II" },
                    { 237, 14, "Sistema de Información Contable II" },
                    { 238, 14, "Derecho I" },
                    { 239, 14, "Economía" },
                    { 240, 14, "Estadística Aplicada" },
                    { 241, 14, "Didáctica de la Administración I" },
                    { 242, 14, "Práctica Docencia II" },
                    { 243, 15, "Historia y Política de la Educación Argentina" },
                    { 244, 15, "Filosofía" },
                    { 245, 15, "Metodología de la Investigación" },
                    { 246, 15, "Administración III" },
                    { 247, 15, "Sistema de Información Contable III" },
                    { 248, 15, "Práctica Impositiva y Laboral" },
                    { 249, 15, "Derecho II" },
                    { 250, 15, "Didáctica de la Administración II" },
                    { 251, 15, "Sujetos de la Educación Secundaria" },
                    { 252, 15, "Práctica Docente III" },
                    { 253, 15, "Producción de los Recursos Didácticos I" },
                    { 254, 16, "Ética y Trabajo Docente" },
                    { 255, 16, "Educación Sexual Integral" },
                    { 256, 16, "UCCV Comunicación Social" },
                    { 257, 16, "Administración IV" },
                    { 258, 16, "Gestión Organizacional" },
                    { 259, 16, "Matemática Financiera" },
                    { 260, 16, "Prácticas de Investigación" },
                    { 261, 16, "Práctica Docente IV (Residencia)" },
                    { 262, 16, "Producción de los Recursos Didácticos II" },
                    { 263, 16, "Unidad de Definición Institucional" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnioCarreras_CarreraId",
                table: "AnioCarreras",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleInscripciones_InscripcionId",
                table: "DetalleInscripciones",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleInscripciones_MateriaId",
                table: "DetalleInscripciones",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_AlumnoId",
                table: "Inscripciones",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_CarreraId",
                table: "Inscripciones",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_AnioCarreraId",
                table: "Materias",
                column: "AnioCarreraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleInscripciones");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "AnioCarreras");

            migrationBuilder.DropTable(
                name: "Carreras");
        }
    }
}
