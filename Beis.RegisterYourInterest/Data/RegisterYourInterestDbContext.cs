using Beis.Common.Entities;
using Beis.Common.Entities.Interfaces;
using Beis.Common.Entities.ModelBuilderExtensions;
using Beis.Common.Entities.Models;
using Beis.RegisterYourInterest.Data;//.Entities;
using Microsoft.EntityFrameworkCore;


namespace Beis.RegisterYourInterest.Data
{
    /// <summary>
    /// wrapped db context for migrations. possibly register this in classes instad of the generic?
    /// </summary>
    public class RegisterYourInterestDbContext : RegisterYourInterestDbContext<Applicant>
    {
        public RegisterYourInterestDbContext(DbContextOptions<RegisterYourInterestDbContext> options)
            : base(options)
        {
            // Intentionally empty
        }
    }

    public class RegisterYourInterestDbContext<TEntity> : BaseUserDbContext<BaseUserEntity>
    {
        public RegisterYourInterestDbContext() : base()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public RegisterYourInterestDbContext(DbContextOptions options)
                : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

   

        public DbSet<Applicant> applicants { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)          
        {
            base.OnModelCreating(modelBuilder);
      
        }
    }
}
