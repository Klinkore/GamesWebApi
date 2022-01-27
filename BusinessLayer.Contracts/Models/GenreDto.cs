using System.Collections.Generic;

namespace BusinessLayer.Contracts.Models
{
    /// <summary>
    /// Жанр. Транспортный объект.
    /// </summary>
    public class GenreDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя жанра
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Игры с этим жанром
        /// </summary>
        public ICollection<GameDto> Games { get; set; }
    }
}
