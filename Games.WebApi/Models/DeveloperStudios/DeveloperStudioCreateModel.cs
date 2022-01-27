using System.ComponentModel.DataAnnotations;

namespace Games.WebApi.Models.DeveloperStudios
{
    /// <summary>
    /// Модель, содержащая информаци о созданной студии разработчике
    /// </summary>
    public class DeveloperStudioCreateModel
    {
        /// <summary>
        /// Название студии разработчика
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
