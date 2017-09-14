using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<CarInfo> Carinfo { get; set; }

        public virtual DbSet<ReapCarData> ReapCarData { get; set; }
        public virtual DbSet<DealCarData> DealCarData { get; set; }
        public virtual DbSet<CerealsBossData> CerealsBossData { get; set; }

        public virtual DbSet<HireData> HireData { get; set; }
        public virtual DbSet<ResumeData> ResumeData { get; set; }
        public virtual DbSet<DriverData> DriverData { get; set; }
    }
}
