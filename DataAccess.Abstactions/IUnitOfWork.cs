using System.Threading.Tasks;

namespace DataAccess.Abstactions
{
    /// <summary>
    /// Интерфейс для реализации патерна Unit of Work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        Task SaveChanges();
    }
}
