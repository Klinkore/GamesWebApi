using Games.WebApi.Models.Genres;
using Games.WebApi.Models.DeveloperStudios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Games.WebApi.Models.Games
{
    /// <summary>
    /// Модель игры
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор студии разработчика, которой пренадлежит игра
        /// </summary>
        [Required]
        public DeveloperStudioModel DeveloperStudio { get; set; }

        /// <summary>
        /// Жанры
        /// </summary>
        public ICollection<GenreModel> Genres { get; set; }
    }
}
