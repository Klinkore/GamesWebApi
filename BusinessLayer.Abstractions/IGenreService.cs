using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;

namespace BusinessLayer.Abstractions
{
    /// <summary>
    /// Сервис для работы с жанрами
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Получить жанр по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<OperationResult<GenreDto>> GetById(long id);

        /// <summary>
        /// Получить все жанры
        /// </summary>
        Task<OperationResult<ICollection<GenreDto>>> GetAll();

        /// <summary>
        /// Добавить жанр
        /// </summary>
        /// <param name="genreDto">Модель жанра</param>
        Task<OperationResult<GenreDto>> Create(GenreDto genreDto);

        /// <summary>
        /// Обновить информацию о жанре
        /// </summary>
        /// <param name="genreDto">Модель жанра</param>
        Task<OperationResult<bool>> Update(GenreDto genreDto);

        /// <summary>
        /// Удалить жанр
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        Task<OperationResult<bool>> Delete(long id);
    }
}