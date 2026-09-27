using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerImages_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo" },
                    { 2, "Alexandria" },
                    { 3, "Giza" },
                    { 4, "Qalyubia" },
                    { 5, "Dakahlia" },
                    { 6, "Sharqia" },
                    { 7, "Gharbia" },
                    { 8, "Monufia" },
                    { 9, "Beheira" },
                    { 10, "Kafr El Sheikh" },
                    { 11, "Damietta" },
                    { 12, "Port Said" },
                    { 13, "Ismailia" },
                    { 14, "Suez" },
                    { 15, "North Sinai" },
                    { 16, "South Sinai" },
                    { 17, "Beni Suef" },
                    { 18, "Faiyum" },
                    { 19, "Minya" },
                    { 20, "Assiut" },
                    { 21, "Sohag" },
                    { 22, "Qena" },
                    { 23, "Luxor" },
                    { 24, "Aswan" },
                    { 25, "Red Sea" },
                    { 26, "New Valley" },
                    { 27, "Matrouh" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "GovernorateId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Nasr City" },
                    { 2, 1, "Maadi" },
                    { 3, 1, "Heliopolis" },
                    { 4, 1, "Downtown Cairo" },
                    { 5, 1, "New Cairo" },
                    { 6, 2, "Sidi Gaber" },
                    { 7, 2, "Miami" },
                    { 8, 2, "Smouha" },
                    { 9, 2, "Montaza" },
                    { 10, 2, "Al Agamy" },
                    { 11, 3, "Dokki" },
                    { 12, 3, "Mohandessin" },
                    { 13, 3, "6th of October" },
                    { 14, 3, "Haram" },
                    { 15, 3, "Sheikh Zayed" },
                    { 16, 4, "Banha" },
                    { 17, 4, "Shubra El Kheima" },
                    { 18, 4, "Qalyub" },
                    { 19, 5, "Mansoura" },
                    { 20, 5, "Talkha" },
                    { 21, 5, "Mit Ghamr" },
                    { 22, 6, "Zagazig" },
                    { 23, 6, "10th of Ramadan" },
                    { 24, 6, "Belbeis" },
                    { 25, 7, "Tanta" },
                    { 26, 7, "Al Mahalla Al Kubra" },
                    { 27, 7, "Kafr El Zayat" },
                    { 28, 8, "Shibin El Kom" },
                    { 29, 8, "Menouf" },
                    { 30, 8, "Sadat City" },
                    { 31, 9, "Damanhur" },
                    { 32, 9, "Kafr El Dawwar" },
                    { 33, 9, "Rashid" },
                    { 34, 10, "Kafr El Sheikh City" },
                    { 35, 10, "Desouk" },
                    { 36, 10, "Baltim" },
                    { 37, 11, "Damietta City" },
                    { 38, 11, "Ras El Bar" },
                    { 39, 11, "Faraskur" },
                    { 40, 12, "Port Fouad" },
                    { 41, 12, "Al Manakh" },
                    { 42, 12, "Al Zohour" },
                    { 43, 13, "Ismailia City" },
                    { 44, 13, "Fayed" },
                    { 45, 13, "Qantara" },
                    { 46, 14, "Suez City" },
                    { 47, 14, "Ain Sokhna" },
                    { 48, 14, "Arbaeen" },
                    { 49, 15, "Arish" },
                    { 50, 15, "Sheikh Zuweid" },
                    { 51, 15, "Rafah" },
                    { 52, 16, "Sharm El Sheikh" },
                    { 53, 16, "Dahab" },
                    { 54, 16, "Saint Catherine" },
                    { 55, 17, "Beni Suef City" },
                    { 56, 17, "Nasser" },
                    { 57, 17, "Al Fashn" },
                    { 58, 18, "Faiyum City" },
                    { 59, 18, "Sinnuris" },
                    { 60, 18, "Tamiya" },
                    { 61, 19, "Minya City" },
                    { 62, 19, "Mallawi" },
                    { 63, 19, "Beni Mazar" },
                    { 64, 20, "Assiut City" },
                    { 65, 20, "Dairut" },
                    { 66, 20, "Abnub" },
                    { 67, 21, "Sohag City" },
                    { 68, 21, "Akhmim" },
                    { 69, 21, "Girga" },
                    { 70, 22, "Qena City" },
                    { 71, 22, "Nag Hammadi" },
                    { 72, 22, "Qus" },
                    { 73, 23, "Luxor City" },
                    { 74, 23, "Esna" },
                    { 75, 23, "Armant" },
                    { 76, 24, "Aswan City" },
                    { 77, 24, "Kom Ombo" },
                    { 78, 24, "Edfu" },
                    { 79, 25, "Hurghada" },
                    { 80, 25, "Marsa Alam" },
                    { 81, 25, "Safaga" },
                    { 82, 26, "Kharga" },
                    { 83, 26, "Dakhla" },
                    { 84, 26, "Farafra" },
                    { 85, 27, "Marsa Matrouh" },
                    { 86, 27, "Sallum" },
                    { 87, 27, "Sidi Barrani" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_GovernorateId_Name",
                table: "Cities",
                columns: new[] { "GovernorateId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerImages_CustomerId",
                table: "CustomerImages",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GovernorateId",
                table: "Customers",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Governorates_Name",
                table: "Governorates",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerImages");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Governorates");
        }
    }
}
