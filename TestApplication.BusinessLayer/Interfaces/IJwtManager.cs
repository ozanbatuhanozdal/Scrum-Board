﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Entities.Models;

namespace TestApplication.BusinessLayer.Interfaces
{//IJwtManager
    public interface IJwtManager
    {
        string TokenCreate(User user, List<UserType> userType);
       
    }
}
