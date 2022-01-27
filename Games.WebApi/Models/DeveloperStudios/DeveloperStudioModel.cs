using System.ComponentModel.DataAnnotations;

namespace Games.WebApi.Models.DeveloperStudios
{
    /// <summary>
    /// Модель студии разработчика
    /// </summary>
    public class DeveloperStudioModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Required]
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        /// <summary>
        /// Название студии разработчика
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
