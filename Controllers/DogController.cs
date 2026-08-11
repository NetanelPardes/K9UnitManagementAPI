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
        return Ok(dog);
    }
}
