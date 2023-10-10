using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Project.Model;
using Project.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(RepositoryWrapper repo) : base(repo)
        {
        }
        [HttpPost("Login")]
        public dynamic Login([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string email = json.Email;
            string password = json.Password;

            User item = repo.UserRepository.FindByCondition(k => k.Email == email && k.Password == password).SingleOrDefault<User>();

            if (item != null)
            {
                // Caching kullanılabilir

                Rol rol = repo.RolRepository.FindByCondition(r => r.Id == item.RolId).SingleOrDefault<Rol>();
                Dictionary<string, object> claims = new Dictionary<string, object>();
                if (rol != null)
                    claims.Add(ClaimTypes.Role, rol.Name);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes("AhlatciBaslangicProjectApplication");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
                    Claims = claims
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new
                {
                    success = true,
                    data = tokenHandler.WriteToken(token),
                    rol = rol?.Name,
                    id= item?.Id
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Please check your information."
                };
            }
        }
    }
}
