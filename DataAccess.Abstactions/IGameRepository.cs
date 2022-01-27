using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Abstactions
{
    /// <summary>
    /// Репозиторий с играми
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Получить игру по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<Game> GetById(long id);

        /// <summary>
        /// Получить игру по жанру
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        Task<ICollection<Game>> GetByGenre(long id);

        /// <summary>
        /// Получить список всех игр
        /// </summary>
        Task<ICollection<Game>> GetAll();

        /// <summary>
        /// Получить список жанров игры
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        Task<ICollection<Genre>> GetGenres(long gameId);

        /// <summary>
        /// Обновить список жанров игры
        /// </summary>
        /// <param name="genres">Список жанров</param>
        /// <param name="gameId">Идентификатор игры</param>
        Task UpdateGenres(List<Genre> genres,long gameId);

        /// <summary>
        /// Обновить информацию о игре
        /// </summary>
        /// <param name="game">Модель игры</param>
        Task Update(Game game);

        /// <summary>
        /// Добавить игру
        /// </summary>
        /// <param name="game">Модель игры</param>
        Task<Game> Add(Game game);

        /// <summary>
        /// Удалить игру
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        Task Delete(long id);
    }
}
