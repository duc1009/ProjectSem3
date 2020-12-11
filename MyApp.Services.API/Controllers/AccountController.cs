
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Model;

namespace MyApp.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private IConfiguration _config;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            IConfiguration config /*IOptions<AppJwtSettings> appJwtSettings*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            // _appJwtSettings = appJwtSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromForm] RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {

                var newUser = new IdentityUser()
                {
                    UserName = registerUser.Email,
                    Email = registerUser.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(newUser, registerUser.Password);

                if (result.Succeeded)
                {
                    GenerateJWTToken(newUser.Email);

                    return Redirect("/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        AddError(error.Description);
                    }

                    return CustomResponse();
                }


            }
            return CustomResponse(ModelState);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm]LoginUser loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                var jwtString = GenerateJWTToken(loginUser.Email);
                return Redirect("/");
            }

            if (result.IsLockedOut)
            {
                AddError("This user is temporarily blocked");
                return CustomResponse();
            }

            AddError("Incorrect user or password");
            return CustomResponse();
        }

        private string GenerateJWTToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["AppJwtSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", email.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        [HttpPost]
        [Route("upfile")]
        public IActionResult HandleUploadImage(IFormFile formFile )
        {
            //[FromQuery] string sohoadon, [FromQuery] string userid
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            string hoaDonFolder = Path.Combine(uploadFolder, "123");
            if (!Directory.Exists(Path.GetDirectoryName(hoaDonFolder)))
                Directory.CreateDirectory(Path.GetDirectoryName(hoaDonFolder));

            string userFolder = Path.Combine(hoaDonFolder, "456");
            if (!Directory.Exists(Path.GetDirectoryName(userFolder)))
                Directory.CreateDirectory(Path.GetDirectoryName(userFolder));


            string filename = Guid.NewGuid().ToString() + "_" + formFile.FileName;
            using (var stream = new FileStream(filename, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            return  Ok();
        }

    }
}
