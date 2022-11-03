using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDirectoryApi.Migrations
{
    public partial class PhoneNumberRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Persons_PersonId",
                table: "PhoneNumber");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "PhoneNumber",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Persons_PersonId",
                table: "PhoneNumber",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Persons_PersonId",
                table: "PhoneNumber");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "PhoneNumber",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Persons_PersonId",
                table: "PhoneNumber",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
