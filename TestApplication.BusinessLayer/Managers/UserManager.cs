using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.BusinessLayer.Managers
{
    public class UserManager : ManagerBase<User> , IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IRepositoryBase<User> repository, IUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }


        public async Task<bool> CheckPassword(UserLoginDto userLoginDto)
        {
            var user = await _userRepository.GetAsync(x => x.Email == userLoginDto.Email);
            return user.Password == userLoginDto.Password ? true : false;


        }

        public async Task<User> FindByEmail(string email)
        {
            return await _userRepository.GetAsync(x => x.Email == email);

        }

        public async Task<List<UserType>> GetRolesByEmail(string email)
        {
            return await _userRepository.GetRolesByEmail(email);
        }
    }
}
