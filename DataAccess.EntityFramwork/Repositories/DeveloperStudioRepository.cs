using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstactions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Repositories
{
    /// <summary>
    /// Репозиторий с студиями разработчиками
    /// </summary>
    public class DeveloperStudioRepository : IDeveloperStuidoRepository
    {
        private readonly BoardDbContext _dbContext;

        public DeveloperStudioRepository(BoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<DeveloperStudio> Add(DeveloperStudio developerStudio)
        {
            var result = await _dbContext.DeveloperStudios.AddAsync(developerStudio);
            return result.Entity;
        }

        /// <inheritdoc/>
        public async Task Delete(long id)
        {
            var developerStudio =  await _dbContext.DeveloperStudios.FindAsync(id);
            _dbContext.DeveloperStudios.Remove(developerStudio);

        }

        /// <inheritdoc/>
        public async Task<ICollection<DeveloperStudio>> GetAll()
        {
            return await _dbContext.DeveloperStudios
                .AsNoTracking()
                .ToArrayAsync();
        }

        /// <inheritdoc/>
        public Task<DeveloperStudio> GetById(long id)
        {
            return _dbContext.DeveloperStudios.FindAsync(id).AsTask();
        }

        /// <inheritdoc/>
        public Task Update(DeveloperStudio developerStudios)
        {
            _dbContext.DeveloperStudios.Update(developerStudios);
            return Task.CompletedTask;
        }
    }
}
