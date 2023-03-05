using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Balance.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accruals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accruals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accruals_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccrualId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryAmounts_Accruals_AccrualId",
                        column: x => x.AccrualId,
                        principalTable: "Accruals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                column: "Id",
                value: 808251);

            migrationBuilder.InsertData(
                table: "Accruals",
                columns: new[] { "Id", "AccountId", "Amount", "DateTime" },
                values: new object[,]
                {
                    { 1, 808251, 3206.69m, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 808251, 2708.58m, new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 808251, 4186.33m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 808251, 4117.3m, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 808251, 3744.13m, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 808251, 3736.89m, new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 808251, 4133.56m, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 808251, 2362.34m, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 808251, 3314.17m, new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 808251, 3812.3m, new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 808251, 4094.2m, new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 808251, 4198.42m, new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 808251, 4035.72m, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 808251, 4217.02m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 808251, 4196.03m, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 808251, 1475.39m, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 808251, 4405.54m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 808251, 1422.11m, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 808251, 3996.37m, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 808251, 1425.48m, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 808251, 3618.13m, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 808251, 4253.45m, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 808251, 4712.1m, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 808251, 2756.79m, new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 808251, 3672.17m, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 808251, 3702.91m, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 808251, 3872.25m, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AccountId", "Amount", "DateTime", "Guid" },
                values: new object[,]
                {
                    { 1, 808251, 100m, new DateTime(2019, 2, 22, 9, 25, 0, 0, DateTimeKind.Unspecified), new Guid("ded84f45-aa79-4e10-ae1c-9f1ee4062709") },
                    { 2, 808251, 8840.63m, new DateTime(2019, 2, 2, 14, 50, 32, 0, DateTimeKind.Unspecified), new Guid("ff18a790-f9c3-440c-9f9b-7e085a6531e6") },
                    { 3, 808251, 4612.1m, new DateTime(2019, 3, 15, 21, 6, 10, 0, DateTimeKind.Unspecified), new Guid("a1a85f99-8e1c-4a70-901e-eab334e3bc12") },
                    { 4, 808251, 4117.3m, new DateTime(2019, 4, 6, 8, 47, 8, 0, DateTimeKind.Unspecified), new Guid("29bd3151-c2b0-467a-a32c-d7df6ea8a495") },
                    { 5, 808251, 3744.13m, new DateTime(2019, 5, 21, 20, 51, 43, 0, DateTimeKind.Unspecified), new Guid("d8c1da6b-1cfd-4b5b-bfa7-ff6e553372e4") },
                    { 6, 808251, 6493.68m, new DateTime(2019, 7, 1, 20, 5, 23, 0, DateTimeKind.Unspecified), new Guid("9291f910-b160-471f-8cdf-56d7dbbf78ba") },
                    { 7, 808251, 2708.58m, new DateTime(2019, 8, 8, 8, 47, 43, 0, DateTimeKind.Unspecified), new Guid("b5b7c9e5-f2c6-400f-b708-b1b42c9652c5") },
                    { 8, 808251, 1m, new DateTime(2019, 8, 8, 10, 19, 46, 0, DateTimeKind.Unspecified), new Guid("34168b38-c77c-4474-a440-0f74e980e978") },
                    { 9, 808251, 2361.34m, new DateTime(2019, 9, 10, 21, 45, 30, 0, DateTimeKind.Unspecified), new Guid("fffe8706-9779-4be0-b836-5b074c779e6a") },
                    { 10, 808251, 3314.17m, new DateTime(2019, 10, 1, 21, 30, 36, 0, DateTimeKind.Unspecified), new Guid("7cf9e5d2-1a09-400c-a4b4-d5aecc8c760e") },
                    { 11, 808251, 4034.72m, new DateTime(2021, 1, 7, 9, 56, 23, 0, DateTimeKind.Unspecified), new Guid("6cb33594-dd8a-4d86-9db8-85e7488b80d3") },
                    { 12, 808251, 1m, new DateTime(2021, 1, 13, 12, 45, 1, 0, DateTimeKind.Unspecified), new Guid("9ec11c18-7e05-41cd-a3cf-8d2d9e4309fb") },
                    { 13, 808251, 10m, new DateTime(2021, 1, 13, 12, 37, 2, 0, DateTimeKind.Unspecified), new Guid("fb6882bc-a5f3-466c-9655-7d296f2c8103") },
                    { 14, 808251, 1m, new DateTime(2021, 1, 13, 12, 38, 45, 0, DateTimeKind.Unspecified), new Guid("aaa2ff85-fb86-4794-b53b-5d8f51eb6206") },
                    { 15, 808251, 10m, new DateTime(2020, 7, 24, 16, 35, 32, 0, DateTimeKind.Unspecified), new Guid("a97c9733-9961-4994-9eef-cd69478040c4") },
                    { 16, 808251, 10m, new DateTime(2020, 7, 8, 10, 51, 53, 0, DateTimeKind.Unspecified), new Guid("9800b5ee-f0b1-4bdd-863c-2eccf7482ca8") },
                    { 17, 808251, 1425.48m, new DateTime(2020, 7, 3, 14, 5, 58, 0, DateTimeKind.Unspecified), new Guid("acb7f497-d3d2-44a9-9f41-a80d6bcb4d94") },
                    { 18, 808251, 10m, new DateTime(2020, 5, 27, 11, 3, 47, 0, DateTimeKind.Unspecified), new Guid("e1281c35-283f-48bc-a4f7-e66af74dee3a") },
                    { 19, 808251, 10m, new DateTime(2020, 5, 21, 12, 12, 2, 0, DateTimeKind.Unspecified), new Guid("c55c137c-3c89-4aa5-8451-cffbb7828a6f") },
                    { 20, 808251, 1m, new DateTime(2020, 5, 21, 12, 13, 52, 0, DateTimeKind.Unspecified), new Guid("1b540330-4be2-4369-9944-4710ecc49dd9") },
                    { 21, 808251, 100m, new DateTime(2020, 5, 19, 20, 40, 21, 0, DateTimeKind.Unspecified), new Guid("e10d8845-dbb6-437e-b47c-657f5225d01d") },
                    { 22, 808251, 10m, new DateTime(2020, 5, 15, 14, 19, 48, 0, DateTimeKind.Unspecified), new Guid("2bd2da3a-c6ed-463b-9135-159520399804") },
                    { 23, 808251, 15m, new DateTime(2020, 5, 15, 14, 20, 19, 0, DateTimeKind.Unspecified), new Guid("5721a487-70d6-4fa7-a81a-d9f52002052b") },
                    { 24, 808251, 1000m, new DateTime(2020, 5, 20, 8, 55, 18, 0, DateTimeKind.Unspecified), new Guid("ff577d1a-6781-46d6-973b-bf4cb703fe3a") },
                    { 25, 808251, 165m, new DateTime(2020, 5, 21, 12, 13, 14, 0, DateTimeKind.Unspecified), new Guid("f514b40c-095e-4e9b-b3c3-cd4d0774ff95") },
                    { 26, 808251, 29.39m, new DateTime(2020, 5, 15, 14, 21, 9, 0, DateTimeKind.Unspecified), new Guid("f6f5c6fb-e6ae-473d-bf70-f32e7472d7a6") },
                    { 27, 808251, 125m, new DateTime(2020, 5, 19, 20, 40, 45, 0, DateTimeKind.Unspecified), new Guid("14f65234-54eb-4ca7-bd46-ec9b9a4ed2dc") },
                    { 28, 808251, 3812.3m, new DateTime(2019, 11, 1, 10, 3, 5, 0, DateTimeKind.Unspecified), new Guid("c4858527-5edc-45df-a01c-c630901f23bf") },
                    { 29, 808251, 4094.2m, new DateTime(2019, 12, 2, 13, 29, 17, 0, DateTimeKind.Unspecified), new Guid("e3327b59-4bb5-4a35-a049-45447d7a1a33") },
                    { 30, 808251, 4198.42m, new DateTime(2020, 1, 10, 20, 56, 14, 0, DateTimeKind.Unspecified), new Guid("992d1d03-7b6b-4d09-8bcc-9061f272d7a5") },
                    { 31, 808251, 20m, new DateTime(2020, 1, 30, 0, 35, 27, 0, DateTimeKind.Unspecified), new Guid("a67d331a-30a6-4b76-9937-e65a2be876b8") },
                    { 32, 808251, 4217.02m, new DateTime(2020, 2, 1, 12, 33, 7, 0, DateTimeKind.Unspecified), new Guid("0b4120f3-efa1-4243-9862-e264e3d879c7") },
                    { 33, 808251, 1411.11m, new DateTime(2020, 6, 19, 13, 29, 30, 0, DateTimeKind.Unspecified), new Guid("81dd2abd-cc90-466d-9442-8853d3c4d64e") },
                    { 34, 808251, 1m, new DateTime(2020, 4, 21, 12, 5, 18, 0, DateTimeKind.Unspecified), new Guid("d03f927a-6cff-4c27-9b94-958eed4a9f63") },
                    { 35, 808251, 10m, new DateTime(2020, 4, 21, 12, 7, 18, 0, DateTimeKind.Unspecified), new Guid("69ae0749-c20a-413e-8b13-5a22ce1eb32a") },
                    { 36, 808251, 10m, new DateTime(2020, 4, 21, 12, 4, 32, 0, DateTimeKind.Unspecified), new Guid("ab8c3615-6e3d-45d9-ba28-47b1d8f6e21c") },
                    { 37, 808251, 7382.72m, new DateTime(2020, 4, 1, 14, 28, 35, 0, DateTimeKind.Unspecified), new Guid("df2740ec-9436-4271-959f-2c0c2531e8b0") },
                    { 38, 808251, 3702.91m, new DateTime(2020, 11, 18, 19, 32, 30, 0, DateTimeKind.Unspecified), new Guid("124e2884-a800-4a18-9c55-af95d7dbb29a") },
                    { 39, 808251, 3598.13m, new DateTime(2020, 8, 5, 11, 1, 52, 0, DateTimeKind.Unspecified), new Guid("a8920cef-5d6a-437f-8ba6-f2591bd18790") },
                    { 40, 808251, 10m, new DateTime(2020, 8, 11, 12, 46, 45, 0, DateTimeKind.Unspecified), new Guid("c93331fa-175c-491a-9f1b-cf8242a6ab05") },
                    { 41, 808251, 3672.17m, new DateTime(2020, 10, 2, 14, 58, 46, 0, DateTimeKind.Unspecified), new Guid("71f1eba9-de8e-4599-8ecf-a3149bab1179") },
                    { 42, 808251, 4243.45m, new DateTime(2020, 9, 4, 16, 44, 15, 0, DateTimeKind.Unspecified), new Guid("82dcf303-1839-42de-aa37-bdb85c603cde") },
                    { 43, 808251, 3976.37m, new DateTime(2021, 4, 9, 22, 46, 4, 0, DateTimeKind.Unspecified), new Guid("6449bdcb-b5cc-421e-83fa-53fdbd27ea40") },
                    { 44, 808251, 4179.8m, new DateTime(2021, 2, 4, 19, 47, 51, 0, DateTimeKind.Unspecified), new Guid("6cc291bd-17c2-41f4-9396-32c5293dca58") },
                    { 45, 808251, 5m, new DateTime(2021, 2, 3, 17, 57, 48, 0, DateTimeKind.Unspecified), new Guid("649458aa-85ad-4809-8155-b8cb34c8e492") },
                    { 46, 808251, 10m, new DateTime(2021, 2, 3, 17, 55, 14, 0, DateTimeKind.Unspecified), new Guid("dcfa3aa7-c7fb-4a42-8ddf-5e7e063899b4") },
                    { 47, 808251, 43.54m, new DateTime(2021, 2, 3, 17, 53, 23, 0, DateTimeKind.Unspecified), new Guid("e113d4f9-8b6d-4b51-b144-d0ba3833a77c") },
                    { 48, 808251, 20m, new DateTime(2021, 2, 3, 20, 55, 20, 0, DateTimeKind.Unspecified), new Guid("7ac3e34d-55e6-45f6-8eb5-274969aa3f95") },
                    { 49, 808251, 12.2m, new DateTime(2021, 2, 3, 20, 50, 2, 0, DateTimeKind.Unspecified), new Guid("038fb8c2-d7a3-4cf7-a65b-1e7bef26e06c") },
                    { 50, 808251, 8m, new DateTime(2021, 2, 3, 19, 51, 6, 0, DateTimeKind.Unspecified), new Guid("19eb22bb-4160-48e5-b256-f9c6c183d5b5") },
                    { 51, 808251, 15m, new DateTime(2021, 2, 3, 20, 57, 0, 0, DateTimeKind.Unspecified), new Guid("b16f527c-f358-413b-bc26-eca3235caddf") },
                    { 52, 808251, 100m, new DateTime(2021, 2, 3, 17, 52, 44, 0, DateTimeKind.Unspecified), new Guid("ffd741ba-6a79-460e-90ba-aaf834e3d7e0") },
                    { 53, 808251, 3872.25m, new DateTime(2020, 12, 5, 15, 24, 57, 0, DateTimeKind.Unspecified), new Guid("d9af2afc-658b-4a82-aae6-1973f2bb4992") },
                    { 54, 808251, 1m, new DateTime(2020, 12, 28, 13, 9, 1, 0, DateTimeKind.Unspecified), new Guid("d5c26f52-219f-4e26-b84d-68d1cb04fdac") },
                    { 55, 808251, 4133.56m, new DateTime(2021, 3, 4, 14, 32, 23, 0, DateTimeKind.Unspecified), new Guid("459051e6-9c1a-4272-988e-6fc0162c2879") },
                    { 56, 808251, 10m, new DateTime(2021, 3, 30, 15, 50, 42, 0, DateTimeKind.Unspecified), new Guid("98698da6-7822-4f07-a735-6b9d4de4a8a4") },
                    { 57, 808251, 10m, new DateTime(2021, 3, 30, 16, 5, 7, 0, DateTimeKind.Unspecified), new Guid("a5b6c10f-165f-457d-acd2-afe87f5296f5") }
                });

            migrationBuilder.InsertData(
                table: "HistoryAmounts",
                columns: new[] { "Id", "AccrualId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 4176.03m },
                    { 2, 2, 6493.68m },
                    { 3, 3, 9480.45m },
                    { 4, 4, 4612.1m },
                    { 5, 5, 4117.3m },
                    { 6, 6, 3744.13m },
                    { 7, 7, 4393.54m },
                    { 8, 8, 0m },
                    { 9, 9, 2361.34m },
                    { 10, 10, 3314.17m },
                    { 11, 11, 3812.3m },
                    { 12, 12, 100m },
                    { 13, 13, 3872.25m },
                    { 14, 14, 4198.42m },
                    { 15, 15, 4197.02m },
                    { 16, 16, 150m },
                    { 17, 17, 4034.72m },
                    { 18, 18, 1454.39m },
                    { 19, 19, 90m },
                    { 20, 20, 1411.11m },
                    { 21, 21, 1425.48m },
                    { 22, 22, 850m },
                    { 23, 23, 8840.63m },
                    { 24, 24, 3736.89m },
                    { 25, 25, 4243.45m },
                    { 26, 26, 3672.17m },
                    { 27, 27, 3702.91m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accruals_AccountId",
                table: "Accruals",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAmounts_AccrualId",
                table: "HistoryAmounts",
                column: "AccrualId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AccountId",
                table: "Payments",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryAmounts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Accruals");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
