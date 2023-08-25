using Heroes.App.Databases.Entities;
using Microsoft.EntityFrameworkCore;

namespace Heroes.App.Databases;

public class HeroContext: DbContext
{
    /*protected readonly IConfiguration _configuration;

     public HeroContext(IConfiguration configuration) : base()
     {
         _configuration = configuration;
     }

     protected override void OnConfiguring(DbContextOptionsBuilder options)
     {
         options.UseNpgsql(_configuration.GetConnectionString("PostgreSQL"),
             o => o.MigrationsHistoryTable("__EFMigrationsHistory"));
     }*/
    
    public HeroContext(DbContextOptions<HeroContext> options)
        : base(options)
    {
    }

    public DbSet<HeroEntity> Heroes { get; set; }
}