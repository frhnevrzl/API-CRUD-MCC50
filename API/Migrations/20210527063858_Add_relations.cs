﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Add_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Person",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Person", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_University",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_University", x => x.UniversityId);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_Person_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Person",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Education",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Education", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_TB_M_Education_TB_M_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "TB_M_University",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Profiling",
                columns: table => new
                {
                    NIK = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Profiling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_T_Profiling_TB_M_Account_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_Profiling_TB_M_Education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "TB_M_Education",
                        principalColumn: "EducationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Education_UniversityId",
                table: "TB_M_Education",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Profiling_EducationId",
                table: "TB_T_Profiling",
                column: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_Profiling");

            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Education");

            migrationBuilder.DropTable(
                name: "TB_M_Person");

            migrationBuilder.DropTable(
                name: "TB_M_University");
        }
    }
}
