using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;

namespace BusinessLayer.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы с играми
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Получение игры по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        Task<OperationResult<GameDto>> GetById(long id);

        /// <summary>
        /// Получение игры по идентификатору жанра
        /// </summary>
        /// <param name="id">Идентификатор жанра игры</param>
        Task<OperationResult<ICollection<GameDto>>> GetByGenre(long id);

        /// <summary>
        /// Получение списка всех игр
        /// </summary>
        Task<OperationResult<ICollection<GameDto>>> GetAll();

        /// <summary>
        /// Создание игру
        /// </summary>
        /// <param name="gameDto">игра</param>
        Task<OperationResult<GameDto>> Create(GameDto gameDto);

        /// <summary>
        /// Изменение игру
        /// </summary>
        /// <param name="gameDto">Игра</param>
        Task<OperationResult<bool>> Update(GameDto gameDto);

        /// <summary>
        /// Удаление игру
        /// </summary>
        /// <param name="id">Идентификатор существующего игры</param>
        Task<OperationResult<bool>> Delete(long id);
    }
}