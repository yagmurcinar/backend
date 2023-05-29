using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UdemyProject.Models;

namespace loginuser.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _signingKey;
    private readonly IConfiguration _configuration;
    private readonly EducationContext _context;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
        _issuer = _configuration["JwtConfig:Issuer"];
        _audience = _configuration["JwtConfig:Audience"];
        _signingKey = _configuration["JwtConfig:SigningKey"];
        _context = new EducationContext();
    }



    [HttpPost]
    public AuthModel Get(UserModel userModel)
    {
        //string hashedPassword = CreateHash(userModel.Password);
        User user = _context.Users.FirstOrDefault(x => x.Email == userModel.Email && x.Password == userModel.Password);
        if (user!=null)
        {
            try
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: new List<Claim>
                    {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "User")
                    },
                    expires: DateTime.Now.AddDays(20),
                    signingCredentials: signingCredentials

                );
                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return new AuthModel { Token = token, IsAuthenticated = true, user = user };
            }
            catch (System.Exception)
            {

                return new AuthModel { Token = null, IsAuthenticated = false };
            }

        }
        else
        {
            return new AuthModel { Token = null, IsAuthenticated = false };
        }

    }
    [HttpPost("CreateUser")]
    public User CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;

    }
    [HttpGet("ValidateToken")]
    public bool ValidateToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("BuBenimSigningKey");
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }

    }
    public static string CreateHash(string unHashed)
    {
        var x = new System.Security.Cryptography.HMACMD5();
        var data = Encoding.ASCII.GetBytes(unHashed);
        data = x.ComputeHash(data);
        return Encoding.ASCII.GetString(data);
    }
}