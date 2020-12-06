
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SolutionShop.Data.Entities;
using SolutionShop.Utilities.Exceptions;
using SolutionShop.ViewModel.Catalog.ProductImages;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        
        public UserService(UserManager<AppUser> userManage,SignInManager<AppUser> signInManage,RoleManager<AppRole> roleManager,IConfiguration config)
        {
            _userManager = userManage;
            _signInManager = signInManage;
            _roleManager = roleManager;
            _config = config;
           
        }
        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null) return null;
            //throw new Shopexception("Not user name");

            var rs = await _signInManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, true);
            if (!rs.Succeeded)
            {
                return null;
            }
            var roles = _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role,string.Join(";",roles)),
                new Claim(ClaimTypes.Name,request.UserName)

            };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<PagedResult<UserVm>>>GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.UserName.Contains(request.KeyWord) || x.PhoneNumber.Contains
                  (request.KeyWord));
            }
            int totalRow = await query.CountAsync();

            var data = await query.Skip(request.PageIndex - 1 * request.PageSize).Take(request.PageSize).Select(x => new UserVm()
            {
               Email=x.Email,
               PhoneNumber=x.PhoneNumber,
               FirstName=x.FirstName,
               LastName=x.LastName,
               Id=x.Id,
               UserName=x.UserName
            }).ToListAsync();
            //chon project

            var pagedResult = new PagedResult<UserVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex=request.PageIndex,
                PageSize=request.PageSize,

            };
            return new ApiSuccessResult<PagedResult<UserVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiError<bool>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiError<bool>("Emai đã tồn tại");
            }

            user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, request.PassWord);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiError<bool>("Đăng ký không thành công");
        }

        public async Task<ApiResult<bool>> Update(Guid id,UserUpdateRequest request)
        {

            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiError<bool>("Emai đã tồn tại");
            }
            var user = await _userManager.FindByNameAsync(id.ToString());


            user.Dob = request.Dob;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiError<bool>("Update o thanh cong");
        }
        public async Task<ApiResult<UserVm>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                return new ApiError<UserVm>("User o ton tai");

            }
            var userVm = new UserVm()
            {
                Dob = user.Dob,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id=user.Id,
                PhoneNumber = user.PhoneNumber,
                UserName=user.UserName
            };
            return new ApiSuccessResult<UserVm>(userVm); 
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                return new ApiError<bool>("User o ton tai");

            }
            var rs=await _userManager.DeleteAsync(user);
            if(rs.Succeeded)
            return new ApiSuccessResult<bool>();
            return new ApiError<bool>("Ko xóa được");
    }
    }
}
