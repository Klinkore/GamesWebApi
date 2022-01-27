using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstactions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Repositories
{
    /// <summary>
    /// Репозиторий с играми
    /// </summary>
    public class GameRepository : IGameRepository
    {
        private readonly BoardDbContext _dbContext;

        public GameRepository(BoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<Game> GetGames()
        {
            return _dbContext.Games
               .Include(x => x.Genres)
               .Include(x => x.DeveloperStudio);
        }

        /// <inheritdoc/>
        public async Task<Game> GetById(long id)
        {
            return await GetGames()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task<ICollection<Game>> GetByGenre(long id)
        {
            return await _dbContext.GameGenres
                .Include(x => x.Game.DeveloperStudio)
                .Where(x => x.GenreId == id)
                .Select(x => x.Game)
                .ToArrayAsync();
        }

        public async Task<ICollection<Game>> GetAll()
        {
            return await GetGames()
                .AsNoTracking()
                .ToArrayAsync();
        }

        /// <inheritdoc/>
        public Task Update(Game game)
        {
            return Task.FromResult(_dbContext.Games.Update(game));
        }

        /// <inheritdoc/>
        public async Task<Game> Add(Game game)
        {
            var result = await _dbContext.Games.AddAsync(game);
            return result.Entity;
        }

        /// <inheritdoc/>
        public async Task Delete(long id)
        {
            var entity = await _dbContext.Games.FindAsync(id);
            _dbContext.Games.Remove(entity);
        }

        /// <inheritdoc/>
        public async Task<ICollection<Genre>> GetGenres(long gameId)
        {
            return await _dbContext.GameGenres
                .Include(x => x.Genre)
                .Where(x => x.GameId == gameId)
                .Select(x => x.Genre)
                .ToArrayAsync();
        }

        /// <inheritdoc/>
        public Task UpdateGenres(List<Genre> genres, long gameId)
        {
            var game = _dbContext.Games
                .Include(x => x.Genres)
                .SingleOrDefault(x => x.Id == gameId);
            if (game == null)
            {
                return Task.CompletedTask;
            }
            if (game.Genres?.Any() != null)
            {
                foreach (var genre in game.Genres)
                {
                    if (!genres.Any(x => x.Id == genre.GenreId))
                    {
                        _dbContext.GameGenres.Remove(genre);
                    }
                }
            }
            else
            {
                game.Genres = new List<GameGenre>();
            }
            foreach (var genre in genres)
            {
                if (!game.Genres.Any(x => x.GenreId == genre.Id))
                {
                    game.Genres.Add(new GameGenre
                    {
                        GameId = gameId,
                        GenreId = genre.Id
                    });
                }
            }
            return Task.CompletedTask;
        }
    }
}
