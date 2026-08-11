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
            if(createDogDTO.DateOfBirth < DateTime.Now)
            {
                return null;
            }
            var mi = _DbContext.Dogs.Where(d => d.MicrochipId == createDogDTO.MicrochipId).FirstOrDefaultAsync();
            if(mi != null)
            {
                return null;
            }
            var had = _DbContext.Handlers.Where(h => h.Id == createDogDTO.HandlerId).FirstOrDefaultAsync();
            if (mi == null)
            {
                return null;
            }
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
    }
}
