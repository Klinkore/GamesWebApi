using System.ComponentModel.DataAnnotations;

namespace Games.WebApi.Models.DeveloperStudios
{
    /// <summary>
    /// Модель, содержащая информацию для обновления студии разработчика
    /// </summary>
    public class DeveloperStudioUpdateModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Required]
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        /// <summary>
        /// Наименование студии разработчика
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
