using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "maitrise_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    libelle = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maitrise_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profil",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    description = table.Column<string>(type: "varchar(10)", nullable: false),
                    description_courte = table.Column<string>(type: "varchar(10)", nullable: false),
                    libelle = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profil", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "voie_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    libelle = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voie_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "voie",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    libelle = table.Column<string>(type: "varchar(10)", nullable: false),
                    TypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voie", x => x.id);
                    table.ForeignKey(
                        name: "FK_voie_voie_type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "voie_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "maitrise",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    description = table.Column<string>(type: "varchar(10)", nullable: false),
                    libelle = table.Column<string>(type: "varchar(10)", nullable: false),
                    niveau = table.Column<string>(type: "varchar(10)", nullable: false),
                    voieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maitrise", x => x.id);
                    table.ForeignKey(
                        name: "FK_maitrise_voie_voieId",
                        column: x => x.voieId,
                        principalTable: "voie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "voie_profil",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    id_voie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voie_profil", x => x.id);
                    table.ForeignKey(
                        name: "FK_voie_profil_voie_id_voie",
                        column: x => x.id_voie,
                        principalTable: "voie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "maitrise_maitrise_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    maitriseId = table.Column<int>(nullable: true),
                    maitriseTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maitrise_maitrise_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_maitrise_maitrise_type_maitrise_maitriseId",
                        column: x => x.maitriseId,
                        principalTable: "maitrise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_maitrise_maitrise_type_maitrise_type_maitriseTypeId",
                        column: x => x.maitriseTypeId,
                        principalTable: "maitrise_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_maitrise_voieId",
                table: "maitrise",
                column: "voieId");

            migrationBuilder.CreateIndex(
                name: "IX_maitrise_maitrise_type_maitriseId",
                table: "maitrise_maitrise_type",
                column: "maitriseId");

            migrationBuilder.CreateIndex(
                name: "IX_maitrise_maitrise_type_maitriseTypeId",
                table: "maitrise_maitrise_type",
                column: "maitriseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_voie_TypeId",
                table: "voie",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_voie_profil_id_voie",
                table: "voie_profil",
                column: "id_voie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "maitrise_maitrise_type");

            migrationBuilder.DropTable(
                name: "profil");

            migrationBuilder.DropTable(
                name: "voie_profil");

            migrationBuilder.DropTable(
                name: "maitrise");

            migrationBuilder.DropTable(
                name: "maitrise_type");

            migrationBuilder.DropTable(
                name: "voie");

            migrationBuilder.DropTable(
                name: "voie_type");
        }
    }
}
