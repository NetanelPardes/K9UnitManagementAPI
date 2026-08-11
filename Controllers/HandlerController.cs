using K9UnitManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using K9UnitManagementAPI.DTO;
using K9UnitManagementAPI.Models;

namespace K9UnitManagementAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HandlerController : ControllerBase
{

    private readonly IHandlerRepository _handlerRepository;

    public HandlerController(IHandlerRepository handlerRepository)
    {
        _handlerRepository = handlerRepository;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHandler(int id)
    {
        var del = await _handlerRepository.DeleteHandler(id);
        if(del == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}

