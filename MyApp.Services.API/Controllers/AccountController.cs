
using System;
using System.Collections.Generic;
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
                await _userManager.AddToRoleAsync(user, "User");
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

        [AllowAnonymous]
        [HttpPost]
        [Route("upfile")]
        public ActionResult HandleUploadImage([FromForm] DataForm dataForm )
        {
            //[FromQuery] string sohoadon, [FromQuery] string userid
            //string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            //string hoaDonFolder = Path.Combine(uploadFolder, "hoadon");
            //if (!Directory.Exists(Path.GetDirectoryName(hoaDonFolder)))
            //    Directory.CreateDirectory(Path.GetDirectoryName(hoaDonFolder));

            //string userFolder = Path.Combine(hoaDonFolder, "userid");
            //if (!Directory.Exists(Path.GetDirectoryName(userFolder)))
            //    Directory.CreateDirectory(Path.GetDirectoryName(userFolder));

            //string filename = Guid.NewGuid().ToString() + "_" + dataForm.File.FileName;
            //using (var stream = new FileStream(filename, FileMode.Create))
            //{
            //    dataForm.File.CopyTo(stream);
            //}


            return  Ok(new { status = true, message = "Student Posted Successfully"});
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("upload1")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload1([FromBody] List<IFormFile> files)
        {
            return Ok(new { status = true });
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("upload2")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload2([FromBody]IFormFile file)
        {
            return Ok(new { status = true });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> test()
        {
            return Ok(new { status = true });
        }

    }



    public class DataForm 
    {
        public IFormFile File { get; set; }
    }
}
