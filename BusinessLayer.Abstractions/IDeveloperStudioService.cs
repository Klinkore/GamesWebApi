using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;

namespace BusinessLayer.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы со студиями разработчиками
    /// </summary>
    public interface IDeveloperStudioService
    {
        /// <summary>
        /// Получение студии разработчика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор студии разработчика</param>
        Task<OperationResult<DeveloperStudioDto>> GetById(long id);

        /// <summary>
        /// Получить все студии разработчики
        /// </summary>
        Task<OperationResult<ICollection<DeveloperStudioDto>>> GetAll();

        /// <summary>
        /// Создание студии разработчика
        /// </summary>
        /// <param name="developerStudioDto">Студия разработчик</param>
        Task<OperationResult<DeveloperStudioDto>> Create(DeveloperStudioDto developerStudioDto);

        /// <summary>
        /// Изменение студии разработчика
        /// </summary>
        /// <param name="developerStudioDto">Модель студии разработчика</param>
        Task<OperationResult<bool>> Update(DeveloperStudioDto developerStudioDto);

        /// <summary>
        /// Удаление студии разработчика
        /// </summary>
        /// <param name="id">Идентификатор существующей студии разработчика</param>
        Task<OperationResult<bool>> Delete(long id);
    }
}