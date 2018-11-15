using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarMeetingManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarMakes",
                columns: table => new
                {
                    MakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMakes", x => x.MakeId);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Lowerings",
                columns: table => new
                {
                    LoweringId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lowerings", x => x.LoweringId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    EventTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MakeId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    ProductionYear = table.Column<int>(nullable: false),
                    Displacement = table.Column<string>(nullable: true),
                    LoweringId = table.Column<int>(nullable: false),
                    Wheels = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Lowerings_LoweringId",
                        column: x => x.LoweringId,
                        principalTable: "Lowerings",
                        principalColumn: "LoweringId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarMakes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "CarMakes",
                        principalColumn: "MakeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    ClubId = table.Column<int>(nullable: false),
                    CarId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Cars_CarId1",
                        column: x => x.CarId1,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_LoweringId",
                table: "Cars",
                column: "LoweringId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MakeId",
                table: "Cars",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CarId1",
                table: "Members",
                column: "CarId1");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ClubId",
                table: "Members",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_MemberId",
                table: "Registrations",
                column: "MemberId");

            //EventTypes
            migrationBuilder.InsertData(
                                table: "EventTypes",
                                columns: new[] { "EventTypeId", "Type" },
                                values: new object[] { 1, 1 });
            migrationBuilder.InsertData(
                                table: "EventTypes",
                                columns: new[] { "EventTypeId", "Type" },
                                values: new object[] { 2, 2 });
            migrationBuilder.InsertData(
                                table: "EventTypes",
                                columns: new[] { "EventTypeId", "Type" },
                                values: new object[] { 3, 3 });
            migrationBuilder.InsertData(
                                table: "EventTypes",
                                columns: new[] { "EventTypeId", "Type" },
                                values: new object[] { 4, 4 });
            migrationBuilder.InsertData(
                                table: "EventTypes",
                                columns: new[] { "EventTypeId", "Type" },
                                values: new object[] { 5, 5 });

            //Lowerings
            migrationBuilder.InsertData(
                                table: "Lowerings",
                                columns: new[] { "LoweringId", "Type" },
                                values: new object[] { 1, 1 });
            migrationBuilder.InsertData(
                                table: "Lowerings",
                                columns: new[] { "LoweringId", "Type" },
                                values: new object[] { 2, 2 });
            migrationBuilder.InsertData(
                                table: "Lowerings",
                                columns: new[] { "LoweringId", "Type" },
                                values: new object[] { 3, 3 });
            migrationBuilder.InsertData(
                                table: "Lowerings",
                                columns: new[] { "LoweringId", "Type" },
                                values: new object[] { 4, 4 });

            //CarMakes
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 1, "BMW", "GER" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 2, "Audi", "GER" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 3, "Mercedes", "GER" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 4, "Porsche", "GER" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 5, "Volkswagen", "GER" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 6, "Opel", "GER" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 7, "Mazda", "JAP" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 8, "Mitsubishi", "JAP" });
            migrationBuilder.InsertData(
                                 table: "CarMakes",
                                 columns: new[] { "MakeID", "Make", "CountryCode" },
                                 values: new object[] { 9, "Honda", "JAP" });
            migrationBuilder.InsertData(
                                 table: "CarMakes",
                                 columns: new[] { "MakeID", "Make", "CountryCode" },
                                 values: new object[] { 10, "Subaru", "JAP" });
            migrationBuilder.InsertData(
                                 table: "CarMakes",
                                 columns: new[] { "MakeID", "Make", "CountryCode" },
                                 values: new object[] { 11, "Toyota", "JAP" });
            migrationBuilder.InsertData(
                                 table: "CarMakes",
                                 columns: new[] { "MakeID", "Make", "CountryCode" },
                                 values: new object[] { 12, "Suzuki", "JAP" });
            migrationBuilder.InsertData(
                                 table: "CarMakes",
                                 columns: new[] { "MakeID", "Make", "CountryCode" },
                                 values: new object[] { 13, "Nissan", "JAP" });
            migrationBuilder.InsertData(
                                 table: "CarMakes",
                                 columns: new[] { "MakeID", "Make", "CountryCode" },
                                 values: new object[] { 14, "Daihatsu", "JAP" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 15, "Abarth", "ITA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 16, "AC", "GBR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 17, "Acura", "JAP" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 18, "Alfa Romeo", "ITA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 19, "Aston Martin", "GBR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 20, "Bently", "GBR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 21, "Bugatti", "FRA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 22, "Buick", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 23, "Cadillac", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 24, "Chevrolet", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 25, "Citroën", "FRA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 26, "Chrysler", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 27, "Datsun", "JAP" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 28, "Dodge", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 29, "Ferrari", "ITA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 30, "Fiat", "ITA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 31, "Ford", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 32, "Genesis", "KOR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 33, "GMC", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 34, "Holden", "AUS" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 35, "Hyundai", "KOR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 36, "Infinity", "JAP" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 37, "Jaguar", "GBR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 38, "Jeep", "ITA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 39, "Koenigsegg", "SWE" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 40, "Kia", "KOR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 41, "Lamborghini", "ITA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 42, "Land Rover", "GBR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 43, "Lexus", "JAP" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 44, "Lincoln", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 45, "Lotus", "GBR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 46, "Maserati", "ITA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 47, "McLaren", "GBR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 48, "MG", "GBR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 49, "Mini", "GER" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 50, "Peugot", "FRA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 51, "Plymouth", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 52, "Renault", "FRA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 53, "Rolls-Royce", "GBR" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 54, "Seat", "SPA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 55, "Smart", "GER" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 56, "Tesla", "USA" });
            migrationBuilder.InsertData(
                                table: "CarMakes",
                                columns: new[] { "MakeID", "Make", "CountryCode" },
                                values: new object[] { 57, "Volvo", "SWE" });
            //Cars
            migrationBuilder.InsertData(
                                 table: "Cars",
                                 columns: new[] { "CarId", "MakeId", "Model", "ProductionYear", "Displacement", "LoweringId", "Wheels", "MemberId" },
                                 values: new object[] { 1, 7, "3",
                                         "2015", "2000 cc", 3,
                                         "asa TEC GT7 19\"", 1});

            //Clubs
            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "ClubId", "Name", "Description", "Photo", "Contact" },
                values: new object[] {1, "MazdaClubBelgium", "Club uit België, alle modellen binnen mazda zijn toegelaten.",
                "no photo","mazdaclubbe@hotmail.com" });
            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "ClubId", "Name", "Description", "Photo", "Contact" },
                values: new object[] { 2, "DuitseOldtimer", "Club voor duitse oldtimers.", "no photo", "DuitseOldtimer@hotmail.com" });

            //Members
            migrationBuilder.InsertData(
                                 table: "Members",
                                 columns: new[] { "MemberId", "Name", "Surname", "DateOfBirth", "PostalCode", "City", "Email", "Username", "Password", "CarId", "ClubId" },
                                 values: new object[] { 1, "Gert", "Scheers",
                                         DateTime.Parse("1994-11-17").Date, "3920", "Lommel",
                                         "gert_378@hotmail.com", "gert.scheers", "test", 1, 1});

            //Events
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Name", "Description", "Location", "Capacity", "EventTypeId" },
                values: new object[] { 1, "Japfest", "Meeting op Circuit Zandvoort, enkel voor Japanse auto's en brommers.",
                     "Zandvoort", 1500, 1 });
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Name", "Description", "Location", "Capacity", "EventTypeId" },
                values: new object[] { 2, "Germanized", "Meeting voor Duitse merken.", "Hechtel", 500, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Lowerings");

            migrationBuilder.DropTable(
                name: "CarMakes");
        }
    }
}
