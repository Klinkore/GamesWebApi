using AutoMapper;
using BusinessLayer.Contracts.Models;
using Games.WebApi.Models.Genres;

namespace Games.WebApi.Mapping
{
    /// <summary>
    /// Профиль маппера для моделей тега
    /// </summary>
    public class GenreApiMappingProfile : Profile
    {
        /// <summary>
        /// Конструктор маппера
        /// </summary>
        public GenreApiMappingProfile()
        {
            CreateMap<GenreModel, GenreDto>()
                .ForMember(d => d.Games, opt => opt.Ignore());
            CreateMap<GenreCreateModel, GenreDto>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Games, opt => opt.Ignore());
            CreateMap<GenreUsingModel, GenreDto>()
                .ForMember(d => d.Name, opt => opt.Ignore())
                .ForMember(d => d.Games, opt => opt.Ignore());
            CreateMap<GenreDto, GenreModel>();
        }
    }
}
