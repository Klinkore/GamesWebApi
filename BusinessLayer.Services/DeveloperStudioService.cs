using System;
using BusinessLayer.Abstractions;
using DataAccess.Entities;
using DataAccess.Abstactions;
using AutoMapper;
using BusinessLayer.Contracts;
using System.Threading.Tasks;
using BusinessLayer.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using Games.Common;
using FluentValidation;
using Games.Common.Exceptions;

namespace BusinessLayer.Services
{
    /// <summary>
    /// Сервис для работы с студиями разработчиками
    /// </summary>
    public class DeveloperStudioService : IDeveloperStudioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeveloperStuidoRepository _developerStudioRepository;
        private readonly AbstractValidator<DeveloperStudioDto> _developerStudioDtoValidator;

        public DeveloperStudioService(IMapper mapper, IUnitOfWork unitOfWork, IDeveloperStuidoRepository developerStudioRepository, AbstractValidator<DeveloperStudioDto> developerStudioDtoValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _developerStudioRepository = developerStudioRepository;
            _developerStudioDtoValidator = developerStudioDtoValidator;
        }

        /// <inheritdoc/>
        public async Task<OperationResult<DeveloperStudioDto>> GetById(long id)
        {
            var developerStudio = await _developerStudioRepository.GetById(id);
            if (developerStudio != null)
            {
                return OperationResult<DeveloperStudioDto>.Ok(_mapper.Map<DeveloperStudioDto>(developerStudio));
            }
            throw new EntityNotFoundException(ErrorMessage.DeveloperStudioNotFound);
        }

        /// <inheritdoc/>
        public async Task<OperationResult<ICollection<DeveloperStudioDto>>> GetAll()
        {
            var developerStudios = await _developerStudioRepository.GetAll();
            return OperationResult<ICollection<DeveloperStudioDto>>.Ok(_mapper.Map<ICollection<DeveloperStudioDto>>(developerStudios));
        }

        /// <inheritdoc/>
        public async Task<OperationResult<DeveloperStudioDto>> Create(DeveloperStudioDto developerStudioDto)
        {
            var validationResult = await _developerStudioDtoValidator.ValidateAsync(developerStudioDto);
            if (validationResult.IsValid)
            {
                var developerStudio = _mapper.Map<DeveloperStudio>(developerStudioDto);
                var result = await _developerStudioRepository.Add(developerStudio);
                await _unitOfWork.SaveChanges();
                return OperationResult<DeveloperStudioDto>.Ok(_mapper.Map<DeveloperStudioDto>(result));
            }
            throw new BadRequestException(string.Join('\n',validationResult.Errors.Select(x => x.ErrorMessage).ToArray()));
        }

        /// <inheritdoc/>
        public async Task<OperationResult<bool>> Update(DeveloperStudioDto developerStudioDto)
        {
            var validationResult = await _developerStudioDtoValidator.ValidateAsync(developerStudioDto);
            if (validationResult.IsValid)
            {
                var developerStudio = await _developerStudioRepository.GetById(developerStudioDto.Id);
                if (developerStudio == null)
                {
                    throw new EntityNotFoundException(ErrorMessage.DeveloperStudioNotFound);
                }
                _mapper.Map(developerStudioDto, developerStudio);
                await _developerStudioRepository.Update(developerStudio);
                await _unitOfWork.SaveChanges();
                return OperationResult<bool>.Ok(true);
            }
            throw new BadRequestException(string.Join('\n',validationResult.Errors.Select(x => x.ErrorMessage).ToArray()));
        }

        /// <inheritdoc/>
        public async Task<OperationResult<bool>> Delete(long id)
        {
            if (await _developerStudioRepository.GetById(id) != null)
            {
                await _developerStudioRepository.Delete(id);
                await _unitOfWork.SaveChanges();
                return OperationResult<bool>.Ok(true);
            }
            throw new EntityNotFoundException(ErrorMessage.DeveloperStudioNotFound);
        }
    }
}
