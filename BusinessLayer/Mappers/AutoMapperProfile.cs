using AutoMapper;
using Dtos.RoleDtos;
using Dtos.UserDtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserForLoginDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserToAddDto, User>();
            CreateMap<UserToUpdateDto, User>();
            CreateMap< User, UserToListDto>();
            CreateMap< Role, RoleToListDto>();
            CreateMap< RoleToAddDto, Role>();
        }
    }
}
