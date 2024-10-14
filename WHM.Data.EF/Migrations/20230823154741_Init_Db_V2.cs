using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHM.Data.EF.Migrations
{
    public partial class Init_Db_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVip",
                table: "WHM_Client");

            migrationBuilder.AddColumn<short>(
                name: "RoleId",
                table: "WHM_Account",
                type: "smallint",
                nullable: false,
                defaultValue: (short)2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "WHM_Account");

            migrationBuilder.AddColumn<bool>(
                name: "IsVip",
                table: "WHM_Client",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
