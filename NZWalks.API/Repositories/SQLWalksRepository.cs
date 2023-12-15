using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public class SQLWalksRepository : IWalksRepository
    {
        private readonly NZWalksDbContext _DbContext;

        public SQLWalksRepository(NZWalksDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _DbContext.Walks.AddAsync(walk);
            await _DbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walkDm = await _DbContext.Walks.FindAsync(id);
            if (walkDm == null)
                return null;
            _DbContext.Walks.Remove(walkDm);
            await _DbContext.SaveChangesAsync();
            return walkDm;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _DbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).ToListAsync();
        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
            var walk = await _DbContext.Walks
                .Include(x => x.Difficulty)
                .Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
                return null;
            return walk;
        }

        public async Task<Walk> PutAsync(Guid id, Walk walk)
        {
            var existedWalk = await _DbContext.Walks.FindAsync(id);
            if (existedWalk == null)
                return null;

            existedWalk.Name = walk.Name;
            existedWalk.Description = walk.Description;
            existedWalk.LengthInKm = walk.LengthInKm;
            existedWalk.WalkImageUrl = walk.WalkImageUrl;
            existedWalk.RegionId = walk.RegionId;
            existedWalk.DifficultyId = walk.DifficultyId;

            await _DbContext.SaveChangesAsync();

            return existedWalk;
        }
    }
}
