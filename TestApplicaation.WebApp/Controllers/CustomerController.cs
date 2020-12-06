using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Common.Dto.UserDtos;

namespace TestApplication.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async  Task<IActionResult> Create(UserAddDto model)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateDto userUpdateDto)
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }
    }
}
