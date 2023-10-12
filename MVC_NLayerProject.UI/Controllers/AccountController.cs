using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_NLayerProject.BLL.DTOs.UserDTOs;
using MVC_NLayerProject.BLL.UserService;
using MVC_NLayerProject.UI.Models.VMs.UserVMs;
using System.Security.Claims;

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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUserId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserDTO users = await _userService.GetById(currentUserId);
            UserVM userVMs = _mapper.Map<UserVM>(users);
            return View(userVMs);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (ModelState.IsValid)
            {
                UserRegisterDTO userRegisterDTO = _mapper.Map<UserRegisterDTO>(userRegisterVM);
                var result = await _userService.Create(userRegisterDTO, userRegisterVM.Password);
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

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserLogInVM userLoginVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserLoginDTO userLoginDTO = _mapper.Map<UserLoginDTO>(userLoginVM);
                    await _userService.LogIn(userLoginDTO);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(userLoginVM);
        }

        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOut();
            return RedirectToAction("Login");
        }

        [Authorize]
        public async Task<IActionResult> Update(string id)
        {
            UserDTO user = await _userService.GetById(id);
            if (user == null)
                return NotFound();
            UserUpdateVM userUpdateVM = _mapper.Map<UserUpdateVM>(user);
            return View(userUpdateVM);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateVM userUpdateVM)
        {
            if (ModelState.IsValid)
            {
                UserUpdateDTO userUpdateDTO = _mapper.Map<UserUpdateDTO>(userUpdateVM);
                var result = await _userService.Update(userUpdateDTO);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(userUpdateVM);
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userService.Delete(id);
            if (result.Succeeded)
                return RedirectToAction("Index");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(result);
        }
    }
}
