using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApp.Infra.Data.Migrations
{
    public partial class editAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_Material_MaterialId",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "BillDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialId",
                table: "BillDetail",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_Material_MaterialId",
                table: "BillDetail",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_Material_MaterialId",
                table: "BillDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialId",
                table: "BillDetail",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldMaxLength: 40);

            migrationBuilder.AddColumn<Guid>(
                name: "MateriaId",
                table: "BillDetail",
                type: "uniqueidentifier",
                maxLength: 40,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_Material_MaterialId",
                table: "BillDetail",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
