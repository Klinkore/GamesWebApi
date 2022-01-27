using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    /// <summary>
    /// Жанр игры
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование жанра
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Игры этого жанра
        /// </summary>
        public virtual ICollection<GameGenre> Games { get; set; }
    }
}
