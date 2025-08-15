using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationWideUserSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "SubCreditTypes");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "CreditTypes");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "CreditCalculationRules");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "CreditApprovalSteps");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "CreditApprovalHistories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "CreditApplications");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ApplicationUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "SubCreditTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "CreditTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "CreditCalculationRules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "CreditApprovalSteps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "CreditApprovalHistories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "CreditApplications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ApplicationUsers",
                type: "datetime2",
                nullable: true);
        }
    }
}
