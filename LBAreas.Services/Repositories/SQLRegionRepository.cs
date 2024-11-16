using LBAreas.Entities.Data;
using LBAreas.Entities.Models.Domain;
using LBAreas.Services.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBAreas.Services.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly LBAreasDbContext db;

        public SQLRegionRepository(LBAreasDbContext db)
        {
            this.db = db;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await db.Regions.AddAsync(region);
            await db.SaveChangesAsync();
            return region; 
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await db.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            db.Regions.Remove(existingRegion);
            await db.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
          return  await db.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
           return await db.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await db.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await db.SaveChangesAsync();

            return existingRegion;
        }
    }
}
