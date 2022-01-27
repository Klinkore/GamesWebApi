using AutoMapper;
using BusinessLayer.Contracts;
using Games.Common;
using Games.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Games.WebApi.Controllers
{
    /// <summary>
    /// Базовый класс контроллеров
    /// </summary>
    public class BaseGameController : ControllerBase
    {
        /// <summary>
        /// Интерфейс маппера
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Конструктор базового контроллера
        /// </summary>
        public BaseGameController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Выполнение метода переданного через параметры
        /// </summary>
        /// <typeparam name="TRequest">Тип данных возвращаеммых сервисом</typeparam>
        /// <param name="actionMethod">Метод сервисов</param>
        /// <returns>Данные о результатах выполнения метода сервиса</returns>
        public async Task<IActionResult> ExecuteMethod<TRequest>(Func<Task<OperationResult<TRequest>>> actionMethod)
        {
            try
            {
                var operationResult = await actionMethod.Invoke();
                if (!operationResult.Success)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        operationResult.GetErrors());
                }

                return Ok(operationResult.Result);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (BadRequestException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (ForbiddenException e)
            {
                return StatusCode(StatusCodes.Status403Forbidden, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessage.InternalServerError);
            }
        }

        /// <summary>
        /// Обработка результатов выполнения метода сервисов
        /// </summary>
        /// <typeparam name="TRequest">Тип данных возвращаеммых сервисом</typeparam>
        /// <param name="actionMethod">Метод сервисов</param>
        /// <returns>Данные о результатах выполнения метода сервиса</returns>
        protected async Task<IActionResult> ProcessResult<TRequest>(Func<Task<OperationResult<TRequest>>> actionMethod)
        {
            return await ExecuteMethod(actionMethod);
        }

        /// <summary>
        /// Обработка результатов выполнения метода сервисов
        /// </summary>
        /// <typeparam name="TResult">Тип результата который необходимо вернуть</typeparam>
        /// <typeparam name="TRequest">Тип данных возвращаеммых сервисом</typeparam>
        /// <param name="actionMethod">Метод сервисов</param>
        /// <returns>Данные о результатах выполнения метода сервиса</returns>
        protected async Task<IActionResult> ProcessResult<TResult, TRequest>(Func<Task<OperationResult<TRequest>>> actionMethod)
        {
            var result = await ExecuteMethod(actionMethod);
            if (result is OkObjectResult)
            {
                return Ok(_mapper.Map<TResult>(((OkObjectResult)result).Value));
            };
            return result;
        }

        /// <summary>
        /// Обработка результатов создания сущности при помощи метода сервисов
        /// </summary>
        /// <typeparam name="TResult">Тип результата который необходимо вернуть</typeparam>
        /// <typeparam name="TRequest">Тип данных возвращаеммых сервисом</typeparam>
        /// <param name="actionMethod">Метод сервисов</param>
        /// <returns>Данные о результатах выполнения метода сервиса</returns>
        protected async Task<IActionResult> ProcessResultOfCreation<TResult, TRequest>(Func<Task<OperationResult<TRequest>>> actionMethod)
        {
            var result = await ExecuteMethod(actionMethod);
            if (result is OkObjectResult)
            {
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<TResult>(((OkObjectResult)result).Value));
            };
            return result;
        }

        /// <summary>
        /// Обработка результатов создания сущности при помощи метода сервисов
        /// </summary>
        /// <typeparam name="TRequest">Тип данных возвращаеммых сервисом</typeparam>
        /// <param name="actionMethod">Метод сервисов</param>
        /// <returns>Данные о результатах выполнения метода сервиса</returns>
        protected async Task<IActionResult> ProcessResultOfCreation<TRequest>(Func<Task<OperationResult<TRequest>>> actionMethod)
        {
            var result = await ExecuteMethod(actionMethod);
            if (result is OkObjectResult)
            {
                return StatusCode(StatusCodes.Status201Created, ((OkObjectResult)result).Value);
            };
            return result;
        }
    }
}
