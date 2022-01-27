using Games.WebApi.Models.Genres;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Games.WebApi.Models.Games
{
    /// <summary>
    /// Модель, содержащая информацию о созданной игре
    /// </summary>
    public class GameCreateModel
    {
        /// <summary>
        /// Название игры
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор студии разработчика, которой пренадлежит игра
        /// </summary>
        [Required]
        [Range(1, long.MaxValue)]
        public long DeveloperStudioId { get; set; }

        /// <summary>
        /// Список жанров игры
        /// </summary>
        public ICollection<GenreUsingModel> Genres { get; set; }
    }
}
