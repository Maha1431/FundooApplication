using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Tabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<int>(type: "int", nullable: false),
                    adddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registereddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifieddate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Userid);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_users_Userid",
                        column: x => x.Userid,
                        principalTable: "users",
                        principalColumn: "Userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    noteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReminder = table.Column<bool>(type: "bit", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    IsTrash = table.Column<bool>(type: "bit", nullable: false),
                    IsPin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.noteId);
                    table.ForeignKey(
                        name: "FK_notes_users_Userid",
                        column: x => x.Userid,
                        principalTable: "users",
                        principalColumn: "Userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "label",
                columns: table => new
                {
                    labelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noteId = table.Column<int>(type: "int", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_label", x => x.labelId);
                    table.ForeignKey(
                        name: "FK_label_notes_noteId",
                        column: x => x.noteId,
                        principalTable: "notes",
                        principalColumn: "noteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_label_users_Userid",
                        column: x => x.Userid,
                        principalTable: "users",
                        principalColumn: "Userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Userid",
                table: "Address",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_label_noteId",
                table: "label",
                column: "noteId");

            migrationBuilder.CreateIndex(
                name: "IX_label_Userid",
                table: "label",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_notes_Userid",
                table: "notes",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "label");

            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
