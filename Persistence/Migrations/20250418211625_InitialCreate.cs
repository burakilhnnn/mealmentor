using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MealType = table.Column<string>(type: "text", nullable: false),
                    MealName = table.Column<string>(type: "text", nullable: false),
                    calories = table.Column<string>(type: "text", nullable: false),
                    protein = table.Column<string>(type: "text", nullable: false),
                    carbs = table.Column<string>(type: "text", nullable: false),
                    fats = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    openWelcome = table.Column<bool>(type: "boolean", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    ActivityLevel = table.Column<string>(type: "text", nullable: false),
                    Goal = table.Column<string>(type: "text", nullable: false),
                    rateOfFatLossMuscleGain = table.Column<string>(type: "text", nullable: false),
                    poundsToLoseGainPerWeek = table.Column<double>(type: "double precision", nullable: false),
                    bmr = table.Column<int>(type: "integer", nullable: false),
                    tdee = table.Column<int>(type: "integer", nullable: false),
                    dailyCalories = table.Column<int>(type: "integer", nullable: false),
                    proteinGrams = table.Column<int>(type: "integer", nullable: false),
                    carbsGrams = table.Column<int>(type: "integer", nullable: false),
                    fatGrams = table.Column<int>(type: "integer", nullable: false),
                    percentProtein = table.Column<int>(type: "integer", nullable: false),
                    percentCarbs = table.Column<int>(type: "integer", nullable: false),
                    percentFat = table.Column<int>(type: "integer", nullable: false),
                    userStatsExist = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MealPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    TabName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlans_MealPlan_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "MealPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealRows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MealPlansId = table.Column<Guid>(type: "uuid", nullable: false),
                    MealName = table.Column<string>(type: "text", nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false),
                    Protein = table.Column<int>(type: "integer", nullable: false),
                    Carbs = table.Column<int>(type: "integer", nullable: false),
                    Fats = table.Column<int>(type: "integer", nullable: false),
                    MealPlansId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    MealPlansId2 = table.Column<Guid>(type: "uuid", nullable: true),
                    MealPlansId3 = table.Column<Guid>(type: "uuid", nullable: true),
                    MealPlansId4 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealRows_MealPlans_MealPlansId",
                        column: x => x.MealPlansId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealRows_MealPlans_MealPlansId1",
                        column: x => x.MealPlansId1,
                        principalTable: "MealPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MealRows_MealPlans_MealPlansId2",
                        column: x => x.MealPlansId2,
                        principalTable: "MealPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MealRows_MealPlans_MealPlansId3",
                        column: x => x.MealPlansId3,
                        principalTable: "MealPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MealRows_MealPlans_MealPlansId4",
                        column: x => x.MealPlansId4,
                        principalTable: "MealPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_MealPlanId",
                table: "MealPlans",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MealRows_MealPlansId",
                table: "MealRows",
                column: "MealPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_MealRows_MealPlansId1",
                table: "MealRows",
                column: "MealPlansId1");

            migrationBuilder.CreateIndex(
                name: "IX_MealRows_MealPlansId2",
                table: "MealRows",
                column: "MealPlansId2");

            migrationBuilder.CreateIndex(
                name: "IX_MealRows_MealPlansId3",
                table: "MealRows",
                column: "MealPlansId3");

            migrationBuilder.CreateIndex(
                name: "IX_MealRows_MealPlansId4",
                table: "MealRows",
                column: "MealPlansId4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "MealRows");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MealPlans");

            migrationBuilder.DropTable(
                name: "MealPlan");
        }
    }
}
