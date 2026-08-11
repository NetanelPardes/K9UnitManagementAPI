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

    [HttpGet("training-sessions/detailed")]
    public async Task<ActionResult<IEnumerable<TrainingWithFullDetailsDTO>>> TrainingWithFullDetails()
    {
        var train = _trainingSessionRepository.TrainingWithFullDetails();
        return Ok(train);
    }
    [HttpGet("training-sessions/paged")]
    public async Task<ActionResult<TrainingListTDO>> TrainingListBypage([FromQuery] int page, [FromQuery] int pageSize)
    {
        var train = _trainingSessionRepository.TrainingListByPage(page, pageSize);
        return Ok(train);
    }
}

