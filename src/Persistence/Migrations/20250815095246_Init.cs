using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinTerm = table.Column<int>(type: "int", nullable: false),
                    MaxTerm = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCreditTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessRequirements = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MinCompanyAge = table.Column<int>(type: "int", nullable: false),
                    MinAnnualRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequiredLicenses = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCreditTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCreditTypes_CreditTypes_Id",
                        column: x => x.Id,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditApprovalSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StepDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditApprovalSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditApprovalSteps_CreditTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditCalculationRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RuleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RuleDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    MinValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCalculationRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCalculationRules_CreditTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCreditTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequiredDocuments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MaxMonthlyIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCreditTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCreditTypes_CreditTypes_Id",
                        column: x => x.Id,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCreditTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SpecificInterestRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SpecialConditions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCreditTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCreditTypes_CreditTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    TradeRegistryNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactPersonPhone = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ContactPersonEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstablishmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCustomers_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomers_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCreditTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestedTerm = table.Column<int>(type: "int", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ApprovedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApprovedTerm = table.Column<int>(type: "int", nullable: true),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InterestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditApplications_CreditTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditApplications_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditApplications_SubCreditTypes_SubCreditTypeId",
                        column: x => x.SubCreditTypeId,
                        principalTable: "SubCreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCreditApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BusinessType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyAge = table.Column<int>(type: "int", nullable: false),
                    AnnualRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TradeRegistryNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCreditApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCreditApplications_CreditApplications_Id",
                        column: x => x.Id,
                        principalTable: "CreditApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditApprovalHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditApprovalStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditApprovalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditApprovalHistories_CreditApplications_CreditApplicationId",
                        column: x => x.CreditApplicationId,
                        principalTable: "CreditApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditApprovalHistories_CreditApprovalSteps_CreditApprovalStepId",
                        column: x => x.CreditApprovalStepId,
                        principalTable: "CreditApprovalSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCreditApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmploymentDuration = table.Column<int>(type: "int", nullable: false),
                    CollateralType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CollateralValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCreditApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCreditApplications_CreditApplications_Id",
                        column: x => x.Id,
                        principalTable: "CreditApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_CustomerId",
                table: "ApplicationUsers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_UserId",
                table: "ApplicationUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCreditApplications_BusinessType",
                table: "CorporateCreditApplications",
                column: "BusinessType");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCreditApplications_CompanyName",
                table: "CorporateCreditApplications",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCreditApplications_TaxNumber",
                table: "CorporateCreditApplications",
                column: "TaxNumber",
                unique: true,
                filter: "[TaxNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCreditApplications_TradeRegistryNumber",
                table: "CorporateCreditApplications",
                column: "TradeRegistryNumber",
                unique: true,
                filter: "[TradeRegistryNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCreditTypes_MinAnnualRevenue",
                table: "CorporateCreditTypes",
                column: "MinAnnualRevenue");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCreditTypes_MinCompanyAge",
                table: "CorporateCreditTypes",
                column: "MinCompanyAge");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomers_TaxNumber",
                table: "CorporateCustomers",
                column: "TaxNumber",
                unique: true,
                filter: "[TaxNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomers_TradeRegistryNumber",
                table: "CorporateCustomers",
                column: "TradeRegistryNumber",
                unique: true,
                filter: "[TradeRegistryNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_ApplicationDate",
                table: "CreditApplications",
                column: "ApplicationDate");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_CreditTypeId",
                table: "CreditApplications",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_CustomerId",
                table: "CreditApplications",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_Status",
                table: "CreditApplications",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_SubCreditTypeId",
                table: "CreditApplications",
                column: "SubCreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApprovalHistories_CreditApplicationId",
                table: "CreditApprovalHistories",
                column: "CreditApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApprovalHistories_CreditApprovalStepId",
                table: "CreditApprovalHistories",
                column: "CreditApprovalStepId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApprovalHistories_ProcessDate",
                table: "CreditApprovalHistories",
                column: "ProcessDate");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApprovalHistories_Status",
                table: "CreditApprovalHistories",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApprovalSteps_CreditTypeId",
                table: "CreditApprovalSteps",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApprovalSteps_IsActive",
                table: "CreditApprovalSteps",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApprovalSteps_Order",
                table: "CreditApprovalSteps",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApprovalSteps_Type",
                table: "CreditApprovalSteps",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCalculationRules_CreditTypeId",
                table: "CreditCalculationRules",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCalculationRules_IsActive",
                table: "CreditCalculationRules",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCalculationRules_Priority",
                table: "CreditCalculationRules",
                column: "Priority");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCalculationRules_Type",
                table: "CreditCalculationRules",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_CreditTypes_Category",
                table: "CreditTypes",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_CreditTypes_IsActive",
                table: "CreditTypes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CreditTypes_Name",
                table: "CreditTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerNumber",
                table: "Customers",
                column: "CustomerNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCreditApplications_EmploymentDuration",
                table: "IndividualCreditApplications",
                column: "EmploymentDuration");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCreditApplications_EmploymentType",
                table: "IndividualCreditApplications",
                column: "EmploymentType");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCreditTypes_MaxAge",
                table: "IndividualCreditTypes",
                column: "MaxAge");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCreditTypes_MinAge",
                table: "IndividualCreditTypes",
                column: "MinAge");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomers_NationalId",
                table: "IndividualCustomers",
                column: "NationalId",
                unique: true,
                filter: "[NationalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubCreditTypes_CreditTypeId",
                table: "SubCreditTypes",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCreditTypes_IsActive",
                table: "SubCreditTypes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_SubCreditTypes_Name",
                table: "SubCreditTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationId",
                table: "UserOperationClaims",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "CorporateCreditApplications");

            migrationBuilder.DropTable(
                name: "CorporateCreditTypes");

            migrationBuilder.DropTable(
                name: "CorporateCustomers");

            migrationBuilder.DropTable(
                name: "CreditApprovalHistories");

            migrationBuilder.DropTable(
                name: "CreditCalculationRules");

            migrationBuilder.DropTable(
                name: "IndividualCreditApplications");

            migrationBuilder.DropTable(
                name: "IndividualCreditTypes");

            migrationBuilder.DropTable(
                name: "IndividualCustomers");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "CreditApprovalSteps");

            migrationBuilder.DropTable(
                name: "CreditApplications");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SubCreditTypes");

            migrationBuilder.DropTable(
                name: "CreditTypes");
        }
    }
}
