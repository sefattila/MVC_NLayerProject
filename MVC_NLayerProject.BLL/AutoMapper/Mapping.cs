using AutoMapper;
using MVC_NLayerProject.BLL.DTOs.UserDTOs;
using MVC_NLayerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.BLL.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //User Mapping
            CreateMap<UserDTO, AppUser>().ReverseMap();
            CreateMap<UserRegisterDTO, AppUser>().ReverseMap();
            CreateMap<UserUpdateDTO, AppUser>().ReverseMap();
            CreateMap<UserLoginDTO, AppUser>().ReverseMap();
        }
    }
}
