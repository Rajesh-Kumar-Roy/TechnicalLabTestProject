using Microsoft.EntityFrameworkCore.Migrations;
using TechnicalLabTest.SeedData;

namespace TechnicalLabTest.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CountrySeedData.Up(migrationBuilder);
            CitySeedData.Up(migrationBuilder);
            LanguageSeedData.Up(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            CountrySeedData.Down(migrationBuilder);
            CitySeedData.Down(migrationBuilder);
            LanguageSeedData.Down(migrationBuilder);
        }
    }
}
