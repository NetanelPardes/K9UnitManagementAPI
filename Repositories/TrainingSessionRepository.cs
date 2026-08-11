using K9UnitManagementAPI.Data;
using K9UnitManagementAPI.DTO;
using K9UnitManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace K9UnitManagementAPI.Repositories
{
    public class TrainingSessionRepository : ITrainingSessionRepository
    {
        private readonly K9UnitManagementDbContext _DbContext;
        public TrainingSessionRepository(K9UnitManagementDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<CreateTrainingSessionTDO?> CreateTraining(CreateTrainingSessionTDO createTrainingSessionTDO)
        {
            var dog = _DbContext.Dogs.Where(c => c.Id == createTrainingSessionTDO.DogId).FirstOrDefaultAsync();
            if (dog == null)
            {
                return null;
            }
            if (createTrainingSessionTDO.SessionDate < DateTime.Now)
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

        public async Task<IEnumerable<TrainingWithFullDetailsDTO>> TrainingWithFullDetails()
        {
            return _DbContext.TrainingSessions.Select(n => new TrainingWithFullDetailsDTO
            {
                Id = n.Id,
                SessionDate = n.SessionDate,
                DurationMinutes = n.DurationMinutes,
                TrainingType = n.TrainingType,
                PerformanceScore = n.PerformanceScore,
                Passed = n.Passed,
                Evaluator = n.Evaluator,
                DogId = n.dog.Id,
                DogName = n.dog.Name,
                Specialty = n.dog.Specialty,
                HandlerFullName = n.dog.HandlerId != null ? n.dog.handler.FullName : null
            });
        }
        public async Task<TrainingListTDO> TrainingListByPage(int page = 1 , int pageSize = 10)
        {
            var train = _DbContext.TrainingSessions.AsQueryable();
            var totalItem = train.Count();
            var item = train.OrderByDescending(n => n.SessionDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(n => new TrainingWithFullDetailsDTO
                {
                    Id = n.Id,
                    SessionDate = n.SessionDate,
                    DurationMinutes = n.DurationMinutes,
                    TrainingType = n.TrainingType,
                    PerformanceScore = n.PerformanceScore,
                    Passed = n.Passed,
                    Evaluator = n.Evaluator,
                    DogId = n.dog.Id,
                    DogName = n.dog.Name,
                    Specialty = n.dog.Specialty,
                    HandlerFullName = n.dog.HandlerId != null ? n.dog.handler.FullName : null
                }).ToList();
            return new TrainingListTDO
            {
                Items = item,
                TotalResults = totalItem,
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItem /(double) pageSize)

            };
        }
    }
}
