using ApiIntegration.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Users;
using System;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IRoleApiClient _roleApiClient;

        public UserController(IUserApiClient userApiClient, IConfiguration configuration,IRoleApiClient roleApiClient)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _roleApiClient = roleApiClient;
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
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
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
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }
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
            {
                TempData["result"] = "Tạo thành công";
                return RedirectToAction("Index");
            }
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
            return RedirectToAction("Error", "HomeA");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _userApiClient.UpdateUser(request.Id,request);
            if (rs.IsSuccessed)
            {
                TempData["result"] = "Cập nhật người dùng thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", rs.Message);

            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> RoleAsign(Guid id)
        {
            var roleAssignRequest = await GetRoleAssignRequest(id);
            return View(roleAssignRequest);
        }
        [HttpPost]
        public async Task<IActionResult> RoleAsign(RoleAsignRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _userApiClient.RoleAsign(request.Id, request);
            if (rs.IsSuccessed)
            {
                TempData["result"] = "Cập nhật quyền thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", rs.Message);
            var roleAssignRequest =await GetRoleAssignRequest(request.Id);

            return View(roleAssignRequest);
        }
        private async Task<RoleAsignRequest> GetRoleAssignRequest(Guid id)
        {
            var rs = await _userApiClient.GetById(id);
            var role = await _roleApiClient.GetAll();
            var roleAsignRequest = new RoleAsignRequest();
            foreach (var roleName in role.Result)
            {
                roleAsignRequest.Roles.Add(new SelectItem()
                {
                    Id = roleName.Id.ToString(),
                    Name = roleName.Name,
                    Selected = rs.Result.Roles.Contains(roleName.Name)
                });
            }
            return roleAsignRequest;
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

