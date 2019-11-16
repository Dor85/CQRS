using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.Persistence.Migrations
{
    public partial class TaskResponsable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_People_AssignedId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_People_ResposableId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ResposableId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ResposableId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedId",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponsableId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tasks",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ResponsableId",
                table: "Tasks",
                column: "ResponsableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_People_AssignedId",
                table: "Tasks",
                column: "AssignedId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_People_ResponsableId",
                table: "Tasks",
                column: "ResponsableId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_People_AssignedId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_People_ResponsableId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ResponsableId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ResponsableId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ResposableId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ResposableId",
                table: "Tasks",
                column: "ResposableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_People_AssignedId",
                table: "Tasks",
                column: "AssignedId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_People_ResposableId",
                table: "Tasks",
                column: "ResposableId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
