using Microsoft.AspNetCore.Mvc;
using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TeamsController : ControllerBase{
    private static AppDbContext _context;

    public TeamsController(AppDbContext context){
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(){
        var teams = await _context.Teams.ToListAsync();
        return Ok(teams);
    }

    [HttpGet("{id:int}")]

    public async Task<IActionResult> Get(int id){
       

       var team = await _context.Teams.FirstOrDefaultAsync(x => x.id == id);

       if (team  == null){
        return BadRequest("team is not found");
       }
       return Ok(team);
    }

    [HttpPost]

    public async Task<IActionResult> Post(Team team){
        await _context.Teams.AddAsync(team);

        await _context.SaveChangesAsync();

        return CreatedAtAction("Get", routeValues:team.id, value:team);
    }

    [HttpPatch]

    public async Task<IActionResult> Patch(int id, string country){
       var team = await _context.Teams.FirstOrDefaultAsync(x => x.id == id);

       if (team == null){
        return BadRequest("team is not found");
       }

       team.Country = country;
       await _context.SaveChangesAsync();


       return NoContent();
    }

    [HttpDelete]

    public async Task<IActionResult> Delete(int id){
        var team = await _context.Teams.FirstOrDefaultAsync(x => x.id == id);

        if (team== null){
            return BadRequest("team is not found");

        }
        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}
