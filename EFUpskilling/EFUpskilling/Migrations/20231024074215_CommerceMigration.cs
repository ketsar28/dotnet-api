using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFUpskilling.Migrations
{
    /// <inheritdoc />
    public partial class CommerceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "m_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    product_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    stock = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_product", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "m_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    customer_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    address = table.Column<string>(type: "varchar(255)", nullable: false),
                    mobile_phone = table.Column<string>(type: "varchar(255)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_user", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "m_purchase",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    trans_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_purchase", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_purchase_m_user_user_id",
                        column: x => x.user_id,
                        principalTable: "m_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "trx_purchase_detail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    purchase_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    product_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trx_purchase_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_trx_purchase_detail_m_product_product_id",
                        column: x => x.product_id,
                        principalTable: "m_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trx_purchase_detail_m_purchase_purchase_id",
                        column: x => x.purchase_id,
                        principalTable: "m_purchase",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_m_purchase_user_id",
                table: "m_purchase",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_trx_purchase_detail_product_id",
                table: "trx_purchase_detail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_trx_purchase_detail_purchase_id",
                table: "trx_purchase_detail",
                column: "purchase_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trx_purchase_detail");

            migrationBuilder.DropTable(
                name: "m_product");

            migrationBuilder.DropTable(
                name: "m_purchase");

            migrationBuilder.DropTable(
                name: "m_user");
        }
    }
}
