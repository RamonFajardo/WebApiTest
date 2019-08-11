using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApiTest.Data;
using WebApiTest.DTO;
using WebApiTest.Models;


namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Variables Privadas
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;
        #endregion

        #region Constructores

        public UserController(IUserRepository repository, IConfiguration config)
        {
            _repo = repository;
            _config = config;
        }

        #endregion

        #region Metodos GET

        [HttpGet("GetUsers")]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            return Ok(users);
        }


        #endregion

        #region Metodos POST
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
        {
            userForRegisterDTO.UserName = userForRegisterDTO.UserName.ToLower();

            if (await _repo.UserExists(userForRegisterDTO.UserName))
            {
                return BadRequest("El usuario ya existe");
            }

            var userToCreate = new User {
                UserName = userForRegisterDTO.UserName

            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDTO.Password);

            return StatusCode(201);
            

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDTO userLogin)
        {
            var userFromRepo = await _repo.LoginAsync(userLogin.UserName.ToLower(), userLogin.Password);

            if (userFromRepo == null)
                return Unauthorized();

            //Crea los claims para el JWT
            var Claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.ID.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            //Crea las llaves   para el token JWT

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var Credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); // Firma el token

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims), //Agrega los claims
                Expires = DateTime.Now.AddDays(1), // El tiempo de expiracion del token
                SigningCredentials = Credentials //Las credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });

        }



        #endregion


    }
}
