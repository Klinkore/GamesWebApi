using Games.WebApi.Models.Genres;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Games.WebApi.Models.Games
{
    /// <summary>
    /// Модель, использующаяся для обновления информации об игре
    /// </summary>
    public class GameUpdateModel
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
        [Range(1, long.MaxValue)]
        public long DeveloperStudioId { get; set; }

        /// <summary>
        /// Жанры
        /// </summary>
        public ICollection<GenreUsingModel> Genres { get; set; }
    }
}
