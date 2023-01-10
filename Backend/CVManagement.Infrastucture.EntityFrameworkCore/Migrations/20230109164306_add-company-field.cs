using Microsoft.EntityFrameworkCore.Migrations;

namespace CVManagement.Infrastucture.EntityFrameworkCore.Migrations
{
    public partial class addcompanyfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_ExperienceInformations_ExperienceInformationId",
                table: "CVs");

            migrationBuilder.DropIndex(
                name: "IX_CVs_ExperienceInformationId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "ExperienceInformations");

            migrationBuilder.DropColumn(
                name: "ExperienceInformationId",
                table: "CVs");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PersonalInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "ExperienceInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyField",
                table: "ExperienceInformations",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExperienceInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CVs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceInformations_CVId",
                table: "ExperienceInformations",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceInformations_CVs_CVId",
                table: "ExperienceInformations",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceInformations_CVs_CVId",
                table: "ExperienceInformations");

            migrationBuilder.DropIndex(
                name: "IX_ExperienceInformations_CVId",
                table: "ExperienceInformations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PersonalInformations");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "ExperienceInformations");

            migrationBuilder.DropColumn(
                name: "CompanyField",
                table: "ExperienceInformations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExperienceInformations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CVs");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ExperienceInformations",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceInformationId",
                table: "CVs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CVs_ExperienceInformationId",
                table: "CVs",
                column: "ExperienceInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_ExperienceInformations_ExperienceInformationId",
                table: "CVs",
                column: "ExperienceInformationId",
                principalTable: "ExperienceInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
