using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalLabTest.SeedData
{
    public class CitySeedData
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[Cities] ON 
                INSERT [dbo].[Cities] ([Id], [Name],[CountryId]) VALUES 
                (1, N'Dhaka', 1),
                (2, N'Rangpur',1),
                (3, N'Rajshahi',1),
                (4, N'Mumbai', 2),
                (5, N'Delhi',2),
                (6, N'Bangalore',2),
                (7, N'Karachi', 3),
                (8, N'Lahore',3),
                (9, N'Rawalpindi',3);
                SET IDENTITY_INSERT [dbo].[Cities] OFF");

        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Cities;
                   DBCC CHECKIDENT ('Cities', RESEED, 0)");
        }
    }
}
