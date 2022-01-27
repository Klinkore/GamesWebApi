using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Abstactions
{
    /// <summary>
    /// Репозиторий с жанрами
    /// </summary>
    public interface IGenreRepository
    {
        /// <summary>
        /// Получить жанр по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<Genre> GetById(long id);

        /// <summary>
        /// Получить весь список жанров
        /// </summary>
        Task<ICollection<Genre>> GetAll();

        /// <summary>
        /// Получить игры определенного жанра
        /// </summary>
        /// <param name="gameId">Идентификатор жанра</param>
        Task<ICollection<Game>> GetGames(long gameId);

        /// <summary>
        /// Добавить жанр
        /// </summary>
        /// <param name="genre">Жанр</param>
        Task<Genre> Add(Genre genre);

        /// <summary>
        /// Обновить информацию о жанре
        /// </summary>
        /// <param name="genre">Жанр</param>
        Task Update(Genre genre);

        /// <summary>
        /// Удалить жанр
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        Task Delete(long id);
    }
}
