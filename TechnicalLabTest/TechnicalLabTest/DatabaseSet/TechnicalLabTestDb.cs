using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicalLabTest.Models;

namespace TechnicalLabTest.DatabaseSet
{
    public class TechnicalLabTestDb: DbContext
    {
        public TechnicalLabTestDb()
        {
            
        }
        

        public TechnicalLabTestDb(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<PersonalInformationDetail> PersonalInformationDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseSqlServer("server=DEVCRS\\MSSQLSERVERV19; Database=TechnicalTestDb;Integrated Security=true;");
            optionsBuilder.UseSqlServer("server=DESKTOP-R53ADIM; Database=TechnicalTestDb;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
                modelBuilder.Entity<City>()
                    .HasOne(s => s.Country)
                    .WithMany(g => g.Cities)
                    .HasForeignKey(s => s.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);  

                modelBuilder.Entity<PersonalInformation>()
                    .HasOne(s => s.Country)
                    .WithMany(g => g.PersonalInformations)
                    .HasForeignKey(s => s.CountryId)
                    .OnDelete(DeleteBehavior.Restrict); 

                modelBuilder.Entity<PersonalInformation>()
                    .HasOne(s => s.City)
                    .WithMany(g => g.PersonalInformations)
                    .HasForeignKey(s => s.CityId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonalInformationDetail>()
                    .HasOne(s => s.Language)
                    .WithMany(g => g.PersonalInformationDetails)
                    .HasForeignKey(s => s.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
