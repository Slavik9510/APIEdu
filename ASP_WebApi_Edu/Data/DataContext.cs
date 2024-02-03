using ASP_WebApi_Edu.Converters;
using ASP_WebApi_Edu.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASP_WebApi_Edu.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);

            builder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>(); 
        }
    }
}
