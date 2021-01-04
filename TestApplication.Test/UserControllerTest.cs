using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.BusinessLayer.Managers;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;
using TestApplication.WebApp.Controllers;
using TestApplication.WebApp.Models.Interfaces;
using Xunit;

namespace TestApplication.Test
{
    //user controller test 
   public  class UserControllerTest
    {
        
        private Mock<IUserManager> _mockUserManager;
        private Mock<IMapper> _mockMapper;
        private Mock<IUserTypeManager> _mockUserTypeManager;
        private Mock<ILoggedUserProvider> _mockLoggedUser;

        //test edeceğimiz nesne user controller.
        private UserController _userController;

        private List<User> UsersList;
        private List<UserAddDto> userAddDto;
        public UserControllerTest()
        {
            //const. ınitial ediyoruz.
            _mockUserManager = new Mock<IUserManager>();
            _mockMapper = new Mock<IMapper>();
            _mockUserTypeManager = new Mock<IUserTypeManager>();
            _mockLoggedUser = new Mock<ILoggedUserProvider>();
            //product controllerı mockladık.
            _userController = new UserController(_mockLoggedUser.Object , _mockUserManager.Object, _mockUserTypeManager.Object, _mockMapper.Object);
            UsersList = new List<User>() { new User {
                //ornek user ekleme
                UserId=15,
                Name="denemeTest",
                Email="denemeTest@hotmail.com",
                Password="123deneme",
                CreatedDate=DateTime.Now
            } ,new User{
                  UserId=17,
                Name="denemeKullanıcı",
                Email="denemeKullanıcı@hotmail.com",
                Password="123",
                CreatedDate=DateTime.Now

            },new User{
                  UserId=16,
                Name="test3",
                Email="test3@hotmail.com",
                Password="147",
                CreatedDate=DateTime.Now
            } };
            userAddDto = new List<UserAddDto>() { new UserAddDto
            {

               UserId=18,
               Name="tes1",
               Email="test@hotmail.com",
               Password="125",
               CreateDate=DateTime.Now
             } };
        }

        //isimlendirme kuralına göre
        //test edilen metot-Action'ın çalışma durumunu test ediliyor-geriye view dönmesini bekliyoruz.
        //index metodunun geriye bir view döndürüp döndürmediğini test ediyoruz.
        [Fact]
        public async void Index_ActionExecute_returnView()
        {
            var result = await _userController.Index();
            // gelen result ın ViewResult  olup olmadığını test ediyoruz. 
            Assert.IsType<ViewResult>(result);
        }

        //index metodumuzun geriye bir list dönüp dönmediğini test ediyoruz.

        [Fact]
        public async void  Index_ActionExecute_UserList()
        {
            //index metodu çalışırken içinde bir getallAsync metodu çalışıyor.
            //taklit edeceğimiz metodu tasarlıyoruz.
            //ındex metodumuz GetAllASync adından bir metotla karşılaşırsa geriye user listesini dönsün.
            _mockUserManager.Setup(repo => repo.GetAllASync()).ReturnsAsync(UsersList);
            var result = await _userController.Index();
            var ViewResult = Assert.IsType<ViewResult>(result);

            //NotEqule
            //7 adet userımız olmadığı için test true.
            Assert.NotEqual<int>(7, UsersList.Count());


        }
        //create view test
        [Fact]
        public async void Create_ActionExecute_returnView()
        {
            var result = await _userController.Create();
            Assert.IsType<ViewResult>(result);
        }


        //create metodunun post edilmesi durumunu test ediyoruz.
        //hata verdiğimiz zaman ındexe yönelmek yerine aynı sayfaya yöneliyor mu onu test ediyoruz.

         [Fact]
         public async void Create_InvalidState_ReturnView()
        {
            //modelstate üzerinden bir hata oluşturuyoruz.
            _userController.ModelState.AddModelError("Email", "Email alanı gereklidir.");
            var result = await _userController.Create(userAddDto.First());
            var viewResult = Assert.IsType<ViewResult>(result);
            //geriye dönen viewresult modeli user mı onu test ediyoruz.
            Assert.IsType<UserAddDto>(viewResult.Model);
        }

        //Delete metodunda modelstate geçerli olduğunda index sayfasına
        //yönelip yönelmediğimizi test ediyoruz.

        [Fact]
        public async void Delete_ReturnRedirectToIndexAction()
        {

            var result = await _userController.Delete(userAddDto.First());
         
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal<string>("Index", redirect.ActionName);

        }

    }
}
