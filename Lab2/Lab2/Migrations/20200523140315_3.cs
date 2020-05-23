using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab2.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Expenses_ExpensesId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comment_1");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ExpensesId",
                table: "Comment_1",
                newName: "IX_Comment_1_ExpensesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment_1",
                table: "Comment_1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_1_Expenses_ExpensesId",
                table: "Comment_1",
                column: "ExpensesId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_1_Expenses_ExpensesId",
                table: "Comment_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment_1",
                table: "Comment_1");

            migrationBuilder.RenameTable(
                name: "Comment_1",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_1_ExpensesId",
                table: "Comment",
                newName: "IX_Comment_ExpensesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Expenses_ExpensesId",
                table: "Comment",
                column: "ExpensesId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
