using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Beis.RegisterYourInterest.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uprn = table.Column<string>(type: "text", nullable: true),
                    address_line_1 = table.Column<string>(type: "text", nullable: true),
                    address_line_2 = table.Column<string>(type: "text", nullable: true),
                    town = table.Column<string>(type: "text", nullable: true),
                    county = table.Column<string>(type: "text", nullable: true),
                    postcode = table.Column<string>(type: "text", nullable: true),
                    custodian_code = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email_address = table.Column<string>(type: "text", nullable: false),
                    verification_code = table.Column<Guid>(type: "uuid", nullable: true),
                    verification_expiry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    email_verified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    applicant_phone_number = table.Column<string>(type: "text", nullable: true),
                    address_id1 = table.Column<int>(type: "integer", nullable: true),
                    address_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_Address_address_id1",
                        column: x => x.address_id1,
                        principalTable: "Address",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_address_id1",
                table: "users",
                column: "address_id1");

            migrationBuilder.CreateIndex(
                name: "IX_users_email_address",
                table: "users",
                column: "email_address",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
