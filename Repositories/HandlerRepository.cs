using K9UnitManagementAPI.Data;
using K9UnitManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace K9UnitManagementAPI.Repositories
{
    public class HandlerRepository: IHandlerRepository
    {
        private readonly K9UnitManagementDbContext _DbContext;
        public HandlerRepository(K9UnitManagementDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<bool> DeleteHandler(int id)
        {
            var handler = _DbContext.Handlers.Where(h => h.Id == id).FirstOrDefault();
            if(handler == null)
            { 
                return false; 
            }
            _DbContext.Handlers.Remove(handler);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }
}
