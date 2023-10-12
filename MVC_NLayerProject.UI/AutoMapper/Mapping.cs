using AutoMapper;
using MVC_NLayerProject.BLL.DTOs.UserDTOs;
using MVC_NLayerProject.UI.Models.VMs.UserVMs;

namespace MVC_NLayerProject.UI.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserVM, UserDTO>().ReverseMap();
            CreateMap<UserRegisterVM, UserRegisterDTO>().ReverseMap();
            CreateMap<UserUpdateVM, UserUpdateDTO>().ReverseMap();
            CreateMap<UserLogInVM, UserLoginDTO>().ReverseMap();
            CreateMap<UserDTO, UserUpdateVM>().ReverseMap();
        }
    }
}
