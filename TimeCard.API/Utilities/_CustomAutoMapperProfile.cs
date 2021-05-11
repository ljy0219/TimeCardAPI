using AutoMapper;
using TimeCard.Model;
using TimeCard.Model.DTO;

namespace TimeCard.API.Utilities
{
    public class _CustomAutoMapperProfile : Profile
    {
        public _CustomAutoMapperProfile()
        {
            base.CreateMap<UserInfo,UserInfoDTO>;
        }
    }
}