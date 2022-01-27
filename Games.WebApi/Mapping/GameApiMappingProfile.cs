using AutoMapper;
using BusinessLayer.Contracts.Models;
using Games.WebApi.Models.Games;

namespace Games.WebApi.Mapping
{
    /// <summary>
    /// Профиль маппера моделей игр
    /// </summary>
    public class GameApiMappingProfile : Profile
    {
        public GameApiMappingProfile()
        {
            CreateMap<GameCreateModel, GameDto>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DeveloperStudio, opt => opt.Ignore());
            CreateMap<GameUpdateModel, GameDto>()
                .ForMember(d => d.DeveloperStudio, opt => opt.Ignore());
            CreateMap<GameModel, GameDto>()
                .ForMember(d => d.DeveloperStudio, opt => opt.Ignore());
            CreateMap<GameDto, GameModel>();
        }
    }
}
