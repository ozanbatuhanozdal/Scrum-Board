﻿using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.EntityFrameworkCore.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}