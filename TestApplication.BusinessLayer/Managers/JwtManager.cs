using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.Common.Helpers.StringInfos;
using TestApplication.Entities.Models;

namespace TestApplication.BusinessLayer.Managers
{
    public class JwtManager : IJwtManager
    {
        public string TokenCreate(User user, List<UserType> userType)
        {
            var bytes = Encoding.UTF8.GetBytes(JwtInfo.SecretKey);


            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtInfo.Issuer, audience: JwtInfo.Audience, notBefore: DateTime.Now, expires: DateTime.Now.AddDays(7), signingCredentials: credentials, claims: GetClaims(user, userType));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }



        private List<Claim> GetClaims(User user, List<UserType> userType)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));


            if (userType?.Count > 0)
            {
                foreach (var role in userType)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.UserTypeName));
                }

            }

            return claims;
        }
    }
}
