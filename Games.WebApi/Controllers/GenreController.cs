using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BusinessLayer.Abstractions;
using BusinessLayer.Contracts.Models;
using Games.WebApi.Models.Genres;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Games.WebApi.Controllers
{
    /// <summary>
    /// Контроллер жанров
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : BaseGameController
    {
        private readonly IGenreService _genreService;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public GenreController(IGenreService genreService, IMapper mapper) : base(mapper)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Получить жанр
        /// </summary>
        /// <param name="id">Идентификатор</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Range(1, long.MaxValue)]long id)
        {
            return await ProcessResult<GenreModel, GenreDto>(async () => await _genreService.GetById(id));
        }

        /// <summary>
        /// Получить все жанры
        /// </summary>
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return await ProcessResult<ICollection<GenreModel>, ICollection<GenreDto>>(
                async () => await _genreService.GetAll());
        }

        /// <summary>
        /// Создать жанр
        /// </summary>
        /// <param name="genreCreateModel">Модель жанра</param>
        [HttpPost]
        public async Task<IActionResult> Create([Required]GenreCreateModel genreCreateModel)
        {
            return await ExecuteMethod(
                async () => await _genreService.Create(_mapper.Map<GenreDto>(genreCreateModel)));
        }

        /// <summary>
        /// Удалить жанр
        /// </summary>
        /// <param name="id">Идентификтор</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Range(1, long.MaxValue)]long id)
        {
            return await ExecuteMethod(async () => await _genreService.Delete(id));
        }

        /// <summary>
        /// Обновить жанр
        /// </summary>
        /// <param name="genreModel">Модель жанра</param>
        [HttpPut]
        public async Task<IActionResult> Update([Required]GenreModel genreModel)
        {
            return await ProcessResult(async () => await _genreService.Update(_mapper.Map<GenreDto>(genreModel)));
        }
    }
}
