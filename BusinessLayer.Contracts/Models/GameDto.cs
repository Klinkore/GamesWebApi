using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Contracts.Models
{
    /// <summary>
    /// Игра. Транспортный объект
    /// </summary>
    public class GameDto
    {
        /// <summary>
        /// Идентификатор игры
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название игры
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор студии разработчика
        /// </summary>
        public long DeveloperStudioId { get; set; }

        /// <summary>
        /// Студия разработчик
        /// </summary>
        public DeveloperStudioDto DeveloperStudio { get; set; }

        /// <summary>
        /// Жанры
        /// </summary>
        public ICollection<GenreDto> Genres { get; set; }
    }
}
