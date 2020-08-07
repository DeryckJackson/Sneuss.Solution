using Microsoft.EntityFrameworkCore.Migrations;

namespace Sneuss.Migrations
{
    public partial class FixMachineIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_Machines_MachineId",
                table: "EngineerMachine");

            migrationBuilder.DropColumn(
                name: "MahchineId",
                table: "EngineerMachine");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "EngineerMachine",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_Machines_MachineId",
                table: "EngineerMachine",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_Machines_MachineId",
                table: "EngineerMachine");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "EngineerMachine",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MahchineId",
                table: "EngineerMachine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_Machines_MachineId",
                table: "EngineerMachine",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
