using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.Repository.Infrastructure.Entity
{
    public partial class FreeCheckDbContext : DbContext
    {
        public FreeCheckDbContext() { }

        public FreeCheckDbContext(DbContextOptions<FreeCheckDbContext> options) : base(options)
        {

        }

        public virtual DbSet<ShoeCheck> ShoeCheck { get; set; }
        public virtual DbSet<ImageCheck> ImageCheck { get; set; }
        public virtual DbSet<BrandCheck> BrandChecks { get; set; }

    }
}
