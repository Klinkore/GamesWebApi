using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BusinessLayer.Abstractions;
using BusinessLayer.Contracts.Models;
using Games.WebApi.Models.Games;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Games.Common;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;

namespace Games.WebApi.Controllers
{
    /// <summary>
    /// Контроллер игр
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : BaseGameController
    {
        private readonly IGameService _gameService;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public GameController(IGameService gameService, IMapper mapper) : base(mapper)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Получить игру
        /// </summary>
        /// <param name="id">Идентификатор</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Range(1, long.MaxValue)]long id)
        {
            return await ProcessResult<GameModel, GameDto>(async () => await _gameService.GetById(id));
        }

        /// <summary>
        /// Получить игры определенного жанра
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        [HttpGet("genre/{id}")]
        public async Task<IActionResult> GetByGenre([Range(1, long.MaxValue)] long id)
        {
            return await ProcessResult<ICollection<GameModel>, ICollection<GameDto>>(async () => await _gameService.GetByGenre(id));
        }

        /// <summary>
        /// Создать игру
        /// </summary>
        /// <param name="gameModel">Модель игры</param>
        [HttpPost]
        public async Task<IActionResult> Create([Required]GameCreateModel gameModel)
        {
            return await ProcessResultOfCreation<GameModel, GameDto>(
                async () => await _gameService.Create(_mapper.Map<GameDto>(gameModel)));
        }

        /// <summary>
        /// Получить все игры
        /// </summary>
        [AllowAnonymous]
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return await ProcessResult<ICollection<GameModel>, ICollection<GameDto>>(
                async () => await _gameService.GetAll());
        }

        /// <summary>
        /// Удалить игру
        /// </summary>
        /// <param name="id">Идентификтор</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Range(1, long.MaxValue)]long id)
        {
            return await ProcessResult(async () => await _gameService.Delete(id));
        }

        /// <summary>
        /// Обновить игру
        /// </summary>
        /// <param name="gameModel">Информация об игре</param>
        [HttpPut]
        public async Task<IActionResult> Update([Required]GameUpdateModel gameModel)
        {
            var gameDto = _mapper.Map<GameDto>(gameModel);
            return await ProcessResult(async () => await _gameService.Update(gameDto));
        }
    }
}
