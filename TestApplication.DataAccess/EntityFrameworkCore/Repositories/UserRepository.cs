using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.EntityFrameworkCore.Repositories
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {

        public async Task<List<UserType>> GetRolesByEmail(string email)
        {
            using var context = new DatabaseContext();
            return await context.User.Join(context.userUserTypes, u => u.UserId, ut => ut.UserId, (user, userUserType) => new
            {
                user,
                userUserType

            }).Join(context.UserType, two => two.userUserType.UserTypeId, r => r.UserTypeId, (twoTable, type) => new
            {
                twoTable.user,
                twoTable.userUserType,
                type
            }).Where(x => x.user.Email == email).Select(x => new UserType
            {

                UserTypeId = x.type.UserTypeId,
                UserTypeName = x.type.UserTypeName,
                UserTypeDescription = x.type.UserTypeDescription

            }).ToListAsync();
        }
    }
}
