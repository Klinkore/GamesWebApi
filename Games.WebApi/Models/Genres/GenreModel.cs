using System.ComponentModel.DataAnnotations;

namespace Games.WebApi.Models.Genres
{
    /// <summary>
    /// Модель жанра
    /// </summary>
    public class GenreModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя жанра
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
