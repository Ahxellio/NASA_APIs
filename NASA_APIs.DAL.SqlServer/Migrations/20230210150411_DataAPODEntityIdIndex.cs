using Microsoft.EntityFrameworkCore.Migrations;

namespace NASA_APIs.DAL.SqlServer.Migrations
{
    public partial class DataAPODEntityIdIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APODValues_Sources_SourceId",
                table: "APODValues");

            migrationBuilder.DropIndex(
                name: "IX_APODValues_Name",
                table: "APODValues");

            migrationBuilder.DropIndex(
                name: "IX_APODValues_SourceId",
                table: "APODValues");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "APODValues");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "APODValues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "APODValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "APODValues",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "APODValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "APODValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_APODValues_Id",
                table: "APODValues",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_APODValues_Title",
                table: "APODValues",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_APODValues_Id",
                table: "APODValues");

            migrationBuilder.DropIndex(
                name: "IX_APODValues_Title",
                table: "APODValues");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "APODValues");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "APODValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "APODValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "APODValues",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "APODValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "APODValues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_APODValues_Name",
                table: "APODValues",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_APODValues_SourceId",
                table: "APODValues",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_APODValues_Sources_SourceId",
                table: "APODValues",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
