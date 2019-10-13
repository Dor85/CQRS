using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.Persistence.Migrations
{
    public partial class AddAddressPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "People",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "People");

            migrationBuilder.DropColumn(
                name: "State",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "People");
        }
    }
}
