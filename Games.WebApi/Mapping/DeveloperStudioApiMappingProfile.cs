using AutoMapper;
using BusinessLayer.Contracts.Models;
using Games.WebApi.Models.DeveloperStudios;

namespace Games.WebApi.Mapping
{
    /// <summary>
    /// Профиль маппера для моделей студий разработчиков
    /// </summary>
    public class DeveloperStudioApiMappingProfile : Profile
    {
        /// <summary>
        /// Конструктор маппера
        /// </summary>
        public DeveloperStudioApiMappingProfile()
        {
            CreateMap<DeveloperStudioCreateModel, DeveloperStudioDto>()
                .ForMember(d => d.Id, opt => opt.Ignore());
            CreateMap<DeveloperStudioUpdateModel, DeveloperStudioDto>();
            CreateMap<DeveloperStudioModel, DeveloperStudioDto>();
            CreateMap<DeveloperStudioDto, DeveloperStudioModel>();
        }
    }
}
