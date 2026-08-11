using K9UnitManagementAPI.Data;
using K9UnitManagementAPI.DTO;
using K9UnitManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace K9UnitManagementAPI.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly K9UnitManagementDbContext _DbContext;
        public DogRepository(K9UnitManagementDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<FindDogByIdDTO?> CreatingDog(CreateDogDTO createDogDTO)
        {
            if (createDogDTO.DateOfBirth > DateTime.Now)
            {
                Console.WriteLine("1");
                return null;
            }
            var mi = _DbContext.Dogs.Where(d => d.MicrochipId == createDogDTO.MicrochipId).FirstOrDefaultAsync();
            if (mi != null)
            {
                Console.WriteLine("2");
                return null;
            }
            var had = _DbContext.Handlers.Where(h => h.Id == createDogDTO.HandlerId).FirstOrDefaultAsync();
            if (had == null)
            {
                Console.WriteLine("3");
                return null;
            }
            Console.WriteLine("4");
            var dog = new Dog
            {
                Name = createDogDTO.Name,
                Breed = createDogDTO.Breed,
                MicrochipId = createDogDTO.MicrochipId,
                DateOfBirth = createDogDTO.DateOfBirth,
                Specialty = createDogDTO.Specialty,
                Status = createDogDTO.Status == null ? "InTraining" : createDogDTO.Status,
                HandlerId = createDogDTO.HandlerId
            };
            _DbContext.Dogs.Add(dog);
            await _DbContext.SaveChangesAsync();
            var newDog = await FindDog(dog.Id);
            return newDog;
        }

        public async Task<FindDogByIdDTO?> FindDog(int id)
        {
            return await _DbContext.Dogs.Where(i => i.Id == id).Select(n => new FindDogByIdDTO
            {
                Id = n.Id,
                Name = n.Name,
                Breed = n.Breed,
                MicrochipId = n.MicrochipId,
                DateOfBirth = n.DateOfBirth,
                Specialty = n.Specialty,
                Status = n.Status
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DogsByFiltersTDO>> SearchDogs(string? specialty, string? status)
        {
            var dogs = _DbContext.Dogs.AsQueryable();
            if (!string.IsNullOrWhiteSpace(specialty))
            {
                dogs = dogs.Where(d => d.Specialty == specialty);
            }
            if (!string.IsNullOrWhiteSpace(status))
            {
                dogs = dogs.Where(d => d.Status == status);
            }
            return dogs.Select(d => new DogsByFiltersTDO
            {
                Id = d.Id,
                Name = d.Name,
                Breed = d.Breed,
                Specialty = d.Specialty,
                Status = d.Status
            }).ToList();
        }
        public async Task<IEnumerable<DogsWithTheHandlerTDO>> DogsWithTheHandler()
        {
            return _DbContext.Dogs.Select(n => new DogsWithTheHandlerTDO
            {
                Id = n.Id,
                Name = n.Name,
                Breed = n.Name,
                Specialty = n.Specialty,
                Status = n.Status,
                HandlerId = n.HandlerId != null ? n.handler.Id : null,
                HandlerName = n.HandlerId != null ? n.handler.FullName : null,
                Rank = n.HandlerId != null ? n.handler.Rank : null
            });
        }

        public async Task<IEnumerable<PerformanceSummaryDTO>> PerformanceSummaryForEachDog()
        {
            return _DbContext.Dogs
                .Select(n => new PerformanceSummaryDTO
                {
                    Id = n.Id,
                    Name = n.Name,
                    Specialty = n.Specialty,
                    NumberOfTrainings = n.trainingSessions.Count(),
                    AveragePerformanceScore = n.trainingSessions.Count() > 0 ? n.trainingSessions.Average(t => (double)t.PerformanceScore) : null
                });
        }

        
    }
}
