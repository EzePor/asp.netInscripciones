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
                name: "alumnos",
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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sigla = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carreras", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cicloslectivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cicloslectivos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "docentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "horas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsRecreo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "turnosexamenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turnosexamenes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "anioscarreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anioscarreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_anioscarreras_carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inscriptoscarreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AlumnoId = table.Column<int>(type: "int", nullable: true),
                    CarreraId = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscriptoscarreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inscriptoscarreras_alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "alumnos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inscriptoscarreras_carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "carreras",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    CicloLectivoId = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inscripciones_alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inscripciones_carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inscripciones_cicloslectivos_CicloLectivoId",
                        column: x => x.CicloLectivoId,
                        principalTable: "cicloslectivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: true),
                    DocenteId = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "alumnos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_usuarios_docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "docentes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnioCarreraId = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_materias_anioscarreras_AnioCarreraId",
                        column: x => x.AnioCarreraId,
                        principalTable: "anioscarreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detallesinscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModalidadCursado = table.Column<int>(type: "int", nullable: false),
                    InscripcionId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallesinscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallesinscripciones_inscripciones_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "inscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallesinscripciones_materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MateriaId = table.Column<int>(type: "int", nullable: true),
                    CantidadHoras = table.Column<int>(type: "int", nullable: false),
                    CicloLectivoId = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_horarios_cicloslectivos_CicloLectivoId",
                        column: x => x.CicloLectivoId,
                        principalTable: "cicloslectivos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_horarios_materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "materias",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mesasexamenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Llamado1 = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Llamado2 = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TurnoExamenId = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesasexamenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mesasexamenes_materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mesasexamenes_turnosexamenes_TurnoExamenId",
                        column: x => x.TurnoExamenId,
                        principalTable: "turnosexamenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalleshorarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HorarioId = table.Column<int>(type: "int", nullable: true),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    HoraId = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleshorarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleshorarios_horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "horarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_detalleshorarios_horas_HoraId",
                        column: x => x.HoraId,
                        principalTable: "horas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "integranteshorarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HorarioId = table.Column<int>(type: "int", nullable: true),
                    DocenteId = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_integranteshorarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_integranteshorarios_docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "docentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_integranteshorarios_horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "horarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detallesmesasexamenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MesaExamenId = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    TipoIntegrante = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallesmesasexamenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallesmesasexamenes_docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallesmesasexamenes_mesasexamenes_MesaExamenId",
                        column: x => x.MesaExamenId,
                        principalTable: "mesasexamenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "alumnos",
                columns: new[] { "Id", "ApellidoNombre", "Direccion", "Eliminado", "Email", "Telefono" },
                values: new object[,]
                {
                    { 1, "Rubén Alejandro Ramirez", "Bv Roque Saenz Peña 2942", false, "aleramirezsj@gmail.com", "15447106" },
                    { 2, "Porchietto Ezequiel Gustavo", "Juan Mantovani 1877", false, "ezeporche@gmail.com", "431264" }
                });

            migrationBuilder.InsertData(
                table: "carreras",
                columns: new[] { "Id", "Eliminado", "Nombre", "Sigla" },
                values: new object[,]
                {
                    { 1, false, "Tecnicatura Superior en Desarrollo de Software", "TSDS" },
                    { 2, false, "Tecnicatura Superior en Soporte de Infraestructura", "TSSITI" },
                    { 3, false, "Tecnicatura Superior en Gestion de las Organizaciones", "TSGO" },
                    { 4, false, "Tecnicatura Superior en Enfermeria", "TSE" },
                    { 5, false, "Profesorado de Educación Secundaria en Ciencias de la Administración", "PEA" },
                    { 6, false, "Profesorado de Educación Inicial", "PEI" },
                    { 7, false, "Profesorado de Educación Secundaria en Economía", "PEE" },
                    { 8, false, "Profesorado de Educación Tecnológica", "PET" },
                    { 9, false, "Licenciatura en Cooperativismo y Mutualismo", "LCM" }
                });

            migrationBuilder.InsertData(
                table: "cicloslectivos",
                columns: new[] { "Id", "Eliminado", "Nombre" },
                values: new object[] { 1, false, "2024" });

            migrationBuilder.InsertData(
                table: "docentes",
                columns: new[] { "Id", "Eliminado", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Adamo, G." },
                    { 2, false, "Aimar, M.A." },
                    { 3, false, "Albaristo, Stef." },
                    { 4, false, "Alesso, A." },
                    { 5, false, "Alesso, M." },
                    { 6, false, "Arnolfo, P." },
                    { 7, false, "Bazán, D." },
                    { 8, false, "Blanche, C." },
                    { 9, false, "Bogni, J." },
                    { 10, false, "Brondino, D." },
                    { 11, false, "Brussa, G." },
                    { 12, false, "Buceta, MB." },
                    { 13, false, "Bueno, M.F." },
                    { 14, false, "Cainero, G." },
                    { 15, false, "Calvo, M." },
                    { 16, false, "Cavallini, J." },
                    { 17, false, "Chauderón, L." },
                    { 18, false, "Chelini, V." },
                    { 19, false, "Corradi, R." },
                    { 20, false, "Dalesio, C." },
                    { 21, false, "Degiorgio, O." },
                    { 22, false, "Della Rosa, M." },
                    { 23, false, "Dellaferrera, C." },
                    { 24, false, "Doglioli, M." },
                    { 25, false, "Duran, C." },
                    { 26, false, "Epes, B." },
                    { 27, false, "Espru, F." },
                    { 28, false, "Ferreyra, M." },
                    { 29, false, "Ferrero, M." },
                    { 30, false, "Ferr, N." },
                    { 31, false, "Gaido, J.P." },
                    { 32, false, "Galmes, M." },
                    { 33, false, "Genero, A." },
                    { 34, false, "Gongora, L." },
                    { 35, false, "Gomez, V." },
                    { 36, false, "Gretter, M.C." },
                    { 37, false, "Grosso, S." },
                    { 38, false, "Imhof, R." },
                    { 39, false, "Imperiale, M." },
                    { 40, false, "Lodi, L." },
                    { 41, false, "Lovino, F." },
                    { 42, false, "Mancilla, J." },
                    { 43, false, "Manattini, S." },
                    { 44, false, "Marenoni, A." },
                    { 45, false, "Martínez, G." },
                    { 46, false, "Mendoza, M." },
                    { 47, false, "Miñoz, A." },
                    { 48, false, "Molina, T." },
                    { 49, false, "Monzón, M.I." },
                    { 50, false, "Nasimbera, R." },
                    { 51, false, "Ortiz, L." },
                    { 52, false, "Paredes, M." },
                    { 53, false, "Pedrazzoli, F." },
                    { 54, false, "Pereyra, S." },
                    { 55, false, "Peressin, S." },
                    { 56, false, "Prida, C." },
                    { 57, false, "Puccio, D." },
                    { 58, false, "Quaglia, E." },
                    { 59, false, "Ramirez, R.A." },
                    { 60, false, "Renteria, D." },
                    { 61, false, "Rodriguez Quain, J." },
                    { 62, false, "Rosso, E." },
                    { 63, false, "Sanchez, R." },
                    { 64, false, "Sandoval, P." },
                    { 65, false, "Sancho, I." },
                    { 66, false, "Sara, J." },
                    { 67, false, "Strada, J." },
                    { 68, false, "Tovar, C." },
                    { 69, false, "Tregnaghi, C." },
                    { 70, false, "Tschopp, M.R." },
                    { 71, false, "Verzzali, A." },
                    { 72, false, "Vigniatti, E." },
                    { 73, false, "Villa, M.F." },
                    { 74, false, "Ruiz, A." },
                    { 75, false, "Sager, L." }
                });

            migrationBuilder.InsertData(
                table: "horas",
                columns: new[] { "Id", "Eliminado", "EsRecreo", "Nombre" },
                values: new object[,]
                {
                    { 1, false, false, "08:00 - 08:40" },
                    { 2, false, false, "08:40 - 09:20" },
                    { 3, false, false, "09:20 - 10:00" },
                    { 4, false, false, "10:00 - 10:40" },
                    { 5, false, true, "10:40 - 10:50" },
                    { 6, false, false, "10:50 - 11:30" },
                    { 7, false, false, "11:30 - 12:10" },
                    { 8, false, false, "12:10 - 12:50" },
                    { 9, false, false, "12:50 - 13:30" },
                    { 10, false, false, "13:10 - 13:50" },
                    { 11, false, false, "13:50 - 14:30" },
                    { 12, false, false, "14:30 - 15:10" },
                    { 13, false, false, "15:10 - 15:50" },
                    { 14, false, true, "15:50 - 16:00" },
                    { 15, false, false, "16:00 - 16:40" },
                    { 16, false, false, "16:40 - 17:20" },
                    { 17, false, false, "17:20 - 18:00" },
                    { 18, false, false, "18:00 - 18:40" },
                    { 19, false, false, "18:40 - 19:20" },
                    { 20, false, false, "19:20 - 20:00" },
                    { 21, false, true, "19:30 - 19:40" },
                    { 22, false, false, "19:40 - 20:20" },
                    { 23, false, false, "20:20 - 21:00" },
                    { 24, false, false, "21:00 - 21:40" }
                });

            migrationBuilder.InsertData(
                table: "turnosexamenes",
                columns: new[] { "Id", "Eliminado", "Nombre" },
                values: new object[] { 1, false, "Julio/Agosto 2024" });

            migrationBuilder.InsertData(
                table: "anioscarreras",
                columns: new[] { "Id", "CarreraId", "Eliminado", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, false, "1er año" },
                    { 2, 1, false, "2do año" },
                    { 3, 1, false, "3er año" },
                    { 4, 2, false, "1er año" },
                    { 5, 2, false, "2do año" },
                    { 6, 2, false, "3er año" },
                    { 7, 3, false, "1er año" },
                    { 8, 3, false, "2do año" },
                    { 9, 3, false, "3er año" },
                    { 10, 4, false, "1er año" },
                    { 11, 4, false, "2do año" },
                    { 12, 4, false, "3er año" },
                    { 13, 5, false, "1er año" },
                    { 14, 5, false, "2do año" },
                    { 15, 5, false, "3er año" },
                    { 16, 5, false, "4to año" },
                    { 17, 6, false, "1er año" },
                    { 18, 6, false, "2do año" },
                    { 19, 6, false, "3er año" },
                    { 20, 6, false, "4to año" },
                    { 21, 7, false, "1er año" },
                    { 22, 7, false, "2do año" },
                    { 23, 7, false, "3er año" },
                    { 24, 7, false, "4to año" },
                    { 25, 8, false, "1er año" },
                    { 26, 8, false, "2do año" },
                    { 27, 8, false, "3er año" },
                    { 28, 8, false, "4to año" }
                });

            migrationBuilder.InsertData(
                table: "inscripciones",
                columns: new[] { "Id", "AlumnoId", "CarreraId", "CicloLectivoId", "Eliminado", "Fecha" },
                values: new object[] { 1, 1, 1, 1, false, new DateTime(2024, 8, 15, 11, 32, 48, 558, DateTimeKind.Local).AddTicks(9155) });

            migrationBuilder.InsertData(
                table: "inscriptoscarreras",
                columns: new[] { "Id", "AlumnoId", "CarreraId", "Eliminado" },
                values: new object[] { 1, 1, 1, false });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "AlumnoId", "DocenteId", "Eliminado", "Email", "TipoUsuario", "User" },
                values: new object[] { 1, null, 1, false, "admin@gmail.com", 2, "admin" });

            migrationBuilder.InsertData(
                table: "materias",
                columns: new[] { "Id", "AnioCarreraId", "Eliminado", "Nombre" },
                values: new object[,]
                {
                    { 1, 21, false, "Pedagogía" },
                    { 2, 21, false, "UCCV Sociología" },
                    { 3, 21, false, "Administración General" },
                    { 4, 21, false, "Economía I" },
                    { 5, 21, false, "Geografía Económica" },
                    { 6, 21, false, "Historia Económica" },
                    { 7, 21, false, "Construcción de Ciudadanía" },
                    { 8, 21, false, "Sistema de Información Contable I" },
                    { 9, 21, false, "Matemática" },
                    { 10, 21, false, "Práctica Docente I" },
                    { 11, 22, false, "Instituciones Educativas" },
                    { 12, 22, false, "Didáctica y Curriculum" },
                    { 13, 22, false, "Psicología y Educación" },
                    { 14, 22, false, "Economía II" },
                    { 15, 22, false, "Sistema de Información Contable II" },
                    { 16, 22, false, "Derecho I" },
                    { 17, 22, false, "Estadística Aplicada" },
                    { 18, 22, false, "Didáctica de la Economía I" },
                    { 19, 22, false, "Práctica Docente II" },
                    { 20, 23, false, "Historia y Política de la Educación Argentina" },
                    { 21, 23, false, "Filosofía" },
                    { 22, 23, false, "Metodología de la Investigación" },
                    { 23, 23, false, "Economía III" },
                    { 24, 23, false, "Finanzas Públicas" },
                    { 25, 23, false, "Derecho II" },
                    { 26, 23, false, "Sujetos de la Educación Secundaria" },
                    { 27, 23, false, "Práctica Docente III" },
                    { 28, 23, false, "Producción de los Recursos Didácticos I" },
                    { 29, 24, false, "Ética y Trabajo Docente" },
                    { 30, 24, false, "Educación Sexual Integral" },
                    { 31, 24, false, "UCCV Comunicación Social" },
                    { 32, 24, false, "Economía Social y Sostenible" },
                    { 33, 24, false, "Economía Argentina Latinoamericana e Internacional" },
                    { 34, 24, false, "Prácticas de Investigación" },
                    { 35, 24, false, "Práctica Docente IV (Residencia)" },
                    { 36, 24, false, "Producción de los Recursos Didácticos II" },
                    { 37, 24, false, "Unidad de Definición Institucional" },
                    { 38, 25, false, "Pedagogía" },
                    { 39, 25, false, "Movimiento y Cuerpo" },
                    { 40, 25, false, "Práctica Docente I: Escenarios Educativos" },
                    { 41, 25, false, "Introducción a la Tecnología" },
                    { 42, 25, false, "Historia de la Tecnología" },
                    { 43, 25, false, "Diseño y Producción de la Tecnología I" },
                    { 44, 25, false, "Matemática" },
                    { 45, 25, false, "Física" },
                    { 46, 26, false, "Psicología de la Educación" },
                    { 47, 26, false, "Didáctica y Curriculum" },
                    { 48, 26, false, "Instituciones Educativas" },
                    { 49, 26, false, "Práctica Docente II: La Institución Escolar" },
                    { 50, 26, false, "Sujetos de la Educación I" },
                    { 51, 26, false, "Tics para la Enseñanza" },
                    { 52, 26, false, "Procesos Productivos" },
                    { 53, 26, false, "Diseño y Producción Tecnológica II" },
                    { 54, 26, false, "Didáctica Específica I" },
                    { 55, 27, false, "Filosofía y Educación" },
                    { 56, 27, false, "Historia Social de la Educación" },
                    { 57, 27, false, "Metodología de la Investigación" },
                    { 58, 27, false, "Práctica Docente III: La Clase" },
                    { 59, 27, false, "Sujetos de la Educación II" },
                    { 60, 27, false, "Materiales" },
                    { 61, 27, false, "Química" },
                    { 62, 27, false, "Procesos de Control" },
                    { 63, 27, false, "Tecnologías Regionales" },
                    { 64, 27, false, "Diseño y Producción Tecnológica III" },
                    { 65, 27, false, "Didáctica Específica II" },
                    { 66, 28, false, "Ética y Trabajo Docente" },
                    { 67, 28, false, "Educación Sexual Integral" },
                    { 68, 28, false, "Unidades de Definición Institucional I" },
                    { 69, 28, false, "Unidades de Definición Institucional II" },
                    { 70, 28, false, "Prácticas de Investigación" },
                    { 71, 28, false, "Práctica Docente IV: El Rol Docente y su Práctica" },
                    { 72, 28, false, "Biotecnología" },
                    { 73, 28, false, "Procesos de Comunicación" },
                    { 74, 28, false, "Problemáticas Sociotécnicas" },
                    { 75, 28, false, "Diseño y Producción Tecnológica IV" },
                    { 76, 28, false, "Taller de Producción Didáctica" },
                    { 77, 1, false, "Comunicación (1° cuat.)" },
                    { 78, 1, false, "Unidad de definición Institucional (2° cuat.)" },
                    { 79, 1, false, "Matemática" },
                    { 80, 1, false, "Inglés Técnico I" },
                    { 81, 1, false, "Administración" },
                    { 82, 1, false, "Tecnología de la Información" },
                    { 83, 1, false, "Lógica y Estructura de Datos" },
                    { 84, 1, false, "Ingeniería de Software I" },
                    { 85, 1, false, "Sistemas Operativos" },
                    { 86, 2, false, "Problemáticas Socio Contemporáneas (1° cuat.)" },
                    { 87, 2, false, "Unidad de definición Institucional (2° cuat.)" },
                    { 88, 2, false, "Inglés Técnico II" },
                    { 89, 2, false, "Innovación y Desarrollo Emprendedor" },
                    { 90, 2, false, "Estadística" },
                    { 91, 2, false, "Programación I" },
                    { 92, 2, false, "Ingeniería de Software II" },
                    { 93, 2, false, "Base de Datos I" },
                    { 94, 2, false, "Práctica Profesionalizante I" },
                    { 95, 3, false, "Ética y Responsabilidad Social" },
                    { 96, 3, false, "Derecho y Legislación Laboral" },
                    { 97, 3, false, "Redes y Comunicación" },
                    { 98, 3, false, "Programación II" },
                    { 99, 3, false, "Gestión de Proyectos de Software" },
                    { 100, 3, false, "Base de Datos II" },
                    { 101, 3, false, "Práctica Profesionalizante II" },
                    { 102, 10, false, "Comunicación" },
                    { 103, 10, false, "Unidad de Definición Institucional I" },
                    { 104, 10, false, "Salud Pública" },
                    { 105, 10, false, "Biología Humana I" },
                    { 106, 10, false, "Sujeto, Cultura y Sociedad" },
                    { 107, 10, false, "Fundamentos del Cuidado en Enfermería" },
                    { 108, 10, false, "Cuidados de Enfermería en la Comunidad y en la Familia" },
                    { 109, 10, false, "Práctica Profesionalizante I" },
                    { 110, 11, false, "Problemáticas Socio Contemporáneas" },
                    { 111, 11, false, "Unidad de Definición Institucional II" },
                    { 112, 11, false, "Informática en Salud" },
                    { 113, 11, false, "Sujeto, Cultura y Sociedad II" },
                    { 114, 11, false, "Biología Humana II" },
                    { 115, 11, false, "Bioseguridad y Medio Ambiente en el Trabajo" },
                    { 116, 11, false, "Farmacología en Enfermería" },
                    { 117, 11, false, "Cuidados de Enfermería a los Adultos y Adultos Mayores" },
                    { 118, 11, false, "Práctica Profesionalizante II" },
                    { 119, 12, false, "Ética y Responsabilidad Social" },
                    { 120, 12, false, "Derecho y Legislación Laboral" },
                    { 121, 12, false, "Inglés Técnico" },
                    { 122, 12, false, "Organización y Gestión en Instituciones de Salud" },
                    { 123, 12, false, "Investigación en Enfermería" },
                    { 124, 12, false, "Cuidados de Enfermería en Salud Mental" },
                    { 125, 12, false, "Cuidados de Enfermería al Niño y al Adolescente" },
                    { 126, 12, false, "Práctica Profesionalizante III" },
                    { 127, 7, false, "Comunicación (1º cuatr.)" },
                    { 128, 7, false, "Unidad de Definición Institucional (2º cuatr.)" },
                    { 129, 7, false, "Economía" },
                    { 130, 7, false, "Matemática y Estadística" },
                    { 131, 7, false, "Contabilidad" },
                    { 132, 7, false, "Informática" },
                    { 133, 7, false, "Administración" },
                    { 134, 7, false, "Gestión de la Producción" },
                    { 135, 7, false, "Gestión del Talento Humano" },
                    { 136, 8, false, "Problemáticas Contemporáneas (1º cuatr.)" },
                    { 137, 8, false, "Unidad de Definición Institucional (2º cuatr.)" },
                    { 138, 8, false, "Innovación y Desarrollo Emprendedor" },
                    { 139, 8, false, "Inglés Técnico" },
                    { 140, 8, false, "Legislación Comercial y Tributaria" },
                    { 141, 8, false, "Gestión de Comercialización e Investigación Comercial" },
                    { 142, 8, false, "Gestión de Costos" },
                    { 143, 8, false, "Gestión Contable" },
                    { 144, 8, false, "Práctica Profesionalizante I" },
                    { 145, 9, false, "Gestión de Seguridad, Salud Ocupacional y Medio Ambiente" },
                    { 146, 9, false, "Ética y Responsabilidad Social" },
                    { 147, 9, false, "Legislación Laboral" },
                    { 148, 9, false, "Estrategia Empresarial" },
                    { 149, 9, false, "Sistema de Información para la Gestión de las Organizaciones" },
                    { 150, 9, false, "Gestión Financiera" },
                    { 151, 9, false, "Evaluación y Administración de Proyectos de Inversión" },
                    { 152, 9, false, "Control de Gestión" },
                    { 153, 9, false, "Prácticas Profesionalizantes II" },
                    { 154, 4, false, "Comunicación (1° cuat.)" },
                    { 155, 4, false, "Unidad de definición Institucional (2° cuat.)" },
                    { 156, 4, false, "Matemática" },
                    { 157, 4, false, "Física Aplicada a las Tecnologías de la Información" },
                    { 158, 4, false, "Administración" },
                    { 159, 4, false, "Inglés Técnico" },
                    { 160, 4, false, "Arquitectura de las Computadoras" },
                    { 161, 4, false, "Lógica y Programación" },
                    { 162, 4, false, "Infraestructura de Redes I" },
                    { 163, 5, false, "Problemáticas Socio Contemporáneas (1° cuat.)" },
                    { 164, 5, false, "Unidad de definición Institucional (2° cuat.)" },
                    { 165, 5, false, "Innovación y Desarrollo Emprendedor" },
                    { 166, 5, false, "Estadística" },
                    { 167, 5, false, "Sistemas Operativos" },
                    { 168, 5, false, "Algoritmos y Estructuras de Datos" },
                    { 169, 5, false, "Base de Datos" },
                    { 170, 5, false, "Infraestructura de Redes II" },
                    { 171, 5, false, "Práctica Profesionalizante I" },
                    { 172, 6, false, "Ética y Responsabilidad Social" },
                    { 173, 6, false, "Derecho y Legislación Laboral" },
                    { 174, 6, false, "Administración de Base de Datos" },
                    { 175, 6, false, "Integridad y Migración de Datos" },
                    { 176, 6, false, "Seguridad de los Sistemas" },
                    { 177, 6, false, "Administración de Sistemas Operativos y Redes" },
                    { 178, 6, false, "Práctica Profesionalizante II" },
                    { 179, 17, false, "Psicología y Educación" },
                    { 180, 17, false, "Pedagogía" },
                    { 181, 17, false, "Sociología de la Educación" },
                    { 182, 17, false, "Historia Argentina y Latinoamericana (1º cuatr.)" },
                    { 183, 17, false, "Movimiento y Cuerpo I" },
                    { 184, 17, false, "Taller de Práctica I" },
                    { 185, 17, false, "Problemáticas Contemporáneas de la Educación Inicial I" },
                    { 186, 17, false, "Comunicación y Expresión Oral y Escrita" },
                    { 187, 17, false, "Resolución de Problemas y Creatividad (1º cuatr.)" },
                    { 188, 17, false, "Ambiente y Sociedad (2º cuatr.)" },
                    { 189, 17, false, "Área Estético-Expresiva I" },
                    { 190, 17, false, "Itinerarios por el Mundo de la Cultura" },
                    { 191, 17, false, "Producción Pedagógica" },
                    { 192, 18, false, "Didáctica General" },
                    { 193, 18, false, "Filosofía de la Educación (1º cuatr.)" },
                    { 194, 18, false, "Conocimiento y Educación (2º cuatr.)" },
                    { 195, 18, false, "Movimiento y Cuerpo II" },
                    { 196, 18, false, "Taller de Práctica II: Seminario de lo Grupal y los Grupos de Aprendizaje" },
                    { 197, 18, false, "Sujeto de la Educación Inicial" },
                    { 198, 18, false, "Didáctica de Educación Inicial I" },
                    { 199, 18, false, "Matemática y su Didáctica I" },
                    { 200, 18, false, "Literatura y su Didáctica" },
                    { 201, 18, false, "Ciencias Naturales y su Didáctica" },
                    { 202, 18, false, "Itinerarios por el Mundo de la Cultura" },
                    { 203, 18, false, "Producción Pedagógica" },
                    { 204, 19, false, "Tecnologías de la Información y de la Comunicación" },
                    { 205, 19, false, "Historia Social de la Educación y Política Educativa Argentina" },
                    { 206, 19, false, "Trayecto de Práctica III: Seminario de Instituciones Educativas" },
                    { 207, 19, false, "Matemática y su Didáctica II" },
                    { 208, 19, false, "Lengua y su Didáctica (1º cuatr.)" },
                    { 209, 19, false, "Alfabetización Inicial (2º cuatr.)" },
                    { 210, 19, false, "Ciencias Sociales y su Didáctica" },
                    { 211, 19, false, "Área Estético-Expresiva II" },
                    { 212, 19, false, "Problemáticas Contemporáneas de la Educación Inicial II (1º cuatr.)" },
                    { 213, 19, false, "Didáctica de la Educación Inicial II (2º cuatr.)" },
                    { 214, 19, false, "Espacios de Definición Institucional (1º cuatr.)" },
                    { 215, 19, false, "Espacios de Definición Institucional (2º cuatr.)" },
                    { 216, 19, false, "Itinerarios por el Mundo de la Cultura" },
                    { 217, 19, false, "Producción Pedagógica" },
                    { 218, 20, false, "Ética, Trabajo Docente, Derechos Humanos y Ciudadanos" },
                    { 219, 20, false, "Taller de Práctica IV" },
                    { 220, 20, false, "Ateneo: (Matemática- Ambiente y Sociedad (Ciencias Naturales- Ciencias Sociales) Lengua y Literatura- Formación Ética y Ciudadana)" },
                    { 221, 20, false, "Sexualidad Humana y Educación (1º cuatr.)" },
                    { 222, 20, false, "Itinerarios por el Mundo de la Cultura" },
                    { 223, 20, false, "Producción Pedagógica" },
                    { 224, 13, false, "Pedagogía" },
                    { 225, 13, false, "UCCV Sociología" },
                    { 226, 13, false, "Administración General" },
                    { 227, 13, false, "Administración I" },
                    { 228, 13, false, "Sistema de Información Contable I" },
                    { 229, 13, false, "Construcción de Ciudadanía" },
                    { 230, 13, false, "Historia Económica" },
                    { 231, 13, false, "Matemática" },
                    { 232, 13, false, "Práctica Docente I" },
                    { 233, 14, false, "Instituciones Educativas" },
                    { 234, 14, false, "Didáctica y Curriculum" },
                    { 235, 14, false, "Psicología y Educación" },
                    { 236, 14, false, "Administración II" },
                    { 237, 14, false, "Sistema de Información Contable II" },
                    { 238, 14, false, "Derecho I" },
                    { 239, 14, false, "Economía" },
                    { 240, 14, false, "Estadística Aplicada" },
                    { 241, 14, false, "Didáctica de la Administración I" },
                    { 242, 14, false, "Práctica Docencia II" },
                    { 243, 15, false, "Historia y Política de la Educación Argentina" },
                    { 244, 15, false, "Filosofía" },
                    { 245, 15, false, "Metodología de la Investigación" },
                    { 246, 15, false, "Administración III" },
                    { 247, 15, false, "Sistema de Información Contable III" },
                    { 248, 15, false, "Práctica Impositiva y Laboral" },
                    { 249, 15, false, "Derecho II" },
                    { 250, 15, false, "Didáctica de la Administración II" },
                    { 251, 15, false, "Sujetos de la Educación Secundaria" },
                    { 252, 15, false, "Práctica Docente III" },
                    { 253, 15, false, "Producción de los Recursos Didácticos I" },
                    { 254, 16, false, "Ética y Trabajo Docente" },
                    { 255, 16, false, "Educación Sexual Integral" },
                    { 256, 16, false, "UCCV Comunicación Social" },
                    { 257, 16, false, "Administración IV" },
                    { 258, 16, false, "Gestión Organizacional" },
                    { 259, 16, false, "Matemática Financiera" },
                    { 260, 16, false, "Prácticas de Investigación" },
                    { 261, 16, false, "Práctica Docente IV (Residencia)" },
                    { 262, 16, false, "Producción de los Recursos Didácticos II" },
                    { 263, 16, false, "Unidad de Definición Institucional" },
                    { 264, 1, false, "Recreo" },
                    { 265, 2, false, "Recreo" },
                    { 266, 3, false, "Recreo" },
                    { 267, 4, false, "Recreo" },
                    { 268, 5, false, "Recreo" },
                    { 269, 6, false, "Recreo" },
                    { 270, 7, false, "Recreo" },
                    { 271, 8, false, "Recreo" },
                    { 272, 9, false, "Recreo" },
                    { 273, 10, false, "Recreo" },
                    { 274, 11, false, "Recreo" },
                    { 275, 12, false, "Recreo" },
                    { 276, 13, false, "Recreo" },
                    { 277, 14, false, "Recreo" },
                    { 278, 15, false, "Recreo" },
                    { 279, 16, false, "Recreo" },
                    { 280, 17, false, "Recreo" },
                    { 281, 18, false, "Recreo" },
                    { 282, 19, false, "Recreo" },
                    { 283, 20, false, "Recreo" },
                    { 284, 21, false, "Recreo" },
                    { 285, 22, false, "Recreo" },
                    { 286, 23, false, "Recreo" },
                    { 287, 24, false, "Recreo" },
                    { 288, 25, false, "Recreo" },
                    { 289, 26, false, "Recreo" },
                    { 290, 27, false, "Recreo" },
                    { 291, 28, false, "Recreo" }
                });

            migrationBuilder.InsertData(
                table: "detallesinscripciones",
                columns: new[] { "Id", "Eliminado", "InscripcionId", "MateriaId", "ModalidadCursado" },
                values: new object[] { 1, false, 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "horarios",
                columns: new[] { "Id", "CantidadHoras", "CicloLectivoId", "Eliminado", "MateriaId" },
                values: new object[] { 1, 4, 1, false, 1 });

            migrationBuilder.InsertData(
                table: "mesasexamenes",
                columns: new[] { "Id", "Eliminado", "Horario", "Llamado1", "Llamado2", "MateriaId", "TurnoExamenId" },
                values: new object[,]
                {
                    { 1, false, "17 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 1 },
                    { 2, false, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 1 },
                    { 3, false, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 1 },
                    { 4, false, "17 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 1 },
                    { 5, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1 },
                    { 6, false, "18 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 1 },
                    { 7, false, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 1 },
                    { 8, false, "17 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 1 },
                    { 9, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 1 },
                    { 10, false, "18 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 62, 1 },
                    { 11, false, "17 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 1 },
                    { 12, false, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 1 },
                    { 13, false, "17 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 1 },
                    { 14, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 1 },
                    { 15, false, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 1 },
                    { 16, false, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 1 },
                    { 17, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 1 },
                    { 18, false, "17 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 1 },
                    { 19, false, "13 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 1 },
                    { 20, false, "13 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 1 },
                    { 21, false, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 1 },
                    { 22, false, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 1 },
                    { 23, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 1 },
                    { 24, false, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 1 },
                    { 25, false, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 1 },
                    { 26, false, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 1 },
                    { 27, false, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 1 },
                    { 28, false, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 1 },
                    { 29, false, "17 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 1 },
                    { 30, false, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 1 },
                    { 31, false, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 1 },
                    { 32, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 1 },
                    { 33, false, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1 },
                    { 34, false, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 1 },
                    { 35, false, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 1 },
                    { 36, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 1 },
                    { 37, false, "18 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 1 },
                    { 38, false, "18 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 161, 1 },
                    { 39, false, "18 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 158, 1 },
                    { 40, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 156, 1 },
                    { 41, false, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 154, 1 },
                    { 42, false, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 155, 1 },
                    { 43, false, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 1 },
                    { 44, false, "18 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 1 },
                    { 45, false, "18 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 163, 1 },
                    { 46, false, "18 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 164, 1 },
                    { 47, false, "18 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 1 },
                    { 48, false, "19 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 1 },
                    { 49, false, "19 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 1 },
                    { 50, false, "18 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 133, 1 },
                    { 51, false, "17 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 131, 1 },
                    { 52, false, "17 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 132, 1 },
                    { 53, false, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 129, 1 },
                    { 54, false, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 1 },
                    { 55, false, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 127, 1 },
                    { 56, false, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 128, 1 },
                    { 57, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 134, 1 },
                    { 58, false, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 135, 1 },
                    { 59, false, "18 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 140, 1 },
                    { 60, false, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 144, 1 },
                    { 61, false, "18 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 141, 1 },
                    { 62, false, "17 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 142, 1 },
                    { 63, false, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 138, 1 },
                    { 64, false, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 139, 1 },
                    { 65, false, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 143, 1 },
                    { 66, false, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 137, 1 },
                    { 67, false, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 136, 1 },
                    { 68, false, "18 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 151, 1 },
                    { 69, false, "17 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 1 },
                    { 70, false, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 146, 1 },
                    { 71, false, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 152, 1 },
                    { 72, false, "8 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 1 },
                    { 73, false, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 1 },
                    { 74, false, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 1 },
                    { 75, false, "8 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 1 },
                    { 76, false, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 1 },
                    { 77, false, "8 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 1 },
                    { 78, false, "8 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 116, 1 },
                    { 79, false, "8 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 1 },
                    { 80, false, "8 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 1 },
                    { 81, false, "8 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 1 },
                    { 82, false, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 1 },
                    { 83, false, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 1 },
                    { 84, false, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 1 },
                    { 85, false, "8 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 119, 1 },
                    { 86, false, "8 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, 1 },
                    { 87, false, "10 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 1 },
                    { 88, false, "8 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, 1 },
                    { 89, false, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 125, 1 },
                    { 90, false, "8 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 1 },
                    { 91, false, "8 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 122, 1 },
                    { 92, false, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 229, 1 },
                    { 93, false, "13 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 224, 1 },
                    { 94, false, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 226, 1 },
                    { 95, false, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 227, 1 },
                    { 96, false, "13 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 225, 1 },
                    { 97, false, "13 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 228, 1 },
                    { 98, false, "13 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 231, 1 },
                    { 99, false, "13 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 230, 1 },
                    { 100, false, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 235, 1 },
                    { 101, false, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 240, 1 },
                    { 102, false, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 238, 1 },
                    { 103, false, "13 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 233, 1 },
                    { 104, false, "13 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 239, 1 },
                    { 105, false, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 234, 1 },
                    { 106, false, "13 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 237, 1 },
                    { 107, false, "13 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 251, 1 },
                    { 108, false, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 246, 1 },
                    { 109, false, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 249, 1 },
                    { 110, false, "13 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 243, 1 },
                    { 111, false, "13 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 245, 1 },
                    { 112, false, "13 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 244, 1 },
                    { 113, false, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 263, 1 },
                    { 114, false, "13 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 259, 1 },
                    { 115, false, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 1 },
                    { 116, false, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 189, 1 },
                    { 117, false, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 1 },
                    { 118, false, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 1 },
                    { 119, false, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 1 },
                    { 120, false, "13 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 1 },
                    { 121, false, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 1 },
                    { 122, false, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 1 },
                    { 123, false, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 1 },
                    { 124, false, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 1 },
                    { 125, false, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 195, 1 },
                    { 126, false, "13 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 1 },
                    { 127, false, "13 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 192, 1 },
                    { 128, false, "8 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 209, 1 },
                    { 129, false, "8 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 1 },
                    { 130, false, "8 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 205, 1 },
                    { 131, false, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 207, 1 },
                    { 132, false, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 1 },
                    { 133, false, "10 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 210, 1 },
                    { 134, false, "10 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 1 },
                    { 135, false, "10 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 215, 1 },
                    { 136, false, "8 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 219, 1 },
                    { 137, false, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 221, 1 },
                    { 138, false, "11 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 218, 1 }
                });

            migrationBuilder.InsertData(
                table: "detalleshorarios",
                columns: new[] { "Id", "Dia", "Eliminado", "HoraId", "HorarioId" },
                values: new object[] { 1, 0, false, 1, 1 });

            migrationBuilder.InsertData(
                table: "detallesmesasexamenes",
                columns: new[] { "Id", "DocenteId", "Eliminado", "MesaExamenId", "TipoIntegrante" },
                values: new object[,]
                {
                    { 1, 6, false, 1, 0 },
                    { 2, 66, false, 1, 1 },
                    { 3, 56, false, 1, 2 },
                    { 4, 16, false, 1, 3 },
                    { 5, 71, false, 2, 0 },
                    { 6, 43, false, 2, 1 },
                    { 7, 39, false, 2, 2 },
                    { 8, 66, false, 2, 3 },
                    { 9, 66, false, 3, 0 },
                    { 10, 45, false, 3, 1 },
                    { 11, 39, false, 3, 2 },
                    { 12, 28, false, 3, 3 },
                    { 13, 38, false, 4, 0 },
                    { 14, 53, false, 4, 1 },
                    { 15, 6, false, 4, 2 },
                    { 16, 23, false, 4, 3 },
                    { 17, 11, false, 5, 0 },
                    { 18, 58, false, 5, 1 },
                    { 19, 54, false, 5, 2 },
                    { 20, 56, false, 5, 3 },
                    { 21, 47, false, 6, 0 },
                    { 22, 16, false, 6, 1 },
                    { 23, 73, false, 6, 2 },
                    { 24, 16, false, 6, 3 },
                    { 25, 39, false, 7, 0 },
                    { 26, 66, false, 7, 1 },
                    { 27, 45, false, 7, 2 },
                    { 28, 28, false, 7, 3 },
                    { 29, 28, false, 8, 0 },
                    { 30, 73, false, 8, 1 },
                    { 31, 39, false, 8, 2 },
                    { 32, 23, false, 8, 3 },
                    { 33, 73, false, 9, 0 },
                    { 34, 16, false, 9, 1 },
                    { 35, 6, false, 9, 2 },
                    { 36, 56, false, 9, 3 },
                    { 37, 16, false, 10, 0 },
                    { 38, 47, false, 10, 1 },
                    { 39, 73, false, 10, 2 },
                    { 40, 16, false, 10, 3 },
                    { 41, 56, false, 11, 0 },
                    { 42, 6, false, 11, 1 },
                    { 43, 66, false, 11, 2 },
                    { 44, 53, false, 11, 3 },
                    { 45, 43, false, 12, 0 },
                    { 46, 71, false, 12, 1 },
                    { 47, 39, false, 12, 2 },
                    { 48, 66, false, 12, 3 },
                    { 49, 73, false, 13, 0 },
                    { 50, 28, false, 13, 1 },
                    { 51, 39, false, 13, 2 },
                    { 52, 23, false, 13, 3 },
                    { 53, 39, false, 14, 0 },
                    { 54, 66, false, 14, 1 },
                    { 55, 72, false, 14, 2 },
                    { 56, 56, false, 14, 3 },
                    { 57, 39, false, 15, 0 },
                    { 58, 71, false, 15, 1 },
                    { 59, 43, false, 15, 2 },
                    { 60, 66, false, 15, 3 },
                    { 61, 45, false, 16, 0 },
                    { 62, 66, false, 16, 1 },
                    { 63, 39, false, 16, 2 },
                    { 64, 28, false, 16, 3 },
                    { 65, 16, false, 17, 0 },
                    { 66, 73, false, 17, 1 },
                    { 67, 6, false, 17, 2 },
                    { 68, 56, false, 17, 3 },
                    { 69, 57, false, 18, 0 },
                    { 70, 37, false, 18, 1 },
                    { 71, 11, false, 18, 2 },
                    { 72, 59, false, 18, 3 },
                    { 73, 64, false, 19, 0 },
                    { 74, 59, false, 19, 1 },
                    { 75, 37, false, 19, 2 },
                    { 76, 31, false, 19, 3 },
                    { 77, 47, false, 20, 0 },
                    { 78, 22, false, 20, 1 },
                    { 79, 34, false, 20, 2 },
                    { 80, 64, false, 20, 3 },
                    { 81, 15, false, 21, 0 },
                    { 82, 59, false, 21, 1 },
                    { 83, 5, false, 21, 2 },
                    { 84, 53, false, 21, 3 },
                    { 85, 5, false, 22, 0 },
                    { 86, 4, false, 22, 1 },
                    { 87, 59, false, 22, 2 },
                    { 88, 57, false, 22, 3 },
                    { 89, 53, false, 23, 0 },
                    { 90, 4, false, 23, 1 },
                    { 91, 5, false, 23, 2 },
                    { 92, 34, false, 23, 3 },
                    { 93, 31, false, 24, 0 },
                    { 94, 64, false, 24, 1 },
                    { 95, 59, false, 24, 2 },
                    { 96, 59, false, 24, 3 },
                    { 97, 31, false, 25, 0 },
                    { 98, 64, false, 25, 1 },
                    { 99, 59, false, 25, 2 },
                    { 100, 59, false, 25, 3 },
                    { 101, 11, false, 26, 0 },
                    { 102, 22, false, 26, 1 },
                    { 103, 34, false, 26, 2 },
                    { 104, 15, false, 26, 3 },
                    { 105, 22, false, 27, 0 },
                    { 106, 34, false, 27, 1 },
                    { 107, 11, false, 27, 2 },
                    { 108, 15, false, 27, 3 },
                    { 109, 22, false, 28, 0 },
                    { 110, 34, false, 28, 1 },
                    { 111, 11, false, 28, 2 },
                    { 112, 15, false, 28, 3 },
                    { 113, 37, false, 29, 0 },
                    { 114, 57, false, 29, 1 },
                    { 115, 11, false, 29, 2 },
                    { 116, 57, false, 29, 3 },
                    { 117, 59, false, 30, 0 },
                    { 118, 15, false, 30, 1 },
                    { 119, 34, false, 30, 2 },
                    { 120, 53, false, 30, 3 },
                    { 121, 4, false, 31, 0 },
                    { 122, 5, false, 31, 1 },
                    { 123, 59, false, 31, 2 },
                    { 124, 57, false, 31, 3 },
                    { 125, 59, false, 32, 0 },
                    { 126, 53, false, 32, 1 },
                    { 127, 31, false, 32, 2 },
                    { 128, 34, false, 32, 3 },
                    { 129, 59, false, 33, 0 },
                    { 130, 15, false, 33, 1 },
                    { 131, 34, false, 33, 2 },
                    { 132, 53, false, 33, 3 },
                    { 133, 7, false, 34, 0 },
                    { 134, 57, false, 34, 1 },
                    { 135, 15, false, 34, 2 },
                    { 136, 15, false, 34, 3 },
                    { 137, 59, false, 35, 0 },
                    { 138, 4, false, 35, 1 },
                    { 139, 5, false, 35, 2 },
                    { 140, 57, false, 35, 3 },
                    { 141, 59, false, 36, 0 },
                    { 142, 53, false, 36, 1 },
                    { 143, 31, false, 36, 2 },
                    { 144, 34, false, 36, 3 },
                    { 145, 4, false, 37, 0 },
                    { 146, 46, false, 37, 1 },
                    { 147, 47, false, 37, 2 },
                    { 148, 59, false, 37, 3 },
                    { 149, 15, false, 38, 0 },
                    { 150, 47, false, 38, 1 },
                    { 151, 5, false, 38, 2 },
                    { 152, 21, false, 38, 3 },
                    { 153, 47, false, 39, 0 },
                    { 154, 15, false, 39, 1 },
                    { 155, 5, false, 39, 2 },
                    { 156, 21, false, 39, 3 },
                    { 157, 58, false, 40, 0 },
                    { 158, 11, false, 40, 1 },
                    { 159, 54, false, 40, 2 },
                    { 160, 46, false, 40, 3 },
                    { 161, 31, false, 41, 0 },
                    { 162, 64, false, 41, 1 },
                    { 163, 59, false, 41, 2 },
                    { 164, 58, false, 41, 3 },
                    { 165, 31, false, 42, 0 },
                    { 166, 64, false, 42, 1 },
                    { 167, 59, false, 42, 2 },
                    { 168, 58, false, 42, 3 },
                    { 169, 11, false, 43, 0 },
                    { 170, 22, false, 43, 1 },
                    { 171, 34, false, 43, 2 },
                    { 172, 46, false, 43, 3 },
                    { 173, 5, false, 44, 0 },
                    { 174, 47, false, 44, 1 },
                    { 175, 15, false, 44, 2 },
                    { 176, 21, false, 44, 3 },
                    { 177, 42, false, 45, 0 },
                    { 178, 46, false, 45, 1 },
                    { 179, 7, false, 45, 2 },
                    { 180, 53, false, 45, 3 },
                    { 181, 42, false, 46, 0 },
                    { 182, 46, false, 46, 1 },
                    { 183, 7, false, 46, 2 },
                    { 184, 53, false, 46, 3 },
                    { 185, 64, false, 47, 0 },
                    { 186, 21, false, 47, 1 },
                    { 187, 47, false, 47, 2 },
                    { 188, 46, false, 47, 3 },
                    { 189, 7, false, 48, 0 },
                    { 190, 46, false, 48, 1 },
                    { 191, 42, false, 48, 2 },
                    { 192, 53, false, 48, 3 },
                    { 193, 46, false, 49, 0 },
                    { 194, 7, false, 49, 1 },
                    { 195, 42, false, 49, 2 },
                    { 196, 53, false, 49, 3 },
                    { 197, 47, false, 50, 0 },
                    { 198, 60, false, 50, 1 },
                    { 199, 18, false, 50, 2 },
                    { 200, 67, false, 50, 3 },
                    { 201, 48, false, 51, 0 },
                    { 202, 2, false, 51, 1 },
                    { 203, 31, false, 51, 2 },
                    { 204, 28, false, 51, 3 },
                    { 205, 64, false, 52, 0 },
                    { 206, 63, false, 52, 1 },
                    { 207, 2, false, 52, 2 },
                    { 208, 33, false, 52, 3 },
                    { 209, 34, false, 53, 0 },
                    { 210, 67, false, 53, 1 },
                    { 211, 17, false, 53, 2 },
                    { 212, 47, false, 53, 3 },
                    { 213, 36, false, 54, 0 },
                    { 214, 29, false, 54, 1 },
                    { 215, 17, false, 54, 2 },
                    { 216, 48, false, 54, 3 },
                    { 217, 31, false, 55, 0 },
                    { 218, 47, false, 55, 1 },
                    { 219, 67, false, 55, 2 },
                    { 220, 2, false, 55, 3 },
                    { 221, 31, false, 56, 0 },
                    { 222, 47, false, 56, 1 },
                    { 223, 67, false, 56, 2 },
                    { 224, 2, false, 56, 3 },
                    { 225, 67, false, 57, 0 },
                    { 226, 48, false, 57, 1 },
                    { 227, 29, false, 57, 2 },
                    { 228, 28, false, 57, 3 },
                    { 229, 2, false, 58, 0 },
                    { 230, 60, false, 58, 1 },
                    { 231, 36, false, 58, 2 },
                    { 232, 28, false, 58, 3 },
                    { 233, 60, false, 59, 0 },
                    { 234, 47, false, 59, 1 },
                    { 235, 18, false, 59, 2 },
                    { 236, 67, false, 59, 3 },
                    { 237, 29, false, 60, 0 },
                    { 238, 7, false, 60, 1 },
                    { 239, 11, false, 60, 2 },
                    { 240, 37, false, 60, 3 },
                    { 241, 17, false, 61, 0 },
                    { 242, 18, false, 61, 1 },
                    { 243, 7, false, 61, 2 },
                    { 244, 29, false, 61, 3 },
                    { 245, 34, false, 62, 0 },
                    { 246, 18, false, 62, 1 },
                    { 247, 37, false, 62, 2 },
                    { 248, 33, false, 62, 3 },
                    { 249, 34, false, 63, 0 },
                    { 250, 48, false, 63, 1 },
                    { 251, 60, false, 63, 2 },
                    { 252, 47, false, 63, 3 },
                    { 253, 37, false, 64, 0 },
                    { 254, 7, false, 64, 1 },
                    { 255, 33, false, 64, 2 },
                    { 256, 48, false, 64, 3 },
                    { 257, 34, false, 65, 0 },
                    { 258, 18, false, 65, 1 },
                    { 259, 48, false, 65, 2 },
                    { 260, 2, false, 65, 3 },
                    { 261, 67, false, 66, 0 },
                    { 262, 48, false, 66, 1 },
                    { 263, 29, false, 66, 2 },
                    { 264, 29, false, 66, 3 },
                    { 265, 63, false, 67, 0 },
                    { 266, 34, false, 67, 1 },
                    { 267, 18, false, 67, 2 },
                    { 268, 29, false, 67, 3 },
                    { 269, 18, false, 68, 0 },
                    { 270, 17, false, 68, 1 },
                    { 271, 7, false, 68, 2 },
                    { 272, 29, false, 68, 3 },
                    { 273, 18, false, 69, 0 },
                    { 274, 34, false, 69, 1 },
                    { 275, 37, false, 69, 2 },
                    { 276, 29, false, 69, 3 },
                    { 277, 7, false, 70, 0 },
                    { 278, 37, false, 70, 1 },
                    { 279, 33, false, 70, 2 },
                    { 280, 48, false, 70, 3 },
                    { 281, 18, false, 71, 0 },
                    { 282, 34, false, 71, 1 },
                    { 283, 48, false, 71, 2 },
                    { 284, 2, false, 71, 3 },
                    { 285, 61, false, 72, 0 },
                    { 286, 9, false, 72, 1 },
                    { 287, 32, false, 72, 2 },
                    { 288, 3, false, 72, 3 },
                    { 289, 8, false, 73, 0 },
                    { 290, 9, false, 73, 1 },
                    { 291, 12, false, 73, 2 },
                    { 292, 61, false, 73, 3 },
                    { 293, 8, false, 74, 0 },
                    { 294, 9, false, 74, 1 },
                    { 295, 12, false, 74, 2 },
                    { 296, 61, false, 74, 3 },
                    { 297, 3, false, 75, 0 },
                    { 298, 61, false, 75, 1 },
                    { 299, 32, false, 75, 2 },
                    { 300, 9, false, 75, 3 },
                    { 301, 54, false, 76, 0 },
                    { 302, 51, false, 76, 1 },
                    { 303, 61, false, 76, 2 },
                    { 304, 3, false, 76, 3 },
                    { 305, 3, false, 77, 0 },
                    { 306, 51, false, 77, 1 },
                    { 307, 32, false, 77, 2 },
                    { 308, 12, false, 77, 3 },
                    { 309, 9, false, 78, 0 },
                    { 310, 61, false, 78, 1 },
                    { 311, 32, false, 78, 2 },
                    { 312, 3, false, 78, 3 },
                    { 313, 61, false, 79, 0 },
                    { 314, 7, false, 79, 1 },
                    { 315, 54, false, 79, 2 },
                    { 316, 61, false, 79, 3 },
                    { 317, 68, false, 80, 0 },
                    { 318, 24, false, 80, 1 },
                    { 319, 3, false, 80, 2 },
                    { 320, 25, false, 80, 3 },
                    { 321, 24, false, 81, 0 },
                    { 322, 68, false, 81, 1 },
                    { 323, 3, false, 81, 2 },
                    { 324, 25, false, 81, 3 },
                    { 325, 54, false, 82, 0 },
                    { 326, 3, false, 82, 1 },
                    { 327, 51, false, 82, 2 },
                    { 328, 61, false, 82, 3 },
                    { 329, 12, false, 83, 0 },
                    { 330, 49, false, 83, 1 },
                    { 331, 7, false, 83, 2 },
                    { 332, 3, false, 83, 3 },
                    { 333, 49, false, 84, 0 },
                    { 334, 12, false, 84, 1 },
                    { 335, 7, false, 84, 2 },
                    { 336, 3, false, 84, 3 },
                    { 337, 7, false, 85, 0 },
                    { 338, 61, false, 85, 1 },
                    { 339, 54, false, 85, 2 },
                    { 340, 61, false, 85, 3 },
                    { 341, 30, false, 86, 0 },
                    { 342, 35, false, 86, 1 },
                    { 343, 31, false, 86, 2 },
                    { 344, 61, false, 86, 3 },
                    { 345, 37, false, 87, 0 },
                    { 346, 68, false, 87, 1 },
                    { 347, 25, false, 87, 2 },
                    { 348, 25, false, 87, 3 },
                    { 349, 9, false, 88, 0 },
                    { 350, 32, false, 88, 1 },
                    { 351, 51, false, 88, 2 },
                    { 352, 3, false, 88, 3 },
                    { 353, 3, false, 89, 0 },
                    { 354, 54, false, 89, 1 },
                    { 355, 51, false, 89, 2 },
                    { 356, 61, false, 89, 3 },
                    { 357, 61, false, 90, 0 },
                    { 358, 3, false, 90, 1 },
                    { 359, 32, false, 90, 2 },
                    { 360, 9, false, 90, 3 },
                    { 361, 25, false, 91, 0 },
                    { 362, 68, false, 91, 1 },
                    { 363, 51, false, 91, 2 },
                    { 364, 9, false, 91, 3 },
                    { 365, 39, false, 92, 0 },
                    { 366, 72, false, 92, 1 },
                    { 367, 20, false, 92, 2 },
                    { 368, 2, false, 92, 3 },
                    { 369, 28, false, 93, 0 },
                    { 370, 72, false, 93, 1 },
                    { 371, 17, false, 93, 2 },
                    { 372, 34, false, 93, 3 },
                    { 373, 17, false, 94, 0 },
                    { 374, 22, false, 94, 1 },
                    { 375, 44, false, 94, 2 },
                    { 376, 47, false, 94, 3 },
                    { 377, 17, false, 95, 0 },
                    { 378, 22, false, 95, 1 },
                    { 379, 44, false, 95, 2 },
                    { 380, 47, false, 95, 3 },
                    { 381, 42, false, 96, 0 },
                    { 382, 71, false, 96, 1 },
                    { 383, 60, false, 96, 2 },
                    { 384, 48, false, 96, 3 },
                    { 385, 34, false, 97, 0 },
                    { 386, 48, false, 97, 1 },
                    { 387, 44, false, 97, 2 },
                    { 388, 22, false, 97, 3 },
                    { 389, 44, false, 98, 0 },
                    { 390, 48, false, 98, 1 },
                    { 391, 34, false, 98, 2 },
                    { 392, 22, false, 98, 3 },
                    { 393, 60, false, 99, 0 },
                    { 394, 28, false, 99, 1 },
                    { 395, 55, false, 99, 2 },
                    { 396, 28, false, 99, 3 },
                    { 397, 72, false, 100, 0 },
                    { 398, 39, false, 100, 1 },
                    { 399, 20, false, 100, 2 },
                    { 400, 34, false, 100, 3 },
                    { 401, 11, false, 101, 0 },
                    { 402, 30, false, 101, 1 },
                    { 403, 31, false, 101, 2 },
                    { 404, 36, false, 101, 3 },
                    { 405, 30, false, 102, 0 },
                    { 406, 11, false, 102, 1 },
                    { 407, 31, false, 102, 2 },
                    { 408, 36, false, 102, 3 },
                    { 409, 49, false, 103, 0 },
                    { 410, 28, false, 103, 1 },
                    { 411, 71, false, 103, 2 },
                    { 412, 2, false, 103, 3 },
                    { 413, 60, false, 104, 0 },
                    { 414, 42, false, 104, 1 },
                    { 415, 71, false, 104, 2 },
                    { 416, 48, false, 104, 3 },
                    { 417, 28, false, 105, 0 },
                    { 418, 64, false, 105, 1 },
                    { 419, 30, false, 105, 2 },
                    { 420, 17, false, 105, 3 },
                    { 421, 34, false, 106, 0 },
                    { 422, 48, false, 106, 1 },
                    { 423, 44, false, 106, 2 },
                    { 424, 22, false, 106, 3 },
                    { 425, 72, false, 107, 0 },
                    { 426, 28, false, 107, 1 },
                    { 427, 17, false, 107, 2 },
                    { 428, 34, false, 107, 3 },
                    { 429, 22, false, 108, 0 },
                    { 430, 17, false, 108, 1 },
                    { 431, 44, false, 108, 2 },
                    { 432, 47, false, 108, 3 },
                    { 433, 30, false, 109, 0 },
                    { 434, 11, false, 109, 1 },
                    { 435, 31, false, 109, 2 },
                    { 436, 36, false, 109, 3 },
                    { 437, 28, false, 110, 0 },
                    { 438, 49, false, 110, 1 },
                    { 439, 71, false, 110, 2 },
                    { 440, 2, false, 110, 3 },
                    { 441, 71, false, 111, 0 },
                    { 442, 42, false, 111, 1 },
                    { 443, 60, false, 111, 2 },
                    { 444, 48, false, 111, 3 },
                    { 445, 28, false, 112, 0 },
                    { 446, 60, false, 112, 1 },
                    { 447, 55, false, 112, 2 },
                    { 448, 27, false, 112, 3 },
                    { 449, 64, false, 113, 0 },
                    { 450, 28, false, 113, 1 },
                    { 451, 30, false, 113, 2 },
                    { 452, 17, false, 113, 3 },
                    { 453, 48, false, 114, 0 },
                    { 454, 44, false, 114, 1 },
                    { 455, 34, false, 114, 2 },
                    { 456, 22, false, 114, 3 },
                    { 457, 42, false, 115, 0 },
                    { 458, 54, false, 115, 1 },
                    { 459, 31, false, 115, 2 },
                    { 460, 44, false, 115, 3 },
                    { 461, 54, false, 116, 0 },
                    { 462, 42, false, 116, 1 },
                    { 463, 31, false, 116, 2 },
                    { 464, 44, false, 116, 3 },
                    { 465, 49, false, 117, 0 },
                    { 466, 69, false, 117, 1 },
                    { 467, 72, false, 117, 2 },
                    { 468, 10, false, 117, 3 },
                    { 469, 43, false, 118, 0 },
                    { 470, 49, false, 118, 1 },
                    { 471, 54, false, 118, 2 },
                    { 472, 36, false, 118, 3 },
                    { 473, 10, false, 119, 0 },
                    { 474, 13, false, 119, 1 },
                    { 475, 65, false, 119, 2 },
                    { 476, 69, false, 119, 3 },
                    { 477, 73, false, 120, 0 },
                    { 478, 40, false, 120, 1 },
                    { 479, 10, false, 120, 2 },
                    { 480, 72, false, 120, 3 },
                    { 481, 54, false, 121, 0 },
                    { 482, 42, false, 121, 1 },
                    { 483, 31, false, 121, 2 },
                    { 484, 44, false, 121, 3 },
                    { 485, 69, false, 122, 0 },
                    { 486, 49, false, 122, 1 },
                    { 487, 72, false, 122, 2 },
                    { 488, 10, false, 122, 3 },
                    { 489, 49, false, 123, 0 },
                    { 490, 43, false, 123, 1 },
                    { 491, 54, false, 123, 2 },
                    { 492, 36, false, 123, 3 },
                    { 493, 13, false, 124, 0 },
                    { 494, 10, false, 124, 1 },
                    { 495, 65, false, 124, 2 },
                    { 496, 69, false, 124, 3 },
                    { 497, 65, false, 125, 0 },
                    { 498, 10, false, 125, 1 },
                    { 499, 13, false, 125, 2 },
                    { 500, 69, false, 125, 3 },
                    { 501, 44, false, 126, 0 },
                    { 502, 11, false, 126, 1 },
                    { 503, 36, false, 126, 2 },
                    { 504, 49, false, 126, 3 },
                    { 505, 40, false, 127, 0 },
                    { 506, 73, false, 127, 1 },
                    { 507, 10, false, 127, 2 },
                    { 508, 72, false, 127, 3 },
                    { 509, 69, false, 128, 0 },
                    { 510, 52, false, 128, 1 },
                    { 511, 42, false, 128, 2 },
                    { 512, 54, false, 128, 3 },
                    { 513, 21, false, 129, 0 },
                    { 514, 68, false, 129, 1 },
                    { 515, 19, false, 129, 2 },
                    { 516, 54, false, 129, 3 },
                    { 517, 27, false, 130, 0 },
                    { 518, 39, false, 130, 1 },
                    { 519, 14, false, 130, 2 },
                    { 520, 54, false, 130, 3 },
                    { 521, 44, false, 131, 0 },
                    { 522, 11, false, 131, 1 },
                    { 523, 19, false, 131, 2 },
                    { 524, 54, false, 131, 3 },
                    { 525, 72, false, 132, 0 },
                    { 526, 71, false, 132, 1 },
                    { 527, 50, false, 132, 2 },
                    { 528, 3, false, 132, 3 },
                    { 529, 39, false, 133, 0 },
                    { 530, 60, false, 133, 1 },
                    { 531, 27, false, 133, 2 },
                    { 532, 12, false, 133, 3 },
                    { 533, 39, false, 134, 0 },
                    { 534, 60, false, 134, 1 },
                    { 535, 27, false, 134, 2 },
                    { 536, 62, false, 134, 3 },
                    { 537, 39, false, 135, 0 },
                    { 538, 60, false, 135, 1 },
                    { 539, 27, false, 135, 2 },
                    { 540, 62, false, 135, 3 },
                    { 541, 64, false, 136, 0 },
                    { 542, 2, false, 136, 1 },
                    { 543, 60, false, 136, 2 },
                    { 544, 54, false, 136, 3 },
                    { 545, 71, false, 137, 0 },
                    { 546, 50, false, 137, 1 },
                    { 547, 72, false, 137, 2 },
                    { 548, 30, false, 137, 3 },
                    { 549, 39, false, 138, 0 },
                    { 550, 27, false, 138, 1 },
                    { 551, 14, false, 138, 2 },
                    { 552, 12, false, 138, 3 }
                });

            migrationBuilder.InsertData(
                table: "integranteshorarios",
                columns: new[] { "Id", "DocenteId", "Eliminado", "HorarioId" },
                values: new object[] { 1, 1, false, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_anioscarreras_CarreraId",
                table: "anioscarreras",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleshorarios_HoraId",
                table: "detalleshorarios",
                column: "HoraId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleshorarios_HorarioId",
                table: "detalleshorarios",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesinscripciones_InscripcionId",
                table: "detallesinscripciones",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesinscripciones_MateriaId",
                table: "detallesinscripciones",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesmesasexamenes_DocenteId",
                table: "detallesmesasexamenes",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesmesasexamenes_MesaExamenId",
                table: "detallesmesasexamenes",
                column: "MesaExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_CicloLectivoId",
                table: "horarios",
                column: "CicloLectivoId");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_MateriaId",
                table: "horarios",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_AlumnoId",
                table: "inscripciones",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_CarreraId",
                table: "inscripciones",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_CicloLectivoId",
                table: "inscripciones",
                column: "CicloLectivoId");

            migrationBuilder.CreateIndex(
                name: "IX_inscriptoscarreras_AlumnoId",
                table: "inscriptoscarreras",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_inscriptoscarreras_CarreraId",
                table: "inscriptoscarreras",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_integranteshorarios_DocenteId",
                table: "integranteshorarios",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_integranteshorarios_HorarioId",
                table: "integranteshorarios",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_materias_AnioCarreraId",
                table: "materias",
                column: "AnioCarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_mesasexamenes_MateriaId",
                table: "mesasexamenes",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_mesasexamenes_TurnoExamenId",
                table: "mesasexamenes",
                column: "TurnoExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_AlumnoId",
                table: "usuarios",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_DocenteId",
                table: "usuarios",
                column: "DocenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleshorarios");

            migrationBuilder.DropTable(
                name: "detallesinscripciones");

            migrationBuilder.DropTable(
                name: "detallesmesasexamenes");

            migrationBuilder.DropTable(
                name: "inscriptoscarreras");

            migrationBuilder.DropTable(
                name: "integranteshorarios");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "horas");

            migrationBuilder.DropTable(
                name: "inscripciones");

            migrationBuilder.DropTable(
                name: "mesasexamenes");

            migrationBuilder.DropTable(
                name: "horarios");

            migrationBuilder.DropTable(
                name: "docentes");

            migrationBuilder.DropTable(
                name: "alumnos");

            migrationBuilder.DropTable(
                name: "turnosexamenes");

            migrationBuilder.DropTable(
                name: "cicloslectivos");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "anioscarreras");

            migrationBuilder.DropTable(
                name: "carreras");
        }
    }
}
