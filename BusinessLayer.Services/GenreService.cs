using System;
using BusinessLayer.Abstractions;
using DataAccess.Entities;
using DataAccess.Abstactions;
using BusinessLayer.Contracts.Models;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Games.Common;
using FluentValidation;
using Games.Common.Exceptions;

namespace BusinessLayer.Services
{
    /// <summary>
    /// Сервис для работы с жанрами
    /// </summary>
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenreRepository _genreRepository;
        private readonly AbstractValidator<GenreDto> _genreDtoValidator;

        public GenreService(IMapper mapper, IGenreRepository genreRepository, IUnitOfWork unitOfWork, AbstractValidator<GenreDto> genreDtoValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _genreRepository = genreRepository;
            _genreDtoValidator = genreDtoValidator;
        }

        /// <inheritdoc />
        public async Task<OperationResult<GenreDto>> GetById(long id)
        {
            var genre = await _genreRepository.GetById(id);
            if (genre != null)
            {
                return OperationResult<GenreDto>.Ok(_mapper.Map<GenreDto>(genre));
            }
            throw new EntityNotFoundException(ErrorMessage.GenreNotFound);
        }

        /// <inheritdoc />
        public async Task<OperationResult<ICollection<GenreDto>>> GetAll()
        {
            var genres = await _genreRepository.GetAll();
            return OperationResult<ICollection<GenreDto>>.Ok(_mapper.Map<ICollection<GenreDto>>(genres));
        }
        /// <inheritdoc/>
        public async Task<OperationResult<GenreDto>> Create(GenreDto genreDto)
        {
            var validationResult = await _genreDtoValidator.ValidateAsync(genreDto);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException(string.Join('\n',validationResult.Errors.Select(x => x.ErrorMessage)));
            }
            else
            {
                var genre = _mapper.Map<Genre>(genreDto);
                var result = await _genreRepository.Add(genre);
                await _unitOfWork.SaveChanges();
                return OperationResult<GenreDto>.Ok(_mapper.Map<GenreDto>(result));
            }

        }

        /// <inheritdoc/>
        public async Task<OperationResult<bool>> Update(GenreDto genreDto)
        {
            var validationResult = await _genreDtoValidator.ValidateAsync(genreDto);
            if (validationResult.IsValid)
            {
                var genre = await _genreRepository.GetById(genreDto.Id);
                if (genre == null)
                {
                    throw new EntityNotFoundException(ErrorMessage.GenreNotFound);
                }
                _mapper.Map(genreDto, genre);

                await _genreRepository.Update(genre);
                await _unitOfWork.SaveChanges();
                return OperationResult<bool>.Ok(true);
            }
            throw new BadRequestException(string.Join('\n',validationResult.Errors.Select(x => x.ErrorMessage)));
        }

        /// <inheritdoc/>
        public async Task<OperationResult<bool>> Delete(long id)
        {
            if (await _genreRepository.GetById(id) != null)
            {
                await _genreRepository.Delete(id);
                await _unitOfWork.SaveChanges();
                return OperationResult<bool>.Ok(true);
            }
            throw new EntityNotFoundException(ErrorMessage.GenreNotFound);
        }
    }
}
