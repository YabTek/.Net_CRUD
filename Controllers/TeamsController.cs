using Microsoft.AspNetCore.Mvc;
using Crud.Models;

namespace Crud.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TeamsController : ControllerBase{
    private List<Team> teams = new List<Team>(){
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

}
