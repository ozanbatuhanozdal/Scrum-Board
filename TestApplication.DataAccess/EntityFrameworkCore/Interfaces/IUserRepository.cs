using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Entities.Models;
using TestApplication.Entities.Views;

namespace TestApplication.DataAccess.EntityFrameworkCore.Interfaces
{
    //IUserRepository
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<List<UserType>> GetRolesByEmail(string email);
        Task<List<UserFullView>> GetUsersFull();
        Task<List<GetAdminUsersView>> GetAdminUsersView();

        Task EditUser(User user);
    }
}
