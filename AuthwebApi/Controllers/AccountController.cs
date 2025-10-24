using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthwebApi.DTO;
using AuthwebApi.Models;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using AuthwebApi.Data;
using Microsoft.AspNetCore.Authorization;

namespace AuthwebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AuthAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;

        public AccountController(AuthAppDbContext context, IConfiguration configuration,
        UserManager<ApiUser> userManager,
        SignInManager<ApiUser> signInManager)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var testUserAccount = new UserAccount
            {
                UserName = input.UserName,
                Amount = 1000,
                ActiveStatus = true
            };

            var res = await _context.UserAccounts.AddAsync(testUserAccount);
            await _context.SaveChangesAsync();

            var newUser = new ApiUser
            {
                UserName = testUserAccount.UserName,
                UserAccount = testUserAccount
            };

            var result = await _userManager.CreateAsync(newUser, input.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "User");
                return StatusCode(201, $"User '{newUser.UserName}' has been created.");
            }
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDTO input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(input.UserName);
                    if (user == null || !await _userManager.CheckPasswordAsync(user, input.Password))
                        throw new Exception("Invalid login attempt.");
                    else
                    {
                        var signingCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"])),
                        SecurityAlgorithms.HmacSha256);

                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.AddRange((await _userManager.GetRolesAsync(user))
                        .Select(r => new Claim(ClaimTypes.Role, r)));

                        var jwtObject = new JwtSecurityToken(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JWT:Expiration"])),
                        signingCredentials: signingCredentials);

                        var jwtString = new JwtSecurityTokenHandler()
                        .WriteToken(jwtObject);
                        return StatusCode(StatusCodes.Status200OK, jwtString);
                    }
                }
                else
                {
                    var details = new ValidationProblemDetails(ModelState);
                    details.Type = "https:/ /tools.ietf.org/html/rfc7231#section-6.5.1";
                    details.Status = StatusCodes.Status400BadRequest;
                    return new BadRequestObjectResult(details);
                }
            }
            catch (Exception e)
            {
                var exceptionDetails = new ProblemDetails();
                exceptionDetails.Detail = e.Message;
                exceptionDetails.Status = StatusCodes.Status401Unauthorized;
                exceptionDetails.Type = "https:/ /tools.ietf.org/html/rfc7231#section-6.6.1";
                return StatusCode(StatusCodes.Status401Unauthorized, exceptionDetails);
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<object>> GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); //finder id via token

            if (userId != null)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return NotFound("User not found.");

                return Ok(new
                {
                    user.Id,
                    user.UserName,
                });
            }

            return NotFound();
        }

    }

}

