using Cwiczenia3.Model;
using Cwiczenia3.Repositories;
using Cwiczenia3.Services;
using Microsoft.AspNetCore.Mvc;


namespace Cwiczenia3.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{

    private IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
    
   
   [HttpGet]
   public IActionResult GetAnimals(string orderBy="name")
   {
     
       var animals = _animalsService.GetAnimals(orderBy);
       return Ok(animals);
   }
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal newAnimal)
    {
        var affectedCount = _animalsService.CreateAnimal(newAnimal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{idAnimal}")]
    public IActionResult UpdateAnimal(int idAnimal, Animal updatedAnimal)
    {
        var affectedCount = _animalsService.UpdateAnimal(updatedAnimal);
        return NoContent();
    }
    
    [HttpDelete("{idAnimal}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        var affectedCount = _animalsService.DeleteAnimal(idAnimal);
        return NoContent();
    }
}