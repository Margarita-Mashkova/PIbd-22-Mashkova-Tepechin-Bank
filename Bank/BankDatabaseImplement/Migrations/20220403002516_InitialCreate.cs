using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankDatabaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clerks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClerkFIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clerks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerFIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientFIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClerkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Clerks_ClerkId",
                        column: x => x.ClerkId,
                        principalTable: "Clerks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepositInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClerkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposits_Clerks_ClerkId",
                        column: x => x.ClerkId,
                        principalTable: "Clerks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RubExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanPrograms_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DepositId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientDeposits_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientDeposits_Deposits_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Replenishments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateReplenishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepositId = table.Column<int>(type: "int", nullable: false),
                    ClerkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replenishments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replenishments_Clerks_ClerkId",
                        column: x => x.ClerkId,
                        principalTable: "Clerks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Replenishments_Deposits_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DepositCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositCurrencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositCurrencies_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositCurrencies_Deposits_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientLoanPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    LoanProgramId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLoanPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientLoanPrograms_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientLoanPrograms_LoanPrograms_LoanProgramId",
                        column: x => x.LoanProgramId,
                        principalTable: "LoanPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanProgramCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    LoanProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProgramCurrencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanProgramCurrencies_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanProgramCurrencies_LoanPrograms_LoanProgramId",
                        column: x => x.LoanProgramId,
                        principalTable: "LoanPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTerm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTerm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanProgramId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terms_LoanPrograms_LoanProgramId",
                        column: x => x.LoanProgramId,
                        principalTable: "LoanPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terms_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeposits_ClientId",
                table: "ClientDeposits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDeposits_DepositId",
                table: "ClientDeposits",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoanPrograms_ClientId",
                table: "ClientLoanPrograms",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLoanPrograms_LoanProgramId",
                table: "ClientLoanPrograms",
                column: "LoanProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClerkId",
                table: "Clients",
                column: "ClerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_ManagerId",
                table: "Currencies",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositCurrencies_CurrencyId",
                table: "DepositCurrencies",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositCurrencies_DepositId",
                table: "DepositCurrencies",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_ClerkId",
                table: "Deposits",
                column: "ClerkId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProgramCurrencies_CurrencyId",
                table: "LoanProgramCurrencies",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProgramCurrencies_LoanProgramId",
                table: "LoanProgramCurrencies",
                column: "LoanProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPrograms_ManagerId",
                table: "LoanPrograms",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Replenishments_ClerkId",
                table: "Replenishments",
                column: "ClerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Replenishments_DepositId",
                table: "Replenishments",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_LoanProgramId",
                table: "Terms",
                column: "LoanProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_ManagerId",
                table: "Terms",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDeposits");

            migrationBuilder.DropTable(
                name: "ClientLoanPrograms");

            migrationBuilder.DropTable(
                name: "DepositCurrencies");

            migrationBuilder.DropTable(
                name: "LoanProgramCurrencies");

            migrationBuilder.DropTable(
                name: "Replenishments");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "LoanPrograms");

            migrationBuilder.DropTable(
                name: "Clerks");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
