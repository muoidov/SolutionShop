using AdminApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using SolutionShop.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        public async Task<IActionResult> Index(string kw, int pi = 1, int ps = 1)
        {
            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                
                KeyWord = kw,
                PageIndex = pi,
                PageSize = ps
            };
            var data = await _userApiClient.GetUsersPagings(request);

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
            return RedirectToAction("Login", "User");
        }
        //chua thong tin dang nhap
       
    }   
}

