using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;
using TestApplication.Entities.Views;

namespace TestApplication.DataAccess.EntityFrameworkCore.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        //entity bazlı somut repository sınıflarımızdır.
        //UserRepository
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

        public async Task<List<GetAdminUsersView>> GetAdminUsersView()
        {
            using var context = new DatabaseContext();

            var y = await context.adminUserView.Select(x => new GetAdminUsersView
            {
                UserId = x.UserId,                
                Email = x.Email,
                Name = x.Name,
                UserTypeName = x.UserTypeName
            }).ToListAsync();

            return y;
        }

        public async Task<List<UserFullView>> GetUsersFull()
        {
            using var context = new DatabaseContext();
            var x = await context.userFullView.Select(x => new UserFullView
            {
                UserId = x.UserId,
                Email = x.Email,
                Name = x.Name,
                PasswordSalt = x.PasswordSalt,
                PasswordHash = x.PasswordHash,
                UserTypeDescription= x.UserTypeDescription,
                UserTypeName = x.UserTypeName

            }).ToListAsync();          
            return x;
        }

        
        public async Task EditUser(User user)
        {
            using var context = new DatabaseContext();
            {
                User updateUser = await context.User.Include(p => p.userUserTypes).FirstOrDefaultAsync(x => x.UserId == user.UserId);
                if (updateUser != null)
                {
                    updateUser.PasswordHash = user.PasswordHash;
                    updateUser.PasswordSalt = user.PasswordSalt;
                    updateUser.Name = user.Name;
                    updateUser.Email = user.Email;
                    updateUser.userUserTypes.Clear();

                    if (user.userUserTypes.Count > 0)
                    {
                        foreach (var ust in user.userUserTypes)
                        {
                            updateUser.userUserTypes.Add(new UserUserType()
                            {
                                UserId = user.UserId,
                                UserTypeId = ust.UserTypeId
                            });
                        }
                    }

                    context.User.Update(updateUser);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
