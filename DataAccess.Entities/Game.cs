using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Entities
{
    /// <summary>
    /// Игра
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор студии разработчика
        /// </summary>
        public long DeveloperStudioId { get; set; }

        /// <summary>
        /// Ссылка на студию разработчика
        /// </summary>
        public virtual DeveloperStudio DeveloperStudio { get; set; }
      
        /// <summary>
        /// Жанры игры
        /// </summary>
        public virtual ICollection<GameGenre> Genres { get; set; }
    }
}
