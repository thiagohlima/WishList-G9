using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Contexts;
using Wishlist.Domains;
using Wishlist.Interfaces;

namespace Wishlist.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishlistContext ctx = new WishlistContext();
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }


        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
