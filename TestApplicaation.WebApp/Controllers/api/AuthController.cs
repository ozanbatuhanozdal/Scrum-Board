using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.Common.Token;

namespace TestApplication.WebApp.Controllers.api
{
    //api controller
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtManager _jwtManager;
        private readonly IUserManager _userManager;

        public AuthController(IJwtManager jwtManager, IUserManager userManager)
        {
            _jwtManager = jwtManager;
            _userManager = userManager;
        }

        [HttpPost("[action]")]        
        public async Task<IActionResult> Signin(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmail(userLoginDto.Email);
            if (user == null)
            {
                return BadRequest("Kullanıcı adı Yada Şifre Hatalı");
            }
            else
            {
                if (await _userManager.CheckPassword(userLoginDto))
                {
                    var roles = await _userManager.GetRolesByEmail(userLoginDto.Email);
                    var token = _jwtManager.TokenCreate(user, roles);
                    JwtAccessToken jwtAccessToken = new JwtAccessToken
                    {
                        Token = token
                    };
                    return Created("", jwtAccessToken);
                }
                return BadRequest("Kullanıcı Adı Veya Şifre Hatalı");
            }
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _userManager.FindByEmail(User.Identity.Name);
            var roles = await _userManager.GetRolesByEmail(User.Identity.Name);


            UserDto userDto = new UserDto
            {
                UserId = user.UserId,                
                Email = user.Email,           
                Name = user.Name,
                Roles = roles.Select(x => x.UserTypeName).ToList()

            };



            return Ok(userDto);


        }
    }
}
