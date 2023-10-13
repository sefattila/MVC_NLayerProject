using AutoMapper;
using MVC_NLayerProject.BLL.DTOs.ArticleDTOs;
using MVC_NLayerProject.BLL.DTOs.SubjectDTOs;
using MVC_NLayerProject.BLL.DTOs.UserDTOs;
using MVC_NLayerProject.UI.Models.VMs.ArticleVMs;
using MVC_NLayerProject.UI.Models.VMs.SubjectVMs;
using MVC_NLayerProject.UI.Models.VMs.UserVMs;

namespace MVC_NLayerProject.UI.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //User
            CreateMap<UserVM, UserDTO>().ReverseMap();
            CreateMap<UserRegisterVM, UserRegisterDTO>().ReverseMap();
            CreateMap<UserUpdateVM, UserUpdateDTO>().ReverseMap();
            CreateMap<UserLogInVM, UserLoginDTO>().ReverseMap();
            CreateMap<UserDTO, UserUpdateVM>().ReverseMap();

            //Article
            CreateMap<ArticleVM, ArticleDTO>().ReverseMap();
            CreateMap<ArticleCreateVM, ArticleCreateDTO>().ReverseMap();
            CreateMap<ArticleUpdateVM, ArticleUpdateDTO>().ReverseMap();
            CreateMap<ArticleUpdateVM, ArticleDTO>()
                .ForMember(dest => dest.AvgReadingTime, opt => opt.Ignore())
                .ForMember(dest=>dest.UserId,opt=>opt.Ignore())
                .ReverseMap();

            //Subject
            CreateMap<SubjectVM, SubjectDTO>().ReverseMap();
        }
    }
}
