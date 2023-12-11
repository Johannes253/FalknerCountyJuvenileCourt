using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Data {
  public class CourtContext : IdentityDbContext<IdentityUser>
{
    public CourtContext(DbContextOptions<CourtContext> options)
        : base(options)
    {
    }

      public DbSet<Crime> Crimes { get; set; }
      public DbSet<Offense> Offenses { get; set; }
      public DbSet<IntakeDecision> IntakeDecisions { get; set; }
      public DbSet<Juvenile> Juveniles { get; set; }
      public DbSet<FilingDecision> FilingDecisions { get; set; }
      public DbSet<Race> Races { get; set; }
      public DbSet<Gender> Genders { get; set; }
      public DbSet<Risk> Risks { get; set; }
      public DbSet<School> Schools { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<Juvenile>().ToTable(nameof(Juveniles))
            .HasMany(j => j.Crimes)
            .WithOne(c => c.Juvenile);
         modelBuilder.Entity<Crime>().ToTable("Crime")
            .HasOne(j => j.Juvenile);
         modelBuilder.Entity<Offense>().ToTable("Offense");
         modelBuilder.Entity<IntakeDecision>().ToTable("Intake Decision");
         modelBuilder.Entity<FilingDecision>().ToTable("Filing Decision");
         modelBuilder.Entity<Race>().ToTable("Race");
         modelBuilder.Entity<Risk>().ToTable("Risk");
         modelBuilder.Entity<School>().ToTable("School");
         modelBuilder.Entity<Gender>().ToTable("Gender");           
      }
   }
}
