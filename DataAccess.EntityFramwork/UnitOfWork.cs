using System.Threading.Tasks;
using DataAccess.Abstactions;

namespace DataAccess.EntityFramework
{
    /// <summary>
    /// Реализация паттерна UnitOfWork 
    /// </summary>
    class UnitOfWork : IUnitOfWork
    {
        private readonly BoardDbContext _dbContext;
        
        public UnitOfWork(BoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        ///<inheritdoc/>
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
