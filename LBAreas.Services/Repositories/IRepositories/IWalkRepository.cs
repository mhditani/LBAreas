using LBAreas.Entities.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBAreas.Services.Repositories.IRepositories
{
    public interface IWalkRepository
    {
       Task<Walk>  CreateAsync(Walk walk);

        Task<List<Walk>> GetAllAsync();

        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id, Walk walk);

        Task<Walk?> DeleteAsync(Guid id);
    }
}
