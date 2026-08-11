using K9UnitManagementAPI.Data;
using K9UnitManagementAPI.DTO;
using K9UnitManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace K9UnitManagementAPI.Repositories
{
    public class TrainingSessionRepository: ITrainingSessionRepository
    {
        private readonly K9UnitManagementDbContext _DbContext;
        public TrainingSessionRepository(K9UnitManagementDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<CreateTrainingSessionTDO?> CreateTraining(CreateTrainingSessionTDO createTrainingSessionTDO)
        {
            var dog = _DbContext.Dogs.Where(c => c.Id == createTrainingSessionTDO.DogId).FirstOrDefaultAsync();
            if(dog == null)
            {
                return null;
            }
            if(createTrainingSessionTDO.SessionDate < DateTime.Now)
            {
                return null;
            }
            TrainingSession newTrainingSession = new TrainingSession
            {
                SessionDate = createTrainingSessionTDO.SessionDate,
                DurationMinutes = createTrainingSessionTDO.DurationMinutes,
                TrainingType = createTrainingSessionTDO.TrainingType,
                PerformanceScore = createTrainingSessionTDO.PerformanceScore,
                Evaluator = createTrainingSessionTDO.Evaluator,
                DogId = createTrainingSessionTDO.DogId,
                Passed = createTrainingSessionTDO.PerformanceScore >= 75 ? true : false
            };
            _DbContext.TrainingSessions.Add(newTrainingSession);
            await _DbContext.SaveChangesAsync();
            return createTrainingSessionTDO;
        }
    }
}
