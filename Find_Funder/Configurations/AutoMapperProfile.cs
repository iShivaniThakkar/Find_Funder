using AutoMapper;
using FindFunder.Core.Domain.ResponseModel;
using FindFunder.Infra.Domain.Entities;

namespace Find_Funder.Configurations
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserResponseModel>();
            
        }
    }
}
