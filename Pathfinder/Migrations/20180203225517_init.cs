using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PathfinderCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alignement",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    description = table.Column<string>(type: "varchar(1000)", nullable: true),
                    nom = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alignement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "caracteristique",
                columns: table => new
                {
                    nom_court = table.Column<string>(type: "varchar(5)", nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", nullable: true),
                    nom = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristique", x => x.nom_court);
                });

            migrationBuilder.CreateTable(
                name: "courbe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    nom = table.Column<string>(type: "varchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courbe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "don",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_don", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dv",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    nom = table.Column<string>(type: "varchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dv", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ouvrage",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    nom = table.Column<string>(type: "varchar(50)", nullable: false),
                    nom_slug = table.Column<string>(type: "varchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ouvrage", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "personnage",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    nom = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personnage", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "special",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_special", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    login = table.Column<string>(type: "varchar(50)", nullable: false),
                    password_hash = table.Column<byte[]>(type: "Binary", maxLength: 16, nullable: false),
                    password_salt = table.Column<byte[]>(type: "Binary", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateur", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "competence",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    caracteristique = table.Column<int>(nullable: false),
                    CaracteristiqueId1 = table.Column<string>(nullable: true),
                    nom = table.Column<string>(type: "varchar(50)", nullable: false),
                    penalite_armure = table.Column<bool>(type: "bit", nullable: false),
                    sans_formation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competence", x => x.id);
                    table.ForeignKey(
                        name: "FK_competence_caracteristique_CaracteristiqueId1",
                        column: x => x.CaracteristiqueId1,
                        principalTable: "caracteristique",
                        principalColumn: "nom_court",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "statistique",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    courbe = table.Column<int>(nullable: false),
                    niveau = table.Column<int>(type: "tinyint", nullable: false),
                    valeur = table.Column<int>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statistique", x => x.id);
                    table.ForeignKey(
                        name: "FK_statistique_courbe_courbe",
                        column: x => x.courbe,
                        principalTable: "courbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    bba = table.Column<int>(nullable: false),
                    dv = table.Column<int>(nullable: false),
                    nom = table.Column<string>(type: "varchar(50)", nullable: false),
                    ouvrage = table.Column<int>(nullable: false),
                    reflexe = table.Column<int>(nullable: false),
                    vigueur = table.Column<int>(nullable: false),
                    volonte = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_classe_courbe_bba",
                        column: x => x.bba,
                        principalTable: "courbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classe_dv_dv",
                        column: x => x.dv,
                        principalTable: "dv",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classe_ouvrage_ouvrage",
                        column: x => x.ouvrage,
                        principalTable: "ouvrage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classe_courbe_reflexe",
                        column: x => x.reflexe,
                        principalTable: "courbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classe_courbe_vigueur",
                        column: x => x.vigueur,
                        principalTable: "courbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classe_courbe_volonte",
                        column: x => x.volonte,
                        principalTable: "courbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "race",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    alignement_religion = table.Column<string>(type: "text", nullable: true),
                    aventurier = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    description_physique = table.Column<string>(type: "text", nullable: true),
                    description_plus = table.Column<string>(type: "text", nullable: true),
                    nom = table.Column<string>(type: "varchar(50)", nullable: false),
                    nom_slug = table.Column<string>(type: "varchar(50)", nullable: true),
                    ouvrage = table.Column<int>(nullable: false),
                    relation = table.Column<string>(type: "text", nullable: true),
                    societe = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race", x => x.id);
                    table.ForeignKey(
                        name: "FK_race_ouvrage_ouvrage",
                        column: x => x.ouvrage,
                        principalTable: "ouvrage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classe_alignement",
                columns: table => new
                {
                    classe_id = table.Column<int>(nullable: false),
                    alignement_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classe_alignement", x => new { x.classe_id, x.alignement_id });
                    table.ForeignKey(
                        name: "FK_classe_alignement_alignement_alignement_id",
                        column: x => x.alignement_id,
                        principalTable: "alignement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classe_alignement_classe_classe_id",
                        column: x => x.classe_id,
                        principalTable: "classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classe_bba",
                table: "classe",
                column: "bba");

            migrationBuilder.CreateIndex(
                name: "IX_classe_dv",
                table: "classe",
                column: "dv");

            migrationBuilder.CreateIndex(
                name: "IX_classe_ouvrage",
                table: "classe",
                column: "ouvrage");

            migrationBuilder.CreateIndex(
                name: "IX_classe_reflexe",
                table: "classe",
                column: "reflexe");

            migrationBuilder.CreateIndex(
                name: "IX_classe_vigueur",
                table: "classe",
                column: "vigueur");

            migrationBuilder.CreateIndex(
                name: "IX_classe_volonte",
                table: "classe",
                column: "volonte");

            migrationBuilder.CreateIndex(
                name: "IX_classe_alignement_alignement_id",
                table: "classe_alignement",
                column: "alignement_id");

            migrationBuilder.CreateIndex(
                name: "IX_competence_CaracteristiqueId1",
                table: "competence",
                column: "CaracteristiqueId1");

            migrationBuilder.CreateIndex(
                name: "IX_race_ouvrage",
                table: "race",
                column: "ouvrage");

            migrationBuilder.CreateIndex(
                name: "IX_statistique_courbe",
                table: "statistique",
                column: "courbe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classe_alignement");

            migrationBuilder.DropTable(
                name: "competence");

            migrationBuilder.DropTable(
                name: "don");

            migrationBuilder.DropTable(
                name: "personnage");

            migrationBuilder.DropTable(
                name: "race");

            migrationBuilder.DropTable(
                name: "special");

            migrationBuilder.DropTable(
                name: "statistique");

            migrationBuilder.DropTable(
                name: "utilisateur");

            migrationBuilder.DropTable(
                name: "alignement");

            migrationBuilder.DropTable(
                name: "classe");

            migrationBuilder.DropTable(
                name: "caracteristique");

            migrationBuilder.DropTable(
                name: "courbe");

            migrationBuilder.DropTable(
                name: "dv");

            migrationBuilder.DropTable(
                name: "ouvrage");
        }
    }
}
