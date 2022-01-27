using AutoMapper;
using BusinessLayer.Contracts.Models;
using DataAccess.Entities;

namespace BusinessLayer.Services.Mapping
{
    /// <summary>
    /// Профиль автомаппера
    /// </summary>
    public class ServiceMappingsProfile : Profile
    {
        public ServiceMappingsProfile()
        {
            CreateMap<Genre, GenreDto>()
                 .ForMember(d => d.Games, opt => opt.Ignore());
            CreateMap<GenreDto, Genre>()
                 .ForMember(d => d.Games, opt => opt.Ignore());
            CreateMap<Game, GameDto>()
                .ForMember(d => d.Genres, opt => opt.Ignore());
            CreateMap<DeveloperStudio, DeveloperStudioDto>();
            CreateMap<DeveloperStudioDto, DeveloperStudio>();
            CreateMap<GameDto, Game>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Genres, opt => opt.Ignore());
        }
    }
}
