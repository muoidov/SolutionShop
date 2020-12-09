using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.System.Users;
using SolutionShop.ViewModel.System.Users;
using System;
using System.Threading.Tasks;

namespace BackendApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Authencate(request);

            if (string.IsNullOrEmpty(result.Result))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var rs = await _userService.Register(request);
            if (!rs.IsSuccessed)
            {
                return BadRequest(rs);
            }
            
            return Ok(rs);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody]UserUpdateRequest request)
        {
                if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var rs = await _userService.Update(id,request);
            if (!rs.IsSuccessed)
            {
                return BadRequest(rs);
            }

            return Ok(rs);
        }
        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAsign(Guid id, [FromBody]RoleAsignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var rs = await _userService.RoleAsign(id, request);
            if (!rs.IsSuccessed)
            {
                return BadRequest(rs);
            }

            return Ok(rs);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]GetUserPagingRequest request)
        {
            var products = await _userService.GetUsersPaging(request);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rs = await _userService.Delete(id);
            return Ok(rs);
        }
    }
}

