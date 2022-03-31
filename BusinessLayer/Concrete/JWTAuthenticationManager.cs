using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using EntityLayer.Concrete.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JWTAuthenticationManager : IJWTAuthenticationService
    {
        private UserManager manageUser = new UserManager(new EfUserRepository());
        private UserRoleManager manageUserRole = new UserRoleManager(new EfUserRoleRepository());

        private readonly string token;
        private List<User> userList;
        public JWTAuthenticationManager(string token)
        {
            this.token = token;
            getUserList();
        }

        
        public async void getUserList()
        {
            this.userList = await manageUser.GetAllElement();
        }
        public async Task<string> GetUserRole(int id)
        {
            var role = await manageUserRole.GetElementById(id);
            return role.RoleName;
        }

        public User Authenticate(UserLogin userLogin) // Check the user on database to authenticate.
        {
            getUserList();
            var currentUser = userList.Find(x => x.UserName == userLogin.UserName && x.Password == userLogin.Password);
            var currentUserDTO = new UserLogin();
            currentUserDTO.UserId = currentUser.UserId;
            currentUserDTO.UserName = currentUser.UserName;
            currentUserDTO.Role = GetUserRole(currentUser.RoleId).Result;
            currentUserDTO.Token = currentUser.TokenKey;

            if (currentUser==null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.token);  // If the Authentication is successful, the JWT token is generated.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, currentUserDTO.UserId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, currentUserDTO.UserName),
                    new Claim(ClaimTypes.Role, currentUserDTO.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            currentUser.TokenKey = tokenHandler.WriteToken(token);
            manageUser.UpdateElement(currentUser); // Set token to user data
            currentUser.Password = null;

            return currentUser;
        }


    }
}
