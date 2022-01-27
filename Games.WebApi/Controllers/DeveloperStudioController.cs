using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BusinessLayer.Abstractions;
using BusinessLayer.Contracts.Models;
using Games.WebApi.Models.DeveloperStudios;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Games.WebApi.Controllers
{
    /// <summary>
    /// Контроллер студий разработчиков
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperStudioController : BaseGameController
    {
        private readonly IDeveloperStudioService _developerStudioService;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public DeveloperStudioController(IDeveloperStudioService developerStudioService, IMapper mapper) : base(mapper)
        {
            _developerStudioService = developerStudioService;
        }

        /// <summary>
        /// Получить студию разработчика
        /// </summary>
        /// <param name="id">Идентификатор</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Range(1, long.MaxValue)]long id)
        {
            return await ProcessResult<DeveloperStudioModel, DeveloperStudioDto>(async () => await _developerStudioService.GetById(id));
        }

        /// <summary>
        /// Получить все студии разработчики
        /// </summary>
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return await ProcessResult<ICollection<DeveloperStudioModel>, ICollection<DeveloperStudioDto>>(
                async () => await _developerStudioService.GetAll());
        }

        /// <summary>
        /// Создать студию разработчика
        /// </summary>
        /// <param name="developerStudioModel">Модель студии разработчика</param>
        [HttpPost]
        public async Task<IActionResult> Create([Required]DeveloperStudioCreateModel developerStudioModel)
        {
            return await ProcessResultOfCreation<DeveloperStudioModel, DeveloperStudioDto>(
                async () => await _developerStudioService.Create(_mapper.Map<DeveloperStudioDto>(developerStudioModel)));
        }

        /// <summary>
        /// Удалить студию разработчика
        /// </summary>
        /// <param name="id">Идентификтор</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Range(1, long.MaxValue)]long id)
        {
            return await ProcessResult(async () => await _developerStudioService.Delete(id));
        }

        /// <summary>
        /// Обновить студию разработчика
        /// </summary>
        /// <param name="developerStudioModel">Модель студии разработчика</param>
        [HttpPut]
        public async Task<IActionResult> Update([Required]DeveloperStudioUpdateModel developerStudioModel)
        {
            return await ProcessResult(async () => await _developerStudioService.Update(_mapper.Map<DeveloperStudioDto>(developerStudioModel)));
        }
    }
}
