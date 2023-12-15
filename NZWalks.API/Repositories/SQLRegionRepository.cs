using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepositaory
    {
        private readonly NZWalksDbContext _DbContext;
        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _DbContext.Regions.AddAsync(region);
            await _DbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var RegionDm = await _DbContext.Regions.FindAsync(id);
            if (RegionDm == null)
                return null;
            _DbContext.Regions.Remove(RegionDm);
            await _DbContext.SaveChangesAsync();
            return RegionDm;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _DbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _DbContext.Regions.FindAsync(id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existedRegion = await _DbContext.Regions.FindAsync(id);
            if (existedRegion == null)
                return null;
            existedRegion.Code = region.Code;
            existedRegion.Name = region.Name;
            existedRegion.RegionImageUrl = region.RegionImageUrl;

            await _DbContext.SaveChangesAsync();

            return existedRegion;

        }
    }
}
