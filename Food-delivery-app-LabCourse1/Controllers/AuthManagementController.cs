using Configuration;
using Food_delivery_app_LabCouse1.Models.DTOs.Requests;
using Food_delivery_app_LabCouse1.Models.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Food_delivery_app_LabCouse1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthManagementController> _logger;
        public AuthManagementController(UserManager<IdentityUser> userManager,
        IOptionsMonitor<JwtConfig> optionsMonitor,
        RoleManager<IdentityRole> roleManager,
        ILogger<AuthManagementController> logger
        )
        {
            _userManager = userManager;
            //e mer vleren aktuale te appsettings edhe e inject ne controller
            _jwtConfig = optionsMonitor.CurrentValue;
            _roleManager = roleManager;
            _logger = logger;

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO user)
        {
            if (ModelState.IsValid)
            {
                //mundemi me perdor modelin veq nese esht valid
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegsitrationResponse()
                    {
                        Errors = new List<string>() {
                                "Email already in use"
                            },
                        Success = false
                    });
                }

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.Username };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {
                    //caktimi i rolit kur nje perdorues regjistrohet ne sistem
                    await _userManager.AddToRoleAsync(newUser, user.Roli);

                    var jwtToken = await GenerateJwtTokenAsync(newUser);

                    return Ok(new RegsitrationResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new RegsitrationResponse()
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }
            }

            //nese sesht valid at her esht bad request
            return BadRequest(new RegsitrationResponse()
            {
                Errors = new List<string>()
                {
                    "Invalid payload"
                },
                Success = false
            });
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    return BadRequest(new RegsitrationResponse()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if (!isCorrect)
                {
                    return BadRequest(new RegsitrationResponse()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    });
                }

                var jwtToken = await GenerateJwtTokenAsync(existingUser);

                Response.Cookies.Append(key: "jwt", value: jwtToken, new CookieOptions
                {
                    HttpOnly = true
                });

                return Ok(existingUser);
            }

            return BadRequest(new RegsitrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }

        private async Task<string> GenerateJwtTokenAsync(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var claims = await GetAllValidClaims(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //Ni tokeni i del afati 6 ore pas regjistrimit
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

        private async Task<List<Claim>> GetAllValidClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Getting the claims that we have assigned to the user
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            // Get the user role and add it to the claims
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole);

                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));

                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims;
        }
        /*
            var handler = new JwtSecurityTokenHandler();
            var restoken = handler.ReadJwtToken(jwt);
        */
        [HttpGet("user")]
        public async Task<IActionResult> GetUser(){
            try{
                var jwt = Request.Cookies["jwt"];
            
                var token = Verify(jwt);

                string userEmail = token.Subject;

                var user = await _userManager.FindByEmailAsync(userEmail);

                return Ok(user);
            }catch(Exception ){
                return Unauthorized();
            }
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(key: "jwt");
            return Ok(new
            {
                message = "success"
            });
        }
    }
}
