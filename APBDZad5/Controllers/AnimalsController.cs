using APBDZad5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDZad5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController(IAnimalsService animalsService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "name")
    {
        var animals = animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }
}