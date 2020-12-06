using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TestApplication.Builder.Concrete;
using TestApplication.Common.Dto.UserDtos;

namespace TestApplication.CustomFilters
{
    public class JwtAuthorizeHelper
    {

        public static void CheckUserRole(UserDto activeUser,string roles,ActionExecutingContext context)
        {
            if (!string.IsNullOrWhiteSpace(roles))
            {
                Status status;
                if (roles.Contains(","))
                {
                    StatusBuilderDirector director = new StatusBuilderDirector(new MultiRoleStatusBuilder());
                    status = director.GenerateStatus(activeUser, roles);
                }
                else
                {
                    StatusBuilderDirector director = new StatusBuilderDirector(new SingleRoleStatusBuilder());
                    status = director.GenerateStatus(activeUser, roles);

                }
                CheckStatus(status, context);

            }
        }

        public static UserDto GetActiveUser(HttpResponseMessage responseMessage)
        {   
            return JsonConvert.DeserializeObject<UserDto>(responseMessage.Content.ReadAsStringAsync().Result);
        }

        private static void CheckStatus(Status status, ActionExecutingContext context)
        {
            if(!status.AccessStatus)
            {              
                    context.Result = new RedirectToActionResult("AccessDenied", "Home", null);                
            }

        }
       
        public static bool CheckToken(ActionExecutingContext context, out string token)
        {
            token = context.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                return true;
            }
            context.Result = new RedirectToActionResult("Signin", "Home", null);
            return false;

        }


        // Getting active user from api 
        public static HttpResponseMessage GetActiveUserResponseMessage(string token)
        {            

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

           return  httpClient.GetAsync("http://localhost:5000/api/Auth/ActiveUser").Result;

        }


        public static UserDto GetCurrentUser(string token)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = httpClient.GetAsync("http://localhost:5000/api/Auth/ActiveUser").Result;

            return JsonConvert.DeserializeObject<UserDto>(responseMessage.Content.ReadAsStringAsync().Result);


        }
    }
}
