﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.EntityFrameworkCore.Repositories
{
    //entity bazlı somut repository sınıflarımızdır.
    //userTypeRepository
    public class UserTypeRepository : RepositoryBase<UserType> , IUserTypeRepository
    {
        
    }
}
