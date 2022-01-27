using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Abstactions
{
    /// <summary>
    /// Репозиторий с студиями разработчиками
    /// </summary>
    public interface IDeveloperStuidoRepository
    { 
        /// <summary>
        /// Получить студию разработчика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<DeveloperStudio> GetById(long id);

        /// <summary>
        /// Получить весь список студий разработчиков
        /// </summary>
        Task<ICollection<DeveloperStudio>> GetAll();

        /// <summary>
        /// Добавить студию разработчика
        /// </summary>
        /// <param name="developerStudio">Студия разработчика</param>
        Task<DeveloperStudio> Add(DeveloperStudio developerStudio);

        /// <summary>
        /// Обновить информацию о студии разработчике
        /// </summary>
        /// <param name="developerStudio">Модель студии разработчика</param>
        Task Update(DeveloperStudio developerStudio);

        /// <summary>
        /// Удалить студию разработчика
        /// </summary>
        /// <param name="id">Идентификатор студии разработчика</param>
        Task Delete(long id);
    }
}
