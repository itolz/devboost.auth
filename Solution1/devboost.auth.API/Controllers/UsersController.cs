using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using devboost.auth.API.Contract;
using devboost.auth.API.Model;
using devboost.auth.API.Model.dbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace devboost.auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly AuthDBContext _context;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UsersController(AuthDBContext context, ITokenService tokenService, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher; 
        }
        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList(); 
        }

     
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDTO userDTO)
        {
            var user = new User { Nome = userDTO.Nome, Email = userDTO.Email, Username = userDTO.Username};

            var passwordHash = _passwordHasher.HashPassword(user, userDTO.Password);

            user.PasswordHash = passwordHash; 

            _context.Users.Add(user);

            _context.SaveChanges();

            return Ok(); 
        }


        [HttpPost("login")]
        public ActionResult<JsonWebToken> Login(LoginDTO login)
        {
            var user = _context.Users.FirstOrDefault(_ => _.Username == login.Username);

            if (user == null) return NotFound();

            var passwordResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, login.Password);

            if (passwordResult == PasswordVerificationResult.Failed) return BadRequest();

            var token = _tokenService.CreateJWT(user);

            return Ok(token); 
        }

   
       
    }
}
