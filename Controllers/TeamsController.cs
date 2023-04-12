using Microsoft.AspNetCore.Mvc;
using Crud.Models;

namespace Crud.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TeamsController : ControllerBase{
    private static List<Team> teams = new List<Team>(){
        new Team() {
             Country = "Ethiopia",
             id = 1,
             Name = "city",
             TeamPrinciple = "toto rolf"
        },
        new Team(){
            
             Country = "Germany",
             id = 2,
             Name = "united",
             TeamPrinciple = "tata"
        },
        new Team(){
            
             Country = "usa",
             id = 3,
             Name = "arsenal",
             TeamPrinciple = "nan"
        }
    };
  
    [HttpGet]
    public IActionResult Get(){
        return Ok(teams);
    }

    [HttpGet("{id:int}")]

    public IActionResult Get(int id){

       var team = teams.FirstOrDefault(x => x.id == id);

       if (team  == null){
        return BadRequest("team is not found");
       }
       return Ok(team);
    }

    [HttpPost]

    public IActionResult Post(Team team){
        teams.Add(team);

        return CreatedAtAction("Get", routeValues:team.id, value:team);
    }

    [HttpPatch]

    public IActionResult Patch(int id, string country){
       var team = teams.FirstOrDefault(x => x.id == id);

       if (team == null){
        return BadRequest("team is not found");
       }

       team.Country = country;

       return NoContent();
    }

    [HttpDelete]

    public IActionResult Delete(int id){
        var team = teams.FirstOrDefault(x => x.id == id);

        if (team== null){
            return BadRequest("team is not found");

        }
        teams.Remove(team);
        
        return NoContent();
    }
}
