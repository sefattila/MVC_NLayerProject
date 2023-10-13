using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC_NLayerProject.BLL.ArticleService;
using MVC_NLayerProject.BLL.DTOs.ArticleDTOs;
using MVC_NLayerProject.BLL.DTOs.SubjectDTOs;
using MVC_NLayerProject.BLL.SubjectService;
using MVC_NLayerProject.BLL.UserService;
using MVC_NLayerProject.CORE.Entities;
using MVC_NLayerProject.CORE.Repositories;
using MVC_NLayerProject.UI.Models.VMs.ArticleVMs;
using MVC_NLayerProject.UI.Models.VMs.SubjectVMs;

namespace MVC_NLayerProject.UI.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public SubjectController(IMapper mapper, ISubjectService subjectService, IArticleService articleService, IUserService userService)
        {
            _mapper = mapper;
            _subjectService = subjectService;
            _articleService = articleService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            IList<SubjectDTO> subjectDTOs = _subjectService.GetActive();
            IList<SubjectVM> subjectVMs = _mapper.Map<IList<SubjectVM>>(subjectDTOs);
            return View(subjectVMs);
        }

        public IActionResult Articles(int id)
        {
            IList<ArticleDTO> articleDTOs = _articleService.GetArticleBySubjectId(id);
            IList<ArticleVM> articleVMs = _mapper.Map<IList<ArticleVM>>(articleDTOs);
            return View(articleVMs);
        }

        public IActionResult InspectArticles(int id)
        {
            ArticleDTO articleDTO = _articleService.GetById(id);
            UserArticleVM userArticleVM = new UserArticleVM
            {
                Id = articleDTO.Id,
                Header = articleDTO.Header,
                Content = articleDTO.Content,
                AvgReadingTime = articleDTO.AvgReadingTime,
                UserName = _userService.GetUserName(articleDTO.UserId)
            };
            return View(userArticleVM);
        }
    }
}
