﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestApplicaation.WebApp.Models;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.CustomFilters;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Models;
using TestApplication.WebApp.Models.Interfaces;

namespace TestApplication.WebApp.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserManager _userManager;

        public HomeController(ILoggedUserProvider loggedUserProvider,IHttpContextAccessor httpContextAccessor,IUserManager userManager) : base(loggedUserProvider)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            
        }

        [JwtAuthorize]
        public IActionResult Index()
        {   
            return View();
        }

        public IActionResult Login()
        {
            string token = HttpContext.Session.GetString("token");
            UserDto user = JwtAuthorizeHelper.GetCurrentUser(token);

            if (user == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                User user = _userManager.Find(x => x.Email == userLoginDto.Email);
                if (user != null)
                {
                    var userJson = JsonConvert.SerializeObject(userLoginDto);
                    var stringContent = new StringContent(userJson, Encoding.UTF8, "application/json");

                    using var httpClient = new HttpClient();
                    var response = await httpClient.PostAsync("http://localhost:5000/api/Auth/Signin", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var token = JsonConvert.DeserializeObject<AccessToken>(await response.Content.ReadAsStringAsync());

                        _httpContextAccessor.HttpContext.Session.SetString("token", token.Token);

                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Api'Hatası");
                        return View(userLoginDto);
                    }


                }
                ModelState.AddModelError("", "Email Or Password is Wrong");
            }
            return View(userLoginDto);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Remove("token");
            return RedirectToAction("Signin", "Home");
        }


    }
}
