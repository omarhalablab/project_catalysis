using AuthenticationPlugin;
using Catalysis.Data;
using Catalysis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Catalysis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase


    {
        private readonly Catalysis_dbContext _dbContext;
        private IConfiguration _configuration;
        private readonly AuthService _auth;
        public UsersController(Catalysis_dbContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _configuration = configuration;
            _auth = new AuthService(_configuration);
        }

        [HttpGet]
        public IActionResult getUsers()
        {
            return Ok(_dbContext.Users);
        }

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            var emailUser = _dbContext.Users.Where(u => u.Email == user.Email).SingleOrDefault();
            if (emailUser != null)
            {
                return BadRequest("user exists, please use another email !....");

            }

            var userObj = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = SecurePasswordHasherHelper.Hash(user.Password),
                Role = "user",
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CreateDate = DateTime.Now,
                PlaceOfBirth = user.PlaceOfBirth,
                LastLogin = DateTime.Now
            };

            var guid = Guid.NewGuid();
            var filePath = Path.Combine("wwwroot/userImages", guid + ".jpg");
            if (user.image != null)
            {
                var fileStream = new FileStream(filePath, FileMode.Create);
                userObj.image.CopyTo(fileStream);
                userObj.ProfileImageUrl = filePath.Remove(0, 18);




            };
            _dbContext.Users.Add(userObj);
            _dbContext.SaveChanges();


            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            var user = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
           var userEmail = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);

            if (userEmail == null)
            {
                return NotFound();

            }

            if (!SecurePasswordHasherHelper.Verify(user.Password!,userEmail.Password))
            {
                return Unauthorized();
            }

            var claims = new[]
{
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(ClaimTypes.Email, user.Email), 
            new Claim(ClaimTypes.Role,userEmail.Role),
            };
            var token = _auth.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                user_id = userEmail.UserId
            });
        }
    }
}