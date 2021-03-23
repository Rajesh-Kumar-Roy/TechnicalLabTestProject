using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalLabTest.SeedData
{
    public class CountrySeedData
    {
        public static void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[Countries] ON 
                INSERT [dbo].[Countries] ([Id], [Name]) VALUES 
                (1, N'Bangladesh'),
                (2, N'India'),
                (3, N'Pakistan');
                SET IDENTITY_INSERT [dbo].[Countries] OFF");

        }

        public static void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Countries;
                   DBCC CHECKIDENT ('Countries', RESEED, 0)");
        }
    }
}
