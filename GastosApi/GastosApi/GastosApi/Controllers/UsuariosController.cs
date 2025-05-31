using GastosApi.Data;
using GastosApi.Models;
using Microsoft.AspNetCore.Mvc;

using GastosApi.Data;
using GastosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GastosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == usuario.NombreUsuario && u.Contrasena == usuario.Contrasena);

            if (user == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            return Ok(user);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] Usuario usuario)
        {
            var existe = await _context.Usuarios.AnyAsync(u => u.NombreUsuario == usuario.NombreUsuario);
            if (existe)
                return BadRequest("El usuario ya existe");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }
    }
}