using K9UnitManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using K9UnitManagementAPI.DTO;
using K9UnitManagementAPI.Models;

namespace K9UnitManagementAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DogController : ControllerBase
{

    private readonly IDogRepository _dogRepository;

    public DogController(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }

    [HttpGet("{id}")]
    public async Task <ActionResult<FindDogByIdDTO>> FindById(int id)
    {
        var dog = await _dogRepository.FindDog(id);
        if(dog == null)
        {
            return NotFound("dog not found");
        }
        return Ok(dog);
    }

    [HttpPost]
    public async Task<ActionResult<FindDogByIdDTO>> CreateDog(CreateDogDTO createDogDTO)
    {
        var dog = await _dogRepository.CreatingDog(createDogDTO);
        if(dog == null)
        {
            return BadRequest("Something was wrong.");
        }
        return Ok(dog);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<DogsByFiltersTDO>>> SearchDogs([FromQuery] string? specialty, [FromQuery] string? status)
    {
        var dogs = _dogRepository.SearchDogs(specialty, status);
        return Ok(dogs);
    }

    [HttpGet("with-handler")]
    public async Task<ActionResult<IEnumerable<DogsWithTheHandlerTDO>>> DogsWithTheHandler()
    {
        var dogs = _dogRepository.DogsWithTheHandler();
        return Ok(dogs);
    }

    [HttpGet("performance-summary")]
    public async Task<ActionResult<IEnumerable<PerformanceSummaryDTO>>> PerformanceSummaryForEachDog()
    {
        var dogs = _dogRepository.PerformanceSummaryForEachDog();
        return Ok(dogs);
    }
}
