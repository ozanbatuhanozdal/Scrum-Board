using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.EntityFrameworkCore.Repositories
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
    }
}
