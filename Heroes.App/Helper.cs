using Heroes.App.Databases;
using Heroes.App.Databases.Entities;
using Heroes.App.Models;

namespace Heroes.App;


public static class Helper
{
   
    static readonly List<HeroEntity> Heroes = new List<HeroEntity>()
    {
        new HeroEntity(){ Id = 32, Name = "Dr. Nice" },
        new HeroEntity(){ Id = 33, Name = "Bombasto" },
        new HeroEntity(){ Id = 34, Name = "Celeritas" },
        new HeroEntity(){ Id = 35, Name = "Magneta" },
        new HeroEntity(){ Id = 36, Name = "RubberMan" },
        new HeroEntity(){ Id = 37, Name = "Dynama" },
        new HeroEntity(){ Id = 38, Name = "Dr. IQ" },
        new HeroEntity(){ Id = 39, Name = "Magma" },
        new HeroEntity(){ Id = 40, Name = "Tornado" }   
    };
    public static void AddHeroesData(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetService<HeroContext>();

        foreach (HeroEntity hero in Heroes) 
        {
            db.Heroes.Add(hero);
        }
        db.SaveChanges();
    }    
    
}