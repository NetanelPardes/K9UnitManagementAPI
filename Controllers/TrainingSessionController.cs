using K9UnitManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using K9UnitManagementAPI.DTO;
using K9UnitManagementAPI.Models;

namespace K9UnitManagementAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TrainingSessionController : ControllerBase
{

    private readonly ITrainingSessionRepository _trainingSessionRepository;

    public TrainingSessionController(ITrainingSessionRepository trainingSessionRepository)
    {
         _trainingSessionRepository = trainingSessionRepository;
    }

    [HttpPost]
    public async Task<ActionResult<CreateTrainingSessionTDO>> CreateTrain(CreateTrainingSessionTDO createTrainingSessionTDO)
    {
        var train = _trainingSessionRepository.CreateTraining(createTrainingSessionTDO);
        if(train == null)
        {
            return BadRequest("Something was wrong.");
        }
        return Ok(train);
    }
}

