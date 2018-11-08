using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CarMeetingManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
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
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Germans",
                columns: table => new
                {
                    GermanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Germans", x => x.GermanId);
                });

            migrationBuilder.CreateTable(
                name: "Japaneses",
                columns: table => new
                {
                    JapaneseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Japaneses", x => x.JapaneseId);
                });

            migrationBuilder.CreateTable(
                name: "Lowerings",
                columns: table => new
                {
                    LoweringId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
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
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    ProductionYear = table.Column<int>(nullable: false),
                    Displacement = table.Column<string>(nullable: true),
                    LoweringId = table.Column<int>(nullable: false),
                    Wheels = table.Column<string>(nullable: true)
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
                    ClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CarId",
                table: "Members",
                column: "CarId");

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
                                values: new object[] { 1, "Japans" });
            migrationBuilder.InsertData(
                                table: "EventTypes",
                                columns: new[] { "EventTypeId", "Type" },
                                values: new object[] { 2, "Duits" });
            migrationBuilder.InsertData(
                                table: "EventTypes",
                                columns: new[] { "EventTypeId", "Type" },
                                values: new object[] { 3, "Oldtimer" });
            migrationBuilder.InsertData(
                                table: "EventTypes",
                                columns: new[] { "EventTypeId", "Type" },
                                values: new object[] { 4, "Tuning" });
            migrationBuilder.InsertData(
                                table: "EventTypes",
                                columns: new[] { "EventTypeId", "Type" },
                                values: new object[] { 5, "Open" });

            //Lowerings
            migrationBuilder.InsertData(
                                table: "Lowerings",
                                columns: new[] { "LoweringId", "Type" },
                                values: new object[] { 1, "Geen" });
            migrationBuilder.InsertData(
                                table: "Lowerings",
                                columns: new[] { "LoweringId", "Type" },
                                values: new object[] { 2, "Veren" });
            migrationBuilder.InsertData(
                                table: "Lowerings",
                                columns: new[] { "LoweringId", "Type" },
                                values: new object[] { 3, "Schroefset" });
            migrationBuilder.InsertData(
                                table: "Lowerings",
                                columns: new[] { "LoweringId", "Type" },
                                values: new object[] { 4, "Air Ride" });

            //Germans
            migrationBuilder.InsertData(
                                table: "Germans",
                                columns: new[] { "GermanId", "Make" },
                                values: new object[] { 1, "BMW" });
            migrationBuilder.InsertData(
                                table: "Germans",
                                columns: new[] { "GermanId", "Make" },
                                values: new object[] { 2, "Audi" });
            migrationBuilder.InsertData(
                                table: "Germans",
                                columns: new[] { "GermanId", "Make" },
                                values: new object[] { 3, "Mercedes" });
            migrationBuilder.InsertData(
                                table: "Germans",
                                columns: new[] { "GermanId", "Make" },
                                values: new object[] { 4, "Porsche" });
            migrationBuilder.InsertData(
                                table: "Germans",
                                columns: new[] { "GermanId", "Make" },
                                values: new object[] { 5, "Volkswagen" });
            migrationBuilder.InsertData(
                                table: "Germans",
                                columns: new[] { "GermanId", "Make" },
                                values: new object[] { 6, "Opel" });

            //Japaneses
            migrationBuilder.InsertData(
                                table: "Japaneses",
                                columns: new[] { "JapaneseId", "Make" },
                                values: new object[] { 1, "Mazda" });
            migrationBuilder.InsertData(
                                table: "Japaneses",
                                columns: new[] { "JapaneseId", "Make" },
                                values: new object[] { 2, "Mitsubishi" });
            migrationBuilder.InsertData(
                                 table: "Japaneses",
                                 columns: new[] { "JapaneseId", "Make" },
                                 values: new object[] { 3, "Honda" });
            migrationBuilder.InsertData(
                                 table: "Japaneses",
                                 columns: new[] { "JapaneseId", "Make" },
                                 values: new object[] { 4, "Subaru" });
            migrationBuilder.InsertData(
                                 table: "Japaneses",
                                 columns: new[] { "JapaneseId", "Make" },
                                 values: new object[] { 5, "Toyota" });
            migrationBuilder.InsertData(
                                 table: "Japaneses",
                                 columns: new[] { "JapaneseId", "Make" },
                                 values: new object[] { 6, "Suzuki" });
            migrationBuilder.InsertData(
                                 table: "Japaneses",
                                 columns: new[] { "JapaneseId", "Make" },
                                 values: new object[] { 7, "Nissan" });
            migrationBuilder.InsertData(
                                 table: "Japaneses",
                                 columns: new[] { "JapaneseId", "Make" },
                                 values: new object[] { 8, "Daihatsu" });

            //Cars
            migrationBuilder.InsertData(
                                 table: "Cars",
                                 columns: new[] { "CarId", "Make", "Model", "ProductionYear", "Displacement", "LoweringId", "Wheels" },
                                 values: new object[] { 1, "Mazda", "3",
                                         "2015", "2000 cc", 3,
                                         "asa TEC GT7 19\""});

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
                name: "Germans");

            migrationBuilder.DropTable(
                name: "Japaneses");

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
        }
    }
}
