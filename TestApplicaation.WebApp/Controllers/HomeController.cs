﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestApplicaation.WebApp.Models;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.CustomerDtos;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.CustomFilters;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Models;
using TestApplication.WebApp.Models.Interfaces;
using TestApplication.WebApp.Services.Interfaces;

namespace TestApplication.WebApp.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserManager _userManager;
        private readonly ICustomerCardManager _customerCardManager;
        private readonly ICustomerManager _customerManager;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public HomeController(ILoggedUserProvider loggedUserProvider,IEmailSender emailSender,ICustomerCardManager customerCardManager,ICustomerManager customerManager,IMapper mapper,IHttpContextAccessor httpContextAccessor,IUserManager userManager) : base(loggedUserProvider)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _customerCardManager = customerCardManager;
            _customerManager = customerManager;
            _emailSender = emailSender;
            _mapper = mapper;
            
        }

        [JwtAuthorize]
        public async Task<IActionResult> Index()
        {
            List<CustomerCard> customerCards = await _customerCardManager.GetAllASync();

            List<Customer> customers = await _customerManager.GetAllASync();

           
            //customers.ForEach(x =>
            //{
              //  customerCards.ForEach(y =>
               // {
                //    if (y.CustomerId == x.CustomerId)
                 //       x.CustomerCards.Add(y);
              //  });
           // });
            customerCards.ForEach(x =>
            {
                customers.ForEach(y =>
                {
                    if (y.CustomerId == x.CustomerId)
                        y.CustomerCards.Add(x);
                });
            });

            //List<CustomerCardListDto> empty = _mapper.Map<List<CustomerCardListDto>>(customerCards);
            List<CustomerListDto> customerListDtos = _mapper.Map<List<CustomerListDto>>(customers);

            //List<CustomerCardListDto> customerListDto = _mapper.Map<List<CustomerListDto>>(empty);
            return View(customers);
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
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmail(userRegisterDto.Email);              
                if (user!=null)
                {
                    ModelState.AddModelError("", "Your Email has been taken");
                    return View(userRegisterDto);
                }
                User addUser = _mapper.Map<User>(userRegisterDto);
                List<UserUserType> userUserType = new List<UserUserType>();
                userUserType.Add(new UserUserType() { UserId = addUser.UserId, UserTypeId = 2 });
                using var hmac = new HMACSHA512();
                addUser.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password));
                addUser.PasswordSalt = hmac.Key;
                addUser.Guid = Guid.NewGuid().ToString();
                addUser.userUserTypes = userUserType;
                await _userManager.AddAsync(addUser);
                return RedirectToAction("Login");
            }
            else
            {

                return View(userRegisterDto);

            }
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(UserForgotPasswordDto forgotPasswordDto)
        {
            if (ModelState.IsValid)
            {
                User user = _userManager.Find(x => x.Email == forgotPasswordDto.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Your Email is wrong");
                    return View(forgotPasswordDto);
                }
                else
                {
                    user.Guid = Guid.NewGuid().ToString();
                    _userManager.UpdateAsync(user);
                    _emailSender.SendEmail(forgotPasswordDto.Email, user.Guid);
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                return View(forgotPasswordDto);
            }

        }

        [Route("[controller]/{action}/{id}")]
        public IActionResult ChangePassword(Guid id)
        {
            User PasswordChangeUser = _userManager.Find(x => x.Guid == id.ToString());
            if (PasswordChangeUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                UserChangePasswordDto user = new UserChangePasswordDto
                {
                    UserId = PasswordChangeUser.UserId
                };

                return View(user);

            }
        }
        [HttpPost]
        [Route("[controller]/{action}/{id}")]
        public IActionResult ChangePassword(UserChangePasswordDto userChangePassword)
        {
            if (ModelState.IsValid)
            {
                if (userChangePassword.Password == userChangePassword.CorrectPassword)
                {
                    User updateUser = _userManager.Find(x => x.UserId == userChangePassword.UserId);
                    using var hmac = new HMACSHA512();
                    updateUser.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userChangePassword.Password));
                    updateUser.PasswordSalt = hmac.Key;
                    updateUser.Guid = Guid.NewGuid().ToString();
                    _userManager.UpdateAsync(updateUser);
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Password and Verify password cannot match");
                    return View(userChangePassword);
                }
            }
            else
            {
                ModelState.AddModelError("", "Write your password");

                return View(userChangePassword);

            }

        }


        public IActionResult Signout()
        {
            HttpContext.Session.Remove("token");
            return RedirectToAction("Login", "Home");
        }


    }
}
