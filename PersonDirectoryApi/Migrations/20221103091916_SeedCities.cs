using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDirectoryApi.Migrations
{
    public partial class SeedCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Tbilisi')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('London')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Tokyo')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
