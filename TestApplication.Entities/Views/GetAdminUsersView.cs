using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Entities.Views
{
    public class GetAdminUsersView
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string UserTypeName { get; set; }
    }
}
