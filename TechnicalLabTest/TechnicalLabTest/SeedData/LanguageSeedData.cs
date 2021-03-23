using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalLabTest.SeedData
{
    public class LanguageSeedData
    {

        public static void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[Languages] ON 
                INSERT [dbo].[Languages] ([Id], [Name]) VALUES 
                (1, N'C#'),
                (2, N'C++'),
                (3, N'Java'),
                (4, N'PHP'),
                (5, N'SQL');
                 SET IDENTITY_INSERT [dbo].[Languages] OFF");

        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Languages;
                   DBCC CHECKIDENT ('Languages', RESEED, 0)");
        }
    }
}
