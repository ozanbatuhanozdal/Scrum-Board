using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Builder.Abstract;
using TestApplication.Common.Dto.UserDtos;

namespace TestApplication.Builder.Concrete
{
    public class SingleRoleStatusBuilder : StatusBuilder
    {
        public override Status GenerateStatus(UserDto activeUser, string roles)
        {
            Status status = new Status();
            if (activeUser.Roles.Contains(roles))
            {
                 status.AccessStatus = true;
            }
            return status;
        }

      
    }
}
