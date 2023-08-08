using CompanyAPI.Data;
using CompanyAPI.Model;
using CompanyAPI.ModelDTO;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CompanyAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string secretKey;
        public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string email)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.LocalUsers.FirstOrDefault(u => u.Email == loginRequestDTO.Email && u.Password == loginRequestDTO.Password);

            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }

            //JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponseDTO;
        }

        public async Task<LocalUser> Register(RegistrationRequestDTO registerUserDTO)
        {
            LocalUser user = new()
            {
                Name = registerUserDTO.Name,
                Email = registerUserDTO.Email,
                Password = registerUserDTO.Password,
            };

            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }

        public async Task<LocalUser> GetUser(int id)
        {
            if (id.Equals(null))
            {
                return null;
            }
            return await _db.LocalUsers.FindAsync(id);
        }

        public async Task UpdateAsync(LocalUser user)
        {
            _db.LocalUsers.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(LocalUser user)
        {
            _db.Remove(user);
            await _db.SaveChangesAsync();
        }

    }
}
