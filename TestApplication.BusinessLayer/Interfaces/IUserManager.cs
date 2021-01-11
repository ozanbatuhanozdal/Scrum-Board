using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.Entities.Models;
using TestApplication.Entities.Views;

namespace TestApplication.BusinessLayer.Interfaces
{
    //IUserManager
    public interface IUserManager : IManagerBase<User>
    {
        public Task<User> FindByEmail(string email);
        public Task<bool> CheckPassword(UserLoginDto userLoginDto);
        Task<List<UserType>> GetRolesByEmail(string email);
        Task<List<UserFullView>> GetUsersFull();
        Task EditUser(User user);
    }
}
