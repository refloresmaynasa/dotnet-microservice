namespace ProductService.Services
{
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using ProductService.Database;
    using ProductService.Database.Entities;
    using ProductService.Models;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class UserService
    {
        private IUnitOfWork unitOfWork;
        private AppSetting appSetting;

        public UserService(IUnitOfWork unitOfWork, IOptions<AppSetting> setting)
        {
            this.unitOfWork = unitOfWork;
            this.appSetting = setting.Value;
        }

        public async Task<UserModel> AuthenticateAsync(string username, string password)
        {
            var user = await unitOfWork.Users.Login(username, password);
            //var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSetting.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "super")
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            UserModel userModel = new UserModel(user.Username, user.Name, user.Email, tokenHandler.WriteToken(token));

            return userModel;
        }

        public async void RegisterUser(UserModel userModel)
        {
            if (await unitOfWork.Users.UserExists(userModel.Username))
            {
                throw new Exception("Username already exists");
            }
            var user = new User 
            {
                Username = userModel.Username,
                Name = userModel.Name,
                Email = userModel.Email
            };
            await unitOfWork.Users.Register(user, userModel.Password);
        }
    }
}
