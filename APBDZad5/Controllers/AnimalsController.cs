using APBDZad5.Models;
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

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        animalsService.UpdateAnimal(id, animal);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        animalsService.DeleteAnimal(id);
        return NoContent();
    }
}