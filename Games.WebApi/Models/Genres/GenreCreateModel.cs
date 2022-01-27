using System.ComponentModel.DataAnnotations;

namespace Games.WebApi.Models.Genres
{
    /// <summary>
    /// Модель, использующаяся для создания жанра
    /// </summary>
    public class GenreCreateModel
    {
        /// <summary>
        /// Имя жанра
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
