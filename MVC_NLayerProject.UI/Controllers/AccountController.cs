using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC_NLayerProject.BLL.DTOs.UserDTOs;
using MVC_NLayerProject.BLL.UserService;
using MVC_NLayerProject.UI.Models.VMs.UserVMs;

namespace MVC_NLayerProject.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVMs userRegisterVMs)
        {
            if (ModelState.IsValid)
            {
                UserRegisterDTO userRegisterDTO = _mapper.Map<UserRegisterDTO>(userRegisterVMs);
                var result = await _userService.Create(userRegisterDTO, userRegisterVMs.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }
    }
}
