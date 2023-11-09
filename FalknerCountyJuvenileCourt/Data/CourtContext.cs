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
      public DbSet<CrimeType> CrimeTypes { get; set; }
      public DbSet<IntakeDecision> IntakeDecisions { get; set; }
      public DbSet<Juvenile> Juveniles { get; set; }
      public DbSet<FilingDecision> FilingDecisions { get; set; }
      public DbSet<Race> Races { get; set; }
      public DbSet<Gender> Genders { get; set; }
      public DbSet<Risk> Risks { get; set; }
      public DbSet<School> Schools { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<Crime>().ToTable("Crime");
         modelBuilder.Entity<CrimeType>().ToTable("CrimeType");
         modelBuilder.Entity<IntakeDecision>().ToTable("IntakeDecision");
         modelBuilder.Entity<Juvenile>().ToTable(nameof(Juveniles)); 
         modelBuilder.Entity<FilingDecision>().ToTable("FilingDecision");
         modelBuilder.Entity<Race>().ToTable("Race");
         modelBuilder.Entity<Risk>().ToTable("Risk");
         modelBuilder.Entity<School>().ToTable("School");
         modelBuilder.Entity<Gender>().ToTable("Gender");

         // Might need to change it to the following when dealing with many-to-many relationships
         // modelBuilder.Entity<Course>().ToTable(nameof(Course))
         //        .HasMany(c => c.Instructors)
         //        .WithMany(i => i.Courses);
         //    modelBuilder.Entity<Student>().ToTable(nameof(Student));
         //    modelBuilder.Entity<Instructor>().ToTable(nameof(Instructor));
      }
   }
}
