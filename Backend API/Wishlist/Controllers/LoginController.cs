using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Domains;
using Wishlist.Interfaces;
using Wishlist.Repositories;
using Wishlist.ViewModels;

namespace Wishlist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return BadRequest("Email ou senha inválidos!");
                }
                
                return Ok($"Usuário Logado! Seja bem vindo! {usuarioBuscado.NomeUsuario}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
