using K9UnitManagementAPI.DTO;

namespace K9UnitManagementAPI.Repositories
{
    public interface ITrainingSessionRepository
    {
        Task<CreateTrainingSessionTDO?> CreateTraining(CreateTrainingSessionTDO createTrainingSessionTDO);

        Task<IEnumerable<TrainingWithFullDetailsDTO>> TrainingWithFullDetails();

        Task<TrainingListTDO> TrainingListByPage(int page = 1, int pageSize = 10);
    }
}
