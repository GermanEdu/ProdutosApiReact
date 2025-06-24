using Microsoft.AspNetCore.Mvc;
using ProdutosApiReact.Context;
using ProdutosApiReact.Models;
using ProdutosApiReact.Services;
using ProdutosApiReact.ViewModels;

namespace ProdutosApiReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AuthenticateService _authService;

        public UsuarioController(AppDbContext context, AuthenticateService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var token = _authService.Authenticate(loginModel);
            if (token == null)
                return Unauthorized("Usuário ou senha inválidos.");

            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            var userExists = _context.Usuarios.Any(u => u.Email == registerModel.Email);
            if (userExists)
                return BadRequest("Usuário já existe.");

            var usuario = new Usuario
            {
                Email = registerModel.Email,
                Senha = registerModel.Senha // você pode aplicar hash aqui se desejar
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok("Usuário registrado com sucesso.");
        }
    }
}

