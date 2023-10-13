using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_NLayerProject.BLL.ArticleService;
using MVC_NLayerProject.BLL.DTOs.ArticleDTOs;
using MVC_NLayerProject.BLL.UserService;
using MVC_NLayerProject.UI.Models.VMs.ArticleVMs;
using System.Security.Claims;

namespace MVC_NLayerProject.UI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, IMapper mapper, IUserService userService)
        {
            _articleService = articleService;
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult Index()
        {
            IList<ArticleDTO> articleDTOs = _articleService.GetActives(); ;
            IList<ArticleVM> articleVMs = _mapper.Map<IList<ArticleVM>>(articleDTOs);
            return View(articleVMs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArticleCreateVM articleCreateVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    articleCreateVM.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    ArticleCreateDTO articleCreateDTO = _mapper.Map<ArticleCreateDTO>(articleCreateVM);
                    _articleService.Create(articleCreateDTO);
                    return RedirectToAction("Index");

                }
                catch (ArgumentNullException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
            return RedirectToAction("Register", "Account");
        }
        [Authorize]
        public IActionResult Update(int id)
        {
            ArticleDTO articleDTO = _articleService.GetById(id);
            ArticleUpdateVM articleUpdateVM = _mapper.Map<ArticleUpdateVM>(articleDTO);
            return View(articleUpdateVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(ArticleUpdateVM articleUpdateVM)
        {
            try
            {
                ArticleUpdateDTO articleUpdateDTO = _mapper.Map<ArticleUpdateDTO>(articleUpdateVM);
                _articleService.Update(articleUpdateDTO);
                return RedirectToAction("Index");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult CurrentUserArticle()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IList<ArticleDTO> articleDTOs = _articleService.CurrentUserArticles(currentUserId);
            IList<ArticleVM> articleVMs = _mapper.Map<IList<ArticleVM>>(articleDTOs);
            return View(articleVMs);
        }

        public IActionResult InspectArticle(int id)
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
