using BE_Drink.Config;
using BE_Drink.DbContext;
using BE_Drink.Models.Customer;
using BE_Drink.Models.Dtos;
using BE_Drink.Models.Dtos.requests;
using BE_Drink.Models.Dtos.response;
using BE_Drink.service.email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BE_Drink.Controllers.authen
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        private readonly BE_DrinkContext context;
        public AuthenController(
            UserManager<IdentityUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            IMailService mailService,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _mailService = mailService;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> register([FromBody] UserRegistrantion user)
        {
            if (ModelState.IsValid)
            {

                // We can utilise the model
                var existingUser = await _userManager.FindByEmailAsync(user.email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                        "Tài khoản đã được đăng kí"
                                    },
                        Success = false
                    });
                }

                var newUser = new User()
                {
                    fullName = user.fullName,
                    Email = user.email,
                    UserName = user.email,
                    type = user.type,
                    isAdmin = user.isAdmin,
                    isShipper = user.isShipper
                };
                var isCreated = await _userManager.CreateAsync(newUser, user.password);
                var userbyEmail = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == user.email);
                if (isCreated.Succeeded)
                {

                    var jwtToken = GenerateJwtToken(newUser);

                    return Ok(new RegistrationResponse()
                    {
                        Infor = new JsonResult(userbyEmail),
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Success = false
                    });
                }
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                            "Tài khoản hoặc mật khẩu không hợp lệ"
                        },
                Success = false
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            //var userbyid = await _context.User.FindAsync(id);

            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.email); // Bói ra pass hass

                if (existingUser == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Tài khoản chưa được đăng kí"
                            },
                        Success = false
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.password); //  Check pass hash với pass truyền vào qua bộ lọc

                if (!isCorrect)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Tài khoản hoặc mật khẩu không chính xác"
                            },
                        Success = false
                    });
                }

                var jwtToken = GenerateJwtToken(existingUser); // Create jwt
                var userbyEmail = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == user.email); // Bói ra thôg tin của thag có mail đúng trog db


                if (userbyEmail != null)
                {
                    return Ok(new RegistrationResponse()
                    {
                        Infor = new JsonResult(userbyEmail),
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return Ok(new RegistrationResponse()
                    {
                        Success = false,
                    });
                }
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }


        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

        [Route("activeAccount/{id}")]
        [HttpPut]
        public JsonResult activeAccout(String id)
        {

            var userbyEmail = _userManager.Users.SingleOrDefaultAsync(x => x.Id == id);
            string query = @"update AspNetUsers set 
            status = 1 
            where id = '" + id + "'";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BE_DrinkContext");
            SqlDataReader myRender;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myRender = myCommand.ExecuteReader();
                    table.Load(myRender);
                    myRender.Close(); myCon.Close();
                }
            }
            
                return new JsonResult(new response()
                {
                    mess = "",
                    status = true
                });
        }
    }
}
