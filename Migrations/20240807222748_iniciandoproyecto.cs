using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inscripciones.Migrations
{
    /// <inheritdoc />
    public partial class iniciandoproyecto : Migration
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
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    EsRecreo = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    CarreraId = table.Column<int>(type: "int", nullable: false)
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
                    CarreraId = table.Column<int>(type: "int", nullable: true)
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
                    CicloLectivoId = table.Column<int>(type: "int", nullable: false)
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
                    DocenteId = table.Column<int>(type: "int", nullable: true)
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
                    AnioCarreraId = table.Column<int>(type: "int", nullable: false)
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
                    MateriaId = table.Column<int>(type: "int", nullable: false)
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
                    CicloLectivoId = table.Column<int>(type: "int", nullable: true)
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
                    TurnoExamenId = table.Column<int>(type: "int", nullable: false)
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
                    HoraId = table.Column<int>(type: "int", nullable: true)
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
                    DocenteId = table.Column<int>(type: "int", nullable: true)
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
                    TipoIntegrante = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "ApellidoNombre", "Direccion", "Email", "Telefono" },
                values: new object[] { 1, "Rubén Alejandro Ramirez", "Bv Roque Saenz Peña 2942", "aleramirezsj@gmail.com", "15447106" });

            migrationBuilder.InsertData(
                table: "carreras",
                columns: new[] { "Id", "Nombre", "Sigla" },
                values: new object[,]
                {
                    { 1, "Tecnicatura Superior en Desarrollo de Software", "TSDS" },
                    { 2, "Tecnicatura Superior en Soporte de Infraestructura", "TSSITI" },
                    { 3, "Tecnicatura Superior en Gestion de las Organizaciones", "TSGO" },
                    { 4, "Tecnicatura Superior en Enfermeria", "TSE" },
                    { 5, "Profesorado de Educación Secundaria en Ciencias de la Administración", "PEA" },
                    { 6, "Profesorado de Educación Inicial", "PEI" },
                    { 7, "Profesorado de Educación Secundaria en Economía", "PEE" },
                    { 8, "Profesorado de Educación Tecnológica", "PET" },
                    { 9, "Licenciatura en Cooperativismo y Mutualismo", "LCM" }
                });

            migrationBuilder.InsertData(
                table: "cicloslectivos",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "2024" });

            migrationBuilder.InsertData(
                table: "docentes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Adamo, G." },
                    { 2, "Aimar, M.A." },
                    { 3, "Albaristo, Stef." },
                    { 4, "Alesso, A." },
                    { 5, "Alesso, M." },
                    { 6, "Arnolfo, P." },
                    { 7, "Bazán, D." },
                    { 8, "Blanche, C." },
                    { 9, "Bogni, J." },
                    { 10, "Brondino, D." },
                    { 11, "Brussa, G." },
                    { 12, "Buceta, MB." },
                    { 13, "Bueno, M.F." },
                    { 14, "Cainero, G." },
                    { 15, "Calvo, M." },
                    { 16, "Cavallini, J." },
                    { 17, "Chauderón, L." },
                    { 18, "Chelini, V." },
                    { 19, "Corradi, R." },
                    { 20, "Dalesio, C." },
                    { 21, "Degiorgio, O." },
                    { 22, "Della Rosa, M." },
                    { 23, "Dellaferrera, C." },
                    { 24, "Doglioli, M." },
                    { 25, "Duran, C." },
                    { 26, "Epes, B." },
                    { 27, "Espru, F." },
                    { 28, "Ferreyra, M." },
                    { 29, "Ferrero, M." },
                    { 30, "Ferr, N." },
                    { 31, "Gaido, J.P." },
                    { 32, "Galmes, M." },
                    { 33, "Genero, A." },
                    { 34, "Gongora, L." },
                    { 35, "Gomez, V." },
                    { 36, "Gretter, M.C." },
                    { 37, "Grosso, S." },
                    { 38, "Imhof, R." },
                    { 39, "Imperiale, M." },
                    { 40, "Lodi, L." },
                    { 41, "Lovino, F." },
                    { 42, "Mancilla, J." },
                    { 43, "Manattini, S." },
                    { 44, "Marenoni, A." },
                    { 45, "Martínez, G." },
                    { 46, "Mendoza, M." },
                    { 47, "Miñoz, A." },
                    { 48, "Molina, T." },
                    { 49, "Monzón, M.I." },
                    { 50, "Nasimbera, R." },
                    { 51, "Ortiz, L." },
                    { 52, "Paredes, M." },
                    { 53, "Pedrazzoli, F." },
                    { 54, "Pereyra, S." },
                    { 55, "Peressin, S." },
                    { 56, "Prida, C." },
                    { 57, "Puccio, D." },
                    { 58, "Quaglia, E." },
                    { 59, "Ramirez, R.A." },
                    { 60, "Renteria, D." },
                    { 61, "Rodriguez Quain, J." },
                    { 62, "Rosso, E." },
                    { 63, "Sanchez, R." },
                    { 64, "Sandoval, P." },
                    { 65, "Sancho, I." },
                    { 66, "Sara, J." },
                    { 67, "Strada, J." },
                    { 68, "Tovar, C." },
                    { 69, "Tregnaghi, C." },
                    { 70, "Tschopp, M.R." },
                    { 71, "Verzzali, A." },
                    { 72, "Vigniatti, E." },
                    { 73, "Villa, M.F." },
                    { 74, "Ruiz, A." },
                    { 75, "Sager, L." }
                });

            migrationBuilder.InsertData(
                table: "horas",
                columns: new[] { "Id", "EsRecreo", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "08:00 - 08:40" },
                    { 2, false, "08:40 - 09:20" },
                    { 3, false, "09:20 - 10:00" },
                    { 4, false, "10:00 - 10:40" },
                    { 5, true, "10:40 - 10:50" },
                    { 6, false, "10:50 - 11:30" },
                    { 7, false, "11:30 - 12:10" },
                    { 8, false, "12:10 - 12:50" },
                    { 9, false, "12:50 - 13:30" },
                    { 10, false, "13:10 - 13:50" },
                    { 11, false, "13:50 - 14:30" },
                    { 12, false, "14:30 - 15:10" },
                    { 13, false, "15:10 - 15:50" },
                    { 14, true, "15:50 - 16:00" },
                    { 15, false, "16:00 - 16:40" },
                    { 16, false, "16:40 - 17:20" },
                    { 17, false, "17:20 - 18:00" },
                    { 18, false, "18:00 - 18:40" },
                    { 19, false, "18:40 - 19:20" },
                    { 20, false, "19:20 - 20:00" },
                    { 21, true, "19:30 - 19:40" },
                    { 22, false, "19:40 - 20:20" },
                    { 23, false, "20:20 - 21:00" },
                    { 24, false, "21:00 - 21:40" }
                });

            migrationBuilder.InsertData(
                table: "turnosexamenes",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Julio/Agosto 2024" });

            migrationBuilder.InsertData(
                table: "anioscarreras",
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
                table: "inscripciones",
                columns: new[] { "Id", "AlumnoId", "CarreraId", "CicloLectivoId", "Fecha" },
                values: new object[] { 1, 1, 1, 1, new DateTime(2024, 8, 7, 19, 27, 47, 588, DateTimeKind.Local).AddTicks(4819) });

            migrationBuilder.InsertData(
                table: "inscriptoscarreras",
                columns: new[] { "Id", "AlumnoId", "CarreraId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "AlumnoId", "DocenteId", "Email", "TipoUsuario", "User" },
                values: new object[] { 1, null, 1, "admin@gmail.com", 2, "admin" });

            migrationBuilder.InsertData(
                table: "materias",
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
                    { 263, 16, "Unidad de Definición Institucional" },
                    { 264, 1, "Recreo" },
                    { 265, 2, "Recreo" },
                    { 266, 3, "Recreo" },
                    { 267, 4, "Recreo" },
                    { 268, 5, "Recreo" },
                    { 269, 6, "Recreo" },
                    { 270, 7, "Recreo" },
                    { 271, 8, "Recreo" },
                    { 272, 9, "Recreo" },
                    { 273, 10, "Recreo" },
                    { 274, 11, "Recreo" },
                    { 275, 12, "Recreo" },
                    { 276, 13, "Recreo" },
                    { 277, 14, "Recreo" },
                    { 278, 15, "Recreo" },
                    { 279, 16, "Recreo" },
                    { 280, 17, "Recreo" },
                    { 281, 18, "Recreo" },
                    { 282, 19, "Recreo" },
                    { 283, 20, "Recreo" },
                    { 284, 21, "Recreo" },
                    { 285, 22, "Recreo" },
                    { 286, 23, "Recreo" },
                    { 287, 24, "Recreo" },
                    { 288, 25, "Recreo" },
                    { 289, 26, "Recreo" },
                    { 290, 27, "Recreo" },
                    { 291, 28, "Recreo" }
                });

            migrationBuilder.InsertData(
                table: "detallesinscripciones",
                columns: new[] { "Id", "InscripcionId", "MateriaId", "ModalidadCursado" },
                values: new object[] { 1, 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "horarios",
                columns: new[] { "Id", "CantidadHoras", "CicloLectivoId", "MateriaId" },
                values: new object[] { 1, 4, 1, 1 });

            migrationBuilder.InsertData(
                table: "mesasexamenes",
                columns: new[] { "Id", "Horario", "Llamado1", "Llamado2", "MateriaId", "TurnoExamenId" },
                values: new object[,]
                {
                    { 1, "17 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 1 },
                    { 2, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 1 },
                    { 3, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 1 },
                    { 4, "17 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 1 },
                    { 5, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1 },
                    { 6, "18 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 1 },
                    { 7, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 1 },
                    { 8, "17 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 1 },
                    { 9, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 1 },
                    { 10, "18 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 62, 1 },
                    { 11, "17 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 1 },
                    { 12, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 1 },
                    { 13, "17 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 1 },
                    { 14, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 1 },
                    { 15, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 1 },
                    { 16, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 1 },
                    { 17, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 1 },
                    { 18, "17 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 1 },
                    { 19, "13 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 1 },
                    { 20, "13 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 1 },
                    { 21, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 1 },
                    { 22, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 1 },
                    { 23, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 1 },
                    { 24, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 1 },
                    { 25, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 1 },
                    { 26, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 1 },
                    { 27, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 1 },
                    { 28, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 1 },
                    { 29, "17 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 1 },
                    { 30, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 1 },
                    { 31, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 1 },
                    { 32, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 1 },
                    { 33, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1 },
                    { 34, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 1 },
                    { 35, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 1 },
                    { 36, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 1 },
                    { 37, "18 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 1 },
                    { 38, "18 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 161, 1 },
                    { 39, "18 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 158, 1 },
                    { 40, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 156, 1 },
                    { 41, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 154, 1 },
                    { 42, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 155, 1 },
                    { 43, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 1 },
                    { 44, "18 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 1 },
                    { 45, "18 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 163, 1 },
                    { 46, "18 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 164, 1 },
                    { 47, "18 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 1 },
                    { 48, "19 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 1 },
                    { 49, "19 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 1 },
                    { 50, "18 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 133, 1 },
                    { 51, "17 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 131, 1 },
                    { 52, "17 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 132, 1 },
                    { 53, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 129, 1 },
                    { 54, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 1 },
                    { 55, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 127, 1 },
                    { 56, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 128, 1 },
                    { 57, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 134, 1 },
                    { 58, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 135, 1 },
                    { 59, "18 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 140, 1 },
                    { 60, "17 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 144, 1 },
                    { 61, "18 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 141, 1 },
                    { 62, "17 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 142, 1 },
                    { 63, "17 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 138, 1 },
                    { 64, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 139, 1 },
                    { 65, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 143, 1 },
                    { 66, "17 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 137, 1 },
                    { 67, "17 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 136, 1 },
                    { 68, "18 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 151, 1 },
                    { 69, "17 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 1 },
                    { 70, "17 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 146, 1 },
                    { 71, "18 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 152, 1 },
                    { 72, "8 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 1 },
                    { 73, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 1 },
                    { 74, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 1 },
                    { 75, "8 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 1 },
                    { 76, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 1 },
                    { 77, "8 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 1 },
                    { 78, "8 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 116, 1 },
                    { 79, "8 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 1 },
                    { 80, "8 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 1 },
                    { 81, "8 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 1 },
                    { 82, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 1 },
                    { 83, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 1 },
                    { 84, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 1 },
                    { 85, "8 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 119, 1 },
                    { 86, "8 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, 1 },
                    { 87, "10 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 1 },
                    { 88, "8 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, 1 },
                    { 89, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 125, 1 },
                    { 90, "8 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 1 },
                    { 91, "8 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 122, 1 },
                    { 92, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 229, 1 },
                    { 93, "13 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 224, 1 },
                    { 94, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 226, 1 },
                    { 95, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 227, 1 },
                    { 96, "13 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 225, 1 },
                    { 97, "13 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 228, 1 },
                    { 98, "13 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 231, 1 },
                    { 99, "13 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 230, 1 },
                    { 100, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 235, 1 },
                    { 101, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 240, 1 },
                    { 102, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 238, 1 },
                    { 103, "13 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 233, 1 },
                    { 104, "13 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 239, 1 },
                    { 105, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 234, 1 },
                    { 106, "13 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 237, 1 },
                    { 107, "13 HS", new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 251, 1 },
                    { 108, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 246, 1 },
                    { 109, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 249, 1 },
                    { 110, "13 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 243, 1 },
                    { 111, "13 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 245, 1 },
                    { 112, "13 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 244, 1 },
                    { 113, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 263, 1 },
                    { 114, "13 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 259, 1 },
                    { 115, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 1 },
                    { 116, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 189, 1 },
                    { 117, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 1 },
                    { 118, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 1 },
                    { 119, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 1 },
                    { 120, "13 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 1 },
                    { 121, "13 HS", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 1 },
                    { 122, "13 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 1 },
                    { 123, "13 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 1 },
                    { 124, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 1 },
                    { 125, "13 HS", new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 195, 1 },
                    { 126, "13 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 1 },
                    { 127, "13 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 192, 1 },
                    { 128, "8 HS", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 209, 1 },
                    { 129, "8 HS", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 1 },
                    { 130, "8 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 205, 1 },
                    { 131, "8 HS", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 207, 1 },
                    { 132, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 1 },
                    { 133, "10 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 210, 1 },
                    { 134, "10 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 1 },
                    { 135, "10 HS", new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 215, 1 },
                    { 136, "8 HS", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 219, 1 },
                    { 137, "8 HS", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 221, 1 },
                    { 138, "11 HS", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 218, 1 }
                });

            migrationBuilder.InsertData(
                table: "detalleshorarios",
                columns: new[] { "Id", "Dia", "HoraId", "HorarioId" },
                values: new object[] { 1, 0, 1, 1 });

            migrationBuilder.InsertData(
                table: "detallesmesasexamenes",
                columns: new[] { "Id", "DocenteId", "MesaExamenId", "TipoIntegrante" },
                values: new object[,]
                {
                    { 1, 6, 1, 0 },
                    { 2, 66, 1, 1 },
                    { 3, 56, 1, 2 },
                    { 4, 16, 1, 3 },
                    { 5, 71, 2, 0 },
                    { 6, 43, 2, 1 },
                    { 7, 39, 2, 2 },
                    { 8, 66, 2, 3 },
                    { 9, 66, 3, 0 },
                    { 10, 45, 3, 1 },
                    { 11, 39, 3, 2 },
                    { 12, 28, 3, 3 },
                    { 13, 38, 4, 0 },
                    { 14, 53, 4, 1 },
                    { 15, 6, 4, 2 },
                    { 16, 23, 4, 3 },
                    { 17, 11, 5, 0 },
                    { 18, 58, 5, 1 },
                    { 19, 54, 5, 2 },
                    { 20, 56, 5, 3 },
                    { 21, 47, 6, 0 },
                    { 22, 16, 6, 1 },
                    { 23, 73, 6, 2 },
                    { 24, 16, 6, 3 },
                    { 25, 39, 7, 0 },
                    { 26, 66, 7, 1 },
                    { 27, 45, 7, 2 },
                    { 28, 28, 7, 3 },
                    { 29, 28, 8, 0 },
                    { 30, 73, 8, 1 },
                    { 31, 39, 8, 2 },
                    { 32, 23, 8, 3 },
                    { 33, 73, 9, 0 },
                    { 34, 16, 9, 1 },
                    { 35, 6, 9, 2 },
                    { 36, 56, 9, 3 },
                    { 37, 16, 10, 0 },
                    { 38, 47, 10, 1 },
                    { 39, 73, 10, 2 },
                    { 40, 16, 10, 3 },
                    { 41, 56, 11, 0 },
                    { 42, 6, 11, 1 },
                    { 43, 66, 11, 2 },
                    { 44, 53, 11, 3 },
                    { 45, 43, 12, 0 },
                    { 46, 71, 12, 1 },
                    { 47, 39, 12, 2 },
                    { 48, 66, 12, 3 },
                    { 49, 73, 13, 0 },
                    { 50, 28, 13, 1 },
                    { 51, 39, 13, 2 },
                    { 52, 23, 13, 3 },
                    { 53, 39, 14, 0 },
                    { 54, 66, 14, 1 },
                    { 55, 72, 14, 2 },
                    { 56, 56, 14, 3 },
                    { 57, 39, 15, 0 },
                    { 58, 71, 15, 1 },
                    { 59, 43, 15, 2 },
                    { 60, 66, 15, 3 },
                    { 61, 45, 16, 0 },
                    { 62, 66, 16, 1 },
                    { 63, 39, 16, 2 },
                    { 64, 28, 16, 3 },
                    { 65, 16, 17, 0 },
                    { 66, 73, 17, 1 },
                    { 67, 6, 17, 2 },
                    { 68, 56, 17, 3 },
                    { 69, 57, 18, 0 },
                    { 70, 37, 18, 1 },
                    { 71, 11, 18, 2 },
                    { 72, 59, 18, 3 },
                    { 73, 64, 19, 0 },
                    { 74, 59, 19, 1 },
                    { 75, 37, 19, 2 },
                    { 76, 31, 19, 3 },
                    { 77, 47, 20, 0 },
                    { 78, 22, 20, 1 },
                    { 79, 34, 20, 2 },
                    { 80, 64, 20, 3 },
                    { 81, 15, 21, 0 },
                    { 82, 59, 21, 1 },
                    { 83, 5, 21, 2 },
                    { 84, 53, 21, 3 },
                    { 85, 5, 22, 0 },
                    { 86, 4, 22, 1 },
                    { 87, 59, 22, 2 },
                    { 88, 57, 22, 3 },
                    { 89, 53, 23, 0 },
                    { 90, 4, 23, 1 },
                    { 91, 5, 23, 2 },
                    { 92, 34, 23, 3 },
                    { 93, 31, 24, 0 },
                    { 94, 64, 24, 1 },
                    { 95, 59, 24, 2 },
                    { 96, 59, 24, 3 },
                    { 97, 31, 25, 0 },
                    { 98, 64, 25, 1 },
                    { 99, 59, 25, 2 },
                    { 100, 59, 25, 3 },
                    { 101, 11, 26, 0 },
                    { 102, 22, 26, 1 },
                    { 103, 34, 26, 2 },
                    { 104, 15, 26, 3 },
                    { 105, 22, 27, 0 },
                    { 106, 34, 27, 1 },
                    { 107, 11, 27, 2 },
                    { 108, 15, 27, 3 },
                    { 109, 22, 28, 0 },
                    { 110, 34, 28, 1 },
                    { 111, 11, 28, 2 },
                    { 112, 15, 28, 3 },
                    { 113, 37, 29, 0 },
                    { 114, 57, 29, 1 },
                    { 115, 11, 29, 2 },
                    { 116, 57, 29, 3 },
                    { 117, 59, 30, 0 },
                    { 118, 15, 30, 1 },
                    { 119, 34, 30, 2 },
                    { 120, 53, 30, 3 },
                    { 121, 4, 31, 0 },
                    { 122, 5, 31, 1 },
                    { 123, 59, 31, 2 },
                    { 124, 57, 31, 3 },
                    { 125, 59, 32, 0 },
                    { 126, 53, 32, 1 },
                    { 127, 31, 32, 2 },
                    { 128, 34, 32, 3 },
                    { 129, 59, 33, 0 },
                    { 130, 15, 33, 1 },
                    { 131, 34, 33, 2 },
                    { 132, 53, 33, 3 },
                    { 133, 7, 34, 0 },
                    { 134, 57, 34, 1 },
                    { 135, 15, 34, 2 },
                    { 136, 15, 34, 3 },
                    { 137, 59, 35, 0 },
                    { 138, 4, 35, 1 },
                    { 139, 5, 35, 2 },
                    { 140, 57, 35, 3 },
                    { 141, 59, 36, 0 },
                    { 142, 53, 36, 1 },
                    { 143, 31, 36, 2 },
                    { 144, 34, 36, 3 },
                    { 145, 4, 37, 0 },
                    { 146, 46, 37, 1 },
                    { 147, 47, 37, 2 },
                    { 148, 59, 37, 3 },
                    { 149, 15, 38, 0 },
                    { 150, 47, 38, 1 },
                    { 151, 5, 38, 2 },
                    { 152, 21, 38, 3 },
                    { 153, 47, 39, 0 },
                    { 154, 15, 39, 1 },
                    { 155, 5, 39, 2 },
                    { 156, 21, 39, 3 },
                    { 157, 58, 40, 0 },
                    { 158, 11, 40, 1 },
                    { 159, 54, 40, 2 },
                    { 160, 46, 40, 3 },
                    { 161, 31, 41, 0 },
                    { 162, 64, 41, 1 },
                    { 163, 59, 41, 2 },
                    { 164, 58, 41, 3 },
                    { 165, 31, 42, 0 },
                    { 166, 64, 42, 1 },
                    { 167, 59, 42, 2 },
                    { 168, 58, 42, 3 },
                    { 169, 11, 43, 0 },
                    { 170, 22, 43, 1 },
                    { 171, 34, 43, 2 },
                    { 172, 46, 43, 3 },
                    { 173, 5, 44, 0 },
                    { 174, 47, 44, 1 },
                    { 175, 15, 44, 2 },
                    { 176, 21, 44, 3 },
                    { 177, 42, 45, 0 },
                    { 178, 46, 45, 1 },
                    { 179, 7, 45, 2 },
                    { 180, 53, 45, 3 },
                    { 181, 42, 46, 0 },
                    { 182, 46, 46, 1 },
                    { 183, 7, 46, 2 },
                    { 184, 53, 46, 3 },
                    { 185, 64, 47, 0 },
                    { 186, 21, 47, 1 },
                    { 187, 47, 47, 2 },
                    { 188, 46, 47, 3 },
                    { 189, 7, 48, 0 },
                    { 190, 46, 48, 1 },
                    { 191, 42, 48, 2 },
                    { 192, 53, 48, 3 },
                    { 193, 46, 49, 0 },
                    { 194, 7, 49, 1 },
                    { 195, 42, 49, 2 },
                    { 196, 53, 49, 3 },
                    { 197, 47, 50, 0 },
                    { 198, 60, 50, 1 },
                    { 199, 18, 50, 2 },
                    { 200, 67, 50, 3 },
                    { 201, 48, 51, 0 },
                    { 202, 2, 51, 1 },
                    { 203, 31, 51, 2 },
                    { 204, 28, 51, 3 },
                    { 205, 64, 52, 0 },
                    { 206, 63, 52, 1 },
                    { 207, 2, 52, 2 },
                    { 208, 33, 52, 3 },
                    { 209, 34, 53, 0 },
                    { 210, 67, 53, 1 },
                    { 211, 17, 53, 2 },
                    { 212, 47, 53, 3 },
                    { 213, 36, 54, 0 },
                    { 214, 29, 54, 1 },
                    { 215, 17, 54, 2 },
                    { 216, 48, 54, 3 },
                    { 217, 31, 55, 0 },
                    { 218, 47, 55, 1 },
                    { 219, 67, 55, 2 },
                    { 220, 2, 55, 3 },
                    { 221, 31, 56, 0 },
                    { 222, 47, 56, 1 },
                    { 223, 67, 56, 2 },
                    { 224, 2, 56, 3 },
                    { 225, 67, 57, 0 },
                    { 226, 48, 57, 1 },
                    { 227, 29, 57, 2 },
                    { 228, 28, 57, 3 },
                    { 229, 2, 58, 0 },
                    { 230, 60, 58, 1 },
                    { 231, 36, 58, 2 },
                    { 232, 28, 58, 3 },
                    { 233, 60, 59, 0 },
                    { 234, 47, 59, 1 },
                    { 235, 18, 59, 2 },
                    { 236, 67, 59, 3 },
                    { 237, 29, 60, 0 },
                    { 238, 7, 60, 1 },
                    { 239, 11, 60, 2 },
                    { 240, 37, 60, 3 },
                    { 241, 17, 61, 0 },
                    { 242, 18, 61, 1 },
                    { 243, 7, 61, 2 },
                    { 244, 29, 61, 3 },
                    { 245, 34, 62, 0 },
                    { 246, 18, 62, 1 },
                    { 247, 37, 62, 2 },
                    { 248, 33, 62, 3 },
                    { 249, 34, 63, 0 },
                    { 250, 48, 63, 1 },
                    { 251, 60, 63, 2 },
                    { 252, 47, 63, 3 },
                    { 253, 37, 64, 0 },
                    { 254, 7, 64, 1 },
                    { 255, 33, 64, 2 },
                    { 256, 48, 64, 3 },
                    { 257, 34, 65, 0 },
                    { 258, 18, 65, 1 },
                    { 259, 48, 65, 2 },
                    { 260, 2, 65, 3 },
                    { 261, 67, 66, 0 },
                    { 262, 48, 66, 1 },
                    { 263, 29, 66, 2 },
                    { 264, 29, 66, 3 },
                    { 265, 63, 67, 0 },
                    { 266, 34, 67, 1 },
                    { 267, 18, 67, 2 },
                    { 268, 29, 67, 3 },
                    { 269, 18, 68, 0 },
                    { 270, 17, 68, 1 },
                    { 271, 7, 68, 2 },
                    { 272, 29, 68, 3 },
                    { 273, 18, 69, 0 },
                    { 274, 34, 69, 1 },
                    { 275, 37, 69, 2 },
                    { 276, 29, 69, 3 },
                    { 277, 7, 70, 0 },
                    { 278, 37, 70, 1 },
                    { 279, 33, 70, 2 },
                    { 280, 48, 70, 3 },
                    { 281, 18, 71, 0 },
                    { 282, 34, 71, 1 },
                    { 283, 48, 71, 2 },
                    { 284, 2, 71, 3 },
                    { 285, 61, 72, 0 },
                    { 286, 9, 72, 1 },
                    { 287, 32, 72, 2 },
                    { 288, 3, 72, 3 },
                    { 289, 8, 73, 0 },
                    { 290, 9, 73, 1 },
                    { 291, 12, 73, 2 },
                    { 292, 61, 73, 3 },
                    { 293, 8, 74, 0 },
                    { 294, 9, 74, 1 },
                    { 295, 12, 74, 2 },
                    { 296, 61, 74, 3 },
                    { 297, 3, 75, 0 },
                    { 298, 61, 75, 1 },
                    { 299, 32, 75, 2 },
                    { 300, 9, 75, 3 },
                    { 301, 54, 76, 0 },
                    { 302, 51, 76, 1 },
                    { 303, 61, 76, 2 },
                    { 304, 3, 76, 3 },
                    { 305, 3, 77, 0 },
                    { 306, 51, 77, 1 },
                    { 307, 32, 77, 2 },
                    { 308, 12, 77, 3 },
                    { 309, 9, 78, 0 },
                    { 310, 61, 78, 1 },
                    { 311, 32, 78, 2 },
                    { 312, 3, 78, 3 },
                    { 313, 61, 79, 0 },
                    { 314, 7, 79, 1 },
                    { 315, 54, 79, 2 },
                    { 316, 61, 79, 3 },
                    { 317, 68, 80, 0 },
                    { 318, 24, 80, 1 },
                    { 319, 3, 80, 2 },
                    { 320, 25, 80, 3 },
                    { 321, 24, 81, 0 },
                    { 322, 68, 81, 1 },
                    { 323, 3, 81, 2 },
                    { 324, 25, 81, 3 },
                    { 325, 54, 82, 0 },
                    { 326, 3, 82, 1 },
                    { 327, 51, 82, 2 },
                    { 328, 61, 82, 3 },
                    { 329, 12, 83, 0 },
                    { 330, 49, 83, 1 },
                    { 331, 7, 83, 2 },
                    { 332, 3, 83, 3 },
                    { 333, 49, 84, 0 },
                    { 334, 12, 84, 1 },
                    { 335, 7, 84, 2 },
                    { 336, 3, 84, 3 },
                    { 337, 7, 85, 0 },
                    { 338, 61, 85, 1 },
                    { 339, 54, 85, 2 },
                    { 340, 61, 85, 3 },
                    { 341, 30, 86, 0 },
                    { 342, 35, 86, 1 },
                    { 343, 31, 86, 2 },
                    { 344, 61, 86, 3 },
                    { 345, 37, 87, 0 },
                    { 346, 68, 87, 1 },
                    { 347, 25, 87, 2 },
                    { 348, 25, 87, 3 },
                    { 349, 9, 88, 0 },
                    { 350, 32, 88, 1 },
                    { 351, 51, 88, 2 },
                    { 352, 3, 88, 3 },
                    { 353, 3, 89, 0 },
                    { 354, 54, 89, 1 },
                    { 355, 51, 89, 2 },
                    { 356, 61, 89, 3 },
                    { 357, 61, 90, 0 },
                    { 358, 3, 90, 1 },
                    { 359, 32, 90, 2 },
                    { 360, 9, 90, 3 },
                    { 361, 25, 91, 0 },
                    { 362, 68, 91, 1 },
                    { 363, 51, 91, 2 },
                    { 364, 9, 91, 3 },
                    { 365, 39, 92, 0 },
                    { 366, 72, 92, 1 },
                    { 367, 20, 92, 2 },
                    { 368, 2, 92, 3 },
                    { 369, 28, 93, 0 },
                    { 370, 72, 93, 1 },
                    { 371, 17, 93, 2 },
                    { 372, 34, 93, 3 },
                    { 373, 17, 94, 0 },
                    { 374, 22, 94, 1 },
                    { 375, 44, 94, 2 },
                    { 376, 47, 94, 3 },
                    { 377, 17, 95, 0 },
                    { 378, 22, 95, 1 },
                    { 379, 44, 95, 2 },
                    { 380, 47, 95, 3 },
                    { 381, 42, 96, 0 },
                    { 382, 71, 96, 1 },
                    { 383, 60, 96, 2 },
                    { 384, 48, 96, 3 },
                    { 385, 34, 97, 0 },
                    { 386, 48, 97, 1 },
                    { 387, 44, 97, 2 },
                    { 388, 22, 97, 3 },
                    { 389, 44, 98, 0 },
                    { 390, 48, 98, 1 },
                    { 391, 34, 98, 2 },
                    { 392, 22, 98, 3 },
                    { 393, 60, 99, 0 },
                    { 394, 28, 99, 1 },
                    { 395, 55, 99, 2 },
                    { 396, 28, 99, 3 },
                    { 397, 72, 100, 0 },
                    { 398, 39, 100, 1 },
                    { 399, 20, 100, 2 },
                    { 400, 34, 100, 3 },
                    { 401, 11, 101, 0 },
                    { 402, 30, 101, 1 },
                    { 403, 31, 101, 2 },
                    { 404, 36, 101, 3 },
                    { 405, 30, 102, 0 },
                    { 406, 11, 102, 1 },
                    { 407, 31, 102, 2 },
                    { 408, 36, 102, 3 },
                    { 409, 49, 103, 0 },
                    { 410, 28, 103, 1 },
                    { 411, 71, 103, 2 },
                    { 412, 2, 103, 3 },
                    { 413, 60, 104, 0 },
                    { 414, 42, 104, 1 },
                    { 415, 71, 104, 2 },
                    { 416, 48, 104, 3 },
                    { 417, 28, 105, 0 },
                    { 418, 64, 105, 1 },
                    { 419, 30, 105, 2 },
                    { 420, 17, 105, 3 },
                    { 421, 34, 106, 0 },
                    { 422, 48, 106, 1 },
                    { 423, 44, 106, 2 },
                    { 424, 22, 106, 3 },
                    { 425, 72, 107, 0 },
                    { 426, 28, 107, 1 },
                    { 427, 17, 107, 2 },
                    { 428, 34, 107, 3 },
                    { 429, 22, 108, 0 },
                    { 430, 17, 108, 1 },
                    { 431, 44, 108, 2 },
                    { 432, 47, 108, 3 },
                    { 433, 30, 109, 0 },
                    { 434, 11, 109, 1 },
                    { 435, 31, 109, 2 },
                    { 436, 36, 109, 3 },
                    { 437, 28, 110, 0 },
                    { 438, 49, 110, 1 },
                    { 439, 71, 110, 2 },
                    { 440, 2, 110, 3 },
                    { 441, 71, 111, 0 },
                    { 442, 42, 111, 1 },
                    { 443, 60, 111, 2 },
                    { 444, 48, 111, 3 },
                    { 445, 28, 112, 0 },
                    { 446, 60, 112, 1 },
                    { 447, 55, 112, 2 },
                    { 448, 27, 112, 3 },
                    { 449, 64, 113, 0 },
                    { 450, 28, 113, 1 },
                    { 451, 30, 113, 2 },
                    { 452, 17, 113, 3 },
                    { 453, 48, 114, 0 },
                    { 454, 44, 114, 1 },
                    { 455, 34, 114, 2 },
                    { 456, 22, 114, 3 },
                    { 457, 42, 115, 0 },
                    { 458, 54, 115, 1 },
                    { 459, 31, 115, 2 },
                    { 460, 44, 115, 3 },
                    { 461, 54, 116, 0 },
                    { 462, 42, 116, 1 },
                    { 463, 31, 116, 2 },
                    { 464, 44, 116, 3 },
                    { 465, 49, 117, 0 },
                    { 466, 69, 117, 1 },
                    { 467, 72, 117, 2 },
                    { 468, 10, 117, 3 },
                    { 469, 43, 118, 0 },
                    { 470, 49, 118, 1 },
                    { 471, 54, 118, 2 },
                    { 472, 36, 118, 3 },
                    { 473, 10, 119, 0 },
                    { 474, 13, 119, 1 },
                    { 475, 65, 119, 2 },
                    { 476, 69, 119, 3 },
                    { 477, 73, 120, 0 },
                    { 478, 40, 120, 1 },
                    { 479, 10, 120, 2 },
                    { 480, 72, 120, 3 },
                    { 481, 54, 121, 0 },
                    { 482, 42, 121, 1 },
                    { 483, 31, 121, 2 },
                    { 484, 44, 121, 3 },
                    { 485, 69, 122, 0 },
                    { 486, 49, 122, 1 },
                    { 487, 72, 122, 2 },
                    { 488, 10, 122, 3 },
                    { 489, 49, 123, 0 },
                    { 490, 43, 123, 1 },
                    { 491, 54, 123, 2 },
                    { 492, 36, 123, 3 },
                    { 493, 13, 124, 0 },
                    { 494, 10, 124, 1 },
                    { 495, 65, 124, 2 },
                    { 496, 69, 124, 3 },
                    { 497, 65, 125, 0 },
                    { 498, 10, 125, 1 },
                    { 499, 13, 125, 2 },
                    { 500, 69, 125, 3 },
                    { 501, 44, 126, 0 },
                    { 502, 11, 126, 1 },
                    { 503, 36, 126, 2 },
                    { 504, 49, 126, 3 },
                    { 505, 40, 127, 0 },
                    { 506, 73, 127, 1 },
                    { 507, 10, 127, 2 },
                    { 508, 72, 127, 3 },
                    { 509, 69, 128, 0 },
                    { 510, 52, 128, 1 },
                    { 511, 42, 128, 2 },
                    { 512, 54, 128, 3 },
                    { 513, 21, 129, 0 },
                    { 514, 68, 129, 1 },
                    { 515, 19, 129, 2 },
                    { 516, 54, 129, 3 },
                    { 517, 27, 130, 0 },
                    { 518, 39, 130, 1 },
                    { 519, 14, 130, 2 },
                    { 520, 54, 130, 3 },
                    { 521, 44, 131, 0 },
                    { 522, 11, 131, 1 },
                    { 523, 19, 131, 2 },
                    { 524, 54, 131, 3 },
                    { 525, 72, 132, 0 },
                    { 526, 71, 132, 1 },
                    { 527, 50, 132, 2 },
                    { 528, 3, 132, 3 },
                    { 529, 39, 133, 0 },
                    { 530, 60, 133, 1 },
                    { 531, 27, 133, 2 },
                    { 532, 12, 133, 3 },
                    { 533, 39, 134, 0 },
                    { 534, 60, 134, 1 },
                    { 535, 27, 134, 2 },
                    { 536, 62, 134, 3 },
                    { 537, 39, 135, 0 },
                    { 538, 60, 135, 1 },
                    { 539, 27, 135, 2 },
                    { 540, 62, 135, 3 },
                    { 541, 64, 136, 0 },
                    { 542, 2, 136, 1 },
                    { 543, 60, 136, 2 },
                    { 544, 54, 136, 3 },
                    { 545, 71, 137, 0 },
                    { 546, 50, 137, 1 },
                    { 547, 72, 137, 2 },
                    { 548, 30, 137, 3 },
                    { 549, 39, 138, 0 },
                    { 550, 27, 138, 1 },
                    { 551, 14, 138, 2 },
                    { 552, 12, 138, 3 }
                });

            migrationBuilder.InsertData(
                table: "integranteshorarios",
                columns: new[] { "Id", "DocenteId", "HorarioId" },
                values: new object[] { 1, 1, 1 });

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
