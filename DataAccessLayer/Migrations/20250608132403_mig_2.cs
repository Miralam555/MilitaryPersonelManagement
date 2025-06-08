using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryPersonelRecognition_Injunctions_Injunctionİd",
                table: "MilitaryPersonelRecognition");

            migrationBuilder.RenameColumn(
                name: "Injunctionİd",
                table: "MilitaryPersonelRecognition",
                newName: "InjunctionId");

            migrationBuilder.RenameIndex(
                name: "IX_MilitaryPersonelRecognition_Injunctionİd",
                table: "MilitaryPersonelRecognition",
                newName: "IX_MilitaryPersonelRecognition_InjunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryPersonelRecognition_Injunctions_InjunctionId",
                table: "MilitaryPersonelRecognition",
                column: "InjunctionId",
                principalTable: "Injunctions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryPersonelRecognition_Injunctions_InjunctionId",
                table: "MilitaryPersonelRecognition");

            migrationBuilder.RenameColumn(
                name: "InjunctionId",
                table: "MilitaryPersonelRecognition",
                newName: "Injunctionİd");

            migrationBuilder.RenameIndex(
                name: "IX_MilitaryPersonelRecognition_InjunctionId",
                table: "MilitaryPersonelRecognition",
                newName: "IX_MilitaryPersonelRecognition_Injunctionİd");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryPersonelRecognition_Injunctions_Injunctionİd",
                table: "MilitaryPersonelRecognition",
                column: "Injunctionİd",
                principalTable: "Injunctions",
                principalColumn: "Id");
        }
    }
}
