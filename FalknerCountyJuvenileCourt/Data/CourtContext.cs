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

        public DbSet<FalknerCountyJuvenileCourt.Models.Juvenile> Juvenile { get; set; } = default!;
    }
}
