using K9UnitManagementAPI.DTO;

namespace K9UnitManagementAPI.Repositories
{
    public interface ITrainingSessionRepository
    {
        Task<CreateTrainingSessionTDO?> CreateTraining(CreateTrainingSessionTDO createTrainingSessionTDO);
    }
}
