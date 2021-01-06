using AutoMapper;
using Users.Contracts.Users;
using Users.Data.Entities;
using Users.Models.Users;

namespace Users.WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Contracts to models
            CreateMap<UserContract, UserModel>().ReverseMap();
            CreateMap<CreateUserContract, UserModel>().ReverseMap();
            #endregion

            #region Models to entities
            CreateMap<UserModel, UserEntity>().ReverseMap();
            #endregion
        }
    }
}