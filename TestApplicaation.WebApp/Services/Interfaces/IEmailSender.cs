using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.WebApp.Services.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(string Email, string Guid);
    }
}
