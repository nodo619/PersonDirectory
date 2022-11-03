using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDirectoryApi.Migrations
{
    public partial class PersonToPersonRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonToPerson",
                columns: table => new
                {
                    SourcePersonId = table.Column<int>(type: "int", nullable: false),
                    RelatedPersonId = table.Column<int>(type: "int", nullable: false),
                    ConnectionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonToPerson", x => new { x.SourcePersonId, x.RelatedPersonId });
                    table.ForeignKey(
                        name: "FK_PersonToPerson_Persons_RelatedPersonId",
                        column: x => x.RelatedPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonToPerson_Persons_SourcePersonId",
                        column: x => x.SourcePersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonToPerson_RelatedPersonId",
                table: "PersonToPerson",
                column: "RelatedPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonToPerson");
        }
    }
}
