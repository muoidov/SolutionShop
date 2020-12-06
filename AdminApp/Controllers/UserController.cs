using AdminApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SolutionShop.ViewModel.System.Users;
using System;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string kw, int pi = 1, int ps = 10)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                
                KeyWord = kw,
                PageIndex = pi,
                PageSize = ps
            };
            var data = await _userApiClient.GetUsersPagings(request);
            ViewBag.Keyword = kw;
            return View(data.Result);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var rs = await _userApiClient.GetById(id);
            return View(rs.Result);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {

            return View(new UserDeleteRequest()
            {Id=id
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UserDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _userApiClient.Delete(request.Id);
            if (rs.IsSuccessed)
                return RedirectToAction("Index");
            ModelState.AddModelError("", rs.Message);

            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _userApiClient.RegisterUser(request);
            if (rs.IsSuccessed)
                return RedirectToAction("Index");
            ModelState.AddModelError("", rs.Message);

            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var rs = await _userApiClient.GetById(id);
            if (rs.IsSuccessed) {
                var user = rs.Result;
                var updateRequest = new UserUpdateRequest()
                {
                Dob = user.Dob,
                Email=user.Email,
                LastName=user.LastName,
                FirstName=user.FirstName,
                PhoneNumber=user.PhoneNumber,
                Id=user.Id};
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _userApiClient.UpdateUser(request.Id,request);
            if (rs.IsSuccessed)
                return RedirectToAction("Index");
            ModelState.AddModelError("", rs.Message);

            return View(request);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        //chua thong tin dang nhap
       
    }   
}

