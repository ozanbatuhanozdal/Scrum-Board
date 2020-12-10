using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.BusinessLayer.Managers
{
    public class UserTypeManager : ManagerBase<UserType> , IUserTypeManager
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeManager(IRepositoryBase<UserType> repository,IUserTypeRepository userTypeRepository) : base(repository)
        {
            _userTypeRepository = userTypeRepository;

        }
    }
}
