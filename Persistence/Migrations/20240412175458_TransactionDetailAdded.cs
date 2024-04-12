using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TransactionDetailAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    TransactionDetailId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionType = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransactionHeaderId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.TransactionDetailId);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_TransactionHeaders_TransactionHeaderId",
                        column: x => x.TransactionHeaderId,
                        principalTable: "TransactionHeaders",
                        principalColumn: "TransactionHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_CategoryId",
                table: "TransactionDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_TransactionHeaderId",
                table: "TransactionDetails",
                column: "TransactionHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDetails");
        }
    }
}
