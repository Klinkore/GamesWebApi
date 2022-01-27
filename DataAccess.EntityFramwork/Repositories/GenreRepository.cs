using DataAccess.Abstactions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Repositories
{
    /// <summary>
    /// Репозиторий с жанрами
    /// </summary>
    public class GenreRepository : IGenreRepository
    {
        private readonly BoardDbContext _dbContext;

        public GenreRepository(BoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<Genre> Add(Genre genre)
        {
            var result = await _dbContext.Genres.AddAsync(genre);
            return result.Entity;
        }

        /// <inheritdoc/>
        public async Task Delete(long id)
        {
            var entity = await _dbContext.Genres.FindAsync(id);
            _dbContext.Genres.Remove(entity);
        }

        /// <inheritdoc/>
        public async Task<ICollection<Genre>> GetAll()
        {
            return await _dbContext.Genres
                .AsNoTracking()
                .ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<ICollection<Game>> GetGames(long genreId)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == genreId);
            return genre.Games.Select(x => x.Game).ToList();
        }

        /// <inheritdoc/>
        public Task<Genre> GetById(long id)
        {
            return _dbContext.Genres.FindAsync(id).AsTask();
        }

        /// <inheritdoc/>
        public Task Update(Genre genre)
        {
            _dbContext.Genres.Update(genre);
            return Task.CompletedTask;
        }
    }
}
