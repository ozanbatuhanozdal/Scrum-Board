using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.EntityFrameworkCore.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<List<UserType>> GetRolesByEmail(string email);

        Task EditUser(User user);
    }
}
