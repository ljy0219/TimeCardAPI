using AutoMapper;
using TimeCard.Model;
using TimeCard.Model.DTO;

namespace TimeCard.API.Utilities
{
    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            CreateMap<UserInfo, UserInfoDTO>;
        }
    }
}