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
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly LBAreasDbContext db;

        public SQLWalkRepository(LBAreasDbContext db)
        {
            this.db = db;
        }




        public async Task<Walk> CreateAsync(Walk walk)
        {
            await db.Walks.AddAsync(walk);
            await db.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
           return await db.Walks
                .Include(x => x.Difficulty)
                .Include(x => x.Region)
                .ToListAsync();

        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
           return await db.Walks
                .Include(x => x.Difficulty)
                .Include(x => x.Region)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
