using tpcrm.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace tpcrm
{
    public class JwtAuthenticationService 
    {
        private readonly string key;
        public readonly CrmContext _context;
        public JwtAuthenticationService(CrmContext context){
            _context = context;
        }
        public JwtAuthenticationService(string key)
            {
                this.key = key;
            }


        
        public string Authenticate(USers user)
        {
            // var user= _context.users.Single(u => u.Email.ToUpper().Equals(email.ToUpper())
            //     && u.Password.Equals(password));
                
                if (user == null){
                    return null;
                }
                 JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Grants)
                    }),
                    //set duration of token here
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature) //setting sha256 algorithm
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
        }

        
    }
}
