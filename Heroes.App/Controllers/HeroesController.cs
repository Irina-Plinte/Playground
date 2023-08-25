using Heroes.App.Databases;
using Heroes.App.Databases.Entities;
using Heroes.App.Models;
//using Heroes.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Heroes.App.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HeroesController: ControllerBase
{
    private readonly HeroContext _context;
    
    /*static List<Hero> heroes = new List<Hero>()
    {
        new Hero(){ Id = 22, Name = "Dr. Nice" },
        new Hero(){ Id = 23, Name = "Bombasto" },
        new Hero(){ Id = 24, Name = "Celeritas" },
        new Hero(){ Id = 25, Name = "Magneta" },
        new Hero(){ Id = 26, Name = "RubberMan" },
        new Hero(){ Id = 27, Name = "Dynama" },
        new Hero(){ Id = 28, Name = "Dr. IQ" },
        new Hero(){ Id = 29, Name = "Magma" },
        new Hero(){ Id = 30, Name = "Tornado" }   
    };*/
    
    public HeroesController(HeroContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    //public IEnumerable<Hero> GetHeroes()
    public async Task<IEnumerable<HeroEntity>> GetHeroes()
    
    {
       // return heroes;
       return await _context.Heroes.ToListAsync();
    }  
    
    [HttpGet("{id:Int}")]
    public async Task<HeroEntity> GetHero(int id)
    {
        //var hero = heroes.Find(h => h.Id == id);
        
        var hero = _context.Heroes.FindAsync(id);
        return await hero; 
    }
    
    [HttpPut]
    public async Task<HeroEntity> UpdateHero(HeroEntity heroToUpd)
    {
        //int index = heroes.FindIndex(h => h.Id == heroToUpd.Id);
        //heroes[index] = heroToUpd;
        //return heroes[index];
        var hero = await _context.Heroes.FindAsync(heroToUpd.Id);
        if (hero != null)
        {
            _context.Heroes.Remove(hero);   
            await _context.SaveChangesAsync();
        }
        return hero;
    }
    
    [HttpPost]
    public async Task<HeroEntity> AddHero(CreateHero newHero)
    {
        /*int maxID = heroes.Max(h => h.Id);}
        heroes.Add(new Hero(){ Id = maxID+1, Name = newHero.Name });
        return heroes.Last();*/
        
        var maxid = await _context.Heroes.MaxAsync(h => h.Id);
        var hero = new HeroEntity() { Id = maxid + 1, Name = newHero.Name };
        _context.Heroes.Add(hero);
        await _context.SaveChangesAsync();
        return hero; 
    }
    
    [HttpDelete("{id:Int}")]
    public async Task<HeroEntity>DeleteHero(int id)
    {
        /*var hero = heroes.Find(h => h.Id == id);
        if (hero != null)
        {
            heroes.Remove(hero);    
        }
        return hero; */

        var hero = await _context.Heroes.FindAsync(id);
        if (hero != null)
        {
            _context.Heroes.Remove(hero);   
            await _context.SaveChangesAsync();
        }
        return hero;
    }
    
    [HttpGet("name={term}")]
    public async Task<IEnumerable<HeroEntity>> SearchHeroes(string term)
    {
        /*var hero = heroes.FindAll(h => h.Name.Contains(term, StringComparison.OrdinalIgnoreCase)).ToList();
        return hero; */
        var heros = _context.Heroes.Where(h => EF.Functions.Like(h.Name, "%"+term+"%")).ToListAsync();
        return await heros;
    }
    
    
    
}