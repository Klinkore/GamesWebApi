using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstractions;
using DataAccess.Entities;
using DataAccess.Abstactions;
using AutoMapper;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using Games.Common;
using FluentValidation;
using Games.Common.Exceptions;

namespace BusinessLayer.Services
{
    /// <summary>
    /// Реализация сервиса работы с играми
    /// </summary>
    public class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameRepository _gameRepository;
        private readonly IDeveloperStuidoRepository _developerStudioRepository;
        private readonly AbstractValidator<GameDto> _gameDtoValidator;

        public GameService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IGameRepository gameRepository,
            IDeveloperStuidoRepository developerStudioRepository,
            AbstractValidator<GameDto> gameDtoValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _gameRepository = gameRepository;
            _developerStudioRepository = developerStudioRepository;
            _gameDtoValidator = gameDtoValidator;
        }

        /// <inheritdoc />
        public async Task<OperationResult<GameDto>> GetById(long id)
        {
            var game = await _gameRepository.GetById(id);
            if (game != null)
            {
                var gameDto = _mapper.Map<GameDto>(game);
                var genres = await _gameRepository.GetGenres(id);
                if (genres?.Any() != null)
                {
                    gameDto.Genres = _mapper.Map<ICollection<GenreDto>>(genres);
                }
                return OperationResult<GameDto>.Ok(gameDto);
            }
            throw new EntityNotFoundException(ErrorMessage.GameNotFound);
        }

        /// <inheritdoc />
        public async Task<OperationResult<ICollection<GameDto>>> GetByGenre(long id)
        {
            var games = await _gameRepository.GetByGenre(id);
            if (games != null)
            {
                var result = attachGenres(games).Result;
                return OperationResult<ICollection<GameDto>>.Ok(result);
            }
            throw new EntityNotFoundException(ErrorMessage.GameNotFound);
        }

        /// <inheritdoc />
        public async Task<OperationResult<ICollection<GameDto>>> GetAll()
        {
            var games = await _gameRepository.GetAll();
            if(games != null)
            {
               var result = attachGenres(games).Result;
                return OperationResult<ICollection<GameDto>>.Ok(result);
            }
            return OperationResult<ICollection<GameDto>>.Ok(_mapper.Map<ICollection<GameDto>>(games));
        }

        /// <inheritdoc />
        public async Task<OperationResult<GameDto>> Create(GameDto gameDto)
        {
            var validationResult = await _gameDtoValidator.ValidateAsync(gameDto);
            if (validationResult.IsValid)
            {
                var game = _mapper.Map<Game>(gameDto);
                var newEntity = await _gameRepository.Add(game);
                await _unitOfWork.SaveChanges();
                var result = _mapper.Map<GameDto>(newEntity);
                if (gameDto.Genres != null)
                {
                    await _gameRepository.UpdateGenres(_mapper.Map<ICollection<Genre>>(gameDto.Genres).ToList(), newEntity.Id);
                    await _unitOfWork.SaveChanges();
                    var genres = _mapper.Map<ICollection<GenreDto>>(await _gameRepository.GetGenres(result.Id));
                    result.Genres = genres;
                }
                return OperationResult<GameDto>.Ok(result);
            }
            throw new BadRequestException(string.Join('\n', validationResult.Errors.Select(x => x.ErrorMessage).ToArray()));
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> Update(GameDto gameDto)
        {
            var validationResult = await _gameDtoValidator.ValidateAsync(gameDto);
            if (validationResult.IsValid)
            {
                var game = await _gameRepository.GetById(gameDto.Id);
                if (game != null)
                {
                    _mapper.Map(gameDto, game);
                    await _gameRepository.Update(game);
                    await _gameRepository.UpdateGenres(_mapper.Map<ICollection<Genre>>(gameDto.Genres).ToList(), game.Id);
                    await _unitOfWork.SaveChanges();
                    game = await _gameRepository.GetById(gameDto.Id);
                    return OperationResult<bool>.Ok(true);
                }
                throw new EntityNotFoundException(ErrorMessage.GameNotFound);
            }
            throw new BadRequestException(string.Join('\n', validationResult.Errors.Select(x => x.ErrorMessage).ToArray()));
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> Delete(long id)
        {
            var game = await _gameRepository.GetById(id);
            if (game != null)
            {
                await _gameRepository.Delete(id);
                await _unitOfWork.SaveChanges();
                return OperationResult<bool>.Ok(true);

            }
            throw new EntityNotFoundException(ErrorMessage.GameNotFound);
        }

        private async Task<ICollection<GameDto>> attachGenres(ICollection<Game> games)
        {
            var gamesDto = _mapper.Map<ICollection<GameDto>>(games);
            foreach (var game in gamesDto)
            {
                var genres = await _gameRepository.GetGenres(game.Id);
                if (genres?.Any() != null)
                {
                    game.Genres = _mapper.Map<ICollection<GenreDto>>(genres);
                }
            }
            return gamesDto;
        }
    }
}
