using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Data
{
    public class CourtContext : DbContext
    {
        public CourtContext (DbContextOptions<CourtContext> options)
            : base(options)
        {
        }

        public DbSet<Crime> Crimes { get; set; }
        public DbSet<CrimeResult> CrimeResults { get; set; }
        public DbSet<IntakeDesc> IntakeDescs { get; set; }
        public DbSet<Juvenile> Juveniles { get; set; }
        public DbSet<ProsFilingDesc> ProsFilingDescs { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<RiskAssesment> RiskAssesments { get; set; }
        public DbSet<School> Schools { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crime>().ToTable("Crime");
            modelBuilder.Entity<CrimeResult>().ToTable("CrimeResult");
            modelBuilder.Entity<IntakeDesc>().ToTable("IntakeDesc");
            modelBuilder.Entity<Juvenile>().ToTable("Juveniles");
            modelBuilder.Entity<ProsFilingDesc>().ToTable("ProsFilingDesc");
            modelBuilder.Entity<Race>().ToTable("Race");
            modelBuilder.Entity<RiskAssesment>().ToTable("RiskAssesment");
            modelBuilder.Entity<School>().ToTable("School");
        }
    }
}
